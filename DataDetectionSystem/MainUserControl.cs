using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Model;
using BLL;

namespace DataDetectionSystem
{
    public partial class MainUserControl : UserControl
    {

        public MainUserControl(bool Setting,bool Setting1,bool Setting2,bool Setting3)
        {
         
            InitializeComponent();
            //label1.Parent = testProgressBar;
           // label1.Location = new Point(80, 80);
            ChooseToolStripMenuItem.Enabled = Setting;
            CommonSettingsMenuItem.Enabled = Setting1;
            HookSettingsMenuItem.Enabled = Setting2;
            DirectoriesSettingsMenuItem.Enabled = Setting3;
        }

        //选择检测目录
        private void ChooseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog ChooseFolderBrowserDialog = new FolderBrowserDialog();
            ChooseFolderBrowserDialog.Description = "请选择文件路径";
            if (ChooseFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                Dictionary<string, string> settings = new Dictionary<string, string>();
                settings.Add("Folder", ChooseFolderBrowserDialog.SelectedPath);
                UIUtil.SetConfig(settings);
                //lblSelete.Text = ChooseFolderBrowserDialog.SelectedPath;
                Setting.NewDest newDest = new Setting.NewDest(ChooseFolderBrowserDialog.SelectedPath);
                newDest.ShowDialog();
            }
        }
        //常规设置
        private void CommonSettingsMenuItem_Click(object sender, EventArgs e)
        {
            CommonSettings commonSettings = new CommonSettings(false, false);
            commonSettings.ShowDialog();
        }
        //挂接设置
        private void HookSettingsMenuItem_Click(object sender, EventArgs e)
        {
            HookSettings hookSettings = new HookSettings(false, false);
            hookSettings.ShowDialog();
        }
        //条目设置
        private void DirectoriesSettingsMenuItem_Click(object sender, EventArgs e)
        {
            DirectoriesSettings directoriesSettings = new DirectoriesSettings(false, false);
            directoriesSettings.ShowDialog();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            UIUtil.Test(lblProgress, txtInformation, txtProgressBar);
        }

        private void MainUserControl_Resize(object sender, EventArgs e)
        {
            int width = this.Width - 36;
            txtProgressBar.Width = width;
            txtInformation.Width = width;
            txtInformation.Height = this.Height - 188;
        }

        private void Btn_Logs_Click(object sender, EventArgs e)
        {
            txtInformation.Text = Index.TestResultStr;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Index.TestResult.Clear();
            Index.TestResultStr = "";
            txtProgressBar.Value = 0%100;
            txtInformation.Text = "取消检测";
            lblProgress.Text = "检测已取消";
        }

        private void txtInformation_TextChanged(object sender, EventArgs e)
        {
           
            this.txtInformation.SelectionStart = this.txtInformation.Text.Length;
            this.txtInformation.SelectionLength = 0;
            this.txtInformation.ScrollToCaret();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
