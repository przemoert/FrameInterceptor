using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrameInterceptor.Utils
{
    public enum SenderObject
    {
        Button,
        Checkbox
    }

    public class TypeAreaEventArgs : EventArgs
    {
        public byte Code { get; private set; }
        public SenderObject SenderObject { get; private set; }

        public TypeAreaEventArgs(object iSender)
        {
            if (iSender is Button b)
            {
                this.SenderObject = SenderObject.Button;
                this.Code = this.GetCodeFromButton(b);
            }
        }

        private byte GetCodeFromButton(Button iButton)
        {
            switch (iButton.Name)
            {
                case "btnSOH":
                    return 1;
                case "btnSTX":
                    return 2;
                case "btnETX":
                    return 3;
                case "btnEOT":
                    return 4;
                case "btnENQ":
                    return 5;
                case "btnACK":
                    return 6;
                case "btnBEL":
                    return 7;
                case "btnBS":
                    return 8;
                case "btnHT":
                    return 9;
                case "btnLF":
                    return 10;
                case "btnVT":
                    return 11;
                case "btnFF":
                    return 12;
                case "btnCR":
                    return 13;
                case "btnSO":
                    return 14;
                case "btnSI":
                    return 15;
                case "btnDLE":
                    return 16;
                case "btnNAK":
                    return 21;
                case "btnSYN":
                    return 22;
                case "btnETB":
                    return 23;
                case "btnCAN":
                    return 24;
                case "btnEM":
                    return 25;
                case "btnSUB":
                    return 26;
                case "btnESC":
                    return 27;
                case "btnFS":
                    return 28;
                case "btnGS":
                    return 29;
                case "btnRS":
                    return 30;
                case "btnUS":
                    return 31;
                case "btnDEL":
                    return 127;
                default:
                    return 0;
            }
        }
    }
}
