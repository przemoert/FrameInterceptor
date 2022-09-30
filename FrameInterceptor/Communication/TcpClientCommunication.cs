using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Communication;

namespace FrameInterceptor.Communication
{
    internal class TcpClientCommunication
    {
        private FrameInterceptor _owningForm;
        private SocketClient _socketClient;
        private string _remoteAddress;
        private string _remotePort;

        public TcpClientCommunication(FrameInterceptor iOwner, string iIpAddress, string iPort)
        {
            this._owningForm = iOwner;
            this._remoteAddress = iIpAddress;
            this._remotePort = iPort;

            this._socketClient = new SocketClient(4096);
            this._socketClient.ConnectionTimeout = 5000;
        }

        public async void Connect()
        {
            bool l_result = false;

            try
            {
                this._owningForm.btnClientConnect.Enabled = false;

                l_result = await Task<bool>.Run(() =>
                {
                    return this._socketClient.Connect(this._remoteAddress, this._remotePort);
                });
            }
            catch (ArgumentOutOfRangeException)
            {
                this._owningForm.btnClientConnect.Enabled = true;

                return;
            }

            if (!l_result)
            {
                this._owningForm.ResultLog(this._socketClient.ConnectionResult);
                this._owningForm.btnClientConnect.Enabled = true;

                return;
            }

            if (!this.Connected)
            {
                this._owningForm.ResultLog(this._socketClient.ConnectionResult);
                this._owningForm.btnClientConnect.Enabled = true;

                return;
            }

            this._owningForm.btnClientConnect.Enabled = true;
            this._owningForm.btnClientConnect.Text = "Disconnect";

            this.Receive();
        }

        public async void Receive()
        {
            ConnectionResult l_ConnectionResult = ConnectionResult.Unhandled;

            int l_BytesTransfered = await Task<int>.Run(() =>
            {
                return this._socketClient.ReadSocket(out l_ConnectionResult);
            });


            byte[] l_Buffer = new byte[l_BytesTransfered];

            if (l_BytesTransfered > 0)
            {
                this.Receive();

                this._socketClient.Read(l_Buffer, 0, l_BytesTransfered);
                this._owningForm.ComLog(l_Buffer, l_BytesTransfered, false);
            }
            else if (l_BytesTransfered == 0)
            {
                this._owningForm.ResultLog(l_ConnectionResult);
            }
        }

        public int Send(byte[] iData)
        {
            return this._socketClient.Send(iData, 0, iData.Length);
        }

        public async Task Close()
        {
            await this._socketClient.Close();

            this._owningForm.btnClientConnect.Text = "Connect";
        }

        public SocketClient Client { get => this._socketClient; }
        public bool Connected { get => this._socketClient.Connected; }
    }
}
