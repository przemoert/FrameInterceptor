using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communication
{
    public class Frame
    {
        private byte[] _frame;

        public Frame(byte[] iFrame)
        {
            this._frame = iFrame;
        }

        public Frame(String iFrame)
        {
            this._frame = Encoding.UTF8.GetBytes(iFrame);
        }

        public String Text { get => Encoding.UTF8.GetString(this._frame); }
        public byte[] Bytes { get => this._frame; }
        public char[] Chars { get => Encoding.UTF8.GetString(this._frame).ToCharArray(); }
        public int Length { get => this._frame.Length; }


        public static implicit operator Frame(String iData)
        {
            return new Frame(Encoding.UTF8.GetBytes(iData));
        }

        public static implicit operator Frame(char iData)
        {
            return new Frame(Encoding.UTF8.GetBytes(iData.ToString().ToCharArray()));
        }

        public static implicit operator Frame(char[] iData)
        {
            return new Frame(Encoding.UTF8.GetBytes(iData));
        }
    }

    public class FrameCollection : CollectionBase
    {
        public FrameCollection() { }

        public Frame this[int index] { get => (Frame)this.List[index]; set => this.List[index] = value; }

        public int IndexOf(Frame frame)
        {
            if (frame != null)
            {
                return base.List.IndexOf(frame);
            }
            return -1;
        }

        public int Add(Frame frame)
        {
            if (frame != null)
            {
                return this.List.Add(frame);
            }
            return -1;
        }

        public void Remove(Frame frame)
        {
            this.InnerList.Remove(frame);
        }

        public void AddRange(FrameCollection collection)
        {
            if (collection != null)
            {
                this.InnerList.AddRange(collection);
            }
        }

        public void Insert(int index, Frame frame)
        {
            if (index <= List.Count && frame != null)
            {
                this.List.Insert(index, frame);
            }
        }

        public bool Contains(Frame frame)
        {
            return this.List.Contains(frame);
        }
    }
}
