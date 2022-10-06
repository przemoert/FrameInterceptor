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
    public class SocketServer : IDisposable, IDisposer
    {
        public event EventHandler ClientsListChanged;

        private Socket _socket;
        private List<SocketClient> _clients = new List<SocketClient>();
        private IPEndPoint _socketEP;
        private int _disposed = 0;
        private bool _started = false;
        private int _bufferSize = 1024;
        private bool _closing = false;
        private ConnectionResult _lastConnectionResult = 0;
        private ConnectionResult _connectionResult = ConnectionResult.Unhandled;
        private object _clientsLock = new object();

        public bool Disposed { get => this._disposed != 0; }
        public bool Closing { get => this._closing; }
        public int MaxConnections { get; set; } = 10;
        public bool Binded { get => (this._socket != null && this._socket.LocalEndPoint != null) ? true : false; }
        public List<SocketClient> Clients { get => this._clients; }
        public int ClientsCount { get => this._clients.Count(); }
        public bool Started { get => this._started; }
        public bool AcceptingClients
        {
            //Remember - such constructs are messed up when debugging.
            get
            {
                if (this.ClientsCount >= this.MaxConnections)
                {
                    if (this.ConnectionResult != ConnectionResult.ActiveConnectionsLimit || this.LastConnectionResult != ConnectionResult.ActiveConnectionsLimit)
                        this.ConnectionResult = ConnectionResult.ActiveConnectionsLimit;

                    return false;
                }
                else
                {
                    if (this.ConnectionResult != ConnectionResult.AcceptingClients)
                    {
                        if (this.LastConnectionResult == ConnectionResult.ActiveConnectionsLimit)
                        {
                            this.ConnectionResult = ConnectionResult.AcceptingClientsAfterLimit;
                        }
                        else
                        {
                            this.ConnectionResult = ConnectionResult.AcceptingClients;
                        }

                    }

                    return true;
                }
            }
        }
        public Socket Server 
        {
            get => this._socket; 
            private set
            {
                this._socket = value;
                this.IpAddressAndPortBuffered = this.IpAddressAndPort;
            }
        }
        public IPAddress IPAddress
        {
            get
            {
                if (this.Server == null)
                    return null;

                if (this.Server.LocalEndPoint == null)
                    return null;

                return ((IPEndPoint)Server.LocalEndPoint).Address;
            }
        }
        public int Port
        {
            get
            {
                if (this.Server == null)
                    return -1;

                return ((IPEndPoint)Server.LocalEndPoint).Port;
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


        public SocketServer(IPEndPoint iLocalEP)
        {
            if (iLocalEP == null)
                throw new ArgumentNullException("iLocalEP");

            this._socketEP = iLocalEP;
            //this._socket = new Socket(this._socketEP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            //this.ConnectionResult = ConnectionResult.Success;
        }

        public SocketServer(IPAddress iIpAddress, int iPort)
        {
            if (iIpAddress == null)
                throw new ArgumentNullException("iIpAddress");

            if (!Validation.ValidatePort(iPort))
                throw new ArgumentOutOfRangeException("iPort");

            this._socketEP = new IPEndPoint(iIpAddress, iPort);
            //this._socket = new Socket(this._socketEP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            //this.ConnectionResult = ConnectionResult.Success;
        }

        public SocketServer(byte[] iIpAddress, int iPort)
        {
            if (!Validation.ValidateIp(iIpAddress))
                throw new ArgumentOutOfRangeException("iIpAddress");

            if (!Validation.ValidatePort(iPort))
                throw new ArgumentOutOfRangeException("iPort");

            this._socketEP = new IPEndPoint(new IPAddress(iIpAddress), iPort);
            //this._socket = new Socket(this._socketEP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            //this.ConnectionResult = ConnectionResult.Success;
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
            //this._socket = new Socket(this._socketEP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            //this.ConnectionResult = ConnectionResult.Success;
        }

        public void OpenSocket()
        {
            try
            {
                this.Server = new Socket(this._socketEP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            }
            catch (SocketException ex)
            {
                this.ConnectionResult = ErrorHandler.TranslateSocketError(ex.ErrorCode);

                return;
            }

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
            {
                this.ConnectionResult = ConnectionResult.ServerListening;

                return;
            }

            try
            {
                if (!this.Binded)
                    this._socket.Bind(this._socketEP);

                this._socket.Listen(iBacklog);
            }
            catch (SocketException ex)
            {
                this.Undo();

                this.ConnectionResult = ErrorHandler.TranslateSocketError(ex.ErrorCode);

                return;
            }
            catch (Exception ex)
            {
                this.Undo();
                throw;
            }

            this._started = true;

            this.ConnectionResult = ConnectionResult.ServerListening;
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
            this._closing = false;

            this.OpenSocket();
        }

        public SocketClient OpenToClient()
        {
            return this.OpenToClient(this._bufferSize);
        }

        public SocketClient OpenToClient(int iBufferSize, int iSocketBufferSize = -1)
        {
            if (!this._started)
                throw new InvalidOperationException();

            
            //Before we start accepting we have to check if ConnectionsLimit has been reached. If so we set the result and return null to notify.

            if (this.ClientsCount >= this.MaxConnections)
            {
                this.ConnectionResult = ConnectionResult.ActiveConnectionsLimit;

                return null;
            }

            SocketClient l_client = new SocketClient(this, iBufferSize, iSocketBufferSize);
            IAsyncResult l_AsyncResult = null; 
            
            try
            {
                l_AsyncResult = this._socket.BeginAccept(null, null);
                bool l_Success = l_AsyncResult.AsyncWaitHandle.WaitOne(Timeout.Infinite, true);
            }
            catch (ObjectDisposedException)
            {
                //We can only catch.
                //Memory leaks occured during tests if Socket.EndAccept hasnt been called.
            }


            try
            {
                l_client.Client = this._socket.EndAccept(l_AsyncResult);
            }
            catch (ObjectDisposedException)
            {
                l_client.Close().Wait();

                this.ConnectionResult = ConnectionResult.ListenerClosed;

                return null;
            }
            catch(SocketException ex)
            {
                this.ConnectionResult = ErrorHandler.TranslateSocketError(ex.ErrorCode);

                return null;
            }

            if (l_client.Client != null)
            {
                this.AddClient(l_client);
            }
            else
            {
                l_client.Close().Wait(0);
                l_client.Dispose();
            }

            this.ConnectionResult = ConnectionResult.Success;

            return l_client;
        }

        public void ResetState()
        {
            //The only reason to reset ConnectionResult is to allow new clients to come. Any other scenario will result with exception.
            if (this.ConnectionResult != ConnectionResult.ActiveConnectionsLimit && this._lastConnectionResult != ConnectionResult.Success)
                throw new InvalidOperationException();

            this.ConnectionResult = ConnectionResult.Success;
        }

        public void RemoveClient(SocketClient iClient)
        {
            lock (_clientsLock)
            {
                this._clients.Remove(iClient);
            }

            this.OnClientsListChanged();
        }

        public void AddClient(SocketClient iClient)
        {
            lock (_clientsLock)
            {
                this._clients.Add(iClient);
            }

            this.OnClientsListChanged();
        }

        private void OnClientsListChanged()
        {
            this.ClientsListChanged?.Invoke(this, new EventArgs());
        }


        //This method allows blocked OpenToClient method to unblock. Then OpenToClient returns null.
        //Ones closed socket cant be used again so all closing stuff has to be handle manually.
        public void CloseListener()
        {
            this._closing = true;
            this._socket.Close();
        }

        public async Task Close()
        {
            this._closing = true;

            if (this.ClientsCount > 0)
            {
                //foreach (SocketClient client in this.Clients.ToList())
                while (this.ClientsCount > 0)
                {
                    await this._clients[0].Close(500);
                }
            }

            this._socket.Close();
            this._socket.Dispose();

            this.Dispose();

            this.ConnectionResult = ConnectionResult.ListenerClosed;
        }

        public void Dispose()
        {
            if (this.Disposed)
                throw new ObjectDisposedException(this.GetType().FullName);

            if (this._socket == null)
                throw new ObjectDisposedException(this._socket.GetType().FullName);


            if (Interlocked.CompareExchange(ref this._disposed, 1, 0) == 0)
            {
                if (this.ClientsCount > 0)
                {
                    foreach (SocketClient c in this._clients.ToList())
                    {
                        c.Dispose();
                    }
                }

                this._socket.Dispose();
            }
        }
    }
}
