using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameInterceptor.Utils
{
    public class MacroCommand
    {
        public string StringData { get; private set; }
        public byte[] ByteData { get; private set; }

        public MacroCommand(string iData)
        {
            this.StringData = ControlChars.ReplaceControlChars(iData);
            this.ByteData = Encoding.UTF8.GetBytes(iData);
        }
    }
}
