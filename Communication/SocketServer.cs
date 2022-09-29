using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Communication
{
    public class SocketServer : IDisposable
    {
        private Socket _socket;
        private IPEndPoint _socketEP;
        private int _disposed = 0;
        private bool _started = false;
        private int _bufferSize = 1024;
        private ConnectionResult _lastConnectionResult = 0;
        private ConnectionResult _connectionResult = ConnectionResult.Unhandled;

        public bool Disposed { get => this._disposed != 0; }
        public int MaxConnections { get; set; } = 10;
        public List<SocketClient> Clients { get; private set; } = new List<SocketClient>();
        public int ClientsCount { get => this.Clients.Count(); }
        public bool Started { get => this._started; }
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


        public SocketServer(IPEndPoint iLocalEP)
        {
            if (iLocalEP == null)
                throw new ArgumentNullException("iLocalEP");

            this._socketEP = iLocalEP;
            this._socket = new Socket(this._socketEP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            this.ConnectionResult = ConnectionResult.Success;
        }

        public SocketServer(IPAddress iIpAddress, int iPort)
        {
            if (iIpAddress == null)
                throw new ArgumentNullException("iIpAddress");

            if (!Validation.ValidatePort(iPort))
                throw new ArgumentOutOfRangeException("iPort");

            this._socketEP = new IPEndPoint(iIpAddress, iPort);
            this._socket = new Socket(this._socketEP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            this.ConnectionResult = ConnectionResult.Success;
        }

        public SocketServer(byte[] iIpAddress, int iPort)
        {
            if (!Validation.ValidateIp(iIpAddress))
                throw new ArgumentOutOfRangeException("iIpAddress");

            if (!Validation.ValidatePort(iPort))
                throw new ArgumentOutOfRangeException("iPort");

            this._socketEP = new IPEndPoint(new IPAddress(iIpAddress), iPort);
            this._socket = new Socket(this._socketEP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            this.ConnectionResult = ConnectionResult.Success;
        }

        public SocketServer(string iIpAddress, string iPort)
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

            this._socketEP = new IPEndPoint(new IPAddress(l_Bytes), l_Port);
            this._socket = new Socket(this._socketEP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            this.ConnectionResult = ConnectionResult.Success;
        }

        public void Init()
        {
            this.Init((int)SocketOptionName.MaxConnections);
        }

        public void Init(int iBacklog)
        {
            if (this._socket == null)
            {
                this.ConnectionResult = ConnectionResult.Failed;

                throw new ArgumentNullException("_socket");
            }

            if (this._started)
                return;

            try
            {
                this._socket.Bind(this._socketEP);
                this._socket.Listen(iBacklog);
            }
            catch (SocketException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                this.Undo();
                throw;
            }

            this._started = true;

            this.ConnectionResult = ConnectionResult.Success;
        }

        public void Undo()
        {
            if (this._socket != null)
            {
                this._socket.Close();
                this._socket.Dispose();
                this._socket = null;
            }

            this._started = false;
        }

        public SocketClient OpenToClient()
        {
            return this.OpenToClient(this._bufferSize);
        }

        public SocketClient OpenToClient(int iBufferSize)
        {
            if (!this._started)
                throw new InvalidOperationException();

            if (this.ClientsCount >= this.MaxConnections)
            {
                this.ConnectionResult = ConnectionResult.ActiveConnectionsLimit;

                return null;
            }

            SocketClient l_client = new SocketClient(this, iBufferSize);
            l_client.Client = this._socket.Accept();

            this.Clients.Add(l_client);

            this.ConnectionResult = ConnectionResult.Success;

            return l_client;
        }

        public void RemoveClient(SocketClient iClient)
        {
            this.Clients.Remove(iClient);
        }

        public void Close()
        {

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
