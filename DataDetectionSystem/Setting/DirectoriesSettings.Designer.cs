namespace DataDetectionSystem
{
    partial class DirectoriesSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DirectoriesSettings));
            this.btnOK = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvRules = new System.Windows.Forms.DataGridView();
            this.Field = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Required = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.LengthOperator = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Repeat = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Rule = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.RuleExpression = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBrowserFile = new System.Windows.Forms.Button();
            this.cmbSheets = new System.Windows.Forms.ComboBox();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRules)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(476, 431);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(56, 34);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Controls.Add(this.btnBrowserFile);
            this.panel1.Controls.Add(this.cmbSheets);
            this.panel1.Controls.Add(this.txtFile);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(19, 42);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(513, 384);
            this.panel1.TabIndex = 14;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(3, 72);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(508, 310);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvRules);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Size = new System.Drawing.Size(500, 284);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "字段规则";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvRules
            // 
            this.dgvRules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRules.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Field,
            this.Required,
            this.Type,
            this.LengthOperator,
            this.Length,
            this.Repeat,
            this.Rule,
            this.RuleExpression});
            this.dgvRules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRules.Location = new System.Drawing.Point(2, 2);
            this.dgvRules.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvRules.Name = "dgvRules";
            this.dgvRules.RowHeadersVisible = false;
            this.dgvRules.RowHeadersWidth = 51;
            this.dgvRules.RowTemplate.Height = 27;
            this.dgvRules.Size = new System.Drawing.Size(496, 280);
            this.dgvRules.TabIndex = 0;
            this.dgvRules.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvRules_RowsAdded);
            // 
            // Field
            // 
            this.Field.DropDownWidth = 150;
            this.Field.HeaderText = "字段名";
            this.Field.MinimumWidth = 6;
            this.Field.Name = "Field";
            this.Field.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Field.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Field.Width = 105;
            // 
            // Required
            // 
            this.Required.HeaderText = "必填";
            this.Required.MinimumWidth = 6;
            this.Required.Name = "Required";
            this.Required.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Required.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Required.Width = 60;
            // 
            // Type
            // 
            this.Type.HeaderText = "类型";
            this.Type.MinimumWidth = 6;
            this.Type.Name = "Type";
            this.Type.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Type.Width = 70;
            // 
            // LengthOperator
            // 
            this.LengthOperator.HeaderText = "长度规则";
            this.LengthOperator.MinimumWidth = 6;
            this.LengthOperator.Name = "LengthOperator";
            this.LengthOperator.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.LengthOperator.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.LengthOperator.Width = 80;
            // 
            // Length
            // 
            this.Length.HeaderText = "长度";
            this.Length.MinimumWidth = 6;
            this.Length.Name = "Length";
            this.Length.Width = 80;
            // 
            // Repeat
            // 
            this.Repeat.HeaderText = "重复检查";
            this.Repeat.MinimumWidth = 6;
            this.Repeat.Name = "Repeat";
            this.Repeat.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Repeat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Repeat.Width = 80;
            // 
            // Rule
            // 
            this.Rule.HeaderText = "规则";
            this.Rule.MinimumWidth = 6;
            this.Rule.Name = "Rule";
            this.Rule.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Rule.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Rule.Width = 80;
            // 
            // RuleExpression
            // 
            this.RuleExpression.HeaderText = "规则参数";
            this.RuleExpression.MinimumWidth = 6;
            this.RuleExpression.Name = "RuleExpression";
            this.RuleExpression.Width = 125;
            // 
            // btnBrowserFile
            // 
            this.btnBrowserFile.Location = new System.Drawing.Point(194, 42);
            this.btnBrowserFile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBrowserFile.Name = "btnBrowserFile";
            this.btnBrowserFile.Size = new System.Drawing.Size(30, 20);
            this.btnBrowserFile.TabIndex = 3;
            this.btnBrowserFile.Text = "...";
            this.btnBrowserFile.UseVisualStyleBackColor = true;
            this.btnBrowserFile.Click += new System.EventHandler(this.btnBrowserFile_Click);
            // 
            // cmbSheets
            // 
            this.cmbSheets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSheets.FormattingEnabled = true;
            this.cmbSheets.Location = new System.Drawing.Point(292, 44);
            this.cmbSheets.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbSheets.Name = "cmbSheets";
            this.cmbSheets.Size = new System.Drawing.Size(201, 20);
            this.cmbSheets.TabIndex = 2;
            this.cmbSheets.SelectedIndexChanged += new System.EventHandler(this.cmbSheets_SelectedIndexChanged);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(24, 42);
            this.txtFile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(201, 21);
            this.txtFile.TabIndex = 1;
            this.txtFile.TextChanged += new System.EventHandler(this.txtFile_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(290, 19);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "选择工作簿";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "条目文件";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(105, 14);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(428, 20);
            this.comboBox1.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "选择检测方案：";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(415, 431);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 34);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "支持数据库文件|*.dbf;*.XLS;*.XLSX;*.MDB;*.ACCDB";
            this.openFileDialog1.RestoreDirectory = true;
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(510, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 30);
            this.button1.TabIndex = 15;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DirectoriesSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 473);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "DirectoriesSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DirectoriesSettings";
            this.Load += new System.EventHandler(this.DirectoriesSettings_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRules)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBrowserFile;
        private System.Windows.Forms.ComboBox cmbSheets;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvRules;
        private System.Windows.Forms.DataGridViewComboBoxColumn Field;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Required;
        private System.Windows.Forms.DataGridViewComboBoxColumn Type;
        private System.Windows.Forms.DataGridViewComboBoxColumn LengthOperator;
        private System.Windows.Forms.DataGridViewTextBoxColumn Length;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Repeat;
        private System.Windows.Forms.DataGridViewComboBoxColumn Rule;
        private System.Windows.Forms.DataGridViewTextBoxColumn RuleExpression;
        private System.Windows.Forms.Button button1;
    }
}