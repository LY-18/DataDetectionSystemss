namespace DataDetectionSystem
{
    partial class DPIChange
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.HasCheckBox = new System.Windows.Forms.CheckBox();
            this.Btn_SPath = new System.Windows.Forms.Button();
            this.Txt_SPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.Btn_NPath = new System.Windows.Forms.Button();
            this.Txt_NPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Btn_DpiC = new System.Windows.Forms.Button();
            this.Btn_CreatPdf = new System.Windows.Forms.Button();
            this.Btn_Ex = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Txt_Error = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.TxtFinish = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.HasCheckBox);
            this.groupBox1.Controls.Add(this.Btn_SPath);
            this.groupBox1.Controls.Add(this.Txt_SPath);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(355, 94);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "原文";
            // 
            // HasCheckBox
            // 
            this.HasCheckBox.AutoSize = true;
            this.HasCheckBox.Location = new System.Drawing.Point(68, 56);
            this.HasCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.HasCheckBox.Name = "HasCheckBox";
            this.HasCheckBox.Size = new System.Drawing.Size(120, 16);
            this.HasCheckBox.TabIndex = 3;
            this.HasCheckBox.Text = "包含子文件夹文件";
            this.HasCheckBox.UseVisualStyleBackColor = true;
            // 
            // Btn_SPath
            // 
            this.Btn_SPath.Location = new System.Drawing.Point(270, 22);
            this.Btn_SPath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Btn_SPath.Name = "Btn_SPath";
            this.Btn_SPath.Size = new System.Drawing.Size(56, 21);
            this.Btn_SPath.TabIndex = 2;
            this.Btn_SPath.Text = "选择";
            this.Btn_SPath.UseVisualStyleBackColor = true;
            this.Btn_SPath.Click += new System.EventHandler(this.Btn_SPath_Click);
            // 
            // Txt_SPath
            // 
            this.Txt_SPath.Location = new System.Drawing.Point(68, 22);
            this.Txt_SPath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Txt_SPath.Name = "Txt_SPath";
            this.Txt_SPath.Size = new System.Drawing.Size(199, 21);
            this.Txt_SPath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "原文路径";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox2);
            this.groupBox2.Controls.Add(this.Btn_NPath);
            this.groupBox2.Controls.Add(this.Txt_NPath);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(3, 102);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(355, 85);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "目标";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "100",
            "200",
            "300",
            "400",
            "500",
            "600",
            "700",
            "800",
            "900"});
            this.comboBox2.Location = new System.Drawing.Point(68, 51);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(92, 20);
            this.comboBox2.TabIndex = 4;
            // 
            // Btn_NPath
            // 
            this.Btn_NPath.Location = new System.Drawing.Point(270, 22);
            this.Btn_NPath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Btn_NPath.Name = "Btn_NPath";
            this.Btn_NPath.Size = new System.Drawing.Size(56, 21);
            this.Btn_NPath.TabIndex = 2;
            this.Btn_NPath.Text = "选择";
            this.Btn_NPath.UseVisualStyleBackColor = true;
            this.Btn_NPath.Click += new System.EventHandler(this.Btn_NPath_Click);
            // 
            // Txt_NPath
            // 
            this.Txt_NPath.Location = new System.Drawing.Point(68, 22);
            this.Txt_NPath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Txt_NPath.Name = "Txt_NPath";
            this.Txt_NPath.Size = new System.Drawing.Size(199, 21);
            this.Txt_NPath.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 58);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "分辨率";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 24);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "目标路径";
            // 
            // Btn_DpiC
            // 
            this.Btn_DpiC.Location = new System.Drawing.Point(10, 195);
            this.Btn_DpiC.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Btn_DpiC.Name = "Btn_DpiC";
            this.Btn_DpiC.Size = new System.Drawing.Size(73, 30);
            this.Btn_DpiC.TabIndex = 2;
            this.Btn_DpiC.Text = "修改分辨率";
            this.Btn_DpiC.UseVisualStyleBackColor = true;
            this.Btn_DpiC.Click += new System.EventHandler(this.Btn_DpiC_Click);
            // 
            // Btn_CreatPdf
            // 
            this.Btn_CreatPdf.Location = new System.Drawing.Point(99, 195);
            this.Btn_CreatPdf.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Btn_CreatPdf.Name = "Btn_CreatPdf";
            this.Btn_CreatPdf.Size = new System.Drawing.Size(73, 30);
            this.Btn_CreatPdf.TabIndex = 2;
            this.Btn_CreatPdf.Text = "生成PDF";
            this.Btn_CreatPdf.UseVisualStyleBackColor = true;
            this.Btn_CreatPdf.Click += new System.EventHandler(this.Btn_CreatPdf_Click);
            // 
            // Btn_Ex
            // 
            this.Btn_Ex.Location = new System.Drawing.Point(285, 200);
            this.Btn_Ex.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Btn_Ex.Name = "Btn_Ex";
            this.Btn_Ex.Size = new System.Drawing.Size(73, 30);
            this.Btn_Ex.TabIndex = 2;
            this.Btn_Ex.Text = "退出";
            this.Btn_Ex.UseVisualStyleBackColor = true;
            this.Btn_Ex.Click += new System.EventHandler(this.Btn_Ex_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(3, 235);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(355, 195);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Size = new System.Drawing.Size(347, 169);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "转换列表";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(2, 2);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(343, 165);
            this.listBox1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.Txt_Error);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Size = new System.Drawing.Size(347, 169);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "转换错误日志";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Txt_Error
            // 
            this.Txt_Error.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Txt_Error.Location = new System.Drawing.Point(2, 2);
            this.Txt_Error.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Txt_Error.Multiline = true;
            this.Txt_Error.Name = "Txt_Error";
            this.Txt_Error.Size = new System.Drawing.Size(343, 165);
            this.Txt_Error.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.TxtFinish);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage3.Size = new System.Drawing.Size(347, 169);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "转换修复日志";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // TxtFinish
            // 
            this.TxtFinish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtFinish.Location = new System.Drawing.Point(2, 2);
            this.TxtFinish.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TxtFinish.Multiline = true;
            this.TxtFinish.Name = "TxtFinish";
            this.TxtFinish.Size = new System.Drawing.Size(343, 165);
            this.TxtFinish.TabIndex = 0;
            // 
            // DPIChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 436);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.Btn_Ex);
            this.Controls.Add(this.Btn_CreatPdf);
            this.Controls.Add(this.Btn_DpiC);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DPIChange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PDF【JPG文件分辨率转换】及【生成PDF】";
            this.Load += new System.EventHandler(this.DPIChange_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox HasCheckBox;
        private System.Windows.Forms.Button Btn_SPath;
        private System.Windows.Forms.TextBox Txt_SPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button Btn_NPath;
        private System.Windows.Forms.TextBox Txt_NPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Btn_DpiC;
        private System.Windows.Forms.Button Btn_CreatPdf;
        private System.Windows.Forms.Button Btn_Ex;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox Txt_Error;
        private System.Windows.Forms.TextBox TxtFinish;
    }
}