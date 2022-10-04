using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Communication
{
    public enum BufferOptions
    {
        Flush, //Can hangs if remote host sends data continuosly
        Preserve,
        Dynamic
    }

    public sealed class SocketClient : IDisposable, IDisposer
    {
        private int _disposed = 0;
        private AddressFamily? _family = null;
        private object _syncRoot = new object();
        private Socket _client;
        private bool _closed = false;
        private bool _zeroLengthByteIgnored = false;
        private ConnectionResult _lastConnectionResult = 0;
        private ConnectionResult _connectionResult = ConnectionResult.Success;
        private int _bufferSize = 0;
        private int _socketBuffer = 0;
        private byte[] _buffer;
        private int _currentBufferSize = 0;

        

        public BufferOptions BufferExceededOption { get; set; } = BufferOptions.Preserve;
        public int BufferSize { get => this._bufferSize; }
        public int SocketBuffer { get => this._socketBuffer; }
        public int ConnectionTimeout { get; set; } = Timeout.Infinite;

        public byte[] Buffer { get => this._buffer; }
        public int BufferLength { get => this._currentBufferSize; }
        public bool HasData { get => this.Connected && this._client.Available > 0; }
        public SocketServer Owner { get; private set; }
        public SocketClient Self { get => this; }
        public IPAddress IPAddress
        {
            get
            {
                if (this.Client == null)
                    return null;

                if (this.Client.RemoteEndPoint == null)
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
        public string IpAddressAndPort
        {
            get
            {
                if (this.IPAddress == null)
                {
                    return "Empty";
                }

                return this.IPAddress.ToString() + ":" + this.Port;
            }
        }
        public string IpAddressAndPortBuffered { get; private set; }
        public bool Closed { get => this._closed; }
        public bool Disposed { get => this._disposed != 0; }
        public bool Poll
        {
            get => this.Client.Poll(1000, SelectMode.SelectRead);
        }
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
                    return !(this.Client.Poll(1000, SelectMode.SelectRead) && this.Client.Available == 0);
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
        public bool ZeroLengthByteIgnored { get => _zeroLengthByteIgnored; }
        public ConnectionResult ConnectionResult
        {
            get
            {
                return this._connectionResult;
            }
            private set
            {
                this._lastConnectionResult = this._connectionResult;
                this._connectionResult = value;
            }
        }
        public ConnectionResult LastConnectionResult { get => this._lastConnectionResult; }
        public Socket Client
        {
            get => this._client;
            set
            {
                _client = value;

                this._client.ReceiveBufferSize = this._socketBuffer;
                this._client.SendBufferSize = this._socketBuffer;

                this.IpAddressAndPortBuffered = this.IpAddressAndPort;
            }
        }



        public SocketClient(SocketServer iOwner, int iBufferSize, int iSocketBufferSize = -1)
        {
            this.Owner = iOwner;
            this._bufferSize = iBufferSize;
            this._socketBuffer = (iSocketBufferSize == -1) ? iBufferSize : iSocketBufferSize;
            this._buffer = new byte[this._bufferSize];
            this._currentBufferSize = 0;
        }

        public SocketClient(int iBufferSize = 1024, int iSocketBufferSize = -1) : this(AddressFamily.InterNetwork) 
        {
            this._bufferSize = iBufferSize;
            this._socketBuffer = (iSocketBufferSize == -1) ? iBufferSize : iSocketBufferSize;
            this._buffer = new byte[this._bufferSize];
        }

        private SocketClient(AddressFamily family)
        {
            this._family = family;
        }

        public bool Connect(string iIpAddress, string iPort)
        {
            if (!Validation.ValidateIp(iIpAddress))
                throw new ArgumentOutOfRangeException("iIpAddress");

            int l_Port = 0;

            if (!Int32.TryParse(iPort, out l_Port))
                throw new ArgumentOutOfRangeException("iPort");

            if (!Validation.ValidatePort(l_Port))
                throw new ArgumentOutOfRangeException("l_Port");

            string[] l_Parts = iIpAddress.Split('.');

            byte[] l_Bytes = new byte[4];

            for (int i = 0; i < l_Parts.Length; i++)
            {
                l_Bytes[i] = byte.Parse(l_Parts[i]);
            }

            return Connect(l_Bytes, l_Port);
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
                //this._client.Connect(iRemoteEP);
                IAsyncResult l_AsyncResult = this.Client.BeginConnect(iRemoteEP, null, null);
                l_AsyncResult.AsyncWaitHandle.WaitOne(this.ConnectionTimeout, true);

                this.Client.EndConnect(l_AsyncResult);
            }
            catch (SocketException ex)
            {
                this.ConnectionResult = ErrorHandler.TranslateSocketError((SocketError)ex.ErrorCode);

                return false;
            }
            catch (StackOverflowException)
            {
                throw;
            }
            catch (OutOfMemoryException)
            {
                throw;
            }
            catch (ObjectDisposedException ex)
            {
                this.ConnectionResult = ConnectionResult.HandlerDisposed;

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }

            this.ConnectionResult = ConnectionResult.Success;

            this.IpAddressAndPortBuffered = this.IpAddressAndPort;

            return true;
        }

        private void InitClient()
        {
            this.Client = new Socket((AddressFamily)this._family, SocketType.Stream, ProtocolType.Tcp);
        }

        private void ResetBuffer()
        {
            this._buffer = new byte[this._bufferSize];
            this._currentBufferSize = 0;
        }

        public void AddToBuffer(byte[] iData, int offset, int count)
        {
            if (count == 0)
                return;

            int dataToAddLength = Math.Min(iData.Length, count);

            if ((dataToAddLength + this._currentBufferSize) > this._bufferSize)
            {
                if (this.BufferExceededOption == BufferOptions.Dynamic)
                {
                    this.ResizeInternalBuffer(dataToAddLength + this._currentBufferSize);
                }
            }

            lock (_syncRoot)
            {
                for (int i = 0; i < dataToAddLength; i++)
                {
                    this._buffer[this._currentBufferSize] = iData[i];
                    this._currentBufferSize++;
                }
            }
        }

        public void ResizeInternalBuffer(int iNewBufferSize)
        {
            this._bufferSize = iNewBufferSize;

            if (this._currentBufferSize == 0)
            {
                this._buffer = new byte[this._bufferSize];

                return;
            }

            byte[] l_TempBuffer = this._buffer;
            this._buffer = new byte[this._bufferSize];

            Array.Copy(l_TempBuffer, this._buffer, this._currentBufferSize);
        }


        //NetworkStream is no longer needed. All communication can be managed directly through socket.
        //NetworkStream provides unnecessary layer which would had to be managed.
        public NetworkStream GetStream()
        {
            NetworkStream l_Stream = new NetworkStream(this._client, true);

            return l_Stream;
        }


        public int ReadSocket()
        {
            ConnectionResult l_ConnectionResult = 0;

            int l_BytesTransfered = this.ReadSocket(out l_ConnectionResult);

            this.ConnectionResult = l_ConnectionResult;

            return l_BytesTransfered;
        }

        public int ReadSocket(out ConnectionResult oConnectionResult)
        {
            SocketError l_SocketError = SocketError.Fault;
            IAsyncResult l_AsyncResult = null;

            int l_BufferSpaceAvailable = this._bufferSize - this._currentBufferSize;

            if (l_BufferSpaceAvailable <= 0 && this.BufferExceededOption != BufferOptions.Dynamic)
            {
                this.ConnectionResult = ConnectionResult.BufferSizeExceeded;
                oConnectionResult = this.ConnectionResult;

                return -1;
            }

            byte[] l_buffer = new byte[this._bufferSize];

            try
            {
                l_AsyncResult = this._client.BeginReceive(l_buffer, 0, l_buffer.Length, 0, out l_SocketError, null, null);
                bool l_Success = l_AsyncResult.AsyncWaitHandle.WaitOne(Timeout.Infinite, true);
            }
            catch (ObjectDisposedException)
            {
                this.ConnectionResult = ConnectionResult.HandlerDisposed;
            }
            catch (NullReferenceException ex)
            {
                //Reset. Will be translated;
            }
            catch (ArgumentNullException ex)
            {
                //Reset. Will be translated;
            }


            //If 0 length byte was sent to remote host and host did not responded then closing socket results with blocking returns and EndReceive will throw ObjectDisposed.
            //It is borken by design and logic can only be managed through catching exception.

            int l_BytesTransfered = 0;

            try
            {
                l_BytesTransfered = this._client.EndReceive(l_AsyncResult, out l_SocketError);
            }
            catch (ObjectDisposedException)
            {
                if (this.ConnectionResult != ConnectionResult.HandlerDisposed)
                    this.ConnectionResult = ConnectionResult.ZeroLengthByteIgnored;
            }
            catch (NullReferenceException ex)
            {
                //Reset. Will be translated;
            }
            catch (ArgumentNullException ex)
            {
                //Reset. Will be translated;
            }


            //If error occures it happens within EndReceive. Return must happen outside try catch for out sake.

            if (this.ConnectionResult != ConnectionResult.ZeroLengthByteIgnored && this.ConnectionResult != ConnectionResult.HandlerDisposed)
                this.ConnectionResult = ErrorHandler.TranslateSocketError(l_SocketError);


            if (l_BytesTransfered == 0)
                this.HandleZeroByte();

            if (this.HasData)
            {
                if (this.BufferExceededOption != BufferOptions.Dynamic)
                    this.ConnectionResult = ConnectionResult.BufferSizeExceeded;

                if (this.BufferExceededOption != BufferOptions.Preserve)
                {
                    if (this.BufferExceededOption == BufferOptions.Flush)
                    {
                        this.FlushSocketBuffer();
                    }
                    else if (this.BufferExceededOption == BufferOptions.Dynamic)
                    {
                        l_BytesTransfered = this.RewriteBuffer(ref l_buffer);
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
            }


            try
            {
                this.AddToBuffer(l_buffer, 0, l_BytesTransfered);
            }
            catch (IndexOutOfRangeException ex)
            {
                this.ConnectionResult = ConnectionResult.BufferSizeExceeded;
            }


            oConnectionResult = this.ConnectionResult;

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

        private int FlushSocketBuffer()
        {
            int l_DataFlushed = 0;

            while (this._client.Available > 0)
            {
                byte[] l_TempBuffer = new byte[this._client.Available];

                this._client.Receive(l_TempBuffer, 0, l_TempBuffer.Length, 0);

                l_DataFlushed += l_TempBuffer.Length;
            }

            return l_DataFlushed;
        }

        private int RewriteBuffer(ref byte[] iBuffer)
        {
            int l_NewBufferSize = 0;

            while (this.HasData)
            {
                int l_DataAvailable = this._client.Available;

                int l_OldBufferSize = iBuffer.Length;
                l_NewBufferSize = l_OldBufferSize + l_DataAvailable;

                byte[] l_TempReceiveBuffer = new byte[l_DataAvailable];


                this._client.Receive(l_TempReceiveBuffer, 0, l_DataAvailable, 0);


                byte[] l_TempBuffer = iBuffer;
                iBuffer = new byte[l_NewBufferSize];

                Array.Copy(l_TempBuffer, 0, iBuffer, 0, l_OldBufferSize);
                Array.Copy(l_TempReceiveBuffer, 0, iBuffer, l_OldBufferSize, l_DataAvailable);
            }

            this._socketBuffer = l_NewBufferSize;

            return l_NewBufferSize;
        }

        private void HandleZeroByte()
        {
            if (!this._closed)
            {
                if (!this.Disposed)
                {
                    try
                    {
                        if (this.ConnectionResult == ConnectionResult.ForciblyClosed)
                        {
                            this.Dispose();

                            return;
                        }


                        this.Close(0).Wait();
                        this.ConnectionResult = ConnectionResult.GracefullyClosed;
                    }
                    catch (ObjectDisposedException)
                    {
                        this.ConnectionResult = ConnectionResult.HandlerDisposed;
                    }
                }
                else
                {
                    this.ConnectionResult = ConnectionResult.HandlerDisposed;
                }
            }
            else
            {
                if (this.ConnectionResult != ConnectionResult.ZeroLengthByteIgnored && this.ConnectionResult != ConnectionResult.HandlerDisposed)
                    this.ConnectionResult = ConnectionResult.GracefullyClosed;
            }
        }

        public int Send(byte[] buffer, int offset, int count)
        {
            if (!this.Connected)
                return -1;

            int l_BytesTransfered = count;

            try
            {
                //if (this._stream == null)
                //    this._stream = this.GetStream();

                this._client.Send(buffer, offset, count, 0);
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
            int l_bytesTranfered = 0;
            int l_bytesToRead = Math.Min(this._currentBufferSize - offset, count);

            lock (_syncRoot)
            {
                for (int i = offset; i < offset + l_bytesToRead; i++)
                {
                    buffer[l_bytesTranfered] = this._buffer[i];
                    l_bytesTranfered++;
                }

                this.ResetBuffer();
            }

            return l_bytesTranfered;
        }

        public async Task Close()
        {
            await this.Close(500);
        }

        public async Task Close(int timeout)
        {
            if (!this._closed)
            {
                this._closed = true;

                try
                {
                    this._client.Shutdown(SocketShutdown.Send);
                    await Task.Delay(timeout);
                }
                catch (SocketException ex)
                {

                }
                catch (ObjectDisposedException)
                {
                    throw new ObjectDisposedException(this._client.GetType().FullName);
                }
                catch (Exception ex) 
                { 
                
                }

                this.Client.Close();

                if (!this.Disposed)
                    this.Dispose();
            }
        }

        public void Dispose()
        {
            if (this.Disposed)
                throw new ObjectDisposedException(this.GetType().FullName);

            if (this._client == null)
                throw new ObjectDisposedException(this._client.GetType().FullName);


            if (Interlocked.CompareExchange(ref this._disposed, 1, 0) == 0)
            {
                this.Client.Dispose();

                if (this.Owner != null)
                    this.Owner.RemoveClient(this);
            }
        }
    }
}
