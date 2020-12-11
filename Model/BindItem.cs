using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 绑定项，作为数据绑定非数据库数据源的数据项的数据类型
    /// </summary>
    public class BindItem
    {
        //显示文本字段
        private string text;
        //值字段，为避免与关键字value冲突，字段名采用value的简写
        private string val;

        public BindItem()
        {
            text = "";
            val = "";
        }

        public BindItem(string _text, string _value)
        {
            text = _text;
            val = _value;
        }

        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
            }
        }

        public string Value
        {
            get
            {
                return val;
            }
            set
            {
                val = value;
            }
        }
        //方案名集合
        public static List<string> PlanList = new List<string>();
    }
}
