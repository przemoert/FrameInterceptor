using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communication
{
    public static class Validation
    {
        private static readonly char[] DOMAIN_RESTRICTED = { ' ', '!', '"', '#', '$', '%', '&', '\'', '(', ')', '*', '+', ',', '/', ':', ';', '<', '=', '>', '?', 
                                                            '@', '[', '\\', ']', '^', '_', '`', '{', '|', '}', '~', (char)0, (char)1, (char)2, (char)3, (char)4,
                                                            (char)5, (char)6, (char)7, (char)8, (char)9, (char)10, (char)11, (char)12, (char)13, (char)14, (char)15,
                                                            (char)16, (char)17, (char)18, (char)19, (char)20, (char)21, (char)22, (char)23, (char)24, (char)25, (char)26,
                                                            (char)27, (char)28, (char)29, (char)30, (char)31 };

        public static bool ValidateIp(string iIpAddress)
        {
            string[] parts = iIpAddress.Split('.');

            if (parts.Length != 4)
                return false;

            for (int i = 0; i < parts.Length; i++)
            {
                int output = -1;

                if (!Int32.TryParse(parts[i], out output))
                    return false;

                if (output < 0 || output > 255)
                    return false;
            }

            return true;
        }

        public static bool ValidateIp(byte[] bytes)
        {
            if (bytes.Length != 4)
                return false;

            for (int i = 0; i < bytes.Length; i++)
            {
                if (bytes[i] < 0 || bytes[i] > 255)
                    return false;
            }

            return true;
        }

        public static bool ValidatePort(int iPort)
        {
            return iPort >= 0 && iPort <= 65535;
        }

        public static bool ValidateDomain(string iDomain)
        {
            string l_Domain = iDomain;

            if (!l_Domain.Contains("."))
                return false;

            if (l_Domain.StartsWith(@"http://"))
                l_Domain = l_Domain.Remove(0, 7);

            if (l_Domain.StartsWith(@"https://"))
                l_Domain = l_Domain.Remove(0, 8);

            if (l_Domain.Length > 253)
                return false;

            if (DOMAIN_RESTRICTED.Any(e => l_Domain.Contains(e)))
                return false;


            string[] l_Parts = l_Domain.Split('.');

            if (l_Parts.Length > 127)
                return false;

            if (l_Parts.Any(e => e.StartsWith("-") || e.EndsWith("-")))
                return false;

            if (String.IsNullOrEmpty(l_Parts[l_Parts.Length - 1]))
                return false;

            return true;
        }
    }
}
