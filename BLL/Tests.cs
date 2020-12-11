using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using NPOI.SS.UserModel;
using Util;
using System.Diagnostics;
using OpenCvSharp;

namespace BLL
{
    public class Tests
    {
        /// <summary>
        /// 空白页检测
        /// </summary>
        /// <param name="fileInfo">要检测的文件</param>
        /// <param name="percent">内容百分比</param>
        /// <returns>是否通过</returns>
        public static bool WhiteTest(FileInfo fileInfo, double percent)
        {
            try
            {
                Bitmap bmp = new Bitmap(fileInfo.FullName);
                Rectangle rct = new Rectangle(0, 0, bmp.Width, bmp.Height);
                BitmapData bmpData = bmp.LockBits(rct, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                IntPtr ptr = bmpData.Scan0;
                int height = Math.Abs(bmpData.Stride) * bmp.Height;
                int offset = Math.Abs(bmpData.Stride) - bmp.Width * 3;
                byte[] buffer = new byte[height];
                Marshal.Copy(ptr, buffer, 0, height);
                int whitepixel = 0;
                int x, y;
                for (y = 0; y < bmp.Height; y++)
                {
                    for (x = 0; x < bmp.Width * 3; x += 3)
                    {
                        if (buffer[y * Math.Abs(bmpData.Stride) + x] + buffer[y * Math.Abs(bmpData.Stride) + x + 1] + buffer[y * Math.Abs(bmpData.Stride) + x + 2] > 250 * 3)
                            whitepixel++;
                    }
                }
                bool result;
                if (whitepixel * 1.0 / (bmp.Height * bmp.Width) > (100 - percent) / 100)
                {
                    result = false;
                }
                else
                {
                    result = true;
                }
                bmp.Dispose();
                return result;
            }
            catch
            {
                return false;
            }
        }

       
        public static string Azhi(string fileInfo)
        {
            string paper="";
            try
            {
                Bitmap pic = new Bitmap(fileInfo);
                int width = pic.Size.Width;   // 图片的宽度
                int height = pic.Size.Height;   // 图片的高度
                System.Drawing.Image img = System.Drawing.Image.FromFile(fileInfo);//获取此图形的水平分辨率(即水平dpi)（以像素/英寸为单位）
                double dpiX = img.HorizontalResolution;//即水平dpi
                double dpiY = img.VerticalResolution;//垂直分辨率
                //A1 = 841 * 594
                float imwOne = (int)Math.Round((((float)84.1 / (float)2.54) * dpiX));
                float imhOne = (int)Math.Round((((float)59.4 / (float)2.54) * dpiY));
                //A2 = 594 * 420
                float imwTwo= (int)Math.Round((((float)59.4 / (float)2.54) * dpiX));
                float imhTwo = (int)Math.Round((((float)42.0 / (float)2.54) * dpiY));
                //A0 1189 * 841
                float imwZero = (int)Math.Round((((float)118.9 / (float)2.54) * dpiX));
                float imhZero = (int)Math.Round((((float)84.1 / (float)2.54) * dpiY));
                //A4 210mm×297mm
                float imwFour = (int)Math.Round((((float)21 / (float)2.54) * dpiX));
                float imhFour = (int)Math.Round((((float)29.7 / (float)2.54) * dpiY));
                //A3 297mm×420mm
                float imwThree = (int)Math.Round((((float)29.7 / (float)2.54) * dpiX));
                float imhThree = (int)Math.Round((((float)42 / (float)2.54) * dpiY));
                if (width > imwFour-5&&width< imwFour+5 && height> imhFour-5&&height< imhFour+5)
                    return paper = "A4";
                if (width> imwThree-5&&width<imwThree+5 && height> imhThree-5&&imwThree< imhThree+5)
                    return paper = "A3";
                if (width> imwZero-5&&imwZero< imwZero+5 && height> imhZero-5&&height< imhZero+5)
                    return paper = "A0";
                if (width> imwOne-5&&imwOne< imwOne+5 && height> imhOne-5&&imhOne< imhOne+5)
                    return paper = "A1";
                if (width> imwTwo-5&&imwTwo< imwTwo+5 && height> imhTwo-5&&height< imhTwo+5)
                    return paper = "A2";
                else
                    return paper = "不是A纸规格";
            }
            catch 
            {
                return paper = "图片异常";
            }
        }
        /// <summary>
        /// DPI检测
        /// </summary>
        /// <param name="fileInfo">检测文件</param>
        /// <param name="num">设定DPI的值</param>
        /// <returns>是否通过</returns>
        public static bool DPITest(FileInfo fileInfo, int num)
        {
            bool result = true;
            try
            {
                Image image = Image.FromFile(fileInfo.FullName);
                float dpiX = image.HorizontalResolution;
                float dpiY = image.VerticalResolution;
                float[] dpi = new float[] { dpiX, dpiY };
                foreach (var item in dpi)
                {
                    if (item < num)
                        result = false;
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        ///// <summary>
        ///// 图像倾斜度检测
        ///// </summary>
        ///// <param name="fileInfo">文件</param>
        ///// <param name="num">倾斜度</param>
        ///// <returns></returns>
        //public static bool ItalicTest(FileInfo fileInfo, int num)
        //{
        //    bool result = true;

        //    return result;
        //}
        public delegate void setOutputHandler(string output);
        public static bool ItalicTest(FileInfo fileInfo, int rotate)
        {
            bool result = true;
            Process process = new Process();
            process.StartInfo.FileName = "skew.exe";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardInput = true;

            process.StartInfo.Arguments = " " + fileInfo.FullName;

            process.OutputDataReceived += new DataReceivedEventHandler((object sendingProcess, DataReceivedEventArgs outLine) =>
            {
                double cr = 0;
                try
                {
                    cr = Double.Parse(outLine.Data);
                }
                catch (Exception)
                {

                }
                if (Math.Abs(cr) >= rotate)
                {
                    result = false;
                }
                //handler(outLine.Data);
            });
            process.Start();
            process.BeginOutputReadLine();
            process.WaitForExit();
            process.Close();

            return result;
        }

        /// <summary>
        /// 倾斜度检测（改进，速度）
        /// </summary>
        /// <param name="fileInfo">文件</param>
        /// <param name="rotate">检测度数</param>
        /// <returns></returns>
        public static bool ItalicTests(FileInfo fileInfo, int rotate)
        {

            bool result = true;
            Mat srcImage = Cv2.ImRead(fileInfo.FullName);

            double angle = 0.0;
            try
            {
                MyFindContours(srcImage, ref angle);
                if (angle >= rotate)
                    result = false;

            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
        public static Mat MyFindContours(Mat srcImage, ref double avg)
        {

            //转化为灰度图
            Mat src_gray = new Mat(),canny_Image = new Mat();
            Cv2.WaitKey();
            Cv2.CvtColor(srcImage, src_gray, ColorConversionCodes.RGB2GRAY);
            Cv2.Canny(src_gray, canny_Image, 50, 150, 3);
            //滤波
            //Cv2.Blur(src_gray, src_gray, new Size(3, 3));


            //# 霍夫变换
            // LineSegmentPoint[] linePiont = Cv2.HoughLines(edges, Cv2.PI, 1,, 0);
            //  double rotate_angle =0 ;
            LineSegmentPolar[] lines;
            double rhoBunkai = 1.0;
            double thetaBunkai = Math.PI / 180;
            // Mat edge = new Mat();
            lines = Cv2.HoughLines(canny_Image, rhoBunkai, thetaBunkai, 200);
            double sum = 0;
            double rotate_angle = 0;
            foreach (LineSegmentPolar lsp in lines)
            {
                double a = Math.Cos(lsp.Theta), b = Math.Sin(lsp.Theta);
                double x0 = a * lsp.Rho, y0 = b * lsp.Rho;
                double x1 = x0 + 1000 * (-b);
                double y1 = y0 + 1000 * a;
                double x2 = x0 + 1000 * b;
                double y2 = y0 - 1000 * a;



                if (x1 == x2 || y1 == y2)
                    continue;
                double t = (float)(y2 - y1) / (x2 - x1);

                rotate_angle = Math.Atan(t) * (180 / Math.PI);
                if (rotate_angle > 45)
                {
                    rotate_angle = -90 + rotate_angle;
                }
                else if (rotate_angle < -45)
                {
                    rotate_angle = 90 + rotate_angle;
                }
                sum += rotate_angle;
            }
            avg = sum / (double)lines.Length;

            return null;
        }


        /// <summary>
        /// 重复性检测
        /// </summary>
        /// <param name="compareFile">对比的文件</param>
        /// <param name="testFile">测试文件</param>
        /// <returns>是否通过</returns>
        public static bool RepeatTest(FileInfo compareFile, FileInfo testFile)
        {
            return !(compareFile.Length == testFile.Length && compareFile.CreationTime == testFile.CreationTime);
        }

        /// <summary>
        /// 重复性检测(MD5)
        /// </summary>
        /// <param name="compareFile">对比的文件</param>
        /// <param name="testFile">测试文件</param>
        /// <returns>是否通过</returns>
        public static bool RepeatTestMD5(FileInfo compareFile, FileInfo testFile)
        {
            bool result = true;
            if (compareFile.Exists && testFile.Exists)
            {
                FileStream compareFs = compareFile.OpenRead();
                FileStream testFs = testFile.OpenRead();
                long compareLength = compareFs.Length;
                long testLength = testFs.Length;
                byte[] compareCnt = new byte[compareLength];
                byte[] testCnt = new byte[testLength];
                compareFs.Read(compareCnt, 0, Convert.ToInt32(compareLength));
                testFs.Read(testCnt, 0, Convert.ToInt32(testLength));
                MD5 md5 = MD5.Create();
                byte[] compareHash = md5.ComputeHash(compareCnt);
                byte[] testHash = md5.ComputeHash(testCnt);
                StringBuilder compareSb = new StringBuilder();
                StringBuilder testSb = new StringBuilder();
                int i;
                for (i = 0; i < compareHash.Length; i++)
                {
                    compareSb.Append(compareHash[i].ToString("x2"));
                }
                for (i = 0; i < testHash.Length; i++)
                {
                    testSb.Append(testHash[i].ToString("x2"));
                }
                string sCompareHash = Convert.ToString(compareSb);
                string sTestHash = Convert.ToString(testSb);
                compareFs.Close();
                testFs.Close();
                return sCompareHash != sTestHash;
            }
            return result;
        }

        /// <summary>
        /// 挂接缺漏页检测
        /// </summary>
        /// <param name="folder">检测的文件夹</param>
        /// <param name="excel">条目Excel文件路径</param>
        /// <param name="sheetIndex">条目所在的工作簿</param>
        /// <param name="pageFieldIndex">页号所在的列编号</param>
        /// <param name="archiveIdIndex">档号所在的列编号</param>
        /// <returns>档号与缺漏页列表键值对</returns>
        public static Dictionary<string, List<int>> ShortOfPagesTest(string folder, string excel, int sheetIndex, int archiveIdIndex, int pageFieldIndex)
        {
            Dictionary<string, List<int>> archiveShortOfPages = new Dictionary<string, List<int>>();
            if (!String.IsNullOrWhiteSpace(folder) && Directory.Exists(folder)
                && !String.IsNullOrWhiteSpace(excel) && File.Exists(excel))
            {
                IWorkbook workbook = WorkbookFactory.Create(excel);
                if (sheetIndex >= 0 && workbook.NumberOfSheets > sheetIndex)
                {
                    ISheet sheet = workbook.GetSheetAt(sheetIndex);
                    IRow row;
                    ICell cell;
                    string archiveId, sPages;
                    double pages;
                    List<int> shortOfPages;
                    DirectoryInfo directoryInfo;
                    FileInfo[] fileInfos;
                    int length;
                    string path;
                    FileInfo firstFi;
                    string nameTemplate, ext, namePrefix, pageTemplate, name;
                    int i, j, nameSplitterIndex, pageStrLen;
                    for (i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
                    {
                        row = sheet.GetRow(i);
                        if (row != null)
                        {
                            if (pageFieldIndex >= row.FirstCellNum && pageFieldIndex < row.LastCellNum)
                            {
                                cell = row.GetCell(archiveIdIndex);
                                if (cell != null)
                                {
                                    try
                                    {
                                        archiveId = cell.StringCellValue;
                                    }
                                    catch
                                    {
                                        try
                                        {
                                            archiveId = cell.NumericCellValue.ToString();
                                        }
                                        catch
                                        {
                                            continue;
                                        }
                                    }
                                    cell = row.GetCell(pageFieldIndex);
                                    if (cell != null)
                                    {
                                        try
                                        {
                                            pages = cell.NumericCellValue;
                                        }
                                        catch
                                        {
                                            try
                                            {
                                                sPages = cell.StringCellValue;
                                                if (!Double.TryParse(sPages, out pages))
                                                    continue;
                                            }
                                            catch
                                            {
                                                archiveShortOfPages.Add(archiveId, null);
                                                continue;
                                            }
                                        }
                                        shortOfPages = new List<int>();
                                        if (pages > 0)
                                        {
                                            directoryInfo = new DirectoryInfo(folder + "\\" + archiveId);
                                            if (directoryInfo.Exists)
                                            {
                                                fileInfos = directoryInfo.GetFiles();
                                                length = fileInfos.Length;
                                                if (length == 0)
                                                {
                                                    ShortOfAll(pages, ref shortOfPages);
                                                }
                                                else if (length == 1 && fileInfos[0].Name == "Thumbs.db")
                                                {
                                                    ShortOfAll(pages, ref shortOfPages);
                                                }
                                                else
                                                {
                                                    firstFi = fileInfos[0];
                                                    nameTemplate = firstFi.Name;
                                                    ext = firstFi.Extension;
                                                    nameTemplate = nameTemplate.Substring(0, nameTemplate.LastIndexOf(ext));
                                                    nameSplitterIndex = nameTemplate.LastIndexOf("-") + 1;
                                                    namePrefix = nameTemplate.Substring(0, nameSplitterIndex);
                                                    pageTemplate = nameTemplate.Substring(nameSplitterIndex, nameTemplate.Length - nameSplitterIndex);
                                                    pageStrLen = pageTemplate.Length;
                                                    for (j = 1; j <= pages; j++)
                                                    {
                                                        name = namePrefix + j.ToString("D" + pageStrLen) + ext;
                                                        path = folder + "\\" + archiveId + "\\" + name;
                                                        if (!File.Exists(path))
                                                        {
                                                            shortOfPages.Add(j);
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                ShortOfAll(pages, ref shortOfPages);
                                            }
                                        }
                                        archiveShortOfPages.Add(archiveId, shortOfPages);
                                    }
                                }
                            }
                        }
                    }
                }
                workbook.Close();
            }
            return archiveShortOfPages;
        }

        /// <summary>
        /// 缺少全部页
        /// </summary>
        /// <param name="pages">要求的页数</param>
        /// <param name="shortOfPages">存放缺漏页集合的对象</param>
        private static void ShortOfAll(double pages, ref List<int> shortOfPages)
        {
            for (int i = 1; i <= pages; i++)
            {
                shortOfPages.Add(i);
            }
        }

        public static Dictionary<string, Dictionary<string, Dictionary<string, string>>> DirectoriesTest(string excel, int sheetIndex, Dictionary<string, string> fieldRules, Dictionary<string, string> orderRules)
        {
            Dictionary<string, Dictionary<string, Dictionary<string, string>>> directoriesErrors = new Dictionary<string, Dictionary<string, Dictionary<string, string>>>();
            IWorkbook workbook = WorkbookFactory.Create(excel);
            if (sheetIndex >= 0 && workbook.NumberOfSheets > sheetIndex)
            {
                ISheet sheet = workbook.GetSheetAt(sheetIndex);
                IRow row;
                ICell cell;
                Dictionary<string, Dictionary<string, string>> directoryErrors;
                Dictionary<string, string> fieldErrors;
                int i, fieldIndex;
                string field, sRules, ruleName, ruleValue;
                string[] rules, enumValues;
                bool required;
                object cellValue;
                string cellString;
                long lTemp;
                double dTemp;
                decimal decimalTmp;
                DateTime timeTemp;
                string lengthRule = "", constraintRule = "";
                int index, length, len;
                List<object> testedValues = new List<object>();
                for (i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
                {
                    row = sheet.GetRow(i);
                    directoryErrors = new Dictionary<string, Dictionary<string, string>>();
                    //按理来说，如果一行为空，所有的字段如果需要检查必填应该都不通过，但通常按照习惯，Excel如果一行为空，
                    //说明这是一个空行，并不是用来填写内容的，所以不检测
                    if (row != null)
                    {
                        foreach (string key in fieldRules.Keys)
                        {
                            if (key.StartsWith("FieldRule_"))
                            {
                                field = key.Replace("FieldRule_", "");
                                if (int.TryParse(field, out fieldIndex))
                                {
                                    fieldErrors = new Dictionary<string, string>();
                                    cell = row.GetCell(fieldIndex);
                                    sRules = fieldRules[key];
                                    rules = sRules.Split(';');
                                    foreach (string rule in rules)
                                    {
                                        index = rule.IndexOf("=");
                                        ruleName = rule.Substring(0, index);
                                        index++;
                                        ruleValue = rule.Substring(index, rule.Length - index);
                                        if (!String.IsNullOrWhiteSpace(ruleValue))
                                        {
                                            required = ruleName == "Required" && Format.ConvertToBoolean(ruleValue);
                                            if (cell == null)
                                            {
                                                if (required)
                                                {
                                                    fieldErrors.Add("Required", false.ToString());
                                                }
                                                break;
                                            }
                                            else
                                            {
                                                cellValue = GetCellValue(cell);
                                                if (cellValue == null)
                                                {
                                                    if (required)
                                                    {
                                                        fieldErrors.Add("Required", false.ToString());
                                                    }
                                                    break;
                                                }
                                                else
                                                {
                                                    cellString = cellValue as string;
                                                    if (String.IsNullOrWhiteSpace(cellString))
                                                    {
                                                        if (required)
                                                        {
                                                            fieldErrors.Add("Required", false.ToString());
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        switch (ruleName)
                                                        {
                                                            //必填前面已经检查过了，所以此处跳过
                                                            case "Required":
                                                                break;
                                                            case "Type":
                                                                switch (ruleValue)
                                                                {
                                                                    case "String":
                                                                        if (!(cellValue is string))
                                                                            fieldErrors.Add("Type", "IsNotType:String");
                                                                        break;
                                                                    case "Number":
                                                                        if (!long.TryParse(cellString, out lTemp) && !(Double.TryParse(cellString, out dTemp)) && !Decimal.TryParse(cellString, out decimalTmp))
                                                                            fieldErrors.Add("Type", "IsNotType:Number");
                                                                        break;
                                                                    case "DateTime":
                                                                        if (!DateTime.TryParse(cellString, out timeTemp))
                                                                            fieldErrors.Add("Type", "IsNotType:DateTime");
                                                                        break;
                                                                    default:
                                                                        break;
                                                                }
                                                                break;
                                                            case "LengthOperator":
                                                                lengthRule = ruleValue;
                                                                break;
                                                            case "Length":
                                                                if (!String.IsNullOrWhiteSpace(lengthRule) && int.TryParse(ruleValue, out length))
                                                                {
                                                                    len = cellString.Length;
                                                                    switch (lengthRule)
                                                                    {
                                                                        case "Equal":
                                                                            if (length != len)
                                                                                fieldErrors.Add("Length", "Equal:NotEqual" + length.ToString());
                                                                            break;
                                                                        case "Smaller":
                                                                            if (len >= length)
                                                                                fieldErrors.Add("Length", "Smaller:NotSmaller" + length.ToString());
                                                                            break;
                                                                        case "NotBigger":
                                                                            if (len > length)
                                                                                fieldErrors.Add("Length", "NotBigger:Bigger" + length.ToString());
                                                                            break;
                                                                        case "Bigger":
                                                                            if (len <= length)
                                                                                fieldErrors.Add("Length", "Bigger:NotBigger" + length.ToString());
                                                                            break;
                                                                        case "NotSmaller":
                                                                            if (len < length)
                                                                                fieldErrors.Add("Length", "NotSmaller:Smaller" + length.ToString());
                                                                            break;
                                                                        default:
                                                                            break;
                                                                    }
                                                                }
                                                                break;
                                                            case "Repeat":
                                                                if (Format.ConvertToBoolean(ruleValue))
                                                                {
                                                                    if (testedValues.Contains(cellValue))
                                                                    {
                                                                        fieldErrors.Add("Repeat", "Repeat:" + cellString + " With Line:" + (testedValues.IndexOf(cellValue) + 1));
                                                                    }
                                                                    testedValues.Add(cellValue);
                                                                }
                                                                break;
                                                            case "Rule":
                                                                constraintRule = ruleValue;
                                                                break;
                                                            case "RuleExpression":
                                                                if (!String.IsNullOrWhiteSpace(constraintRule))
                                                                {
                                                                    switch (constraintRule)
                                                                    {
                                                                        case "SaveTime":
                                                                            switch (cellString)
                                                                            {
                                                                                case "短期":
                                                                                    break;
                                                                                case "长期":
                                                                                    break;
                                                                                case "永久":
                                                                                    break;
                                                                                default:
                                                                                    if (!cellString.EndsWith("年"))
                                                                                        fieldErrors.Add("Rule", "SaveTime:" + cellString);
                                                                                    break;
                                                                            }
                                                                            break;
                                                                        case "SecurityLevel":
                                                                            switch (cellString)
                                                                            {
                                                                                case "公开":
                                                                                    break;
                                                                                case "秘密":
                                                                                    break;
                                                                                case "机密":
                                                                                    break;
                                                                                case "绝密":
                                                                                    break;
                                                                                default:
                                                                                    fieldErrors.Add("Rule", "SecurityLevel:" + cellString);
                                                                                    break;
                                                                            }
                                                                            break;
                                                                        case "Const":
                                                                            if (cellString != ruleValue)
                                                                                fieldErrors.Add("Rule", "Const:" + cellString + " NotEqualsWith " + ruleValue + "");
                                                                            break;
                                                                        case "Selectable":
                                                                            enumValues = ruleValue.Split(',');
                                                                            if (enumValues.Length > 0)
                                                                            {
                                                                                if (!enumValues.ToList<string>().Contains(cellString))
                                                                                    fieldErrors.Add("Rule", "Selectable:" + cellString + " NotInEnumValues(" + ruleValue + ")");
                                                                            }
                                                                            break;
                                                                        default: break;
                                                                    }
                                                                }
                                                                break;
                                                            default:
                                                                break;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    if (fieldErrors.Count > 0)
                                        directoryErrors.Add(field, fieldErrors);
                                }
                            }
                        }
                    }
                    if (directoryErrors.Count > 0)
                        directoriesErrors.Add((i + 1).ToString(), directoryErrors);
                }
                if (orderRules.Count > 0)
                {
                    string[] orderKeys = new string[orderRules.Count];
                    orderRules.Keys.CopyTo(orderKeys, 0);
                    for (i = orderRules.Count - 1; i >= 0; i--)
                    {
                        if (true)
                        {

                        }
                    }
                }
            }
            workbook.Close();
            return directoriesErrors;
        }

        /// <summary>
        /// 获取Excel单元格的值
        /// </summary>
        /// <param name="cell">单元格</param>
        /// <returns>值</returns>
        private static object GetCellValue(ICell cell)
        {
            object cellValue;
            try
            {
                cellValue = cell.StringCellValue;
            }
            catch
            {
                try
                {
                    cellValue = cell.NumericCellValue;
                }
                catch
                {
                    try
                    {
                        cellValue = cell.DateCellValue;
                    }
                    catch
                    {
                        try
                        {
                            cellValue = cell.BooleanCellValue;
                        }
                        catch
                        {
                            try
                            {
                                cellValue = cell.RichStringCellValue;
                            }
                            catch
                            {
                                cellValue = null;
                            }
                        }
                    }
                }
            }
            return cellValue;
        }
    }
}
