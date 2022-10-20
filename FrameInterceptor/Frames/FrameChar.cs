using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameInterceptor.Frames
{
    public class FrameChar
    {
        public int Index { get; private set; }
        public byte Value { get; private set; }
        public byte[] ValueRange { get; private set; }


        public FrameChar (int iIndex, byte iValue)
        {
            this.Index = iIndex;
            this.Value = iValue;
        }

        public FrameChar (int iIndex, byte[] iValueRange)
        {
            if (iValueRange.Length % 2 != 0)
                throw new ArgumentOutOfRangeException("iValueRange");

            this.Index = iIndex;
            this.ValueRange = iValueRange;
        }

        public static bool operator ==(FrameChar c, Frame f)
        {
            if (c.Index >= f.Bytes.Length)
                return false;

            int l_Index = (c.Index < 0) ? f.Bytes.Length - 1 : c.Index;

            if (c.ValueRange == null)
            {
                return f.Bytes[l_Index] == c.Value;
            }
            else
            {
                for (int i = 0; i < c.ValueRange.Length; i += 2)
                {
                    if (f.Bytes[l_Index] >= c.ValueRange[i] && f.Bytes[l_Index] <= c.ValueRange[i + 1])
                        return true;
                }
            }

            return false;
        }

        public static bool operator !=(FrameChar c, Frame f) => !(c == f);
        public static bool operator ==(Frame f, FrameChar c) => (c == f);
        public static bool operator !=(Frame f, FrameChar c) => !(c == f);
    }
}
