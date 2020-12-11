namespace DataDetectionSystem
{
    partial class ToolWindow
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
            this.TopMenuStrip = new System.Windows.Forms.MenuStrip();
            this.FileNameCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DPIDesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DPICToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PdfNumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileWaterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SplitPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImageDesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileAddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileDelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CleanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StartDesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PreviousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.DesList = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.TopMenuStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // TopMenuStrip
            // 
            this.TopMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(128)))), ((int)(((byte)(172)))));
            this.TopMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.TopMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileNameCToolStripMenuItem,
            this.DPIDesToolStripMenuItem,
            this.DPICToolStripMenuItem,
            this.PdfNumToolStripMenuItem,
            this.FileWaterToolStripMenuItem,
            this.SplitPageToolStripMenuItem,
            this.ImageDesToolStripMenuItem});
            this.TopMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.TopMenuStrip.Name = "TopMenuStrip";
            this.TopMenuStrip.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.TopMenuStrip.Size = new System.Drawing.Size(656, 25);
            this.TopMenuStrip.TabIndex = 0;
            this.TopMenuStrip.Text = "menuStrip1";
            // 
            // FileNameCToolStripMenuItem
            // 
            this.FileNameCToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.FileNameCToolStripMenuItem.Name = "FileNameCToolStripMenuItem";
            this.FileNameCToolStripMenuItem.Size = new System.Drawing.Size(104, 21);
            this.FileNameCToolStripMenuItem.Text = "文件重命名工具";
            this.FileNameCToolStripMenuItem.Click += new System.EventHandler(this.FileNameCToolStripMenuItem_Click);
            // 
            // DPIDesToolStripMenuItem
            // 
            this.DPIDesToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.DPIDesToolStripMenuItem.Name = "DPIDesToolStripMenuItem";
            this.DPIDesToolStripMenuItem.Size = new System.Drawing.Size(64, 21);
            this.DPIDesToolStripMenuItem.Text = "DPI检测";
            this.DPIDesToolStripMenuItem.Visible = false;
            this.DPIDesToolStripMenuItem.Click += new System.EventHandler(this.DPIDesToolStripMenuItem_Click);
            // 
            // DPICToolStripMenuItem
            // 
            this.DPICToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.DPICToolStripMenuItem.Name = "DPICToolStripMenuItem";
            this.DPICToolStripMenuItem.Size = new System.Drawing.Size(64, 21);
            this.DPICToolStripMenuItem.Text = "DPI修改";
            this.DPICToolStripMenuItem.Click += new System.EventHandler(this.DPICToolStripMenuItem_Click);
            // 
            // PdfNumToolStripMenuItem
            // 
            this.PdfNumToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.PdfNumToolStripMenuItem.Name = "PdfNumToolStripMenuItem";
            this.PdfNumToolStripMenuItem.Size = new System.Drawing.Size(66, 21);
            this.PdfNumToolStripMenuItem.Text = "PDF统计";
            this.PdfNumToolStripMenuItem.Click += new System.EventHandler(this.PdfNumToolStripMenuItem_Click);
            // 
            // FileWaterToolStripMenuItem
            // 
            this.FileWaterToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.FileWaterToolStripMenuItem.Name = "FileWaterToolStripMenuItem";
            this.FileWaterToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.FileWaterToolStripMenuItem.Text = "文件水印";
            this.FileWaterToolStripMenuItem.Click += new System.EventHandler(this.FileWaterToolStripMenuItem_Click);
            // 
            // SplitPageToolStripMenuItem
            // 
            this.SplitPageToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.SplitPageToolStripMenuItem.Name = "SplitPageToolStripMenuItem";
            this.SplitPageToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.SplitPageToolStripMenuItem.Text = "分件器";
            this.SplitPageToolStripMenuItem.Visible = false;
            this.SplitPageToolStripMenuItem.Click += new System.EventHandler(this.SplitPageToolStripMenuItem_Click);
            // 
            // ImageDesToolStripMenuItem
            // 
            this.ImageDesToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.ImageDesToolStripMenuItem.Name = "ImageDesToolStripMenuItem";
            this.ImageDesToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.ImageDesToolStripMenuItem.Text = "图像相似度";
            this.ImageDesToolStripMenuItem.Visible = false;
            this.ImageDesToolStripMenuItem.Click += new System.EventHandler(this.ImageDesToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileAddToolStripMenuItem,
            this.FileDelToolStripMenuItem,
            this.CleanToolStripMenuItem,
            this.StartDesToolStripMenuItem,
            this.PreviousToolStripMenuItem,
            this.NextToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 25);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(656, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileAddToolStripMenuItem
            // 
            this.FileAddToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FileAddToolStripMenuItem.Image = global::DataDetectionSystem.Properties.Resources.resizeApi;
            this.FileAddToolStripMenuItem.Name = "FileAddToolStripMenuItem";
            this.FileAddToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.FileAddToolStripMenuItem.Text = "添加文件";
            this.FileAddToolStripMenuItem.Click += new System.EventHandler(this.FileAddToolStripMenuItem_Click);
            // 
            // FileDelToolStripMenuItem
            // 
            this.FileDelToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FileDelToolStripMenuItem.Image = global::DataDetectionSystem.Properties.Resources.Del;
            this.FileDelToolStripMenuItem.Name = "FileDelToolStripMenuItem";
            this.FileDelToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.FileDelToolStripMenuItem.Text = "删除文件";
            this.FileDelToolStripMenuItem.Click += new System.EventHandler(this.FileDelToolStripMenuItem_Click);
            // 
            // CleanToolStripMenuItem
            // 
            this.CleanToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CleanToolStripMenuItem.Image = global::DataDetectionSystem.Properties.Resources.Ra;
            this.CleanToolStripMenuItem.Name = "CleanToolStripMenuItem";
            this.CleanToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.CleanToolStripMenuItem.Text = "清空列表";
            this.CleanToolStripMenuItem.Click += new System.EventHandler(this.CleanToolStripMenuItem_Click);
            // 
            // StartDesToolStripMenuItem
            // 
            this.StartDesToolStripMenuItem.Image = global::DataDetectionSystem.Properties.Resources.start;
            this.StartDesToolStripMenuItem.Name = "StartDesToolStripMenuItem";
            this.StartDesToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.StartDesToolStripMenuItem.Text = "开始检测";
            this.StartDesToolStripMenuItem.Visible = false;
            this.StartDesToolStripMenuItem.Click += new System.EventHandler(this.StartDesToolStripMenuItem_Click);
            // 
            // PreviousToolStripMenuItem
            // 
            this.PreviousToolStripMenuItem.Image = global::DataDetectionSystem.Properties.Resources.qian;
            this.PreviousToolStripMenuItem.Name = "PreviousToolStripMenuItem";
            this.PreviousToolStripMenuItem.Size = new System.Drawing.Size(100, 24);
            this.PreviousToolStripMenuItem.Text = "上一组图片";
            this.PreviousToolStripMenuItem.Visible = false;
            this.PreviousToolStripMenuItem.Click += new System.EventHandler(this.PreviousToolStripMenuItem_Click);
            // 
            // NextToolStripMenuItem
            // 
            this.NextToolStripMenuItem.Image = global::DataDetectionSystem.Properties.Resources.hou;
            this.NextToolStripMenuItem.Name = "NextToolStripMenuItem";
            this.NextToolStripMenuItem.Size = new System.Drawing.Size(100, 24);
            this.NextToolStripMenuItem.Text = "下一组图片";
            this.NextToolStripMenuItem.Visible = false;
            this.NextToolStripMenuItem.Click += new System.EventHandler(this.NextToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 53);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(656, 394);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(648, 368);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "检测列表";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(2, 2);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.DesList);
            this.splitContainer1.Size = new System.Drawing.Size(644, 364);
            this.splitContainer1.SplitterDistance = 160;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // DesList
            // 
            this.DesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DesList.FormattingEnabled = true;
            this.DesList.ItemHeight = 12;
            this.DesList.Location = new System.Drawing.Point(0, 0);
            this.DesList.Margin = new System.Windows.Forms.Padding(2);
            this.DesList.Name = "DesList";
            this.DesList.Size = new System.Drawing.Size(644, 160);
            this.DesList.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(648, 368);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "查看详情";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(2, 2);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(644, 364);
            this.splitContainer2.SplitterDistance = 52;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.pictureBox2);
            this.splitContainer3.Size = new System.Drawing.Size(644, 309);
            this.splitContainer3.SplitterDistance = 313;
            this.splitContainer3.SplitterWidth = 3;
            this.splitContainer3.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(313, 309);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(328, 309);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // ToolWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.TopMenuStrip);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ToolWindow";
            this.Size = new System.Drawing.Size(656, 447);
            this.TopMenuStrip.ResumeLayout(false);
            this.TopMenuStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip TopMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ImageDesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FileNameCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DPIDesToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileAddToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FileDelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CleanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StartDesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PreviousToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NextToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStripMenuItem DPICToolStripMenuItem;
        private System.Windows.Forms.ListBox DesList;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripMenuItem PdfNumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FileWaterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SplitPageToolStripMenuItem;
    }
}
