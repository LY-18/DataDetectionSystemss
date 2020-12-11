namespace DataDetectionSystem
{
    partial class MainUserControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.BPan = new System.Windows.Forms.Panel();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.Btn_Logs = new System.Windows.Forms.Button();
            this.TopMenuStrip = new System.Windows.Forms.MenuStrip();
            this.ChooseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.CommonSettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.HookSettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.DirectoriesSettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtInformation = new System.Windows.Forms.TextBox();
            this.lblInformation = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.txtProgressBar = new 进度条显示百分比.MyProgressBar();
            this.BPan.SuspendLayout();
            this.TopMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BPan
            // 
            this.BPan.BackColor = System.Drawing.SystemColors.Control;
            this.BPan.Controls.Add(this.btnTest);
            this.BPan.Controls.Add(this.btnCancel);
            this.BPan.Controls.Add(this.Btn_Logs);
            this.BPan.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BPan.Location = new System.Drawing.Point(0, 417);
            this.BPan.Margin = new System.Windows.Forms.Padding(2);
            this.BPan.Name = "BPan";
            this.BPan.Size = new System.Drawing.Size(641, 33);
            this.BPan.TabIndex = 1;
            // 
            // btnTest
            // 
            this.btnTest.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnTest.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTest.ForeColor = System.Drawing.SystemColors.Control;
            this.btnTest.Location = new System.Drawing.Point(398, 0);
            this.btnTest.Margin = new System.Windows.Forms.Padding(2);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(81, 33);
            this.btnTest.TabIndex = 0;
            this.btnTest.Text = "开始检测";
            this.btnTest.UseVisualStyleBackColor = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCancel.Location = new System.Drawing.Point(479, 0);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 33);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "取消检测";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Btn_Logs
            // 
            this.Btn_Logs.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.Btn_Logs.Dock = System.Windows.Forms.DockStyle.Right;
            this.Btn_Logs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Logs.ForeColor = System.Drawing.SystemColors.Control;
            this.Btn_Logs.Location = new System.Drawing.Point(560, 0);
            this.Btn_Logs.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Logs.Name = "Btn_Logs";
            this.Btn_Logs.Size = new System.Drawing.Size(81, 33);
            this.Btn_Logs.TabIndex = 0;
            this.Btn_Logs.Text = "检测日志";
            this.Btn_Logs.UseVisualStyleBackColor = false;
            this.Btn_Logs.Click += new System.EventHandler(this.Btn_Logs_Click);
            // 
            // TopMenuStrip
            // 
            this.TopMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(128)))), ((int)(((byte)(172)))));
            this.TopMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.TopMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChooseToolStripMenuItem,
            this.toolStripMenuItem1,
            this.CommonSettingsMenuItem,
            this.toolStripMenuItem2,
            this.HookSettingsMenuItem,
            this.toolStripMenuItem3,
            this.DirectoriesSettingsMenuItem});
            this.TopMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.TopMenuStrip.Name = "TopMenuStrip";
            this.TopMenuStrip.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.TopMenuStrip.Size = new System.Drawing.Size(641, 25);
            this.TopMenuStrip.TabIndex = 2;
            this.TopMenuStrip.Text = "menuStrip1";
            // 
            // ChooseToolStripMenuItem
            // 
            this.ChooseToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.ChooseToolStripMenuItem.Name = "ChooseToolStripMenuItem";
            this.ChooseToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.ChooseToolStripMenuItem.Text = "选择检测目录";
            this.ChooseToolStripMenuItem.Click += new System.EventHandler(this.ChooseToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Enabled = false;
            this.toolStripMenuItem1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(23, 21);
            this.toolStripMenuItem1.Text = "|";
            // 
            // CommonSettingsMenuItem
            // 
            this.CommonSettingsMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.CommonSettingsMenuItem.Name = "CommonSettingsMenuItem";
            this.CommonSettingsMenuItem.Size = new System.Drawing.Size(68, 21);
            this.CommonSettingsMenuItem.Text = "常规设置";
            this.CommonSettingsMenuItem.Click += new System.EventHandler(this.CommonSettingsMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Enabled = false;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(23, 21);
            this.toolStripMenuItem2.Text = "|";
            // 
            // HookSettingsMenuItem
            // 
            this.HookSettingsMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.HookSettingsMenuItem.Name = "HookSettingsMenuItem";
            this.HookSettingsMenuItem.Size = new System.Drawing.Size(68, 21);
            this.HookSettingsMenuItem.Text = "挂接设置";
            this.HookSettingsMenuItem.Click += new System.EventHandler(this.HookSettingsMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Enabled = false;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(23, 21);
            this.toolStripMenuItem3.Text = "|";
            // 
            // DirectoriesSettingsMenuItem
            // 
            this.DirectoriesSettingsMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.DirectoriesSettingsMenuItem.Name = "DirectoriesSettingsMenuItem";
            this.DirectoriesSettingsMenuItem.Size = new System.Drawing.Size(68, 21);
            this.DirectoriesSettingsMenuItem.Text = "条目设置";
            this.DirectoriesSettingsMenuItem.Click += new System.EventHandler(this.DirectoriesSettingsMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtProgressBar);
            this.panel1.Controls.Add(this.txtInformation);
            this.panel1.Controls.Add(this.lblInformation);
            this.panel1.Controls.Add(this.lblProgress);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(641, 392);
            this.panel1.TabIndex = 3;
            // 
            // txtInformation
            // 
            this.txtInformation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInformation.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtInformation.Location = new System.Drawing.Point(18, 78);
            this.txtInformation.Multiline = true;
            this.txtInformation.Name = "txtInformation";
            this.txtInformation.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtInformation.Size = new System.Drawing.Size(603, 314);
            this.txtInformation.TabIndex = 3;
            this.txtInformation.Text = "欢迎使用数据质量检测系统。。。";
            this.txtInformation.TextChanged += new System.EventHandler(this.txtInformation_TextChanged);
            // 
            // lblInformation
            // 
            this.lblInformation.AutoSize = true;
            this.lblInformation.Location = new System.Drawing.Point(16, 62);
            this.lblInformation.Name = "lblInformation";
            this.lblInformation.Size = new System.Drawing.Size(65, 12);
            this.lblInformation.TabIndex = 2;
            this.lblInformation.Text = "详细信息：";
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(16, 7);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(71, 12);
            this.lblProgress.TabIndex = 0;
            this.lblProgress.Text = "准备开始...";
            // 
            // txtProgressBar
            // 
            this.txtProgressBar.Location = new System.Drawing.Point(18, 22);
            this.txtProgressBar.Name = "txtProgressBar";
            this.txtProgressBar.Size = new System.Drawing.Size(603, 23);
            this.txtProgressBar.TabIndex = 5;
            // 
            // MainUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BPan);
            this.Controls.Add(this.TopMenuStrip);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainUserControl";
            this.Size = new System.Drawing.Size(641, 450);
            this.Resize += new System.EventHandler(this.MainUserControl_Resize);
            this.BPan.ResumeLayout(false);
            this.TopMenuStrip.ResumeLayout(false);
            this.TopMenuStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel BPan;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button Btn_Logs;
        private System.Windows.Forms.MenuStrip TopMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ChooseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CommonSettingsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HookSettingsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DirectoriesSettingsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Label lblInformation;
        private System.Windows.Forms.TextBox txtInformation;
        private 进度条显示百分比.MyProgressBar txtProgressBar;
    }
}
