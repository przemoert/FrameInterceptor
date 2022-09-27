using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communication
{
    internal static class Validation
    {
        internal static bool ValidateIp(string iIpAddress)
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

        internal static bool ValidateIp(byte[] bytes)
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

        internal static bool ValidatePort(int iPort)
        {
            return iPort >= 0 && iPort <= 65535;
        }
    }
}
