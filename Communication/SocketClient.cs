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
        private AddressFamily? _family = null;
        private NetworkStream _stream = null;
        private object _syncRoot = new object();

        private Socket _client;
        public Socket Client { get => _client; set => _client = value; }
        public SocketServer Owner { get; private set; }
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
        public int BufferSize { get; } = 1024;
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


        public SocketClient(SocketServer iOwner, int iBufferSize)
        {
            this.Owner = iOwner;
            this.BufferSize = iBufferSize;
            this.Buffer = new byte[this.BufferSize];
            this.BufferLength = 0;
        }

        public SocketClient(int iBufferSize = 1024) : this(AddressFamily.InterNetwork) 
        {
            this.BufferSize = iBufferSize;
            this.Buffer = new byte[this.BufferSize];
        }

        private SocketClient(AddressFamily family)
        {
            this._family = family;
        }

        public bool Connect(byte[] iIpAddress, int iPort)
        {
            if (!Validation.ValidateIp(iIpAddress))
                throw new ArgumentOutOfRangeException("iIpAddress");

            return this.Connect(new IPAddress(iIpAddress), iPort);
        }

        public bool Connect(IPAddress iIpAddress, int iPort)
        {
            if (this.Disposed)
                throw new ObjectDisposedException(this.GetType().FullName);

            if (this._family == null)
                throw new ArgumentNullException("family");

            if (this.Connected)
                throw new SocketException((int)SocketError.IsConnected);

            if (!Validation.ValidatePort(iPort))
                throw new ArgumentOutOfRangeException("iPort");

            return this.Connect(new IPEndPoint(iIpAddress, iPort));
        }

        public bool Connect(IPEndPoint iRemoteEP)
        {
            if (this.Disposed)
                throw new ObjectDisposedException(this.GetType().FullName);

            if (iRemoteEP == null)
                throw new ArgumentNullException("iRemoteEP");

            if (this._family == null)
                throw new ArgumentNullException("family");

            this.InitClient();

            try
            {
                this._client.Connect(iRemoteEP);
            }
            catch (SocketException)
            {
                throw;
            }
            catch (StackOverflowException)
            {
                throw;
            }
            catch (OutOfMemoryException)
            {
                throw;
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        private void InitClient()
        {
            this._client = new Socket((AddressFamily)this._family, SocketType.Stream, ProtocolType.Tcp);
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

            lock (_syncRoot)
            {
                for (int i = 0; i < dataToAddLength; i++)
                {
                    this.Buffer[this.BufferLength] = iData[i];
                    this.BufferLength++;
                }
            }
        }

        public NetworkStream GetStream()
        {
            NetworkStream l_Stream = new NetworkStream(this._client, true);

            return l_Stream;
        }

        public int ReadSocket()
        {
            if (this._stream == null)
                this._stream = this.GetStream();

            byte[] l_buffer = new byte[this.BufferSize];

            int l_BytesTransfered = this._stream.Read(l_buffer, 0, l_buffer.Length);

            this.AddToBuffer(l_buffer, 0, l_BytesTransfered);

            return l_BytesTransfered;
        }

        public async Task<int> ReadSocketAsnyc()
        {
            int l_BytesTransfered = 0;

            await Task<int>.Run(() =>
            {
                l_BytesTransfered = this.ReadSocket();
            });

            return l_BytesTransfered;
        }

        public int Send(byte[] buffer, int offset, int count)
        {
            if (!this.Connected)
                return -1;

            int l_BytesTransfered = count;

            try
            {
                if (this._stream == null)
                    this._stream = this.GetStream();

                this._stream.Write(buffer, offset, count);
            }
            catch (Exception)
            {
                return -1;
            }

            return l_BytesTransfered;
        }

        public Task<int> SendAsync(byte[] buffer, int offset, int count)
        {
            return Task<int>.Run(() => { return this.Send(buffer, offset, count); });
        }

        public int Read(byte[] buffer, int offset, int count)
        {
            int bytesRead = 0;
            int bytesToRead = Math.Min(this.BufferLength - offset, count);

            lock (_syncRoot)
            {
                for (int i = offset; i < offset + bytesToRead; i++)
                {
                    buffer[bytesRead] = this.Buffer[i];
                    bytesRead++;
                }

                this.ResetBuffer();
            }

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
                //this.Owner.RemoveClient(this);
            }
        }
    }
}
