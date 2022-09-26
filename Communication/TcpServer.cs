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
    public class TcpServer : TcpBase
    {
        const int BUFFER_SIZE = 1024;

        private IPEndPoint _endPoint;
        private Socket _listener = null;
        private Socket _handler = null;
        private int _listenPort;
        private ManualResetEvent _shouldRun = new ManualResetEvent(true);
        private bool _bufferSizeCanBeChanged = true;


        public TcpServer(byte[] iIpAddress, int iPort)
        {
            if (iIpAddress.Length == 4 && iPort > 0)
            {
                base._ipAddress = new IPAddress(iIpAddress);
                this._listenPort = iPort;
                this._endPoint = new IPEndPoint(base._ipAddress, this._listenPort);
                base._bufferSize = BUFFER_SIZE;
            }
            else
            {
                throw new ArgumentException("Bad input provided");
            }

        }

        public TcpServer(string iIpAddress, string iPort)
        {
            if (!base.ValidateIp(iIpAddress))
                throw new ArgumentException();

            int listenPort = 0;

            if (!Int32.TryParse(iPort, out listenPort))
                throw new ArgumentException();

            byte[] ipAddress = base.ConvertStringIpToByte(iIpAddress);

            base._ipAddress = new IPAddress(ipAddress);
            this._listenPort = listenPort;

            this._endPoint = new IPEndPoint(base._ipAddress, this._listenPort);
        }

        public TcpServer(int iPort)
        {
            if (iPort < 1)
                throw new ArgumentException("Bad input provided");

            try
            {
                base._ipAddress = base.GetLocalIpAddress();
            } 
            catch (Exception)
            {
                throw;
            }

            this._listenPort = iPort;

            this._endPoint = new IPEndPoint(base._ipAddress, this._listenPort);
        }

        public TcpServer(IPAddress iIpAddress, int iPort)
        {
            if (iPort < 1)
                throw new ArgumentException("Bad input provided");

            base._ipAddress = iIpAddress;
            this._listenPort = iPort;

            this._endPoint = new IPEndPoint(base._ipAddress, this._listenPort);
        }

        public ConnectionResult InitListener()
        {
            try
            {
                this._listener = new Socket(this._endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                this._listener.Bind(this._endPoint);
                this._listener.Listen(1);
            }
            catch (SocketException ex)
            {
                if (ex.ErrorCode == 10049)
                    return ConnectionResult.IpAddressContextUnknown;
            }
            catch (Exception ex)
            {
                return ConnectionResult.Failed;
            }

            return ConnectionResult.Listening;
        }

        public async Task<ConnectionResult> ListenForClient()
        {
            try
            {
                IAsyncResult ar = await this.InternalListenForClient();

                this._handler = this._listener.EndAccept(ar);
            }
            catch (SocketException ex)
            {
                return ConnectionResult.Failed;
            }

            return ConnectionResult.Connected;
        }

        private async Task<IAsyncResult> InternalListenForClient()
        {
            IAsyncResult ar = null;

            await Task<IAsyncResult>.Run(() =>
            {
                ManualResetEvent allDone = new ManualResetEvent(false);

                ar = this._listener.BeginAccept(null, null);
                ar.AsyncWaitHandle.WaitOne(Timeout.Infinite, true);
            });

            return ar;
        }

        public int Write(byte[] data)
        {
            if (!this.IsConnected)
                return -1;

            try
            {
                int bytesSent = this._handler.Send(data);

                return bytesSent;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public override void Dispose()
        {
            if (Interlocked.CompareExchange(ref base._disposed, 1, 0) == 0)
            {
                if (this._handler != null)
                {
                    if (this.IsConnected)
                    {
                        this._handler.Shutdown(SocketShutdown.Both);
                    }

                    this._handler.Close();
                    this._handler.Dispose();
                }

                if (this._listener != null)
                {
                    this._listener.Close();
                    this._listener.Dispose();
                }
            }
        }

        public int BufferSize 
        { 
            get => base._bufferSize;
            set
            {
                if (this._bufferSizeCanBeChanged)
                {
                    base._bufferSize = value;
                }
                else
                {
                    throw new AccessViolationException("Tried to change buffer size while server is running");
                }
            }
        }

        public bool IsConnected
        {
            get
            {
                if (this._handler == null)
                {
                    return false;
                }

                try
                {
                    return !(this._handler.Poll(1, SelectMode.SelectRead) && this._handler.Available == 0);
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
    }
}
