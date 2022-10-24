using Communication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FrameInterceptor.Communication
{
    internal class TcpServerCommunication : CommunicationCommons, IDisposable
    {
        //private FrameInterceptor_v2 _owningForm;
        private SocketServer _socketServer;
        private string _localAddress;
        private string _localPort;
        private int _maxConnections;
        private int _backlog;
        private int _bufferSize;
        private BufferOptions _bufferExceededOption;
        private int _disposed = 0;


        public TcpServerCommunication(FrameInterceptor_v2 iOwner, string iIpAddress, string iPort, string iBufferSize, string iMaxConnections, string iBacklog) : base(iOwner)
        {
            if (!Int32.TryParse(iMaxConnections, out this._maxConnections))
                throw new ArgumentOutOfRangeException("iMaxConnections");

            if (!Int32.TryParse(iBacklog, out this._backlog))
                throw new ArgumentOutOfRangeException("iBacklog");

            if (!Int32.TryParse(iBufferSize, out this._bufferSize))
                throw new ArgumentOutOfRangeException("iBufferSize");


            this._owningForm = iOwner;
            this._localAddress = iIpAddress;
            this._localPort = iPort;
            this._bufferExceededOption = (BufferOptions)this._owningForm.icServerBufferOptions.Value;

            try
            {
                this._socketServer = new SocketServer(this._localAddress, this._localPort);
                this._socketServer.MaxConnections = this._maxConnections;
            }
            catch (ArgumentOutOfRangeException)
            {
                throw;
            }

            base.SetHandler(this);
        }

        public void CreateSocket()
        {
            this._socketServer.OpenSocket(); 
        }

        public void InitServer()
        {
            try
            {
                this._socketServer.Init(this._backlog);
            }
            catch (ArgumentNullException)
            {
                return;
            }
        }

        public async void Open()
        {
            bool l_GoodToGo =
                this.ConnectionResult == ConnectionResult.Success ||
                this.ConnectionResult == ConnectionResult.ActiveConnectionsLimit ||
                this.ConnectionResult == ConnectionResult.AcceptingClients ||
                this.ConnectionResult == ConnectionResult.ServerListening;


            //If server is closing we MUST stop;
            if (this._socketServer.Closing)
                return;

            //ActiveConnectionsLimit is handled later.
            if (!l_GoodToGo)
            {
                this._owningForm.ResultLog(this.ConnectionResult, this);

                return;
            }

            this._owningForm.btnServerOpen.Enabled = false;


            //We must check here again.
            if (this._socketServer.Closing)
                return;

            //ActiveConnectionsLimit is handled later.
            if (!l_GoodToGo)
            {
                this._owningForm.ResultLog(this.ConnectionResult, this);
                this._owningForm.btnServerOpen.Enabled = true;

                return;
            }

            this._owningForm.btnServerOpen.Text = "Close";
            this._owningForm.btnServerOpen.Enabled = true;


            if (!this._socketServer.AcceptingClients)
            {
                if (this.ConnectionResult == ConnectionResult.ActiveConnectionsLimit && this.Server.LastConnectionResult != this.ConnectionResult)
                {
                    this._owningForm.ResultLog(this.ConnectionResult, this);
                }

                await Task.Delay(2000);

                this.Open();

                return;
            }
            else
            {
                if (this.Server.LastConnectionResult == ConnectionResult.ActiveConnectionsLimit)
                {
                    this._owningForm.ResultLog(this.ConnectionResult, this);
                }
            }


            //And one more time. It costs nothing but prevents various nasty scenarios.
            if (this._socketServer.Closing)
                return;

            SocketClient l_Client = await Task<SocketClient>.Run(() =>
            {
                return this._socketServer.OpenToClient(this._bufferSize);
            });



            if (l_Client != null)
            {
                //Client has connected. Log it and start receiving data
                this.Clients.Add(l_Client);
                //this._owningForm.ResetClientsBindings();

                this._owningForm.Log($"{l_Client.IpAddressAndPort} -> {this.Server.IpAddressAndPort}", this);

                this.Open();

                l_Client.BufferExceededOption = this._bufferExceededOption;

                this.Receive(l_Client);
            }
        }


        public async void DisconnectClinet(SocketClient iClient)
        {
            if (iClient != null)
                await iClient.Close();

            this.Clients.Remove(iClient);

            //this._owningForm.ResetClientsBindings();
        }

        public async Task Close()
        {
            //Because of use of DGV for listing clients we cant use native server closing to disconnect all clients.
            //We must iterate over each client, close it manually and reset bindings.
            if (this._socketServer != null)
                this._socketServer.CloseListener();

            if (this.Clients.Count > 0)
            {
                foreach (SocketClient client in this.Clients.ToList())
                {
                    if (!client.Closed)
                    {
                        await client.Close();
                    }

                    this.Clients.Remove(client);

                    //this._owningForm.ResetClientsBindings();
                }
            }

            if (this._socketServer != null)
                await this._socketServer.Close();

            this.Dispose();

            this._owningForm.ResultLog(this._socketServer.ConnectionResult, this);
        }

        public void Dispose()
        {
            if (this.Disposed)
                throw new ObjectDisposedException(this.GetType().FullName);

            if (Interlocked.CompareExchange(ref this._disposed, 1, 0) == 0)
            {
                //base.RemoveHandler();

                if (this._socketServer != null && !this._socketServer.Disposed)
                    this._socketServer.Dispose();
            }
        }

        public SocketServer Server { get => this._socketServer; }
        public BindingList<SocketClient> Clients { get; } = new BindingList<SocketClient>();
        public ConnectionResult ConnectionResult { get => this.Server.ConnectionResult; }
        public bool Disposed { get => this._disposed != 0; }
    }
}
