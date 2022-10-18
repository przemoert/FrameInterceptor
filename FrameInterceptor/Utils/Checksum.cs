using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameInterceptor.Frames;

namespace FrameInterceptor.Utils
{
    public class Checksum
    {
        private Frame _frame;
        private byte _checkSum8Mod256;
        private byte _checkSum8Xor;
        private byte _checkSum2sComp;

        public Checksum(Frame iFrame)
        {
            if (iFrame == null)
                throw new ArgumentNullException("iFrame");

            this._frame = iFrame;

            this._checkSum8Mod256 = this.CheckSum8Mod256();
            this._checkSum8Xor = this.CheckSum8Xor();
            this._checkSum2sComp = this.CheckSum2Comp();
        }

        private byte CheckSum8Mod256()
        {
            int l_Sum = 0;

            for (int i = 0; i < this._frame.Bytes.Length; i++)
            {
                l_Sum += this._frame.Bytes[i];
            }

            l_Sum %= 256;

            return (byte)l_Sum;
        }

        private byte CheckSum8Xor()
        {
            byte l_Sum = 0;

            for (int i = 0; i < this._frame.Bytes.Length; i++)
            {
                l_Sum ^= this._frame.Bytes[i];
            }

            return l_Sum;
        }

        private byte CheckSum2Comp()
        {
            long l_Sum = 0;

            for (int i = 0; i < this._frame.Bytes.Length; i++)
            {
                l_Sum = (l_Sum + this._frame.Bytes[i]) & 255;
            }

            return (byte)(256 - l_Sum);
        }

        public byte CheckSum8Mod256_Sum { get => this._checkSum8Mod256; }
        public string CheckSum8Mod256_Hex { get => this._checkSum8Mod256.ToString("X2"); }
        public byte CheckSum8Xor_Sum { get => this._checkSum8Xor; }
        public string CheckSum8Xor_Hex { get => this._checkSum8Xor.ToString("X2"); }
        public byte CheckSum2sComp_Sum { get => this._checkSum2sComp; }
        public string CheckSum2sComp_Hex { get => this._checkSum2sComp.ToString("X2"); }
    }
}
