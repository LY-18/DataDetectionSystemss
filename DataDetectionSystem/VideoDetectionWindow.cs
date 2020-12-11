using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataDetectionSystem.Setting;

namespace DataDetectionSystem
{
    public partial class VideoDetectionWindow : UserControl
    {
        public VideoDetectionWindow()
        {
            InitializeComponent();
        }
        //常规设置
        private void SettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VideoSettings videoSetting = new VideoSettings();
            videoSetting.ShowDialog();
        }
        //添加检测文件
        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
