using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using System.Drawing.Printing;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections;

namespace DataDetectionSystem
{
    public partial class ResultUserControl : UserControl
    {
        public static float errorPers = 0;
        public ResultUserControl()
        {
            InitializeComponent();
        }

        private void ResultUserControl_Load(object sender, EventArgs e)
        {
            Results();
        }

        public static void ins()
        {
            ResultUserControl resultUserControl = new ResultUserControl();
            resultUserControl.Results();
            //errorPers = resultUserControl.errorPer();
        }
        private void Results()
        {
            ArrayList arrayListStr = new ArrayList();
            ArrayList arrayListNum = new ArrayList();
            ArrayList arraylistAnum = new ArrayList();
            ArrayList arraylistNum = new ArrayList();
            Dictionary<string, object> testResult = Index.TestResult;

            if (testResult.Count > 0)
            {
                //文件总数
                if (testResult.ContainsKey("Count"))
                {
                    object count = testResult["Count"];
                    if (count == null)
                        count = 0;
                    lblCountNum.Text += count;
                }
                //文件大小
                if (testResult.ContainsKey("Length"))
                {
                    object oLength = testResult["Length"];
                    if (oLength == null)
                        oLength = 0;
                    long length = Convert.ToInt64(oLength);
                    if (length > 1024)
                    {
                        length = length / 1024;
                        if (length > 1024)
                        {
                            length = length / 1024;
                            lblLengthNum.Text += length + "MB";
                        }
                        else
                            lblLengthNum.Text += length + "KB";
                    }
                    else
                        lblLengthNum.Text += length + "B";
                }
                //通过文件数量
                if (testResult.ContainsKey("PassedCount"))
                {
                    object passedCount = testResult["PassedCount"];
                    if (passedCount == null)
                        passedCount = 0;
                    lblPassedCountNum.Text += passedCount;
                }
                //通过文件大小
                if (testResult.ContainsKey("PassedLength"))
                {
                    object oPassedLength = testResult["PassedLength"];
                    if (oPassedLength == null)
                        oPassedLength = 0;
                    long passedLength = Convert.ToInt64(oPassedLength);
                    if (passedLength > 1024)
                    {
                        passedLength = passedLength / 1024;
                        if (passedLength > 1024)
                        {
                            passedLength = passedLength / 1024;
                            lblPassedLengthNum.Text += passedLength + "MB";
                        }
                        else
                            lblPassedLengthNum.Text += passedLength + "KB";
                    }
                    else
                        lblPassedLengthNum.Text += passedLength + "B";
                }
                //疑似文件容量
                if (testResult.ContainsKey("FailLength"))
                {
                    object oFailLength = testResult["FailLength"];
                    if (oFailLength == null)
                        oFailLength = 0;
                    long failLength = Convert.ToInt64(oFailLength);
                    if (failLength > 1024)
                    {
                        failLength = failLength / 1024;
                        if (failLength > 1024)
                        {
                            failLength = failLength / 1024;
                            lblFailLengthNum.Text += failLength + "MB";
                        }
                        else
                            lblFailLengthNum.Text += failLength + "KB";
                    }
                    else
                        lblFailLengthNum.Text += failLength + "B";
                }
                //失败文件数
                if (testResult.ContainsKey("FailCount"))
                {
                    object failCount = testResult["FailCount"];
                    if (failCount == null)
                        failCount = 0;
                    lblFailCountNum.Text += failCount;
                }
                //重复文件
                if (testResult.ContainsKey("RepeatFilesMD5"))
                {
                    object oRepeatFilesMD5 = testResult["RepeatFilesMD5"];
                    if (oRepeatFilesMD5 != null)
                    {
                        List<string> repeatFilesMD5 = oRepeatFilesMD5 as List<string>;
                        if (repeatFilesMD5 != null)
                            lblRepeatCountNum.Text += repeatFilesMD5.Count;
                        arrayListStr.Add("重复文件");
                        arrayListNum.Add(repeatFilesMD5.Count);
                    }
                }
                else if (testResult.ContainsKey("RepeatFiles"))
                {
                    object oRepeatFiles = testResult["RepeatFiles"];
                    if (oRepeatFiles != null)
                    {
                        List<string> repeatFiles = oRepeatFiles as List<string>;
                        if (repeatFiles != null)
                            lblRepeatCountNum.Text += repeatFiles.Count;
                        arrayListStr.Add("重复文件");
                        arrayListNum.Add(repeatFiles.Count);
                    }
                }
                //缺页漏页情况
                if (testResult.ContainsKey("ShortOfPages"))
                {
                    object oArchiveShortOfPages = testResult["ShortOfPages"];
                    if (oArchiveShortOfPages != null)
                    {
                        Dictionary<string, List<int>> archiveShortOfPages = oArchiveShortOfPages as Dictionary<string, List<int>>;
                        List<int> shortOfPages;
                        int shortOfPageCount = 0;
                        if (archiveShortOfPages != null)
                        {
                            foreach (string archiveId in archiveShortOfPages.Keys)
                            {
                                shortOfPages = archiveShortOfPages[archiveId];
                                if (shortOfPages != null)
                                {
                                    shortOfPageCount += shortOfPages.Count;
                                }
                            }
                            lblShortOfPagesNum.Text += shortOfPageCount.ToString();
                        }
                    }
                }
                //空白页
                if (testResult.ContainsKey("nullpagenum"))
                {
                    object failCount = testResult["nullpagenum"];
                    if (failCount == null)
                        failCount = 0;
                    lblNullPageNum.Text = failCount.ToString();
                    arrayListStr.Add("空白页");
                    arrayListNum.Add(failCount);
                }
                //条目检测情况
                if (testResult.ContainsKey("DirectoriesErrors"))
                {
                    object failCount = testResult["DirectoriesErrors"]; 
                    if (failCount == null)
                        failCount = 0;
                    lblIndexTestNum.Text += (failCount as Dictionary<string, Dictionary<string, Dictionary<string, string>>>).Count.ToString();
                }
                //dpi检测情况
                //if (testResult.ContainsKey("DpiNum"))
                //{
                //    object failCount = testResult["DpiNum"];
                //    if (failCount == null)
                //        failCount = 0;
                //    lblDPINum.Text += failCount;
                //    arrayListStr.Add("dpi");
                //    arrayListNum.Add(failCount);
                //}
                //图幅检测
                if (testResult.ContainsKey("afei"))
                {
                    object aFei = testResult["afei"];
                    if (aFei==null)
                        aFei = 0;
                    lbFeinum.Text+= aFei;
                    arraylistAnum.Add("其他");
                    arraylistNum.Add(aFei);
                }
                if (testResult.ContainsKey("azero"))
                {
                    object aZero = testResult["azero"];
                    if (aZero == null)
                        aZero = 0;
                    lbZeroNum.Text += aZero;
                    arraylistAnum.Add("A0");
                    arraylistNum.Add(aZero);
                }
                if (testResult.ContainsKey("aone"))
                {
                    object aOne = testResult["aone"];
                    if (aOne == null)
                        aOne = 0;
                    lbOnenum.Text += aOne;
                    arraylistAnum.Add("A1");
                    arraylistNum.Add(aOne);
                }
                if (testResult.ContainsKey("atwo"))
                {
                    object aTwo = testResult["atwo"];
                    if (aTwo == null)
                        aTwo = 0;
                    lbTwonum.Text += aTwo;
                    arraylistAnum.Add("A2");
                    arraylistNum.Add(aTwo);
                }
                if (testResult.ContainsKey("athree"))
                {
                    object aThree = testResult["athree"];
                    if (aThree == null)
                        aThree = 0;
                    lbThreenum.Text += aThree;
                    arraylistAnum.Add("A3");
                    arraylistNum.Add(aThree);
                }
                if (testResult.ContainsKey("afour"))
                {
                    object aFour = testResult["afour"];
                    if (aFour == null)
                        aFour = 0;
                    lbFournum.Text += aFour;
                    arraylistAnum.Add("A4");
                    arraylistNum.Add(aFour);
                }
                if (lbZeroNum.Text == "" || lbOnenum.Text == "" || lbTwonum.Text == "" || lbThreenum.Text == "" || lbFournum.Text == "")
                    lbTotalnum.Text = (Convert.ToInt32(lbZeroNum.Text) * 16 + Convert.ToInt32(lbOnenum.Text) * 8 + Convert.ToInt32(lbTwonum.Text) * 4 + Convert.ToInt32(lbThreenum.Text) * 2 + Convert.ToInt32(lbFournum.Text)).ToString();
               

                //图像倾斜度检测
                if (testResult.ContainsKey("ItalicNum"))
                {
                    object failCount = testResult["ItalicNum"];
                    if (failCount == null)
                        failCount = 0;
                    lblItalicNum.Text += failCount;
                    arrayListStr.Add("图像倾斜度");
                    arrayListNum.Add(failCount);
                }
                

                string[] arrString = (string[])arrayListStr.ToArray(typeof(string));
                
                int[] arrInt = (int[])arrayListNum.ToArray(typeof(int));
                string[] arrPaner = (string[])arraylistAnum.ToArray(typeof(string));
                int[] arrpanerInt = (int[])arraylistNum.ToArray(typeof(int));
                Index.TestResults = "文件总述" + "\r\n"
                                  + lblCountNum.Text + "\r\n"
                                  + lblLengthNum.Text + "\r\n"
                                  + lblPassedCountNum.Text + "\r\n"
                                  + lblPassedLengthNum.Text + "\r\n"
                                  + lblFailLengthNum.Text + "\r\n\r\n"
                                  + "异常文件" + "\r\n"
                                  + lblFailCountNum.Text + "\r\n"
                                  + lblRepeatCountNum.Text + "\r\n"
                                  + lblNullPageNum.Text + "\r\n\r\n"
                                  + lblDPINum.Text + "\r\n"
                                  + lblItalicNum.Text + "\r\n"
                                  + "通过率：" + Passcent() * 100 + "%" + "\r\n";

                try
                {
                    IndexWindow.count = Convert.ToInt32(lblCountNum.Text.ToString());
                    IndexWindow.errorCount = Convert.ToInt32(lblFailCountNum.Text.ToString());

                }
                catch (Exception)
                {

                }
                try
                {
                    Chartloads(arrString, arrInt, arrPaner, arrpanerInt);
                }
                catch (Exception ex)
                {

                }
            }
        }

        private double Passcent()
        {
            double res;

            try
            {
                double passs = Convert.ToInt32(lblCountNum.Text.ToString());
                double passss = Convert.ToInt32(lblFailCountNum.Text.ToString());
                res = (passs - passss) / passs;

            }
            catch (Exception)
            {
                res = 0;
            }

            return res;
        }

        private int splitnum(string str)
        {
            string[] arr = str.Split('：');
            return int.Parse(arr[1]);
        }

        //打印报表
        private void PrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = UIUtil.logpaths;
            if (!String.IsNullOrEmpty(path))
                PrintPdf(path);
        }

        /// <summary>
        /// 打印报表
        /// </summary>
        /// <param name="pathName"></param>
        private void PrintPdf(string pathName)
        {
            //加载PDF文档
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(pathName);

            //设置打印对话框属性
            PrintDialog dialogPrint = new PrintDialog();
            dialogPrint.AllowPrintToFile = true;
            dialogPrint.AllowSomePages = true;
            dialogPrint.PrinterSettings.MinimumPage = 1;
            dialogPrint.PrinterSettings.MaximumPage = doc.Pages.Count;
            dialogPrint.PrinterSettings.FromPage = 1;
            dialogPrint.PrinterSettings.ToPage = doc.Pages.Count;

            if (dialogPrint.ShowDialog() == DialogResult.OK)
            {
                //指定打印机及打印页码范围
                doc.PrintFromPage = dialogPrint.PrinterSettings.FromPage;
                doc.PrintToPage = dialogPrint.PrinterSettings.ToPage;
                doc.PrinterName = dialogPrint.PrinterSettings.PrinterName;

                //打印文档
                PrintDocument printDoc = doc.PrintDocument;
                dialogPrint.Document = printDoc;
                printDoc.Print();
            }
        }

        //加载图表
        private void Chartloads(string[] vs, int[] resS,string[] arrPaners,int[] arrpanerInts)
        {
            string[] values = vs;
            //string[] xValues = { "失败文件数", "重复文件", "空白页" };
            chart.Series.Clear();
            chart.ChartAreas.Clear();

            Series Series1 = new Series();
            chart.Text = "异常文件占比";
            chart.Series.Add(Series1);
            chart.Series["Series1"].ChartType = SeriesChartType.Pie;
            chart.Legends[0].Enabled = true;
            chart.Legends[0].Docking = Docking.Bottom;
            chart.Series["Series1"].LegendText = "#VALX";//开启图例
            chart.Series["Series1"].Label = "#PERCENT";
            chart.Series["Series1"].IsXValueIndexed = false;
            chart.Series["Series1"].IsValueShownAsLabel = false;
            chart.Series["Series1"]["PieLineColor"] = "Black";//连线颜色
            chart.Series["Series1"]["PieLabelStyle"] = "Outside";//标签位置
            chart.Series["Series1"].ToolTip = "#VALX";//显示提示用语
            ChartArea ChartArea1 = new ChartArea();
            chart.ChartAreas.Add(ChartArea1);

            //开启三维模式的原因是为了避免标签重叠
            chart.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;//开启三维模式;PointDepth:厚度BorderWidth:边框宽

            chart.ChartAreas["ChartArea1"].Area3DStyle.Rotation = 15;//起始角度
            chart.ChartAreas["ChartArea1"].Area3DStyle.Inclination = 45;//倾斜度(0～90)
            chart.ChartAreas["ChartArea1"].Area3DStyle.LightStyle = LightStyle.Realistic;//表面光泽度
            chart.ChartAreas["ChartArea1"].Position.Width = 100;//绘图区充满
            chart.ChartAreas["ChartArea1"].Position.Height = 100;
            chart.Series["Series1"].Points.DataBindXY(values, resS);

            chart.Series["Series1"].Points[0].Color = Color.Green;//控制饼图一部分颜色为绿色
            chart.Series["Series1"].Points[1].Color = Color.Orange;//控制饼图一部分颜色为橙色
            chart.Series["Series1"].Points[2].Color = Color.Red;//控制饼图一部分颜色为红色
            //chart.Series["Series1"].Points[3].Color = Color.Blue;//控制饼图一部分颜色为红色
            //charpaner

            string[] panerValues = arrPaners;
            charPaner.Series.Clear();
            charPaner.ChartAreas.Clear();
            Series series = new Series();
            charPaner.Text = "图幅文件占比";
            charPaner.Series.Add(series);
            charPaner.Series["Series1"].ChartType = SeriesChartType.Pie;
            charPaner.Legends[0].Enabled = true;
            charPaner.Legends[0].Docking = Docking.Bottom;
            charPaner.Series["Series1"].LegendText = "#VALX";
            charPaner.Series["Series1"].Label = "#PERCENT";
            charPaner.Series["Series1"].IsXValueIndexed = false;
            charPaner.Series["Series1"].IsValueShownAsLabel = false;
            charPaner.Series["Series1"]["PieLineColor"] = "Black";
            charPaner.Series["Series1"]["PieLabelStyle"] = "Outside";
            charPaner.Series["Series1"].ToolTip = "#VALX";
            ChartArea chartAreapaner= new ChartArea();
            charPaner.ChartAreas.Add(chartAreapaner);
            charPaner.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            charPaner.ChartAreas["ChartArea1"].Area3DStyle.Inclination = 15;
            charPaner.ChartAreas["ChartArea1"].Area3DStyle.LightStyle = LightStyle.Realistic;
            charPaner.ChartAreas["ChartArea1"].Area3DStyle.LightStyle = LightStyle.Realistic;//表面光泽度
            charPaner.ChartAreas["ChartArea1"].Position.Width = 100;
            charPaner.ChartAreas["ChartArea1"].Position.Height = 100;
            charPaner.Series["Series1"].Points.DataBindXY(panerValues, arrpanerInts);
            charPaner.Series["Series1"].Points[0].Color = Color.Green;
            charPaner.Series["Series1"].Points[1].Color = Color.Orange;
            charPaner.Series["Series1"].Points[2].Color = Color.Red;
            charPaner.Series["Series1"].Points[3].Color = Color.Blue;
        }

        //详细报告
        private void DetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = UIUtil.logpaths;
            if (!String.IsNullOrEmpty(path))
                System.Diagnostics.Process.Start(path);
            else
                MessageBox.Show("未生成检测报告，请先进行检测");
        }

        //重置lbl的值
        private void CleanlblNum()
        {
            lblCountNum.Text = "";
            lblLengthNum.Text = "";
            lblPassedCountNum.Text = "";
            lblPassedLengthNum.Text = "";
            lblFailLengthNum.Text = "";
            lblFailCountNum.Text = "";
            lblRepeatCountNum.Text = "";
            lblNullPageNum.Text = "";
            lblItalicNum.Text = "";
            lblShortOfPagesNum.Text = "";
            lblAllHookNum.Text = "";
            lblIndexHookNum.Text = "";
            lblIndexTestNum.Text = "";
            lblShortOfPagesNum.Text = "";
            lbZero.Text = "";
            lbZeroNum.Text = "";
            lbOne.Text = "";
            lbOnenum.Text = "";
            lbTwo.Text = "";
            lbTwonum.Text = "";
            lbThree.Text = "";
            lbThreenum.Text = "";
            lbFour.Text = "";
            lbFournum.Text = "";
            lbFei.Text = "";
            lbFeinum.Text = "";
        }

        private void charPaner_Click(object sender, EventArgs e)
        {

        }
    }
}
