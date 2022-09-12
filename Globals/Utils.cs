using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globals
{
    public static class Utils
    {
        public static bool IsValidIp(string iIpAddress)
        {
            if (String.IsNullOrEmpty(iIpAddress) || String.IsNullOrEmpty(iIpAddress))
                return false;

            if (iIpAddress.Count(e => e == '.') != 3)
                return false;

            string[] parts = iIpAddress.Split('.');

            for (int i = 0; i < parts.Length; i++)
            {
                if (!byte.TryParse(parts[i], out _))
                    return false;
            }

            return true;
        }

        public static string ConvertByteIpToString(byte[] iIpAddress)
        {
            string output = String.Empty;

            if (iIpAddress.Length == 4)
            {
                for (int i = 0; i < iIpAddress.Length; i++)
                    output += iIpAddress.ToString() + ".";

                output = output.Trim('.');
            }

            return output;
        }
    }
}
