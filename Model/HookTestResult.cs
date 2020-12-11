using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class HookTestResult
    {
        public List<int> ShortOfPages;
        public List<string> HookUnmatchedDirectories;

        public HookTestResult()
        {
            ShortOfPages = null;
            HookUnmatchedDirectories = null;
        }
    }
}
