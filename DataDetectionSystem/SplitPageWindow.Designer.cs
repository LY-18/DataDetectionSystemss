namespace DataDetectionSystem
{
    partial class SplitPageWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.ArchiveChoicePath = new System.Windows.Forms.TextBox();
            this.Btn_ArchiveChoice = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PartsChoicePath = new System.Windows.Forms.TextBox();
            this.ExChoice = new System.Windows.Forms.TextBox();
            this.Btn_PartsChoice = new System.Windows.Forms.Button();
            this.Btn_ExChoice = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ListLog = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.nullDirListbox = new System.Windows.Forms.ListBox();
            this.Btn_Start = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.ArchiveCatePath = new System.Windows.Forms.TextBox();
            this.Btn_ArchiveCateChoice = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "案卷条目";
            // 
            // ArchiveChoicePath
            // 
            this.ArchiveChoicePath.Location = new System.Drawing.Point(111, 21);
            this.ArchiveChoicePath.Name = "ArchiveChoicePath";
            this.ArchiveChoicePath.Size = new System.Drawing.Size(351, 25);
            this.ArchiveChoicePath.TabIndex = 1;
            // 
            // Btn_ArchiveChoice
            // 
            this.Btn_ArchiveChoice.Location = new System.Drawing.Point(416, 21);
            this.Btn_ArchiveChoice.Name = "Btn_ArchiveChoice";
            this.Btn_ArchiveChoice.Size = new System.Drawing.Size(46, 25);
            this.Btn_ArchiveChoice.TabIndex = 2;
            this.Btn_ArchiveChoice.Text = "…";
            this.Btn_ArchiveChoice.UseVisualStyleBackColor = true;
            this.Btn_ArchiveChoice.Click += new System.EventHandler(this.Btn_ArchiveChoice_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "分件目录";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "输出目录";
            // 
            // PartsChoicePath
            // 
            this.PartsChoicePath.Location = new System.Drawing.Point(111, 103);
            this.PartsChoicePath.Name = "PartsChoicePath";
            this.PartsChoicePath.Size = new System.Drawing.Size(351, 25);
            this.PartsChoicePath.TabIndex = 1;
            // 
            // ExChoice
            // 
            this.ExChoice.Location = new System.Drawing.Point(111, 141);
            this.ExChoice.Name = "ExChoice";
            this.ExChoice.Size = new System.Drawing.Size(351, 25);
            this.ExChoice.TabIndex = 1;
            // 
            // Btn_PartsChoice
            // 
            this.Btn_PartsChoice.Location = new System.Drawing.Point(416, 103);
            this.Btn_PartsChoice.Name = "Btn_PartsChoice";
            this.Btn_PartsChoice.Size = new System.Drawing.Size(46, 25);
            this.Btn_PartsChoice.TabIndex = 2;
            this.Btn_PartsChoice.Text = "…";
            this.Btn_PartsChoice.UseVisualStyleBackColor = true;
            this.Btn_PartsChoice.Click += new System.EventHandler(this.Btn_PartsChoice_Click);
            // 
            // Btn_ExChoice
            // 
            this.Btn_ExChoice.Location = new System.Drawing.Point(416, 141);
            this.Btn_ExChoice.Name = "Btn_ExChoice";
            this.Btn_ExChoice.Size = new System.Drawing.Size(46, 25);
            this.Btn_ExChoice.TabIndex = 2;
            this.Btn_ExChoice.Text = "…";
            this.Btn_ExChoice.UseVisualStyleBackColor = true;
            this.Btn_ExChoice.Click += new System.EventHandler(this.Btn_ExChoice_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(14, 210);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(448, 291);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ListLog);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(440, 262);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "分件日志";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ListLog
            // 
            this.ListLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListLog.FormattingEnabled = true;
            this.ListLog.ItemHeight = 15;
            this.ListLog.Location = new System.Drawing.Point(3, 3);
            this.ListLog.Name = "ListLog";
            this.ListLog.Size = new System.Drawing.Size(434, 256);
            this.ListLog.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.nullDirListbox);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(440, 262);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "分件目录空文件夹";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // nullDirListbox
            // 
            this.nullDirListbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nullDirListbox.FormattingEnabled = true;
            this.nullDirListbox.ItemHeight = 15;
            this.nullDirListbox.Location = new System.Drawing.Point(3, 3);
            this.nullDirListbox.Name = "nullDirListbox";
            this.nullDirListbox.Size = new System.Drawing.Size(434, 256);
            this.nullDirListbox.TabIndex = 0;
            // 
            // Btn_Start
            // 
            this.Btn_Start.Location = new System.Drawing.Point(165, 505);
            this.Btn_Start.Name = "Btn_Start";
            this.Btn_Start.Size = new System.Drawing.Size(111, 38);
            this.Btn_Start.TabIndex = 2;
            this.Btn_Start.Text = "开始分件";
            this.Btn_Start.UseVisualStyleBackColor = true;
            this.Btn_Start.Click += new System.EventHandler(this.Btn_Start_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "案卷目录";
            // 
            // ArchiveCatePath
            // 
            this.ArchiveCatePath.Location = new System.Drawing.Point(111, 61);
            this.ArchiveCatePath.Name = "ArchiveCatePath";
            this.ArchiveCatePath.Size = new System.Drawing.Size(351, 25);
            this.ArchiveCatePath.TabIndex = 1;
            // 
            // Btn_ArchiveCateChoice
            // 
            this.Btn_ArchiveCateChoice.Location = new System.Drawing.Point(416, 61);
            this.Btn_ArchiveCateChoice.Name = "Btn_ArchiveCateChoice";
            this.Btn_ArchiveCateChoice.Size = new System.Drawing.Size(48, 25);
            this.Btn_ArchiveCateChoice.TabIndex = 6;
            this.Btn_ArchiveCateChoice.Text = "…";
            this.Btn_ArchiveCateChoice.UseVisualStyleBackColor = true;
            this.Btn_ArchiveCateChoice.Click += new System.EventHandler(this.Btn_ArchiveCateChoice_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.listBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(440, 262);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "输出路径空文件夹";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(3, 3);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(434, 256);
            this.listBox1.TabIndex = 0;
            // 
            // SplitPageWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 547);
            this.Controls.Add(this.Btn_ArchiveCateChoice);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.Btn_Start);
            this.Controls.Add(this.Btn_ExChoice);
            this.Controls.Add(this.Btn_PartsChoice);
            this.Controls.Add(this.Btn_ArchiveChoice);
            this.Controls.Add(this.ExChoice);
            this.Controls.Add(this.PartsChoicePath);
            this.Controls.Add(this.ArchiveCatePath);
            this.Controls.Add(this.ArchiveChoicePath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SplitPageWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "分件器";
            this.Load += new System.EventHandler(this.SplitPageWindow_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ArchiveChoicePath;
        private System.Windows.Forms.Button Btn_ArchiveChoice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PartsChoicePath;
        private System.Windows.Forms.TextBox ExChoice;
        private System.Windows.Forms.Button Btn_PartsChoice;
        private System.Windows.Forms.Button Btn_ExChoice;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button Btn_Start;
        private System.Windows.Forms.ListBox ListLog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ArchiveCatePath;
        private System.Windows.Forms.Button Btn_ArchiveCateChoice;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox nullDirListbox;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListBox listBox1;
    }
}