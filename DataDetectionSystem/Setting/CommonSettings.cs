using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Spire.Pdf;
using Spire.Pdf.Graphics;

namespace DataDetectionSystem
{
    public partial class CommonSettings : Form
    {
        public static string LogsPath;
        public static void loads()
        {
            CommonSettings commonSettings = new CommonSettings(false,false) ;
            commonSettings.LoadSettings();
        }
        public CommonSettings(bool lab, bool com)
        {
            InitializeComponent();
            label1.Visible = lab;
            comboBox1.Visible = com;
        }

        /// <summary>
        /// 清除控件上先前的值
        /// </summary>
        private void ClearControlValues()
        {
            chkWhite.Checked = false;
            numWhitePercent.Value = 20;
            chkDPI.Checked = false;
            chkTu.Checked = false;
            numDPI.Value = 100;
            chkItalic.Checked = false;
            numItalicDegree.Value = 3;
            chkImgRange.Checked = false;
            numRangeEnabledError.Value = 3;
            chkA0.Checked = false;
            chkA1.Checked = false;
            chkA2.Checked = false;
            chkA3.Checked = false;
            chkA4.Checked = false;
            chkA5.Checked = false;
            chkA6.Checked = false;
            chkRepeat.Checked = false;
            chkRepeatMD5.Checked = false;
            chkFolderContinue.Checked = false;
            chkFileContinue.Checked = false;
            cmbFilenameRule.Text = "";
            numNoLen.Value = 0;
            chkIgnoreHidden.Checked = false;
            chkIgnoreFolder.Checked = false;
            txtIgnoreFolders.Text = "";
            dtpTestTimer.Value = DateTime.Now;
            chkHook.Checked = false;
            chkDirectories.Checked = false;
            chkVideo.Checked = false;
        }

        /// <summary>
        /// 读取保存的配置信息并加载
        /// </summary>
        private void LoadSettings()
        {
            Dictionary<string, string> settings = UIUtil.ReadSettings();
            if (UIUtil.GetDictionaryBooleanVal(settings, "ValidateWhite"))
            {
                chkWhite.Checked = true;
                decimal whitePercent = UIUtil.GetDictionaryDecimalVal(settings, "WhitePercent");
                if (whitePercent != -1)
                {
                    numWhitePercent.Value = whitePercent;
                }
            }
            if (UIUtil.GetDictionaryBooleanVal(settings, "ValidateDPI"))
            {
                chkDPI.Checked = true;
                decimal DPI = UIUtil.GetDictionaryDecimalVal(settings, "DPI");
                if (DPI != -1)
                {
                    numDPI.Value = DPI;
                }
            }
            if (UIUtil.GetDictionaryBooleanVal(settings, "tufu"))
            {
                chkTu.Checked = true;
                //decimal tufu = UIUtil.GetDictionaryDecimalVal(settings,"chktu");
                //if (tufu!=-1)
                //{
                
            }
            //}
            if (UIUtil.GetDictionaryBooleanVal(settings, "ValidateItalic"))
            {
                chkItalic.Checked = true;
                decimal degree = UIUtil.GetDictionaryDecimalVal(settings, "ItalicDegree");
                if (degree != -1)
                {
                    numItalicDegree.Value = degree;
                }
            }
            if (UIUtil.GetDictionaryBooleanVal(settings, "ValidateImgRange"))
            {
                chkImgRange.Checked = true;
                decimal errorPecent = UIUtil.GetDictionaryDecimalVal(settings, "ImgRangeEnabledErrorPecent");
                if (errorPecent != -1)
                {
                    numRangeEnabledError.Value = errorPecent;
                }
            }
            if (UIUtil.GetDictionaryBooleanVal(settings, "ValidateA0"))
            {
                chkA0.Checked = true;
            }
            if (UIUtil.GetDictionaryBooleanVal(settings, "ValidateA1"))
            {
                chkA1.Checked = true;
            }
            if (UIUtil.GetDictionaryBooleanVal(settings, "ValidateA2"))
            {
                chkA2.Checked = true;
            }
            if (UIUtil.GetDictionaryBooleanVal(settings, "ValidateA3"))
            {
                chkA3.Checked = true;
            }
            if (UIUtil.GetDictionaryBooleanVal(settings, "ValidateA4"))
            {
                chkA4.Checked = true;
            }
            if (UIUtil.GetDictionaryBooleanVal(settings, "ValidateA5"))
            {
                chkA5.Checked = true;
            }
            if (UIUtil.GetDictionaryBooleanVal(settings, "ValidateA6"))
            {
                chkA6.Checked = true;
            }
            if (UIUtil.GetDictionaryBooleanVal(settings, "ValidateRepeat"))
            {
                chkRepeat.Checked = true;
            }
            if (UIUtil.GetDictionaryBooleanVal(settings, "ValidateRepeatMD5"))
            {
                chkRepeatMD5.Checked = true;
            }
            if (UIUtil.GetDictionaryBooleanVal(settings, "ValidateHook"))
            {
                chkHook.Checked = true;
            }
            bool backupRepeat = UIUtil.GetDictionaryBooleanVal(settings, "BackupRepeat");
            if (UIUtil.GetDictionaryBooleanVal(settings, "ValidateFolderContinue"))
            {
                chkFolderContinue.Checked = true;
            }
            if (UIUtil.GetDictionaryBooleanVal(settings, "ValidateFileContinue"))
            {
                chkFileContinue.Checked = true;
            }
            string fileNameRule = UIUtil.GetDictionaryValue(settings, "FileNameRule");
            if (!String.IsNullOrWhiteSpace(fileNameRule))
            {
                cmbFilenameRule.Text = fileNameRule;
                decimal NoLength = UIUtil.GetDictionaryDecimalVal(settings, "AutoNoLen");
                if (NoLength != -1)
                {
                    numNoLen.Value = NoLength;
                }
            }
            if (UIUtil.GetDictionaryBooleanVal(settings, "IgnoreHidden"))
            {
                chkIgnoreHidden.Checked = true;
            }
            if (UIUtil.GetDictionaryBooleanVal(settings, "ValidateDirectories"))
            {
                chkDirectories.Checked = true;
            }
            if (UIUtil.GetDictionaryBooleanVal(settings, "IgnoreFolder"))
            {
                chkIgnoreFolder.Checked = true;
                txtIgnoreFolders.Text = UIUtil.GetDictionaryValue(settings, "IgnoreFolders");
            }
            dtpTestTimer.Value = UIUtil.GetDictionaryDateTimeVal(settings, "IntervalTime");
            LogPath.Text = UIUtil.GetDictionaryValue(settings, "logpath");
            LogsPath = LogPath.Text;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DateTime oldInterval = UIUtil.GetDictionaryDateTimeVal(UIUtil.ReadSettings(), "IntervalTime");
            Dictionary<string, string> settings = new Dictionary<string, string>();
            settings.Add("ValidateWhite", chkWhite.Checked.ToString());
            settings.Add("WhitePercent", numWhitePercent.Value.ToString());
            settings.Add("ValidateDPI", chkDPI.Checked.ToString());
            settings.Add("tufu",chkTu.Checked.ToString());//图幅检测：
            settings.Add("DPI", numDPI.Value.ToString());
            settings.Add("ValidateItalic", chkItalic.Checked.ToString());
            settings.Add("ItalicDegree", numItalicDegree.Value.ToString());
            settings.Add("ValidateImgRange", chkImgRange.ToString());
            settings.Add("ImgRangeEnabledErrorPecent", numRangeEnabledError.ToString());
            settings.Add("ValidateA0", chkA0.Checked.ToString());
            settings.Add("ValidateA1", chkA1.Checked.ToString());
            settings.Add("ValidateA2", chkA2.Checked.ToString());
            settings.Add("ValidateA3", chkA3.Checked.ToString());
            settings.Add("ValidateA4", chkA4.Checked.ToString());
            settings.Add("ValidateA5", chkA5.Checked.ToString());
            settings.Add("ValidateA6", chkA6.Checked.ToString());
            settings.Add("ValidateRepeat", chkRepeat.Checked.ToString());
            settings.Add("ValidateRepeatMD5", chkRepeatMD5.Checked.ToString());
            settings.Add("ValidateFolderContinue", chkFolderContinue.Checked.ToString());
            settings.Add("ValidateFileContinue", chkFileContinue.Checked.ToString());
            settings.Add("FileNameRule", cmbFilenameRule.Text);
            settings.Add("AutoNoLen", numNoLen.Value.ToString());
            settings.Add("IgnoreHidden", chkIgnoreHidden.Checked.ToString());
            settings.Add("IgnoreFolder", chkIgnoreFolder.Checked.ToString());
            settings.Add("IgnoreFolders", txtIgnoreFolders.Text.Trim());
            settings.Add("IntervalTime", dtpTestTimer.Value.ToString());
            settings.Add("ValidateDirectories", chkDirectories.Checked.ToString());
            settings.Add("ValidateHook", chkHook.Checked.ToString());
            UIUtil.SetConfig(settings);
            if (dtpTestTimer.Value != oldInterval)
            {
                Index.timer.Change(-1, 1000000000);
                Index.TestOnTickTime();
            }

            this.Close();
        }

        private void CommonSettings_Load(object sender, EventArgs e)
        {
            ClearControlValues();
            LoadSettings();

            List<string> vs = Model.BindItem.PlanList;
            foreach (var item in vs)
            {
                comboBox1.Items.Add(item);
            }
        }

        private void Btn_LogPathChoice_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> settings = new Dictionary<string, string>();

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "请选择报表存放路径";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                LogsPath = fbd.SelectedPath;
                LogPath.Text = LogsPath;
                settings.Add("logpath", LogPath.Text.ToString());
                UIUtil.SetConfig(settings);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkItalic_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
