using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameInterceptor.Frames;
using FrameInterceptor.Utils;

namespace FrameInterceptor.Astm
{
    class AstmFrame
    {
        private Frame _frame;
        private string _checkSumOfInput;
        private Checksum _internalCheckSum;
        private bool _recognizedCompleteFrame = false;
        private int _checkSumIndex1 = 0;
        private int _checkSumIndex2 = 0;

        public AstmFrame(Frame iFrame)
        {
            this._frame = iFrame;

            //this._checkSumOfInput = new Checksum(this._frame);
        }

        private void AnalyzeFrame()
        {

        }

        private bool IsFrameComplete()
        {
            if (this._frame.Bytes[0] != 2)
                return false;

            byte l_Prefix = 0;
            if (!Byte.TryParse(this._frame.Chars[1].ToString(), out l_Prefix))
                return false;

            if (l_Prefix > 7)
                return false;

            if (this._frame.Bytes[2] < 65 || this._frame.Bytes[2] > 90)
                return false;

            if (this._frame.Bytes[3] != 124)
                return false;

            bool l_Found = false;
            for (int i = 0; i < this._frame.Bytes.Length; i++)
            {
                if (this._frame.Bytes[i] == 124)
                    l_Found = true;
            }

            if (!l_Found)
                return false;

            int l_CRIndex = Array.IndexOf(this._frame.Bytes, 13);
            if (l_CRIndex < 0)
                return false;

            if (this._frame.Bytes.Length != l_CRIndex + 6)
                return false;

            if (this._frame.Bytes[l_CRIndex + 1] != 3)
                return false;

            if (this._frame.Bytes[l_CRIndex] + 4 != 13 || this._frame.Bytes[l_CRIndex + 5] != 10)
                return false;

            if (!(this._frame.Bytes[l_CRIndex + 2] >= 48 && this._frame.Bytes[l_CRIndex + 2] <= 57) || !(this._frame.Bytes[l_CRIndex + 2] >= 65 && this._frame.Bytes[l_CRIndex + 2] <= 70))
                return false;

            if (!(this._frame.Bytes[l_CRIndex + 3] >= 48 && this._frame.Bytes[l_CRIndex + 3] <= 57) || !(this._frame.Bytes[l_CRIndex + 3] >= 65 && this._frame.Bytes[l_CRIndex + 3] <= 70))
                return false;

            this._checkSumIndex1 = this._frame.Bytes[l_CRIndex + 2];
            this._checkSumIndex2 = this._frame.Bytes[l_CRIndex + 3];

            return true;
        }

        public bool RecognizedCompleteFrame { get => this._recognizedCompleteFrame; }
        public byte FrameCalculatedCheckSum { get => this._internalCheckSum.CheckSum8Mod256_Sum; }
        public string FrameCalculatedCheckSumHex { get => this._internalCheckSum.CheckSum8Mod256_Hex; }
    }
}
