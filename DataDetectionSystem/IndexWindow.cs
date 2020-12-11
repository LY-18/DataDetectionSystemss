using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DataDetectionSystem
{
    public partial class IndexWindow : UserControl
    {
        public delegate void SetData();
        public static SetData setData;
        //检查次数
        public static double testNum = 0;
        //异常比例总和
        public static double testErrorPer = 0;
        //检测总数
        public static int count = 0;
        //错误数量
        public static int errorCount = 0;

        public static int erroNum = 0;


        public IndexWindow()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            setData();
        }

        private void IndexWindow_Load(object sender, EventArgs e)
        {
            lblTestNum.Text = testNum.ToString();

            lblTestErrorPer.Text = string.Format("{0:#.00%}", erroNum / testNum);

            int[] vs = new int[] { erroNum, (Convert.ToInt32(testNum) - erroNum) };
            chartload(vs);
        }

        private void chartload(int[] resS)
        {
            string[] xValues = { "出现异常情况", "通过情况" };
            chart.Series.Clear();
            chart.ChartAreas.Clear();

            Series Series1 = new Series();
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
            chart.Series["Series1"].Points.DataBindXY(xValues, resS);

            chart.Series["Series1"].Points[0].Color = Color.Red;//控制饼图一部分颜色为绿色
            chart.Series["Series1"].Points[1].Color = Color.Green;//控制饼图一部分颜色为橙色
        }
    }
}
