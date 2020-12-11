using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Model
{
    public class ThreadParam
    {
        public Label label;
        public TextBox textBox;
        public ProgressBar progressBar;
        public NotifyIcon notifyIcon;
       

        public ThreadParam()
        {
            label = new Label();
            textBox = new TextBox();
            progressBar = new ProgressBar();
        }

        public ThreadParam(NotifyIcon _notifyIcon)
        {
            label = new Label();
            textBox = new TextBox();
            progressBar = new ProgressBar();
            notifyIcon = _notifyIcon;
        }
    }
}
