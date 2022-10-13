using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameInterceptor.Utils
{
    public class MacroCommand
    {
        private string _stringData;
        private byte[] _byteData;

        public string StringData 
        { 
            get => this._stringData; 
            set
            {
                this._stringData = value;
                this._byteData = Encoding.UTF8.GetBytes(ControlChars.ReplaceControlCharsReversed(this._stringData));
            } 
        }
        public byte[] ByteData 
        {
            get => this._byteData;
            set
            {
                this._byteData = value;
                this._stringData = ControlChars.ReplaceControlChars(Encoding.UTF8.GetString(this._byteData));
            } 
        }

        public MacroCommand(string iData)
        {
            this._stringData = ControlChars.ReplaceControlChars(iData);
            this._byteData = Encoding.UTF8.GetBytes(ControlChars.ReplaceControlCharsReversed(this._stringData));
        }
    }
}
