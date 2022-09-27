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

        public EventHandler<TcpDataEventArgs> TcpDataReceived;

        private IPEndPoint _endPoint;
        private Socket _listener = null;
        private Socket _handler = null;
        private int _listenPort;
        private bool _bufferSizeCanBeChanged = true;
        private List<SocketClient> _clients = new List<SocketClient>();
        private int _clientsLimit = 10;


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

        //public async Task<SocketClient> ListenForClient()
        //{
        //    //SocketClient socketClient = new SocketClient(this, 1024);
        //    //socketClient.Client = await this.InternalListenForClient();

        //    //if (this._clients.Count >= this._clientsLimit)
        //    //{
        //    //    socketClient.Close();
        //    //    return null;
        //    //}

        //    //if (socketClient.Connected)
        //    //{
        //    //    this._clients.Add(socketClient);
        //    //}

        //    //return socketClient;
        //}

        private async Task<Socket> InternalListenForClient()
        {
            Socket socket = null;

            await Task<IAsyncResult>.Run(() =>
            {
                socket = this._listener.Accept();
            });

            return socket;
        }

        public async Task<int> ReadAsync(SocketClient client)
        {
            if (this.Disposed)
                throw new ObjectDisposedException(this.GetType().FullName);

            if (client.Client == null)
                throw new NullReferenceException();


            byte[] tmpBuffer = new byte[this._bufferSize];
            int bytesReceived = 0;

            try
            {
                bytesReceived = await Task<int>.Run(() =>
                {
                    int numBytes = client.Client.Receive(tmpBuffer, 0, client.BufferSize, SocketFlags.None);
                    client.AddToBuffer(tmpBuffer, 0, numBytes);

                    return numBytes;
                });
            }
            catch (SocketException ex)
            {
                if (ex.ErrorCode == 10054)
                {
                    return (int)ConnectionResult.ForciblyClosed;
                }
            }

            return bytesReceived;
        }

        private void OnDataReceived(object sender, EventArgs e)
        {
            if (sender is Socket s)
            {
                TcpDataEventArgs args = new TcpDataEventArgs();

                //this.ReadAsync(s);
            }
        }

        public int Write(SocketClient client, byte[] data)
        {
            if (!client.Connected)
                return -1;

            try
            {
                int bytesSent = client.Client.Send(data);

                return bytesSent;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public void AddClient(SocketClient client)
        {
            this._clients.Add(client);
        }

        public void RemoveClient(SocketClient client)
        {
            this._clients.Remove(client);
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

        public string RemoteIpAddress 
        {
            get
            {
                if (this._handler == null)
                    return null;

                return ((IPEndPoint)this._handler.RemoteEndPoint).Address.ToString();
            }
        }
        public string RemotePort
        {
            get
            {
                if (this._handler == null)
                    return null;

                return ((IPEndPoint)this._handler.RemoteEndPoint).Port.ToString();
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

        public List<SocketClient> Clients { get => _clients; }
        public int ClientsLimit { get => _clientsLimit; set => _clientsLimit = value; }
    }

    public class TcpDataEventArgs : EventArgs
    {
        Socket socket;
        int Length;
    }
}
