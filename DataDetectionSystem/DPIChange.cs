using Spire.Pdf;
using Spire.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace DataDetectionSystem
{
    public partial class DPIChange : Form
    {
        List<string> PathList = new List<string>();
        List<string> FileList = new List<string>();

        public DPIChange()
        {
            InitializeComponent();
        }
        private void DPIChange_Load(object sender, EventArgs e)
        {
            //默认选择的分辨率
            comboBox2.SelectedIndex = 2;
        }
        //原文路径
        private void Btn_SPath_Click(object sender, EventArgs e)
        {
            PathList.Clear();
            string sPath = "";
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "请选择输入文件夹";

            if (folder.ShowDialog() == DialogResult.OK)
            {
                sPath = folder.SelectedPath;
                Txt_SPath.Text = sPath;
                string fn = "";
                ///获取指定驱动盘目录
                string[] s = Directory.GetFileSystemEntries(sPath);
                if (!HasCheckBox.Checked)
                {
                    foreach (var item in s)
                    {
                        if (!File.Exists(item))
                        {
                            PathList.Add(item);
                        }
                        else
                        {
                            FileList.Add(item);
                        }
                    }
                }
                else
                {
                    foreach (var item in s)
                    {
                        if (!File.Exists(item))
                        {
                            PathList.Add(item);
                            Expendtree(item);
                        }
                        else
                        {
                            FileList.Add(item);
                        }
                    }
                }
            }
            foreach (var item in PathList)
            {
                listBox1.Items.Add(item);
            }
        }
        //目标路径
        private void Btn_NPath_Click(object sender, EventArgs e)
        {
            string sPath = "";
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "请选择输出文件夹";

            if (folder.ShowDialog() == DialogResult.OK)
            {
                sPath = folder.SelectedPath;
                Txt_NPath.Text = sPath;
            }
        }
        //修改分辨率
        private void Btn_DpiC_Click(object sender, EventArgs e)
        {
            if (Txt_NPath.Text != String.Empty || Txt_SPath.Text != String.Empty)
            {
                foreach (var item in FileList)
                {
                    try
                    {
                        DPIChanges(item, float.Parse(comboBox2.Text.ToString()), Txt_NPath.Text);
                        TxtFinish.Text += item + "：修改分辨率完成\r\n";
                    }
                    catch (Exception ex)
                    {
                        Txt_Error.Text += item + "：出现修改分辨率错误，原因：" + ex.Message.ToString() + "\r\n";
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择路径");
            }
        }
        //生成PDF
        private void Btn_CreatPdf_Click(object sender, EventArgs e)
        {
            if (Txt_NPath.Text != String.Empty||Txt_SPath.Text !=String.Empty)
            {
                foreach (var item in FileList)
                {
                    try
                    {
                        ImageToPdf(item, Txt_NPath.Text);
                        TxtFinish.Text += item + "：PDF生成成功\r\n";
                    }
                    catch (Exception ex)
                    {
                        Txt_Error.Text += item + "：出现错误，原因：" + ex.Message.ToString() + "\r\n";
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择路径");
            }
        }
        //退出
        private void Btn_Ex_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Expendtree(string path)
        {
            try
            {
                string[] dirs = Directory.GetFileSystemEntries(path);
                foreach (string dir in dirs)
                {
                    try
                    {
                        if (!File.Exists(dir))
                        {
                            PathList.Add(dir);
                            Expendtree(dir);
                        }
                        else
                        {
                            FileList.Add(dir);
                        }
                    }
                    catch (Exception ex)
                    {
                        Txt_Error.Text += dir + "：出现错误，原因：" + ex.Message.ToString() + "\r\n";
                        throw;
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void ImageToPdf(string ImagePath,string NPath)
        {
            string fileNameExt = ImagePath.Substring(ImagePath.LastIndexOf("\\") + 1);
            string ePath = ImagePath.Remove(ImagePath.LastIndexOf("."));
            //新建PDF文档，添加一页
            PdfDocument doc = new PdfDocument();
            PdfPageBase page = doc.Pages.Add();

            //加载图片到Image对象
            Image image = Image.FromFile(ImagePath);

            //调整图片大小
            int width = image.Width;
            int height = image.Height;
            float scale = page.Size.Width / width;  //缩放比例
            Size size = new Size((int)(width * scale), (int)(height * scale));
            Bitmap scaledImage = new Bitmap(image, size);
            ////595
            //float pages = page.Size.Width;
            ////842
            //float pagess = page.Size.Height;
            //加载缩放后的图片到PdfImage对象
            PdfImage pdfImage = PdfImage.FromImage(scaledImage);

            //设置图片位置
            float x = 0f;
            float y = 0f;

            //在指定位置绘入图片
            page.Canvas.DrawImage(pdfImage, x, y);

            //保存文档
            doc.SaveToFile(NPath+"\\"+ fileNameExt + ".pdf");
        }

        private float[] GetDpi(string filename)
        {
            Image image = Image.FromFile(filename);
            float dpiX = image.HorizontalResolution;
            float dpiY = image.VerticalResolution;
            float[] dpi = new float[] { dpiX, dpiY };
            return dpi;
        }

        private void DPIChanges(string SPath, float DpiNum, string NPath)
        {
            string fileNameExt = SPath.Substring(SPath.LastIndexOf("\\") + 1);
            string ePath = fileNameExt.Remove(fileNameExt.LastIndexOf("."));
            Image image = Image.FromFile(SPath);
            Bitmap newBitmap = new Bitmap(image);
            newBitmap.SetResolution(DpiNum, DpiNum);
            newBitmap.Save(NPath+"\\"+ fileNameExt, ImageFormat.Jpeg);
        }
    }
}
