using Communication;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FrameInterceptor.Communication
{
    internal class TcpServerCommunication : CommunicationCommons
    {
        //private FrameInterceptor_v2 _owningForm;
        private SocketServer _socketServer;
        private string _localAddress;
        private string _localPort;
        private int _maxConnections;
        private int _backlog;
        private int _bufferSize;
        private BufferOptions _bufferExceededOption;


        public TcpServerCommunication(FrameInterceptor_v2 iOwner, string iIpAddress, string iPort, string iBufferSize, string iMaxConnections, string iBacklog) : base(iOwner)
        {
            if (!Int32.TryParse(iMaxConnections, out this._maxConnections))
                throw new ArgumentOutOfRangeException("iMaxConnections");

            if (!Int32.TryParse(iBacklog, out this._backlog))
                throw new ArgumentOutOfRangeException("iBacklog");

            if (!Int32.TryParse(iBufferSize, out this._bufferSize))
                throw new ArgumentOutOfRangeException("iBufferSize");


            //this._owningForm = iOwner;
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

            base.SetHandler(this._socketServer);
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
                this._owningForm.ResultLog(this.ConnectionResult);

                return;
            }

            this._owningForm.btnServerOpen.Enabled = false;


            //We must check here again.
            if (this._socketServer.Closing)
                return;

            //ActiveConnectionsLimit is handled later.
            if (!l_GoodToGo)
            {
                this._owningForm.ResultLog(this.ConnectionResult);
                this._owningForm.btnServerOpen.Enabled = true;

                return;
            }

            this._owningForm.btnServerOpen.Text = "Close";
            this._owningForm.btnServerOpen.Enabled = true;


            if (!this._socketServer.AcceptingClients)
            {
                if (this.ConnectionResult == ConnectionResult.ActiveConnectionsLimit && this.Server.LastConnectionResult != this.ConnectionResult)
                {
                    this._owningForm.ResultLog(this.ConnectionResult);
                }

                await Task.Delay(2000);

                this.Open();

                return;
            }
            else
            {
                if (this.Server.LastConnectionResult == ConnectionResult.ActiveConnectionsLimit)
                {
                    this._owningForm.ResultLog(this.ConnectionResult);
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
                this._owningForm.ResetClientsBindings();
                this._owningForm.Log($"{l_Client.IpAddressAndPort} -> {this.Server.IpAddressAndPort}");

                this.Open();

                l_Client.BufferExceededOption = this._bufferExceededOption;

                this.Receive(l_Client);
            }
        }

        //private async void Receive(SocketClient iClient)
        //{
        //    if (this._socketServer.Disposed)
        //        return;

        //    ConnectionResult l_ConnectionResult = ConnectionResult.Unhandled;

        //    int l_BytesTransfered = await Task<int>.Run(() =>
        //    {
        //        return iClient.ReadSocket(out l_ConnectionResult);
        //    });

        //    if (iClient.ConnectionResult != ConnectionResult.Success)
        //        this._owningForm.ResultLog(iClient.ConnectionResult, iClient);


        //    if (l_BytesTransfered > 0)
        //    {
        //        //Read client buffer
        //        this.ReadClientBuffer(iClient, l_BytesTransfered);


        //        //Recursive call
        //        this.Receive(iClient);

        //        if (this._owningForm.chkAutoResponse.Checked)
        //        {
        //            if (!String.IsNullOrEmpty(this._owningForm.tbSend.Text))
        //            {
        //                byte[] l_ToSend = Encoding.UTF8.GetBytes(this._owningForm.tbSend.Text);

        //                this.Send(l_ToSend, iClient);
        //            }
        //        }
        //    }
        //    else if (l_BytesTransfered == 0)
        //    {
        //        this._owningForm.ResetClientsBindings();
        //        //this._owningForm.ResultLog(l_ConnectionResult, iClient);
        //    }
        //    else
        //    {
        //        if (iClient.ConnectionResult == ConnectionResult.BufferSizeExceeded)
        //        {
        //            this.ReadClientBuffer(iClient, iClient.BufferLength);

        //            try
        //            {
        //                await iClient.Close();
        //                this._owningForm.ResetClientsBindings();
        //            }
        //            catch (Exception ex)
        //            {

        //            }
        //        }
        //    }
        //}

        //private async void ReadClientBuffer(SocketClient iClient, int iBytesToRead)
        //{
        //    byte[] l_Buffer = new byte[iBytesToRead];

        //    iClient.Read(l_Buffer, 0, iBytesToRead);
        //    await this._owningForm.ComLog(l_Buffer, iBytesToRead, false, iClient);
        //}

        //public async void Send(byte[] iData, SocketClient iClient)
        //{
        //    int l_BytesTransfered = await Task<int>.Run(() =>
        //    {
        //        return iClient.Send(iData, 0, iData.Length);
        //    });

        //    this._owningForm.ComLog(iData, l_BytesTransfered, true, iClient);
        //}

        public async void DisconnectClinet(SocketClient iClient)
        {
            if (iClient != null)
                await iClient.Close();

            this._owningForm.ResetClientsBindings();
        }

        public async Task Close()
        {
            //Because of use of DGV for listing clients we cant use native server closing to disconnect all clients.
            //We must iterate over each client, close it manually and reset bindings.
            this._socketServer.CloseListener();

            if (this.Clients.Count > 0)
            {
                foreach (SocketClient client in this.Clients.ToList())
                {
                    await client.Close();

                    this._owningForm.ResetClientsBindings();
                }
            }

            await this._socketServer.Close();

            this._owningForm.ResultLog(this._socketServer.ConnectionResult);
        }


        public SocketServer Server { get => this._socketServer; }
        public List<SocketClient> Clients { get => this._socketServer.Clients; }
        public ConnectionResult ConnectionResult { get => this.Server.ConnectionResult; }
    }
}
