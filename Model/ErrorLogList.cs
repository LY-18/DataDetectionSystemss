using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ErrorLogList
    {
        /// <summary>
        /// 错误类型
        /// </summary>
        public string ErrorType { get; set; }
        /// <summary>
        /// 错误地址
        /// </summary>
        public string ErrorPath { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }
        
    }
    public class ErrorlistAll
    {
        /// <summary>
        /// 检测数量
        /// </summary>
        public int TestCount { get; set; }
        /// <summary>
        /// 错误数量
        /// </summary>
        public int ErrorCount { get; set; }
        /// <summary>
        /// 通过数量
        /// </summary>
        public int PassedCount { get; set; }
        /// <summary>
        /// 通过率
        /// </summary>
        public string PassedRate { get; set; }
    }
}
