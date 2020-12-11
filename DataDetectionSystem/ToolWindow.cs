using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataDetectionSystem
{
    public partial class ToolWindow : UserControl
    {
        public ToolWindow()
        {
            InitializeComponent();
        }
        #region TopMenu
        //图像检测
        private void ImageDesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        //文件重命名工具
        private void FileNameCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Tools\\bulkrename\\bulkrename.exe");
        }

        //DPI检测
        private void DPIDesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float[] dpi ;
            if (DesList.SelectedIndex >= 0)
            {
                dpi= GetDpi((string)DesList.Items[DesList.SelectedIndex]);
                MessageBox.Show("X:"+dpi[0]+"\rY:" + dpi[1]);
            }
            
        }
        //DPI修改
        private void DPICToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DPIChange dPIChange = new DPIChange();
            dPIChange.ShowDialog();
        }

        //pdf统计
        private void PdfNumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Tools\\PDF统计\\PDF统计.exe");
        }
        //文件水印
        private void FileWaterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Tools\\FileWiter\\JPG与PDF\\JPG与PDF文件水印.exe");
        }
        #endregion

        #region MidMenu
        //添加文件
        private void FileAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "图像文件|*.jpg; *.bmp; *.tif; *.gif;*.crw;*.cr2;*.nef;*.raw;*.pef;*.raf;*.x3f;*.bay;*.orf;*.srf";//过滤的文件，以|隔开，如“文本文件|*.*|Java文件|*.java”
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] strNames = openFileDialog1.FileNames;
                for (int i = 0; i < strNames.Length; i++)
                {
                    DesList.Items.Add(strNames[i]);
                }
            }
        }
        //删除文件
        private void FileDelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DesList.SelectedIndex >= 0)
                DesList.Items.RemoveAt(DesList.SelectedIndex);
        }
        //清空列表
        private void CleanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DesList.Items.Clear();
        }
        //开始检测
        private void StartDesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        //上一组图片
        private void PreviousToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        //下一组图片
        private void NextToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private float[] GetDpi(string filename)
        {
            Image image = Image.FromFile(filename);
            float dpiX = image.HorizontalResolution;
            float dpiY = image.VerticalResolution;
            float[] dpi = new float[] { dpiX, dpiY };
            return dpi;
        }

        private void SplitPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SplitPageWindow splitPageWindow = new SplitPageWindow();
            splitPageWindow.ShowDialog();
        }
    }
}
