using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Communication
{
    public class TcpClient : TcpBase
    {
        const int BUFFER_SIZE = 2048;

        private Socket _client;
        private int _remotePort = 0;
        private AddressFamily? _family = null;
        private NetworkStream _stream = null;
        private byte[] _remoteAddress = new byte[4];
        private bool _clientHasSentZeroLengthByte = false;


        public TcpClient() : this(AddressFamily.InterNetwork) 
        {
            this._internalBufferSize = 0;
            this._bufferSize = BUFFER_SIZE;
        }

        private TcpClient(AddressFamily family)
        {
            this._family = family;
            //this._client = new Socket(family, SocketType.Stream, ProtocolType.Tcp);
        }

        public bool Connect(byte[] iIpAddress, int iPort)
        {
            this._internalBuffer = new byte[this._bufferSize];

            if (this.Disposed)
                throw new ObjectDisposedException(this.GetType().FullName);

            this._remoteAddress = iIpAddress;
            this._remotePort = iPort;

            if (this._family == null)
            {
                throw new NullReferenceException();
            }

            base._ipAddress = new IPAddress(this._remoteAddress);
            
            if (!this.IsConnected)
            {
                if (!this.EstablishConnection())
                {
                    return false;
                }
            }

            return true;
        }

        private bool EstablishConnection()
        {

            if (this._client == null && this._family != null)
            {
                this.InitializeClient();
            }

            if (this._client != null && this._family != null && this._client.RemoteEndPoint != null)
            {
                if (!this.IsConnected)
                {
                    this.InitializeClient();
                }
            }

            if (!this.IsConnected)
            {
                try
                {
                    //this._client.Connect(base._ipAddress, this._remotePort);

                    State state = new State { Success = true };

                    IAsyncResult ar = this._client.BeginConnect(base._ipAddress, this._remotePort, this.EndConnect, state);
                    state.Success = ar.AsyncWaitHandle.WaitOne(base._connetionTimeout, false);

                    if (!state.Success || !this.IsConnected)
                    {
                        return false;
                    }
                }
                catch (SocketException)
                {
                    return false;
                }
            }

            return true;
        }

        private void EndConnect(IAsyncResult ar)
        {
            State state = (State)ar.AsyncState;

            try
            {
                this._client.EndConnect(ar);
            }
            catch { }

            if (this.IsConnected)
                return;

            this._client.Dispose();
        }

        public void StartTalking()
        {
            if (this._client == null || !this.IsConnected)
                throw new NullReferenceException();

            this.CompareStream();

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                try
                {
                    while (true)
                    {
                        if (this.Disposed)
                            break;

                        this.ReadStreamData();
                    }
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null && ex.InnerException is SocketException s && s.ErrorCode == 10054)
                    {
                        this._violatedByRemoteHost = true;
                    }
                    else
                    {
                        _violatedFromOutside = true;
                    }
                }
                finally
                {
                    if (!this.Disposed)
                        this.Dispose();
                }

            }).Start();
        } 

        private void InitializeClient()
        {
            this._client = new Socket((AddressFamily)this._family, SocketType.Stream, ProtocolType.Tcp);
        }

        private NetworkStream GetStream()
        {
            return new NetworkStream(this._client, true);
        }

        private void CompareStream()
        {
            NetworkStream tmpStream = this.GetStream();

            if (!object.ReferenceEquals(this._stream, tmpStream))
            {
                this._stream = tmpStream;
                this._stream.WriteTimeout = base._IOTimeout;
                this._stream.ReadTimeout = base._IOTimeout;
            }
        }

        private void ReadStreamData()
        {
            //this.CompareStream();

            byte[] tmpBuffer = new byte[this._bufferSize];
            int bytesRead = this._stream.Read(tmpBuffer, 0, base._bufferSize);

            if (bytesRead > 0)
            {
                this.AddToBuffer(tmpBuffer, bytesRead);
            }
            else if (bytesRead == 0)
            {
                this._terminatedGracefuly = true;

                if (!this._clientHasSentZeroLengthByte)
                {
                    this._client.Shutdown(SocketShutdown.Send);
                }

                this.Dispose();
            }
        }

        public int Write(string message)
        {
            if (!this.IsConnected)
            {
                return -1;
            }
            
            byte[] data = Encoding.UTF8.GetBytes(message);

            try
            {
                if (base._directionPriority == DirectionPriority.In && base._internalBufferSize > 0)
                {
                    return 0;
                }

                this._stream.Write(data, 0, data.Length);

                return data.Length;
            }
            catch (SocketException)
            {
                return -1;
            }
            catch (Exception)
            {
                return -1;
            }

        }

        public int Read(int offset, int numBytes)
        {
            //this.CompareStream();

            int bytesRead = this._stream.Read(this._internalBuffer, offset, numBytes);

            return 0;
        }

        public override void Close()
        {
            this._client.Shutdown(SocketShutdown.Send);
        }

        public override void Dispose()
        {
            if (this.Disposed)
                throw new ObjectDisposedException(this.GetType().FullName);

            if (this._client == null)
                throw new ObjectDisposedException(this._client.GetType().FullName);

            if (Interlocked.CompareExchange(ref this._disposed, 1, 0) == 0)
            {
                if (this._stream != null)
                    this._stream.Dispose();

                //this._client.Shutdown(SocketShutdown.Both);
                this._client.Close();
                this._client.Dispose();
            }
        }

        public bool IsConnected
        {
            get
            {
                if (this._client == null || (this._client != null && !this._client.Connected))
                {
                    return false;
                }

                try
                {
                    return !(this._client.Poll(1000, SelectMode.SelectRead) && this._client.Available == 0);
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

        public int BufferSize 
        { 
            get => base._bufferSize; 
            set
            {
                if (this.IsConnected)
                    throw new AccessViolationException("Tried to change buffer size while connected");

                base._bufferSize = value;
            }
        }

        public object State { get; private set; }
    }
}
