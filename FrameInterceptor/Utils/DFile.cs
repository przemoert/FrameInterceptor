using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameInterceptor.Utils
{
    public class DFile
    {
        private byte[] _content;
        private string _extension;
        private string _name;
        private string _directory;
        private bool test;

        public DFile(byte[] b)
        {
            this._content = b;
        }

        public DFile(char[] b)
        {
            //this._content = Encoding.UTF8.GetBytes(b);
            this._content = Settings.Instance.Encoding.GetBytes(b);
        }

        public DFile(string b)
        {
            //this._content = Encoding.UTF8.GetBytes(b);
            this._content = Settings.Instance.Encoding.GetBytes(b);
        }

        public DFile(FileInfo fi)
        {
            this.Open(fi);
        }

        private void Open(FileInfo fi)
        {
            this._content = File.ReadAllBytes(fi.FullName);
            this._extension = fi.Extension;
            this._name = fi.Name;
            this._directory = fi.DirectoryName;
        }

        public void WriteFile()
        {
            if (String.IsNullOrEmpty(this._directory))
                throw new ArgumentNullException("Directory");

            if (String.IsNullOrEmpty(this._name))
                throw new ArgumentNullException("Name");

            if (String.IsNullOrEmpty(this.Extension))
                throw new ArgumentNullException(this.Extension);

            if (!System.IO.Directory.Exists(this._directory))
                System.IO.Directory.CreateDirectory(this._directory);

            using (FileStream fs = File.Create(this.FullName))
            {
                fs.Write(this._content, 0, this._content.Length);
            }
        }

        public byte[] Bytes { get => this._content; }
        //public char[] Chars { get => Encoding.UTF8.GetString(this._content).ToCharArray(); }
        public char[] Chars { get => Settings.Instance.Encoding.GetString(this._content).ToCharArray(); }
        //public string Text { get => Encoding.UTF8.GetString(this._content); }
        public string Text { get => Settings.Instance.Encoding.GetString(this._content); }
        public string Extension { get => this._extension; }
        public string Name 
        { 
            get => this._name;
            set
            {
                if (!value.Contains('.'))
                    throw new ArgumentOutOfRangeException("Name");

                this._name = value;

                this._extension = '.' + this._name.Split('.').Last();
            }
        }
        public string Directory { get => this._directory; set => this._directory = value.Trim(' ', '\\', '/'); }
        public string FullName { get => $"{this._directory}\\{this._name}"; }
    }
}
