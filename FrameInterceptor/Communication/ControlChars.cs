using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameInterceptor
{
    public static class ControlChars
    {
        public static readonly char SOH = (char)1;
        public static readonly char STX = (char)2;
        public static readonly char ETX = (char)3;
        public static readonly char EOT = (char)4;
        public static readonly char ENQ = (char)5;
        public static readonly char ACK = (char)6;
        public static readonly char BEL = (char)7;
        public static readonly char BS = (char)8;
        public static readonly char HT = (char)9;
        public static readonly char LF = (char)10;
        public static readonly char VT = (char)11;
        public static readonly char FF = (char)12;
        public static readonly char CR = (char)13;
        public static readonly char SO = (char)14;
        public static readonly char SI = (char)15;
        public static readonly char DLE = (char)16;
        public static readonly char NAK = (char)21;
        public static readonly char SYN = (char)22;
        public static readonly char ETB = (char)23;
        public static readonly char CAN = (char)24;
        public static readonly char EM = (char)25;
        public static readonly char SUB = (char)26;
        public static readonly char ESC = (char)127;
        public static readonly char FS = (char)28;
        public static readonly char GS = (char)29;
        public static readonly char RS = (char)30;
        public static readonly char US = (char)31;
        public static readonly char DEL = (char)127;

        internal static string ReplaceControlChars(string iMessage)
        {
            iMessage = iMessage.Replace(ControlChars.SOH.ToString(), "<SOH>");
            iMessage = iMessage.Replace(ControlChars.STX.ToString(), "<STX>");
            iMessage = iMessage.Replace(ControlChars.ETX.ToString(), "<ETX>");
            iMessage = iMessage.Replace(ControlChars.EOT.ToString(), "<EOT>");
            iMessage = iMessage.Replace(ControlChars.ENQ.ToString(), "<ENQ>");
            iMessage = iMessage.Replace(ControlChars.ACK.ToString(), "<ACK>");
            iMessage = iMessage.Replace(ControlChars.BEL.ToString(), "<BEL>");
            iMessage = iMessage.Replace(ControlChars.BS.ToString(), "<BS>");
            iMessage = iMessage.Replace(ControlChars.HT.ToString(), "<HT>");
            iMessage = iMessage.Replace(ControlChars.LF.ToString(), "<LF>");
            iMessage = iMessage.Replace(ControlChars.VT.ToString(), "<VT>");
            iMessage = iMessage.Replace(ControlChars.FF.ToString(), "<FF>");
            iMessage = iMessage.Replace(ControlChars.CR.ToString(), "<CR>");
            iMessage = iMessage.Replace(ControlChars.SO.ToString(), "<SO>");
            iMessage = iMessage.Replace(ControlChars.SI.ToString(), "<SI>");
            iMessage = iMessage.Replace(ControlChars.DLE.ToString(), "<DLE>");
            iMessage = iMessage.Replace(ControlChars.NAK.ToString(), "<NAK>");
            iMessage = iMessage.Replace(ControlChars.SYN.ToString(), "<SYN>");
            iMessage = iMessage.Replace(ControlChars.ETB.ToString(), "<ETB>");
            iMessage = iMessage.Replace(ControlChars.CAN.ToString(), "<CAN>");
            iMessage = iMessage.Replace(ControlChars.EM.ToString(), "<EM>");
            iMessage = iMessage.Replace(ControlChars.SUB.ToString(), "<SUB>");
            iMessage = iMessage.Replace(ControlChars.ESC.ToString(), "<ESC>");
            iMessage = iMessage.Replace(ControlChars.FS.ToString(), "<FS>");
            iMessage = iMessage.Replace(ControlChars.GS.ToString(), "<GS>");
            iMessage = iMessage.Replace(ControlChars.RS.ToString(), "<RS>");
            iMessage = iMessage.Replace(ControlChars.US.ToString(), "<US>");
            iMessage = iMessage.Replace(ControlChars.DEL.ToString(), "<DEL>");

            return iMessage;
        }

        internal static string ReplaceControlCharsReversed(string iMessage)
        {
            iMessage = iMessage.Replace("<SOH>", ControlChars.SOH.ToString());
            iMessage = iMessage.Replace("<STX>", ControlChars.STX.ToString());
            iMessage = iMessage.Replace("<ETX>", ControlChars.ETX.ToString());
            iMessage = iMessage.Replace("<EOT>", ControlChars.EOT.ToString());
            iMessage = iMessage.Replace("<ENQ>", ControlChars.ENQ.ToString());
            iMessage = iMessage.Replace("<ACK>", ControlChars.ACK.ToString());
            iMessage = iMessage.Replace("<BEL>", ControlChars.BEL.ToString());
            iMessage = iMessage.Replace("<BS>", ControlChars.BS.ToString());
            iMessage = iMessage.Replace("<HT>", ControlChars.HT.ToString());
            iMessage = iMessage.Replace("<LF>", ControlChars.LF.ToString());
            iMessage = iMessage.Replace("<VT>", ControlChars.VT.ToString());
            iMessage = iMessage.Replace("<FF>", ControlChars.FF.ToString());
            iMessage = iMessage.Replace("<CR>", ControlChars.CR.ToString());
            iMessage = iMessage.Replace("<SO>", ControlChars.SO.ToString());
            iMessage = iMessage.Replace("<SI>", ControlChars.SI.ToString());
            iMessage = iMessage.Replace("<DLE>", ControlChars.DLE.ToString());
            iMessage = iMessage.Replace("<NAK>", ControlChars.NAK.ToString());
            iMessage = iMessage.Replace("<SYN>", ControlChars.SYN.ToString());
            iMessage = iMessage.Replace("<ETB>", ControlChars.ETB.ToString());
            iMessage = iMessage.Replace("<CAN>", ControlChars.CAN.ToString());
            iMessage = iMessage.Replace("<EM>", ControlChars.EM.ToString());
            iMessage = iMessage.Replace("<SUB>", ControlChars.SUB.ToString());
            iMessage = iMessage.Replace("<ESC>", ControlChars.ESC.ToString());
            iMessage = iMessage.Replace("<FS>", ControlChars.FS.ToString());
            iMessage = iMessage.Replace("<GS>", ControlChars.GS.ToString());
            iMessage = iMessage.Replace("<RS>", ControlChars.RS.ToString());
            iMessage = iMessage.Replace("<US>", ControlChars.US.ToString());
            iMessage = iMessage.Replace("<DEL>", ControlChars.DEL.ToString());

            return iMessage;
        }
    }
}
