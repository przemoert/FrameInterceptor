using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameInterceptor.Utils
{
    public class Checksum
    {
        private string _frame;
        private byte[] _bytes;
        private string _frameChecksum;
        private string _calculatedChecksum;

        public Checksum(string iFrame)
        {
            if (String.IsNullOrEmpty(iFrame))
                throw new ArgumentNullException("iFrame");

            this._frame = iFrame;
            this._bytes = Settings.Instance.Encoding.GetBytes(this._frame);
        }

        public byte CheckSum8Mod256()
        {
            int l_Sum = 0;

            for (int i = 0; i < this._bytes.Length; i++)
            {
                l_Sum += this._bytes[i];
            }

            l_Sum %= 256;

            return (byte)l_Sum;
        }
    }
}
