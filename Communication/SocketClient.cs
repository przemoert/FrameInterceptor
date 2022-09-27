using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Communication
{
    public sealed class SocketClient : IDisposable
    {
        private int _disposed = 0;
        private AddressFamily _family;

        public Socket Client { get; set; }
        public TcpServer Owner { get; private set; }
        public IPAddress IPAddress
        {
            get
            {
                if (this.Client == null)
                    return null;

                return ((IPEndPoint)Client.RemoteEndPoint).Address;
            }
        }
        public int Port
        {
            get
            {
                if (this.Client == null)
                    return -1;

                return ((IPEndPoint)Client.RemoteEndPoint).Port;
            }
        }
        public byte[] Buffer { get; private set; }
        public int BufferSize { get; }
        public int BufferLength { get; private set; }
        public bool Disposed { get => this._disposed != 0; }
        public bool Connected
        {
            get
            {
                if (this.Client == null)
                {
                    return false;
                }

                try
                {
                    return !(this.Client.Poll(1, SelectMode.SelectRead) && this.Client.Available == 0);
                }
                catch (SocketException)
                {
                    return false;
                }
                catch (NullReferenceException)
                {
                    return false;
                }
                catch (ObjectDisposedException)
                {
                    return false;
                }
            }
        }


        public SocketClient(TcpServer iOwner, int iBufferSize) : this(AddressFamily.InterNetwork)
        {
            this.Owner = iOwner;
            this.BufferSize = iBufferSize;
            this.Buffer = new byte[this.BufferSize];
            this.BufferLength = 0;
        }

        private SocketClient(AddressFamily family)
        {
            this._family = family;
        }

        private void ResetBuffer()
        {
            this.Buffer = new byte[this.BufferSize];
            this.BufferLength = 0;
        }

        public void AddToBuffer(byte[] iData, int offset, int count)
        {
            if (count == 0)
                return;

            int dataToAddLength = Math.Min(iData.Length, count);

            for (int i = 0; i < dataToAddLength; i++)
            {
                this.Buffer[this.BufferLength] = iData[i];
                this.BufferLength++;
            }
        }

        public int ReadStream(byte[] buffer, int offset, int count)
        {
            NetworkStream networkStream = new NetworkStream(this.Client);
            networkStream.Read(buffer, offset, count);

            return 0;
        }

        public int Read(byte[] buffer, int offset, int count)
        {
            int bytesRead = 0;
            int bytesToRead = Math.Min(this.BufferLength - offset, count);

            for (int i = offset; i < offset + bytesToRead; i++)
            {
                buffer[bytesRead] = this.Buffer[i];
                bytesRead++;
            }

            this.ResetBuffer();

            return bytesRead;
        }

        public void Close()
        {
            this.Client.Close();
            this.Dispose();
        }

        public void Dispose()
        {
            if (Interlocked.CompareExchange(ref this._disposed, 1, 0) == 0)
            {
                this.Client.Dispose();
                this.Owner.RemoveClient(this);
            }
        }
    }
}
