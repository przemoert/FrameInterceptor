using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FrameInterceptor.Utils
{
    internal class SerialPortComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            Regex l_Regex = new Regex(@"\w(\d+)$");

            Match l_XResult = l_Regex.Match(x);
            Match l_YResult = l_Regex.Match(y);

            if (l_XResult.Success && l_YResult.Success)
                return Int32.Parse(l_XResult.Groups[1].Value).CompareTo(Int32.Parse(l_YResult.Groups[1].Value));

            return x.CompareTo(y);
        }
    }
}
