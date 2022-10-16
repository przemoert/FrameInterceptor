using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameInterceptor.Utils
{
    public sealed class Settings
    {
        private static Settings _instance;

        private Settings()
        {
            
        }

        public static Settings Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Settings();

                return _instance;
            }
        }



        public int CodePage { get; set; } = 1250;
        public Encoding Encoding { get => System.Text.Encoding.GetEncoding(this.CodePage); }
    }
}
