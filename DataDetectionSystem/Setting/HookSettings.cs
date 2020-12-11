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
using NPOI.SS.UserModel;
using Model;

namespace DataDetectionSystem
{
    public partial class HookSettings : Form
    {
        private IWorkbook workbook;
        
        public HookSettings(bool lab,bool com)
        {
            InitializeComponent();
            label1.Visible = lab;
            comboBox1.Visible = com;
        }

        private void btnBrowserFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = openFileDialog1.FileName;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            if (txtFilePath.Text == null)
            {
                MessageBox.Show("请先选择条目文件！");
                return;
            }
            else if (workbook is null)
            {
                MessageBox.Show("文件：" + txtFilePath.Text + "已经打开，请关闭文件！");
                return;
            }
                workbook.Close();
                Dictionary<string, string> settings = new Dictionary<string, string>();
                settings.Add("HookDirectoriesFile", txtFilePath.Text);
                settings.Add("HookSheet", UIUtil.GetComboSelectedStrVal(cmbSheets));
                settings.Add("ArchiveIdField", UIUtil.GetComboSelectedStrVal(cmbArchiveIdField));
                settings.Add("PageField", UIUtil.GetComboSelectedStrVal(cmbPageField));
                UIUtil.SetConfig(settings);
                this.Close();
        }

        private void txtFilePath_TextChanged(object sender, EventArgs e)
        {
            string text = txtFilePath.Text;
            if (!String.IsNullOrWhiteSpace(text) && File.Exists(text))
            {
                try
                {
                    workbook = WorkbookFactory.Create(text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("文件："+text+"文件已经打开！");
                    return;
                }
                
                List<BindItem> items = new List<BindItem>();
                int sheetsCount = workbook.NumberOfSheets;
                BindItem item;
                for (int i = 0; i < sheetsCount; i++)
                {
                    item = new BindItem();
                    item.Text = workbook.GetSheetName(i);
                    item.Value = i.ToString();
                    items.Add(item);
                }
                cmbSheets.DataSource = items;
                cmbSheets.DisplayMember = "Text";
                cmbSheets.ValueMember = "Value";
                if (cmbSheets.Items.Count > 0)
                {
                    cmbSheets.SelectedIndex = -1;
                    cmbSheets.SelectedIndex = 0;
                }
            }
        }

        private void cmbSheets_SelectedIndexChanged(object sender, EventArgs e)
        {
            object selectedValue = cmbSheets.SelectedValue;
            if (selectedValue != null)
            {
                string sIndex = selectedValue as string;
                int index;
                if (!String.IsNullOrWhiteSpace(sIndex) && int.TryParse(sIndex, out index))
                {
                    ISheet sheet = workbook.GetSheetAt(index);
                    int lastRowNum = sheet.LastRowNum;
                    if (lastRowNum > 0)
                    {
                        IRow row = sheet.GetRow(0);
                        if (row != null)
                        {
                            ICell cell;
                            string cellValue, sI;
                            List<BindItem> items = new List<BindItem>(), pageItems = new List<BindItem>();
                            BindItem item;
                            for (int i = row.FirstCellNum; i < row.LastCellNum; i++)
                            {
                                item = new BindItem();
                                cell = row.GetCell(i);
                                if (cell != null)
                                {
                                    try
                                    {
                                        cellValue = cell.StringCellValue;
                                        item.Text = cellValue;
                                        sI = i.ToString();
                                        item.Value = sI;
                                        items.Add(item);
                                        item = new BindItem();
                                        item.Text = cellValue;
                                        item.Value = sI;
                                        pageItems.Add(item);
                                    }
                                    catch
                                    {

                                    }
                                }
                            }
                            cmbArchiveIdField.DataSource = items;
                            cmbArchiveIdField.DisplayMember = "Text";
                            cmbArchiveIdField.ValueMember = "Value";
                            cmbPageField.DataSource = pageItems;
                            cmbPageField.DisplayMember = "Text";
                            cmbPageField.ValueMember = "Value";
                            if (cmbArchiveIdField.Items.Count > 0)
                            {
                                cmbArchiveIdField.SelectedIndex = -1;
                                cmbArchiveIdField.SelectedIndex = 0;
                            }
                            if (cmbPageField.Items.Count > 0)
                            {
                                cmbPageField.SelectedIndex = -1;
                                cmbPageField.SelectedIndex = 0;
                            }
                        }
                    }
                }
            }
        }

        private void HookSettings_Load(object sender, EventArgs e)
        {
            txtFilePath.ReadOnly = true;
            ClearControlValues();
            LoadSettings();

            List<string> vs = Model.BindItem.PlanList;
            foreach (var item in vs)
            {
                comboBox1.Items.Add(item);

            }
        }

        /// <summary>
        /// 读取保存的配置信息并加载
        /// </summary>
        private void LoadSettings()
        {
            Dictionary<string, string> settings = UIUtil.ReadSettings();
            string filePath = UIUtil.GetDictionaryValue(settings, "HookDirectoriesFile");
            if (!String.IsNullOrWhiteSpace(filePath) && File.Exists(filePath))
            {
                txtFilePath.Text = filePath;
                openFileDialog1.FileName = filePath;
                string sheet = UIUtil.GetDictionaryValue(settings, "HookSheet");
                if (String.IsNullOrWhiteSpace(sheet))
                    cmbSheets.SelectedIndex = -1;
                else
                    cmbSheets.SelectedValue = sheet;
                string field = UIUtil.GetDictionaryValue(settings, "ArchiveIdField");
                if (String.IsNullOrWhiteSpace(field))
                    cmbArchiveIdField.SelectedIndex = -1;
                else
                {
                    cmbArchiveIdField.SelectedValue = field;
                    string rule = UIUtil.GetDictionaryValue(settings, "FieldRole");
                    if (!String.IsNullOrWhiteSpace(rule))
                    {
                        txtFilePath.Text = rule;
                    }
                }
                string pageField = UIUtil.GetDictionaryValue(settings, "PageField");
                if (String.IsNullOrWhiteSpace(pageField))
                    cmbPageField.SelectedIndex = -1;
                else
                    cmbPageField.SelectedValue = pageField;
            }
        }

        /// <summary>
        /// 清除控件上先前的值
        /// </summary>
        private void ClearControlValues()
        {
            txtFilePath.Text = "";
            openFileDialog1.FileName = "";
            cmbArchiveIdField.SelectedIndex = -1;
            cmbArchiveIdField.DataSource = null;
            cmbPageField.SelectedIndex = -1;
            cmbPageField.DataSource = null;
            cmbSheets.SelectedIndex = -1;
            cmbSheets.DataSource = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
