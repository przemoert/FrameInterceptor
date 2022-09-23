using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Communication
{
    public class TcpClient : TcpBase
    {
        public EventHandler ConnectionRefused;
        public EventHandler ConnectionEnd;
        public EventHandler Connected;

        const int BUFFER_SIZE = 2048;

        private Socket _client;
        private int _remotePort = 0;
        private AddressFamily? _family = null;
        private NetworkStream _stream = null;
        private byte[] _remoteAddress = new byte[4];
        private bool _clientHasSentZeroLengthByte = false;
        private bool _autoReconnect;


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

        public bool Connect(string iIpAddress, string iPort, bool iAsync = false)
        {
            if (!base.ValidateIp(iIpAddress))
                return false;

            int remotePort = 0;

            if (!Int32.TryParse(iPort, out remotePort))
                return false;

            byte[] ipAddress = base.ConvertStringIpToByte(iIpAddress);

            return this.Connect(ipAddress, remotePort, iAsync);
        }

        public bool Connect(byte[] iIpAddress, int iPort, bool iAsync = false)
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
                if (!this.EstablishConnection(iAsync))
                {
                    return false;
                }
            }

            return true;
        }

        private bool EstablishConnection(bool iAsync)
        {
            if (this._family == null)
                throw new NullReferenceException();


            this.InitializeClient();

            try
            {
                if (!iAsync)
                    this._client.Connect(base._ipAddress, this._remotePort);
                else
                    this.ConnectAsync();

            }
            catch (SocketException)
            {
                return false;
            }

            return true;
        }

        private void ConnectAsync()
        {
            try
            {
                Task.Factory.FromAsync(this.BeginConnect, this.EndConnect, null);
            }
            catch
            {

            }
        }

        private IAsyncResult BeginConnect(AsyncCallback callBack, object state)
        {
            IAsyncResult result = null; 
            try
            {
                result = this._client.BeginConnect(base._ipAddress, this._remotePort, this.EndConnect, null);
            }
            catch
            {

            }

            return result;
        }

        private void EndConnect(IAsyncResult iAsyncResult)
        {
            try
            {
                this._client.EndConnect(iAsyncResult);

                if (this.IsConnected)
                {
                    this.OnConnected();
                    this.StartTalking();
                }
            }
            catch (SocketException ex)
            {
                if (ex.ErrorCode == 10061)
                    this.OnConnectionRefused();
            }
        }

        private void StartTalking()
        {
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
            catch (Exception ex)
            {
                return -1;
            }

        }

        public void OnConnected()
        {
            this.Connected?.Invoke(this, new EventArgs());
        }

        public void OnConnectionRefused()
        {
            this.ConnectionRefused?.Invoke(this, new EventArgs());

            if (this._autoReconnect)
            {
                Thread.Sleep(5000);
                this.ConnectAsync();
            }
        }

        public void OnConnectionEnd()
        {
            this.ConnectionEnd?.Invoke(this, new EventArgs());
        }

        public override void Close()
        {
            if (!this.Disposed)
            {
                if (this.IsConnected)
                {
                    this._clientHasSentZeroLengthByte = true;
                    this._client.Shutdown(SocketShutdown.Send);
                }
                else
                {
                    this.Dispose();
                }
            }   
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
        public bool AutoReconnect { get => _autoReconnect; set => _autoReconnect = value; }
    }
}
