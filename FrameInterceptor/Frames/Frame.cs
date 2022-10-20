using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameInterceptor.Utils;

namespace FrameInterceptor.Frames
{
    public class Frame
    {
        private byte[] _content;
        private List<FrameChar> _charsDefinition;
        
        public Frame(byte[] iFrame)
        {
            this._content = iFrame;
        }

        public void AddCharDefinition(FrameChar iChar)
        {
            this._charsDefinition.Add(iChar);
        }

        public byte[] Bytes { get => this._content; }
        public char[] Chars { get => Settings.Instance.Encoding.GetString(this._content).ToCharArray(); }
        public string Text { get => Settings.Instance.Encoding.GetString(this._content); }

        #region Operators

        public static implicit operator Frame(byte[] b)
        {
            return new Frame(b);
        }

        public static implicit operator Frame(char[] b)
        {
            return new Frame(Settings.Instance.Encoding.GetBytes(b));
        }

        public static implicit operator Frame(string b)
        {
            return new Frame(Settings.Instance.Encoding.GetBytes(b));
        }

        #endregion
    }
}
