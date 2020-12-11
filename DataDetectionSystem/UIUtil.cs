using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using BLL;
using Model;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using System.Drawing;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;

namespace DataDetectionSystem
{
    //UI层的公共类，封装UI层的通用操作，如果分层，建议将与UI无关的通用功能放到公共层
    public class UIUtil
    {
        public static string logpaths;
        private static string PassRate;
       

        #region 配置相关
        /// <summary>
        /// 读取配置节，根据键返回配置值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>配置字符串</returns>
        public static string ReadSetting(string key)
        {
            if (!string.IsNullOrWhiteSpace(key) && ConfigurationManager.AppSettings.AllKeys.Contains(key))
            {
                string setting = ConfigurationManager.AppSettings[key];
                return setting;
            }
            return "";
        }

        /// <summary>
        /// 读取全部配置
        /// </summary>
        /// <returns>将App.config读取成CLR键值对</returns>
        public static Dictionary<string, string> ReadSettings()
        {
            Dictionary<string, string> keyValues = new Dictionary<string, string>();
            if (ConfigurationManager.AppSettings.Count > 0)
            {
                string[] keys = ConfigurationManager.AppSettings.AllKeys;
                foreach (string key in keys)
                {
                    if (!String.IsNullOrWhiteSpace(key))
                    {
                        string setting = ConfigurationManager.AppSettings[key];
                        keyValues.Add(key, setting);
                    }
                }
            }
            return keyValues;
        }

        /// <summary>
        /// 保存配置，如果不存在指定的配置节，则将其添加到appSettings
        /// </summary>
        /// <param name="keyValues">表示配置节键及设置的键值对的集合</param>
        public static void SetConfig(Dictionary<string, string> keyValues)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            foreach (string key in keyValues.Keys)
            {
                //键不能为空
                if (!String.IsNullOrWhiteSpace(key))
                {
                    string setting = keyValues[key];
                    //配置节值可以为空，但键值不能为null
                    if (setting != null)
                    {
                        if (configuration.AppSettings.Settings.AllKeys.Contains(key))
                            configuration.AppSettings.Settings[key].Value = setting;
                        else
                            configuration.AppSettings.Settings.Add(key, setting);
                    }
                }
            }
            configuration.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        /// <summary>
        /// 保存配置，如果指定了需要清除之前的设置，根据模式匹配需要清除的配置节
        /// </summary>
        /// <param name="keyValues">表示配置节键及设置的键值对的集合</param>
        /// <param name="reset">是否需要清除之前的设置</param>
        /// <param name="pattern">匹配模式</param>
        public static void SetConfig(Dictionary<string, string> keyValues, bool reset, string pattern)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (reset)
            {
                Regex regex = new Regex(pattern);
                foreach (string key in configuration.AppSettings.Settings.AllKeys)
                {
                    if (regex.IsMatch(key))
                    {
                        configuration.AppSettings.Settings.Remove(key);
                    }
                }
            }
            foreach (string key in keyValues.Keys)
            {
                //键不能为空
                if (!String.IsNullOrWhiteSpace(key))
                {
                    string setting = keyValues[key];
                    //配置节值可以为空，但键值不能为null
                    if (setting != null)
                    {
                        if (configuration.AppSettings.Settings.AllKeys.Contains(key))
                            configuration.AppSettings.Settings[key].Value = setting;
                        else
                            configuration.AppSettings.Settings.Add(key, setting);
                    }
                }
            }
            configuration.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        /// <summary>
        /// 获取下拉框的选择值字符串
        /// </summary>
        /// <param name="combo">下拉框</param>
        /// <returns>选择值字符串</returns>
        public static string GetComboSelectedStrVal(ComboBox combo)
        {
            object selectedValue = combo.SelectedValue;
            if (selectedValue == null)
                return "";
            else
            {
                return selectedValue as string;
            }
        }

        /// <summary>
        /// 获取指定设置项的值
        /// </summary>
        /// <param name="settings">表示设置的键值对</param>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        public static string GetDictionaryValue(Dictionary<string, string> settings, string key)
        {
            if (settings.ContainsKey(key))
            {
                string kkk = settings[key];
                return settings[key];
            }
            return "";
        }

        /// <summary>
        /// 获取指定设置项的值的布尔型格式
        /// </summary>
        /// <param name="settings">表示设置的键值对</param>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        public static bool GetDictionaryBooleanVal(Dictionary<string, string> settings, string key)
        {
            if (settings.ContainsKey(key))
            {
                string val = settings[key];
                bool result;
                if (Boolean.TryParse(val, out result))
                {
                    return result;
                }
                return false;
            }
            return false;
        }

        /// <summary>
        /// 获取指定设置项的值的数字型格式
        /// </summary>
        /// <param name="settings">表示设置的键值对</param>
        /// <param name="key">键</param>
        /// <returns>数字类型的值</returns>
        public static decimal GetDictionaryDecimalVal(Dictionary<string, string> settings, string key)
        {
            if (settings.ContainsKey(key))
            {
                string val = settings[key];
                decimal result;
                if (Decimal.TryParse(val, out result))
                {
                    return result;
                }
                return 0;
            }
            return 0;
        }

        /// <summary>
        /// 获取指定设置项的值的时间日期格式
        /// </summary>
        /// <param name="settings">表示设置的键值对</param>
        /// <param name="key">键</param>
        /// <returns>值的时间日期格式</returns>
        public static DateTime GetDictionaryDateTimeVal(Dictionary<string, string> settings, string key)
        {
            if (settings.ContainsKey(key))
            {
                string val = settings[key];
                DateTime result;
                if (DateTime.TryParse(val, out result))
                {
                    return result;
                }
                return DateTime.Now;
            }
            return DateTime.Now;
        }

        /// <summary>
        /// 获取显示布尔值测试结果的文本
        /// </summary>
        /// <param name="result">测试结果</param>
        /// <returns>用于显示的文本</returns>
        public static string BooleanResultToString(bool result)
        {
            return result ? "通过" : "失败";
        }

        /// <summary>
        /// 将字符串转换为布尔型
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns>布尔型值</returns>
        public static bool ConvertToBoolean(string value)
        {
            bool convertedValue;
            if (String.IsNullOrWhiteSpace(value))
                return false;
            if (!Boolean.TryParse(value, out convertedValue))
                return false;
            return convertedValue;
        }
        #endregion

     
        /// <summary>
        /// 本来将UI逻辑写在公共类里面不符合模块化松耦合的设计理念，但巡检和手动的检测的功能是一样的，涉及到对UI的操作，
        /// 还是需要UI逻辑。所以采用灵活的方式将检测的操作封装到公共类里面，作为一个组件单元供检测和巡检调用，
        /// 可以统一维护。实现了检测逻辑的统一性与通用性、模块化。因为涉及到UI的交互，
        /// 但控件是作为窗体的保护成员出现的，而交互的控件相对固定且数量可以接受，所以将控件作为参数传入方法
        /// </summary>
        /// <param name="label">描述当前操作的Label</param>
        /// <param name="textBox">进度详细信息</param>
        /// <param name="progressBar">进度条</param>
        public static void Test(Label label, TextBox textBox, ProgressBar progressBar, params NotifyIcon[] notifyIcon)
        {
            List<ErrorlistAll> errorList = new List<ErrorlistAll>();
            List<ErrorLogList> repeatErrorList = new List<ErrorLogList>();
            List<ErrorLogList> whiteErrorList = new List<ErrorLogList>();
            List<ErrorLogList> DPIErrorList = new List<ErrorLogList>();
            List<ErrorLogList> ItalicErrorList = new List<ErrorLogList>();
            List<ErrorLogList> paperdis = new List<ErrorLogList>();
            string errorPath = "";

            if (notifyIcon.Length > 0)
                notifyIcon[0].ShowBalloonTip(10000);
            Dictionary<string, string> settings = UIUtil.ReadSettings();
            string folder = UIUtil.GetDictionaryValue(settings, "Folder"), fileName;

            label.Text = "检测中...";
            label.Refresh();

            textBox.Text = "开始检测";
            textBox.Refresh();
            progressBar.Value = 0;
            
            progressBar.Refresh();
            string str = progressBar.Value.ToString() + "%";
            progressBar.Value =0;
            Dictionary<string, object> testResult = Index.TestResult;
            testResult.Clear();
            Index.TestResultStr = "";
            //空白页检测
            bool whiteTest = UIUtil.GetDictionaryBooleanVal(settings, "ValidateWhite");
            //重复文件检测
            bool repeatTest = UIUtil.GetDictionaryBooleanVal(settings, "ValidateRepeat");
            //重复文件（MD5）检测
            bool repeatMD5Test = UIUtil.GetDictionaryBooleanVal(settings, "ValidateRepeatMD5");
            //挂接检测
            bool hookTest = UIUtil.GetDictionaryBooleanVal(settings, "ValidateHook");
            //条目检测
            bool directoriesTest = UIUtil.GetDictionaryBooleanVal(settings, "ValidateDirectories");
            //DPI检测
            bool DPITest = UIUtil.GetDictionaryBooleanVal(settings, "ValidateDPI");
            //倾斜度检测
            bool ItalicTest = UIUtil.GetDictionaryBooleanVal(settings, "ValidateItalic");
            //图幅检测
            bool boolTufu = UIUtil.GetDictionaryBooleanVal(settings,"tufu");

            decimal DPI, Italic;
            decimal whitePercent = 0;
            if (whiteTest)
            {
                whitePercent = UIUtil.GetDictionaryDecimalVal(settings, "WhitePercent");
            }
            bool result, whiteResult, repeatResult, repeatMD5Result, DPIResult, ItalicResult;
            if (!String.IsNullOrWhiteSpace(folder) && Directory.Exists(folder))
            {
                List<string> repeatFiles = new List<string>();
                List<string> repeatFilesMD5 = new List<string>();
                List<FileInfo> repeatTestedFiles = new List<FileInfo>();
                List<FileInfo> repeatMD5TestedFiles = new List<FileInfo>();
                DirectoryInfo directoryInfo = new DirectoryInfo(folder);
                DirectoryInfo[] archiveDis = directoryInfo.GetDirectories();
                FileInfo[] fileInfos;
                FileInfo fileInfo;
                int count = 0, passedCount = 0, failCount = 0, nullpage = 0, dpitestpage = 0, italicpage = 0, archiveCount = archiveDis.Length, length,counts=0,AFei=0,AZero=0,AOne=0,ATwo=0,AThree=0,AFour=0, i, j;//archiceCount文件夹数量
                double PassRateNum = 1;
                long passedLength = 0, failLength = 0;
                int a = 0;//子文件总数的参数
                int b = 0;//进度条参数
               
                System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(folder);
                counts = GetFilesCount(dirInfo);
                ///

                for (i = 0; i < archiveCount; i++)
                {
                    textBox.Text += "\r\n\r\n检测文件夹：\"" + archiveDis[i].Name + "\"";
                    textBox.Refresh();
                    fileInfos = archiveDis[i].GetFiles();
                    length = fileInfos.Length;//子文件见图片数量
                    count += length;
                    for (j = 0; j < length; j++)
                    {
                        b = b + 1;
                        progressBar.Value = ((b *100/ counts)) %100;
                        progressBar.Refresh();
                        fileInfo = fileInfos[j];
                        fileName = fileInfo.Name;
                        if (fileName != "Thumbs.db")
                        {
                            textBox.Text += "\r\n检测文件：\"" + fileName + "\"";
                            textBox.Refresh();
                            result = true;
                            //空白页检测
                            if (whiteTest)
                            {
                                textBox.Text += "\r\n空白页检测";
                                textBox.Refresh();
                                whiteResult = Tests.WhiteTest(fileInfo, Convert.ToDouble(whitePercent));
                                result = result && whiteResult;
                                textBox.Text += "\t" + UIUtil.BooleanResultToString(whiteResult);
                                if (!whiteResult)
                                {
                                    errorPath += "空白页检测失败，路径：" + fileInfo.FullName + "\r\n";

                                    ErrorLogList errorLogList = new ErrorLogList
                                    {
                                        ErrorPath = fileInfo.FullName,
                                        ErrorType = "空白页",
                                        Status = "待解决"
                                    };
                                    whiteErrorList.Add(errorLogList);

                                    nullpage++;
                                }
                            }
                          
                            //重复文件检测
                            if (repeatTest)
                            {
                                textBox.Text += "\r\n重复性检测";
                                textBox.Refresh();
                                repeatResult = true;
                                foreach (FileInfo compareFile in repeatTestedFiles)
                                {
                                    repeatResult = repeatResult && Tests.RepeatTest(compareFile, fileInfo);
                                }
                                if (!repeatResult)
                                {
                                    repeatFiles.Add(fileInfo.Name);
                                    errorPath += "重复性检测失败，路径：" + fileInfo.FullName + "\r\n";

                                    ErrorLogList errorLogList = new ErrorLogList
                                    {
                                        ErrorPath = fileInfo.FullName,
                                        ErrorType = "重复文件",
                                        Status = "待解决"
                                    };

                                    repeatErrorList.Add(errorLogList);
                                }
                                result = result && repeatResult;
                                textBox.Text += "\t" + UIUtil.BooleanResultToString(repeatResult);

                                repeatTestedFiles.Add(fileInfo);
                            }
                             //重复文件检测（MD5）
                            if (repeatMD5Test)
                            {
                                textBox.Text += "\r\n重复性检测";
                                textBox.Refresh();
                                repeatMD5Result = true;
                                foreach (FileInfo compareFile in repeatMD5TestedFiles)
                                {
                                    repeatMD5Result = repeatMD5Result && Tests.RepeatTestMD5(compareFile, fileInfo);
                                }
                                if (!repeatMD5Result)
                                {
                                    repeatFilesMD5.Add(fileInfo.Name);
                                    errorPath += "重复性检测失败，路径：" + fileInfo.FullName + "\r\n";

                                    ErrorLogList errorLogList = new ErrorLogList
                                    {
                                        ErrorPath = fileInfo.FullName,
                                        ErrorType = "重复文件",
                                        Status = "待解决"
                                    };
                                    repeatErrorList.Add(errorLogList);
                                }
                                result = result && repeatMD5Result;
                                textBox.Text += "\t" + UIUtil.BooleanResultToString(repeatMD5Result);

                                repeatMD5TestedFiles.Add(fileInfo);
                            }
                            //DPI检测
                            if (DPITest)
                            {
                                DPI = UIUtil.GetDictionaryDecimalVal(settings, "DPI");
                                textBox.Text += "\r\nDPI检测";
                                textBox.Refresh();
                                DPIResult = Tests.ItalicTests(fileInfo, Convert.ToInt32(DPI));
                                result = result && DPIResult;
                                textBox.Text += "\t" + UIUtil.BooleanResultToString(DPIResult);
                                if (!DPIResult)
                                {
                                    errorPath += "DPI低于" + DPI + "，路径：" + fileInfo.FullName + "\r\n";

                                    ErrorLogList errorLogList = new ErrorLogList
                                    {
                                        ErrorPath = fileInfo.FullName,
                                        ErrorType = "DPI",
                                        Status = "待解决"
                                    };
                                    DPIErrorList.Add(errorLogList);

                                    dpitestpage++;
                                }
                            }
                            //图幅检测
                            if (boolTufu)
                            {
                                textBox.Text += "\r\n图幅检测";
                                textBox.Refresh();
                               string  papers = Tests.Azhi(fileInfo.FullName);
                                textBox.Text += "\t"+papers;
                                if (papers== "不是A纸规格"|| papers == "图片异常")
                                {
                                    errorPath += "不是A纸规格，路径：" + fileInfo.FullName + "\r\n";
                                    ErrorLogList errorLogList = new ErrorLogList
                                    {
                                        ErrorPath = fileInfo.FullName,
                                        ErrorType = "A纸规格",
                                        Status = "待解决"
                                    };
                                    paperdis.Add(errorLogList);
                                    AFei++;
                                }
                                if (papers == "A0")
                                    AZero++;
                                if (papers == "A1")
                                    AOne++;
                                if (papers == "A2")
                                    ATwo++;
                                if (papers == "A3")
                                    AThree++;
                                if (papers == "A4")
                                    AFour++;
                            }
                            //倾斜度检测
                            if (ItalicTest)
                            {
                                Italic = UIUtil.GetDictionaryDecimalVal(settings, "ItalicDegree");
                                textBox.Text += "\r\n图像倾斜度检测";
                                textBox.Refresh();

                                ItalicResult = Tests.ItalicTests(fileInfo, Convert.ToInt32(Italic));
                                result = result && ItalicResult;
                                textBox.Text += "\t" + UIUtil.BooleanResultToString(ItalicResult);
                                if (!ItalicResult)
                                {
                                    errorPath += "图像倾斜度大于" + Italic + "，路径：" + fileInfo.FullName + "\r\n";

                                    ErrorLogList errorLogList = new ErrorLogList
                                    {
                                        ErrorPath = fileInfo.FullName,
                                        ErrorType = "倾斜度",
                                        Status = "待解决"
                                    };
                                    ItalicErrorList.Add(errorLogList);

                                    italicpage++;
                                }
                            }
                            //返回结果
                            if (result)
                            {
                                passedCount++;
                                passedLength += fileInfo.Length;
                            }
                            else
                            {
                                failCount++;
                                failLength += fileInfo.Length;
                            }
                        }
                        else
                        {
                            count--;
                        }
                    }
                }
                //检测结果
                 testResult.Add("Count", count);
                testResult.Add("PassedCount", passedCount);
                testResult.Add("FailCount", failCount);
                testResult.Add("Length", passedLength + failLength);
                testResult.Add("PassedLength", passedLength);
                testResult.Add("FailLength", failLength);
               
                PassRateNum = (Convert.ToDouble(count)  - Convert.ToDouble(failCount)) / Convert.ToDouble(count);
                //string.Format("{0:#.00%}", PassRateNum);
                PassRate = string.Format("{0:#.00%}", PassRateNum);
                ErrorlistAll errorlistAll = new ErrorlistAll
                {
                    TestCount = count,
                    ErrorCount = failCount,
                    PassedCount = passedCount,
                    PassedRate = PassRate
                };
                errorList.Add(errorlistAll);
                if (whiteTest)
                {
                    testResult.Add("nullpagenum", nullpage);
                }
                if (repeatTest)
                {
                    testResult.Add("RepeatFiles", repeatFiles);
                }
                if (repeatMD5Test)
                {
                    testResult.Add("RepeatFilesMD5", repeatFilesMD5);
                }
                if (DPITest)
                {
                    testResult.Add("DpiNum", dpitestpage);
                }
                if (ItalicTest)
                {
                    testResult.Add("ItalicNum", italicpage);
                }
                if (boolTufu)
                {
                    testResult.Add("afei", AFei);
                    testResult.Add("azero", AZero);
                    testResult.Add("aone", AOne);
                    testResult.Add("atwo", ATwo);
                    testResult.Add("athree", AThree);
                    testResult.Add("afour", AFour);
                }
                //缺少页数
                if (hookTest)
                {
                    string hookDirectoriesFile = UIUtil.GetDictionaryValue(settings, "HookDirectoriesFile");
                    decimal hookSheet = UIUtil.GetDictionaryDecimalVal(settings, "HookSheet");
                    decimal archiveIdField = UIUtil.GetDictionaryDecimalVal(settings, "ArchiveIdField");
                    decimal pageField = UIUtil.GetDictionaryDecimalVal(settings, "PageField");
                    if (!String.IsNullOrWhiteSpace(hookDirectoriesFile) && File.Exists(hookDirectoriesFile) && hookSheet >= 0 && pageField >= 0)
                    {
                        textBox.Text += "\r\n挂接缺漏页检测";
                        textBox.Refresh();
                        try
                        {
                            Dictionary<string, List<int>> archiveShortOfPages = Tests.ShortOfPagesTest(folder, hookDirectoriesFile, Convert.ToInt32(hookSheet), Convert.ToInt32(archiveIdField), Convert.ToInt32(pageField));
                            List<int> shortOfPages;
                            foreach (string archiveId in archiveShortOfPages.Keys)
                            {
                                shortOfPages = archiveShortOfPages[archiveId];
                                if (shortOfPages != null && shortOfPages.Count > 0)
                                {
                                    textBox.Text += "\r\n档号为" + archiveId + "的案卷缺少第";
                                    for (int k = 0; k < shortOfPages.Count; k++)
                                    {
                                        textBox.Text += shortOfPages[k] + ",";
                                    }
                                    textBox.Text = textBox.Text.TrimEnd(',') + "页";
                                    textBox.Refresh();
                                }
                            }
                            testResult.Add("ShortOfPages", archiveShortOfPages);
                        }
                        catch (IOException exp)
                        {
                            MessageBox.Show("您已打开了挂接条目Excel文件，系统无法访问，请关闭后重试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        textBox.Text += "\r\n已选择挂接检测，但设置不正确，已跳过挂接检测";
                        textBox.Refresh();
                    }
                }
                if (failCount > 0)
                {
                    IndexWindow.erroNum++;
                }
            }
            else
            {
                textBox.Text += "\r\n未选择检测文件夹或检测文件夹不存在，已跳过文件检测！";
                textBox.Refresh();
            }

            if (directoriesTest)
            {
                string directoriesFile = UIUtil.GetDictionaryValue(settings, "DirectoriesFile");
                decimal directoriesSheet = UIUtil.GetDictionaryDecimalVal(settings, "DirectoriesSheet");
                Dictionary<string, string> filerule = new Dictionary<string, string>();
                Dictionary<string, string> orderrule = new Dictionary<string, string>();
                foreach (string item in settings.Keys)
                {
                    if (item.StartsWith("FieldRule_"))
                    {
                        string sFieldIndex = item.Replace("FieldRule_", "");
                        string rulesetting = settings[item];
                        filerule.Add(item, rulesetting);
                    }
                }
                if (!String.IsNullOrWhiteSpace(directoriesFile) && File.Exists(directoriesFile) && directoriesSheet >= 0)
                {
                    textBox.Text += "\r\n条目检测";
                    textBox.Refresh();
                    try
                    {
                        Dictionary<string, Dictionary<string, Dictionary<string, string>>> directoriesErrors = Tests.DirectoriesTest(directoriesFile, Convert.ToInt32(directoriesSheet), filerule, orderrule);
                        Dictionary<string, Dictionary<string, string>> directoryErrors;
                        Dictionary<string, string> fieldErrors;
                        object error;
                        foreach (string rowIndex in directoriesErrors.Keys)
                        {
                            directoryErrors = directoriesErrors[rowIndex];
                            if (directoryErrors != null && directoryErrors.Count > 0)
                            {
                                if (rowIndex != "排序检测")
                                {
                                    textBox.Text += "\r\n第" + rowIndex + "行条目错误：";
                                }
                                else
                                {
                                    textBox.Text += "\r\n排序检测：";
                                }
                                textBox.Refresh();
                                //foreach (int field in directoryErrors.Keys)
                                //{
                                //    fieldErrors = directoryErrors[field];
                                //    if (fieldErrors != null && fieldErrors.Count > 0)
                                //    {
                                //        textBox.Text += "\r\n第" + (field + 1) + "列：";
                                //        textBox.Refresh();
                                //        foreach (string rule in fieldErrors.Keys)
                                //        {
                                //            error = fieldErrors[rule];
                                //            if (error != null)
                                //                textBox.Text += "[" + rule + ":" + error + "];";
                                //        }
                                //        textBox.Text = textBox.Text.TrimEnd(';');
                                //        textBox.Refresh();
                                //    }
                                //}
                            }
                        }
                        testResult.Add("DirectoriesErrors", directoriesErrors);
                    }
                    catch (IOException exp)
                    {
                        MessageBox.Show("您已打开了需要检测的条目Excel文件，系统无法访问，请关闭后重试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    textBox.Text += "\r\n已选择条目检测，但设置不正确，已跳过条目检测";
                    textBox.Refresh();
                }
            }

            progressBar.Value = 100;
            progressBar.Refresh();

            textBox.Text += "\r\n检测结束";
            textBox.Refresh();

            Index.TestResultStr = textBox.Text;
            label.Text = "检测完成！";

            CommonSettings.loads();
            ResultUserControl.ins();


            //打印报表文件
            //logpaths = WriteLogs(CommonSettings.LogsPath, Index.TestResults + "\r\n\r\n详细日志：\r\n" + errorPath + "\r\n");

            logpaths = Logs(CommonSettings.LogsPath, errorList,repeatErrorList,whiteErrorList,DPIErrorList,ItalicErrorList,paperdis);

            label.Refresh();
            IndexWindow.testNum++;
        }
        /// <summary>
        /// ////递归文件夹子文件数量
        /// </summary>
        /// <param name="dirInfo"></param>
        /// <returns></returns>
        public static int GetFilesCount(DirectoryInfo dirInfo)
        {

            int totalFile = 0;
            //totalFile += dirInfo.GetFiles().Length;//获取全部文件
            totalFile += dirInfo.GetFiles("*.*").Length;//获取某种格式
            foreach (System.IO.DirectoryInfo subdir in dirInfo.GetDirectories())
            {
                totalFile += GetFilesCount(subdir);
            }
            return totalFile;
        }
        public static void Test(object state)
        {
            ThreadParam threadParam = state as ThreadParam;
            Test(threadParam.label, threadParam.textBox, threadParam.progressBar,threadParam.notifyIcon);
        }

        public static TimeSpan GetTestDueTime()
        {
            Dictionary<string, string> settings = ReadSettings();
            DateTime settedTime = GetDictionaryDateTimeVal(settings, "IntervalTime");
            int hour = settedTime.Hour;
            int minute = settedTime.Minute;
            int second = settedTime.Second;
            DateTime now = DateTime.Now;
            TimeSpan timeOfDay = now.TimeOfDay;
            TimeSpan tickTime = new TimeSpan(hour, minute, second);
            TimeSpan duetime;
            if (timeOfDay > tickTime)
            {
                DateTime tomorrow = new DateTime(now.Year, now.Month, now.Day, hour, minute, second);
                tomorrow = tomorrow.AddDays(1);
                duetime = tomorrow - now;
            }
            else
            {
                duetime = tickTime - timeOfDay;
            }
            return duetime;
        }

        /// <summary>
        /// 生成报表文件
        /// </summary>
        /// <param name="logpath">报表路径</param>
        /// <param name="log">报表内容</param>
        public static string WriteLogs(string logpath, string log)
        {
            string _Date = DateTime.Now.ToString("yyyy-MM-dd-hh-mm");
            Spire.Pdf.PdfDocument document = new Spire.Pdf.PdfDocument();

            PdfUnitConvertor unitCvtr = new PdfUnitConvertor();
            PdfMargins margins = new PdfMargins();
            PdfPageBase page = document.Pages.Add(PdfPageSize.A3, margins);

            PdfTrueTypeFont TitleFont = new PdfTrueTypeFont(new Font("宋体", 30f), true);

            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("宋体", 14f), true);
            PdfPen pen = new PdfPen(Color.Black);

            string text = log
                            + "\r\n\r\n" +
                           "检测时间：" + DateTime.Now;
            page.Canvas.DrawString("检测报告", TitleFont, pen, 350, 10);
            page.Canvas.DrawString(text, font, pen, 100, 50);

            string path = logpath + "\\" + _Date + ".pdf";

            document.SaveToFile(path);
            return path;
        }

        /// <summary>
        /// 生成Excel报表
        /// </summary>
        /// <param name="logpath">报表路径</param>
        /// <param name="logs">报表内容</param>
        /// <param name="Pass">通过率</param>
        /// <param name="repeatErrorList">重复文件</param>
        /// <param name="whiteErrorList">空白文件</param>
        /// <param name="DPIErrorList">DPI检测不通过</param>
        /// <param name="ItalicErrorList">倾斜度检测不通过</param>
        /// <returns></returns>
        private static string Logs(string logpath, List<ErrorlistAll> logs, List<ErrorLogList> repeatErrorList, List<ErrorLogList> whiteErrorList, List<ErrorLogList> DPIErrorList, List<ErrorLogList> ItalicErrorList,List<ErrorLogList> paperdiss)
        {

            string _Date = DateTime.Now.ToString("yyyy-MM-dd-hh-mm");
          
            string path = logpath + "\\" + _Date + ".xls";
            List<ErrorlistAll> errorLogLists = logs;

            //创建工作薄
            IWorkbook myHSSFworkbook = new HSSFWorkbook();

            ICellStyle style1 = myHSSFworkbook.CreateCellStyle();//样式
            style1.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;//文字水平对齐方式
            style1.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;//文字垂直对齐方式

            //创建一个表单
            ISheet sheet = myHSSFworkbook.CreateSheet("错误汇总");
            ISheet repeatSheet = myHSSFworkbook.CreateSheet("重复文件");
            ISheet whiteSheet = myHSSFworkbook.CreateSheet("空白页");
            ISheet DPISheet = myHSSFworkbook.CreateSheet("DPI不达标");
            ISheet ItalicSheet = myHSSFworkbook.CreateSheet("倾斜度不达标");
            ISheet Paperlabel = myHSSFworkbook.CreateSheet("图幅检测");

            //设置列宽
            int[] columnWidth = { 10, 10, 65, 10};
            for (int i = 0; i < columnWidth.Length; i++)
            {
                //设置列宽度，256*字符数，因为单位是1/256个字符
                repeatSheet.SetColumnWidth(i, 256 * columnWidth[i]);
                whiteSheet.SetColumnWidth(i, 256 * columnWidth[i]);
                DPISheet.SetColumnWidth(i, 256 * columnWidth[i]);
                ItalicSheet.SetColumnWidth(i, 256 * columnWidth[i]);
                Paperlabel.SetColumnWidth(i,256*columnWidth[i]);
            }

            IRow rowHSSF = sheet.CreateRow(0);
            rowHSSF.CreateCell(0).SetCellValue("检测文件数量");
            rowHSSF.CreateCell(1).SetCellValue("通过数量");
            rowHSSF.CreateCell(2).SetCellValue("失败数量");
            rowHSSF.CreateCell(3).SetCellValue("通过率");

            IRow repeatErrorRow = repeatSheet.CreateRow(0);
            repeatErrorRow.CreateCell(1).SetCellValue("错误类型");
            repeatErrorRow.CreateCell(2).SetCellValue("错误路径");
            repeatErrorRow.CreateCell(3).SetCellValue("解决情况");

            IRow whiteErrorRow = whiteSheet.CreateRow(0);
            whiteErrorRow.CreateCell(1).SetCellValue("错误类型");
            whiteErrorRow.CreateCell(2).SetCellValue("错误路径");
            whiteErrorRow.CreateCell(3).SetCellValue("解决情况");

            IRow DPIErrorRow = DPISheet.CreateRow(0);
            DPIErrorRow.CreateCell(1).SetCellValue("错误类型");
            DPIErrorRow.CreateCell(2).SetCellValue("错误路径");
            DPIErrorRow.CreateCell(3).SetCellValue("解决情况");

            IRow paperlabelRow = Paperlabel.CreateRow(0);
            paperlabelRow.CreateCell(1).SetCellValue("错误类型");
            paperlabelRow.CreateCell(2).SetCellValue("错误路径");
            paperlabelRow.CreateCell(3).SetCellValue("解决情况");

            IRow ItalicErrorRow = ItalicSheet.CreateRow(0);
            ItalicErrorRow.CreateCell(1).SetCellValue("错误类型");
            ItalicErrorRow.CreateCell(2).SetCellValue("错误路径");
            ItalicErrorRow.CreateCell(3).SetCellValue("解决情况");

            for (int i = 0; i < errorLogLists.Count; i++)
            {
                rowHSSF = sheet.CreateRow(i+1);
                rowHSSF.CreateCell(0).SetCellValue(errorLogLists[i].TestCount);
                rowHSSF.CreateCell(1).SetCellValue(errorLogLists[i].PassedCount); 
                rowHSSF.CreateCell(2).SetCellValue(errorLogLists[i].ErrorCount);
                rowHSSF.CreateCell(3).SetCellValue(errorLogLists[i].PassedRate);
            }
            //重复
            for (int i = 0; i < repeatErrorList.Count; i++)
            {
                repeatErrorRow = repeatSheet.CreateRow(i + 1);
                repeatErrorRow.CreateCell(1).SetCellValue(repeatErrorList[i].ErrorType);
                repeatErrorRow.CreateCell(2).SetCellValue(repeatErrorList[i].ErrorPath);
                repeatErrorRow.CreateCell(3).SetCellValue(repeatErrorList[i].Status);
            }
            //图幅
            for (int i=0;i<paperdiss.Count;i++)
            {
                paperlabelRow = Paperlabel.CreateRow(i + 1);
                paperlabelRow.CreateCell(1).SetCellValue(paperdiss[i].ErrorType);
                paperlabelRow.CreateCell(2).SetCellValue(paperdiss[i].ErrorPath);
                paperlabelRow.CreateCell(3).SetCellValue(paperdiss[i].Status);
            }
            //空白
            for (int i = 0; i < whiteErrorList.Count; i++)
            {
                whiteErrorRow = whiteSheet.CreateRow(i + 1);
                whiteErrorRow.CreateCell(1).SetCellValue(whiteErrorList[i].ErrorType);
                whiteErrorRow.CreateCell(2).SetCellValue(whiteErrorList[i].ErrorPath);
                whiteErrorRow.CreateCell(3).SetCellValue(whiteErrorList[i].Status);
            }
            //DPI
            for (int i = 0; i < DPIErrorList.Count; i++)
            {
                DPIErrorRow = DPISheet.CreateRow(i + 1);
                DPIErrorRow.CreateCell(1).SetCellValue(DPIErrorList[i].ErrorType);
                DPIErrorRow.CreateCell(2).SetCellValue(DPIErrorList[i].ErrorPath);
                DPIErrorRow.CreateCell(3).SetCellValue(DPIErrorList[i].Status);
            }
            //倾斜度
            for (int i = 0; i < ItalicErrorList.Count; i++)
            {
                ItalicErrorRow = ItalicSheet.CreateRow(i + 1);
                ItalicErrorRow.CreateCell(1).SetCellValue(ItalicErrorList[i].ErrorType);
                ItalicErrorRow.CreateCell(2).SetCellValue(ItalicErrorList[i].ErrorPath);
                ItalicErrorRow.CreateCell(3).SetCellValue(ItalicErrorList[i].Status);
            }
            try
            {
               
            }
            catch (Exception ex)
            {

            }
            FileStream fileHSSF = new FileStream(path, FileMode.Create);
            myHSSFworkbook.Write(fileHSSF);
            fileHSSF.Close();
            return path;
        }
    }
}
