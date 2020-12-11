using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Util
{
    public class Format
    {
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
    }
}
