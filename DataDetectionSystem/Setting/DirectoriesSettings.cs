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
using Model;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;

namespace DataDetectionSystem
{
    public partial class DirectoriesSettings : Form
    {
        List<BindItem> items = new List<BindItem>();
        //创建工作薄
        IWorkbook workbook;
        public DirectoriesSettings(bool lab,bool com)
        {
            InitializeComponent();
            label1.Visible = lab;
            comboBox1.Visible = com;
        }

        private void btnBrowserFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = openFileDialog1.FileName;
            }
        }

        private void txtFile_TextChanged(object sender, EventArgs e)
        {
            string text = txtFile.Text;
            if (!String.IsNullOrWhiteSpace(text) && File.Exists(text))
            {

                workbook = WorkbookFactory.Create(text);
                int sheetsCount = workbook.NumberOfSheets;
                BindItem item;
                items.Clear();
                for (int i = 0; i < sheetsCount; i++)
                {
                    item = new BindItem();
                    item.Text = workbook.GetSheetName(i);
                    item.Value = i.ToString();
                    items.Add(item);
                }
                cmbSheets.DataSource = null;
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
                        IRow excelRow = sheet.GetRow(0);
                        if (excelRow != null)
                        {
                            ICell excelCell;
                            items.Clear();
                            BindItem item;
                            for (int i = excelRow.FirstCellNum; i < excelRow.LastCellNum; i++)
                            {
                                item = new BindItem();
                                excelCell = excelRow.GetCell(i);
                                if (excelCell != null)
                                {
                                    try
                                    {
                                        item.Text = excelCell.StringCellValue;
                                        item.Value = i.ToString();
                                        items.Add(item);
                                    }
                                    catch
                                    {

                                    }
                                }
                            }
                            if (items.Count > 0)
                            {
                                DataGridViewComboBoxCell cell;
                                BindItem[] itemArr;
                                foreach (DataGridViewRow row in dgvRules.Rows)
                                {
                                    itemArr = new BindItem[items.Count];
                                    items.CopyTo(itemArr);
                                    cell = row.Cells["Field"] as DataGridViewComboBoxCell;
                                    if (cell != null)
                                    {
                                        cell.DataSource = itemArr;
                                        cell.DisplayMember = "Text";
                                        cell.ValueMember = "Value";
                                        cell.Value = itemArr[0].Value;
                                    }
                                }
                                //foreach (DataGridViewRow orderRow in dgvOrderRules.Rows)
                                //{
                                //    itemArr = new BindItem[items.Count];
                                //    items.CopyTo(itemArr);
                                //    cell = orderRow.Cells[0] as DataGridViewComboBoxCell;
                                //    if (cell != null)
                                //    {
                                //        cell.DataSource = itemArr;
                                //        cell.DisplayMember = "Text";
                                //        cell.ValueMember = "Value";
                                //        cell.Value = itemArr[0].Value;
                                //    }
                                //}
                            }
                        }
                    }
                }
            }
        }

        private void DirectoriesSettings_Load(object sender, EventArgs e)
        {
            items = new List<BindItem>();
            ClearControlValues();
            LoadSettings();
        }

        private void dgvRules_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dgvRules.Rows.Count > e.RowIndex) 
            {
                DataGridViewRow row = dgvRules.Rows[e.RowIndex];
                LoadControlData(row);
                if (items.Count > 0)
                {
                    BindItem[] itemArr = new BindItem[items.Count];
                    items.CopyTo(itemArr);
                    DataGridViewComboBoxCell cell = row.Cells["Field"] as DataGridViewComboBoxCell;
                    if (cell != null)
                    {
                        cell.DataSource = itemArr;
                        cell.DisplayMember = "Text";
                        cell.ValueMember = "Value";
                        cell.Value = itemArr[0].Value;
                    }
                }
            }
        }

        private void dgvOrderRules_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //if (dgvOrderRules.Rows.Count > e.RowIndex) 
            //{
            //    DataGridViewRow row = dgvOrderRules.Rows[e.RowIndex];
            //    if (items.Count > 0)
            //    {
            //        BindItem[] itemArr = new BindItem[items.Count];
            //        items.CopyTo(itemArr);
            //        DataGridViewComboBoxCell cell = row.Cells[0] as DataGridViewComboBoxCell;
            //        if (cell != null)
            //        {
            //            cell.DataSource = itemArr;
            //            cell.DisplayMember = "Text";
            //            cell.ValueMember = "Value";
            //            cell.Value = itemArr[0].Value;
            //        }
            //    }
            //}
        }

        private void InitControlData()
        {
            foreach (DataGridViewRow row in dgvRules.Rows)
            {
                LoadControlData(row);
            }
        }

        private void LoadControlData(DataGridViewRow row)
        {
            DataGridViewComboBoxCell cell = row.Cells["Type"] as DataGridViewComboBoxCell;
            List<BindItem> bindItems;
            if (cell != null)
            {
                bindItems = new List<BindItem>();
                bindItems.Add(new BindItem("不限", ""));
                bindItems.Add(new BindItem("字符串", "String"));
                bindItems.Add(new BindItem("数字", "Number"));
                bindItems.Add(new BindItem("日期时间", "DateTime"));
                cell.DataSource = bindItems;
                cell.DisplayMember = "Text";
                cell.ValueMember = "Value";
                cell.Value = "";
            }
            cell = row.Cells["LengthOperator"] as DataGridViewComboBoxCell;
            if (cell != null)
            {
                bindItems = new List<BindItem>();
                bindItems.Add(new BindItem("不限", ""));
                bindItems.Add(new BindItem("等于", "Equal"));
                bindItems.Add(new BindItem("小于", "Smaller"));
                bindItems.Add(new BindItem("小于等于", "NotBigger"));
                bindItems.Add(new BindItem("大于", "Bigger"));
                bindItems.Add(new BindItem("大于等于", "NotSmaller"));
                cell.DataSource = bindItems;
                cell.DisplayMember = "Text";
                cell.ValueMember = "Value";
                cell.Value = "";
            }
            cell = row.Cells["Rule"] as DataGridViewComboBoxCell;
            if (cell != null)
            {
                bindItems = new List<BindItem>();
                bindItems.Add(new BindItem("无", ""));
                bindItems.Add(new BindItem("{保管期限}", "SaveTime"));
                bindItems.Add(new BindItem("{密级}", "SecurityLevel"));
                bindItems.Add(new BindItem("{固定值}", "Const"));
                bindItems.Add(new BindItem("{多选一值}", "Selectable"));
                cell.DataSource = bindItems;
                cell.DisplayMember = "Text";
                cell.ValueMember = "Value";
                cell.Value = "";
            }
        }

        private void ClearControlValues()
        {
            txtFile.Text = "";
            openFileDialog1.FileName = "";
            cmbSheets.SelectedIndex = -1;
            cmbSheets.DataSource = null;
        }

        private void LoadSettings()
        {
            Dictionary<string, string> settings = UIUtil.ReadSettings();
            string filePath = UIUtil.GetDictionaryValue(settings, "DirectoriesFile");
            if (!String.IsNullOrWhiteSpace(filePath) && File.Exists(filePath))
            {
                txtFile.Text = filePath;
                openFileDialog1.FileName = filePath;
                string sheet = UIUtil.GetDictionaryValue(settings, "DirectoriesSheet");
                if (String.IsNullOrWhiteSpace(sheet))
                    cmbSheets.SelectedIndex = -1;
                else
                    cmbSheets.SelectedValue = sheet;
                string field, setting;
                string[] rules;
                string ruleName, ruleValue;
                int i, index;
                dgvRules.Rows.Clear();
                //dgvOrderRules.Rows.Clear();
                DataGridViewRow row;
                foreach (string key in settings.Keys)
                {
                    if (key.StartsWith("FieldRule_"))
                    {
                        row = new DataGridViewRow();
                        row.CreateCells(dgvRules);
                        dgvRules.Rows.Add(row);
                        i = dgvRules.Rows.Count - 2;          //因为会自动创建新增行，所以要去掉最后一行
                        if (i >= 0)
                        {
                            row = dgvRules.Rows[i];
                            field = key.Replace("FieldRule_", "");
                            row.Cells["Field"].Value = field;
                            setting = settings[key];
                            rules = setting.Split(';');
                            foreach (string rule in rules)
                            {
                                index = rule.IndexOf("=");
                                ruleName = rule.Substring(0, index);
                                index++;
                                ruleValue = rule.Substring(index, rule.Length - index);
                                switch (ruleName)
                                {
                                    case "Required":
                                        row.Cells["Required"].Value = UIUtil.ConvertToBoolean(ruleValue);
                                        break;
                                    case "Type":
                                        row.Cells["Type"].Value = ruleValue;
                                        break;
                                    case "LengthOperator":
                                        row.Cells["LengthOperator"].Value = ruleValue;
                                        break;
                                    case "Length":
                                        row.Cells["Length"].Value = ruleValue;
                                        break;
                                    case "Repeat":
                                        row.Cells["Repeat"].Value = UIUtil.ConvertToBoolean(ruleValue);
                                        break;
                                    case "Rule":
                                        row.Cells["Rule"].Value = ruleValue;
                                        break;
                                    case "RuleExpression":
                                        row.Cells["RuleExpression"].Value = ruleValue;
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                    //if (key.StartsWith("OrderRule_"))
                    //{
                    //    row = new DataGridViewRow();
                    //    //row.CreateCells(dgvOrderRules);
                    //    //dgvOrderRules.Rows.Add(row);
                    //    //i = dgvOrderRules.Rows.Count - 2;          //因为会自动创建新增行，所以要去掉最后一行
                    //    if (i >= 0)
                    //    {
                    //        row = dgvOrderRules.Rows[i];
                    //        field = key.Replace("OrderRule_", "");
                    //        row.Cells["OrderField"].Value = field;
                    //        setting = settings[key];
                    //        rules = setting.Split(';');
                    //        foreach (string rule in rules)
                    //        {
                    //            index = rule.IndexOf("=");
                    //            ruleName = rule.Substring(0, index);
                    //            index++;
                    //            ruleValue = rule.Substring(index, rule.Length - index);
                    //            switch (ruleName)
                    //            {
                    //                case "Section":
                    //                    row.Cells["Section"].Value = ruleValue;
                    //                    break;
                    //                case "Seperator":
                    //                    row.Cells["Seperator"].Value = ruleValue;
                    //                    break;
                    //                case "Start":
                    //                    row.Cells["Start"].Value = ruleValue;
                    //                    break;
                    //                case "Increment":
                    //                    row.Cells["Increment"].Value = ruleValue;
                    //                    break;
                    //                default:
                    //                    break;
                    //            }
                    //        }
                    //    }
                    //}
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> settings = new Dictionary<string, string>();
            settings.Add("DirectoriesFile", txtFile.Text);
            settings.Add("DirectoriesSheet", UIUtil.GetComboSelectedStrVal(cmbSheets));
            object fieldIndex, required, type, lengthOperator, length, repeat, rule, ruleExpression, section, seperator,
                start, increment;
            foreach (DataGridViewRow row in dgvRules.Rows)
            {
                if (!row.IsNewRow)
                {
                    fieldIndex = row.Cells["Field"].Value;
                    required = row.Cells["Required"].Value;
                    type = row.Cells["Type"].Value;
                    lengthOperator = row.Cells["LengthOperator"].Value;
                    length = row.Cells["Length"].Value;
                    repeat = row.Cells["Repeat"].Value;
                    rule = row.Cells["Rule"].Value;
                    ruleExpression = row.Cells["RuleExpression"].Value;
                    settings.Add("FieldRule_" + fieldIndex, "Required=" + required + ";Type=" + type + ";LengthOperator=" +
                        lengthOperator + ";Length=" + length + ";Repeat=" + repeat + ";Rule=" + rule + ";RuleExpression=" + ruleExpression);
                }
            }
            //foreach (DataGridViewRow row in dgvOrderRules.Rows)
            //{
            //    if (!row.IsNewRow)
            //    {
            //        fieldIndex = row.Cells["OrderField"].Value;
            //        section = row.Cells["Section"].Value;
            //        seperator = row.Cells["Seperator"].Value;
            //        start = row.Cells["Start"].Value;
            //        increment = row.Cells["Increment"].Value;
            //        settings.Add("OrderRule_" + fieldIndex, "Section=" + section + ";Seperator=" + seperator + ";Start=" +
            //            start + ";Increment=" + increment);
            //    }
            //}
            UIUtil.SetConfig(settings, true, "^FieldRule_|^OrderRule_");
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
