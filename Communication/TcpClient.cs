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
        const int BUFFER_SIZE = 2048;

        private Socket _client;
        private IPEndPoint _ipEndPoint;
        private int _remotePort = 0;
        private AddressFamily? _family = null;
        private NetworkStream _stream = null;
        private byte[] _remoteAddress = new byte[4];
        private bool _zeroLengthByteSent = false;


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

        public void SetRemoteEndPoint(string iIpAddress, string iPort)
        {
            if (!base.ValidateIp(iIpAddress))
                throw new ArgumentException();

            int remotePort = 0;

            if (!Int32.TryParse(iPort, out remotePort))
                throw new ArgumentException();

            byte[] ipAddress = base.ConvertStringIpToByte(iIpAddress);

            this.SetRemoteEndPoint(ipAddress, remotePort);
        }

        public void SetRemoteEndPoint(byte[] iIpAddress, int iPort)
        {
            this._remoteAddress = iIpAddress;
            this._remotePort = iPort;
            base._ipAddress = new IPAddress(this._remoteAddress);
            this._ipEndPoint = new IPEndPoint(base._ipAddress, this._remotePort);
        }

        public ConnectionResult Connect()
        {
            this._internalBuffer = new byte[this._bufferSize];

            if (this._family == null)
                throw new NullReferenceException();

            
            if (!this.IsConnected)
            {
                try
                {
                    this.InitializeClient();
                    this._client.Connect(base._ipAddress, this._remotePort);

                    //this.StartTalking();
                }
                catch (SocketException ex)
                {
                    if (ex.ErrorCode == 10061)
                        return ConnectionResult.RefusedByRemoteHost;
                    else if (ex.ErrorCode == 10060)
                        return ConnectionResult.Timeout;
                    else
                        return ConnectionResult.Failed;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return ConnectionResult.Connected;
        }

        public async Task<ConnectionResult> ConnectAsync()
        {
            this._internalBuffer = new byte[this._bufferSize];

            if (this._family == null)
                throw new NullReferenceException();

            if (!this.IsConnected)
            {
                try
                {
                    this.InitializeClient();

                    IAsyncResult ar = await this.InternalConnectAsync(true);
                    this._client.EndConnect(ar);
                }
                catch (SocketException ex)
                {
                    if (ex.ErrorCode == 10061)
                        return ConnectionResult.RefusedByRemoteHost;
                    else if (ex.ErrorCode == 10060)
                        return ConnectionResult.Timeout;
                    else
                        return ConnectionResult.Failed;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return ConnectionResult.Connected;
        }

        private async Task<IAsyncResult> InternalConnectAsync(bool e)
        {
            IAsyncResult ar = null;

            await Task<IAsyncResult>.Run(() =>
            {
                ar = this._client.BeginConnect(this._ipEndPoint, null, null);
                ar.AsyncWaitHandle.WaitOne(base.ConnetionTimeout, true);
            });

            return ar;
        }

        public async Task<int> ReadStreamAsync()
        {
            if (this.Disposed)
                throw new ObjectDisposedException(this.GetType().FullName);

            if (this._client == null)
                throw new NullReferenceException("Client has not been initialized");

            if (!this.IsConnected)
                throw new Exception("Client is not connected to a remote host");

            this.CompareStream();

            byte[] tmpBuffer = new byte[this._bufferSize];
            int bytesToRead = 0;

            try
            {
                bytesToRead = await this._stream.ReadAsync(tmpBuffer, 0, tmpBuffer.Length);
            }
            catch (ObjectDisposedException)
            {
                if (this._zeroLengthByteSent)
                {
                    return (int)ConnectionResult.ZeroLengthByteIgnored;
                }
            }
            catch (Exception ex)
            {
                this.Close();

                if (ex.InnerException != null && ex.InnerException is SocketException s && s.ErrorCode == 10054)
                    return (int)ConnectionResult.ForciblyClosed;
                else
                    return (int)ConnectionResult.ClosedNoReason;

            }

            if (bytesToRead > 0)
            {
                this.AddToBuffer(tmpBuffer, bytesToRead);
            }
            else if (bytesToRead == 0)
            {
                if (!this._zeroLengthByteSent)
                {
                    this._client.Shutdown(SocketShutdown.Both);
                    this.Close();
                }
                else
                {
                    this._client.Shutdown(SocketShutdown.Receive);
                }

                return (int)ConnectionResult.GracefulyClosed;
            }

            return bytesToRead;
        }

        public int ReadStream()
        {
            if (this.Disposed)
                throw new ObjectDisposedException(this.GetType().FullName);

            if (this._client == null)
                throw new NullReferenceException("Client has not been initialized");

            if (!this.IsConnected)
                throw new Exception("Client is not connected to a remote host");

            this.CompareStream();

            byte[] tmpBuffer = new byte[this._bufferSize];
            int bytesToRead = 0;
            try
            {
                bytesToRead = this._stream.Read(tmpBuffer, 0, tmpBuffer.Length);
            }
            catch (ObjectDisposedException ex)
            {
                if (this._zeroLengthByteSent)
                {
                    return (int)ConnectionResult.ZeroLengthByteIgnored;
                }
            }
            catch (Exception ex)
            {
                this.Close();

                if (ex.InnerException != null && ex.InnerException is SocketException s && s.ErrorCode == 10054)
                    return (int)ConnectionResult.ForciblyClosed;
                else
                    return (int)ConnectionResult.ClosedNoReason;

            }

            if (bytesToRead > 0)
            {
                this.AddToBuffer(tmpBuffer, bytesToRead);
            }
            else if (bytesToRead == 0)
            {
                if (!this._zeroLengthByteSent)
                {
                    this._client.Shutdown(SocketShutdown.Both);
                    this.Close();
                }
                else
                {
                    this._client.Shutdown(SocketShutdown.Receive);
                }

                return (int)ConnectionResult.GracefulyClosed;
            }

            return bytesToRead;
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

        public int Write(byte[] iData)
        {
            if (!this.IsConnected)
            {
                return -1;
            }

            try
            {
                if (base._directionPriority == DirectionPriority.In && base._internalBufferSize > 0)
                {
                    return 0;
                }

                this._stream.Write(iData, 0, iData.Length);

                return iData.Length;
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

        public override async void Close()
        {
            if (!this.Disposed)
            {
                if (this.IsConnected)
                {
                    this._client.Shutdown(SocketShutdown.Send);
                    this._zeroLengthByteSent = true;

                    await Task.Delay(2000);

                    this.Dispose();
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

        public string RemoteAddress { get => this._ipEndPoint.Address.ToString(); }
        public int RemotePort { get => this._ipEndPoint.Port; }
    }
}
