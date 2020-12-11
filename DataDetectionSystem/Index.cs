using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace DataDetectionSystem
{
    public partial class Index : Form
    {
        //错误数量集
        public static Dictionary<string, object> TestResult;
        public static ThreadParam threadParam;
        public static System.Threading.Timer timer;
        //检测结果日志
        public static string TestResultStr;

        //输出的日志
        public static string TestResults;

        public Index()
        {
            InitializeComponent();
            this.splitContainer1.Panel1.Location = new Point(0, 1);
            this.splitContainer1.Panel1.Size = new Size(284, 22);
            this.splitContainer1.Panel1.TabIndex = 1;
            this.splitContainer1.Panel1.MouseDown += new MouseEventHandler(this.gPanelTitleBack_MouseDown);

            TestResult = new Dictionary<string, object>();
            threadParam = new ThreadParam(notifyIcon1);
        }

        //定义无边框窗体Form
        [DllImport("user32.dll")]//*********************拖动无窗体的控件
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

        private void gPanelTitleBack_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);//*********************调用移动无窗体控件函数
        }

        private void Index_Load(object sender, EventArgs e)
        {
            IndexWindow.setData = AllDe;
            TestOnTickTime();
        }

        public static void TestOnTickTime()
        {
            TimeSpan duetime = UIUtil.GetTestDueTime();
            TimeSpan period = new TimeSpan(24, 0, 0);
            timer = new System.Threading.Timer(UIUtil.Test, threadParam, duetime, period);
        }
        //综合检测控件
        private void AllDe()
        {
            PanWindow.Controls.Clear();
            MainUserControl mainUserControl = new MainUserControl(true, true, true, true);
            mainUserControl.Dock = DockStyle.Fill;
            PanWindow.Controls.Add(mainUserControl);
        }

        //关闭程序
        private void Close_Click(object sender, EventArgs e)
        {
            
        }

        //最大化
        private void Big_Click(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        //最小化
        private void Sm_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        //设置
        private void Setting_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PanWindow.Controls.Clear();
            IndexWindow one = new IndexWindow();
            one.Dock = DockStyle.Fill;
            PanWindow.Controls.Add(one);
        }


        private void AllDetection_Click(object sender, EventArgs e)
        {
            AllDe();
        }


        private void ContinueDetection_Click(object sender, EventArgs e)
        {
            PanWindow.Controls.Clear();
            MainUserControl one = new MainUserControl(true, false, true, false);
            one.Dock = DockStyle.Fill;
            PanWindow.Controls.Add(one);
        }

        private void IndexDetection_Click(object sender, EventArgs e)
        {
            PanWindow.Controls.Clear();
            MainUserControl one = new MainUserControl(false, false, false, true);
            one.Dock = DockStyle.Fill;
            PanWindow.Controls.Add(one);
        }

        private void VideoDetection_Click(object sender, EventArgs e)
        {
            PanWindow.Controls.Clear();
            VideoDetectionWindow videoDetectionWindow = new VideoDetectionWindow();
            videoDetectionWindow.Dock = DockStyle.Fill;
            PanWindow.Controls.Add(videoDetectionWindow);
        }

        private void ResultDetection_Click(object sender, EventArgs e)
        {
            PanWindow.Controls.Clear();
            ResultUserControl resultUserControl = new ResultUserControl();
            resultUserControl.Dock = DockStyle.Fill;
            PanWindow.Controls.Add(resultUserControl);
        }

        private void Tool_Click(object sender, EventArgs e)
        {
            PanWindow.Controls.Clear();
            ToolWindow toolWindow = new ToolWindow();//用户控件
            toolWindow.Dock = DockStyle.Fill;//填充panel
            PanWindow.Controls.Add(toolWindow);//向panel添加用户控件
        }

        private void Index_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("巡检功能需要系统在后台运行，如果退出，将无法巡检，确定要退出吗？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Dispose();
                Application.Exit();
            }
        }

        private void PanWindow_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(new Bitmap(Properties.Resources.tu4), 0, 0);
        }

        private void Close_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
