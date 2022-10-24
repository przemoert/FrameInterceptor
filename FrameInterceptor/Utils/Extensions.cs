using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameInterceptor.Utils
{
    public static class Extensions
    {
        public static bool AnyOf<T>(this T iInput, params T[] iParams)
        {
            if (iInput == null)
                throw new ArgumentNullException("iInput");

            return iParams.Contains(iInput);
        }
    }
}
