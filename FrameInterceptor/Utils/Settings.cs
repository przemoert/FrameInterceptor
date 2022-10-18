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
        private static object _syncRoot = new object();

        private Settings()
        {
            
        }

        public static Settings Instance
        {
            get
            {
                //Locking is heavy. This way we wont lock when singleton was already created, since we only need to lock when first instatiating.
                if (_instance == null)
                {
                    lock(_syncRoot)
                    {
                        if (_instance == null)
                            _instance = new Settings();
                    }
                }

                return _instance;
            }
        }



        public int CodePage { get; set; } = 1250;
        public Encoding Encoding { get => System.Text.Encoding.GetEncoding(this.CodePage); }
    }
}
