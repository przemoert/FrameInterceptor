using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Communication
{
    public enum DirectionPriority
    {
        None,
        In,
        Out
    }

    public abstract class TcpBase : IDisposable
    {
        public EventHandler DataReceived;

        protected IPAddress _ipAddress;
        protected byte[] _internalBuffer = null;
        protected int _internalBufferSize;
        protected bool _terminatedGracefuly = false;
        protected bool _violatedByRemoteHost = false;
        protected bool _violatedFromOutside = false;
        protected int _bufferSize = 0;
        protected byte[] _byteData = null;
        protected object _syncRoot = new object();
        protected int _disposed = 0;
        protected DirectionPriority _directionPriority = DirectionPriority.None;
        protected int _IOTimeout = Timeout.Infinite;
        protected int _connetionTimeout = 50000;


        public virtual int Read(byte[] buffer, int offset, int numBytes)
        {
            if (this._internalBufferSize == 0)
                return 0;

            int bytesRead = 0;

            lock (_syncRoot)
            {
                int bytesToRead = Math.Min(this._internalBufferSize - offset, numBytes);

                for (int i = offset; i < offset + bytesToRead; i++)
                {
                    buffer[bytesRead] = this._internalBuffer[i];
                    bytesRead++;
                }

                this.ShiftLeft(offset + bytesToRead);
            }

            return bytesRead;
        }

        protected virtual int ShiftLeft(int offset)
        {
            if (offset >= this._internalBufferSize)
            {
                this.ClearBuffer();
                return 0;
            }

            //byte[] tempArray = new byte[this._bufferSize];
            int tempPtr = offset;

            while (tempPtr > 0)
            {
                for (int i = tempPtr; i < this._internalBufferSize; i++)
                {
                    this._internalBuffer[i - 1] = this._internalBuffer[i];
                }

                this._internalBufferSize--;
                tempPtr--;
            }

            return this._internalBufferSize;
        }

        protected virtual void AddToBuffer(byte[] iData, int numBytes)
        {
            if (numBytes == 0)
                return;

            lock (_syncRoot)
            {
                if (iData.Length < numBytes)
                    throw new IndexOutOfRangeException("Input length is less than bytes to read");

                if (this._internalBufferSize + numBytes > this._bufferSize)
                    throw new IndexOutOfRangeException("Buffer size exceeded");

                for (int i = 0; i < numBytes; i++)
                {
                    this._internalBuffer[this._internalBufferSize] = iData[i];
                    this._internalBufferSize++;
                }

                this.OnDataReceived();
            }
        }

        public virtual void OnDataReceived()
        {
            this.DataReceived?.Invoke(this, new EventArgs());
        }

        protected virtual void ClearBuffer()
        {
            this._internalBuffer = new byte[this._bufferSize];
            this._internalBufferSize = 0;
        }

        public virtual void Close() => this.Dispose();
        public abstract void Dispose();


        public virtual bool Disposed { get => this._disposed != 0; }
        public virtual int BytesToRead { get => this._internalBufferSize; }
        public DirectionPriority DirectionPriority { get => _directionPriority; set => _directionPriority = value; }
        protected int IOTimeout { get => _IOTimeout; set => _IOTimeout = value; }
        protected int ConnetionTimeout { get => _connetionTimeout; set => _connetionTimeout = value; }
    }
}
