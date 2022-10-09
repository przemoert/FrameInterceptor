using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Communication;

namespace FrameInterceptor.Communication
{
    internal class TcpClientCommunication : CommunicationCommons
    {
        //private FrameInterceptor_v2 _owningForm;
        private SocketClient _socketClient;
        private string _remoteAddress;
        private string _remotePort;
        private int _timeout;
        private int _bufferSize;
        private BufferOptions _bufferExceededOption;

        public TcpClientCommunication(FrameInterceptor_v2 iOwner, string iIpAddress, string iPort, string iBufferSize, string iTimeout) : base(iOwner)
        {
            if (!Int32.TryParse(iBufferSize, out this._bufferSize))
                throw new ArgumentOutOfRangeException("iBufferSize");

            if (!Int32.TryParse(iTimeout, out this._timeout))
                throw new ArgumentOutOfRangeException("iTimeout");

            base._owningForm = iOwner;
            this._remoteAddress = iIpAddress;
            this._remotePort = iPort;
            this._bufferExceededOption = (BufferOptions)this._owningForm.icClientBufferOptions.Value;


            this._socketClient = new SocketClient(this._bufferSize);
            this._socketClient.ConnectionTimeout = this._timeout;
            this._socketClient.BufferExceededOption = this._bufferExceededOption;

            base.SetHandler(this);
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
            catch (ArgumentNullException)
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

            this._owningForm.Log($"Connected to {this.Client.IPAddress.ToString()}:{this.Client.Port}");

            this._owningForm.btnClientConnect.Enabled = true;
            this._owningForm.btnClientConnect.Text = "Disconnect";

            this.Receive(this._socketClient);
        }

        public async Task Close()
        {
            if (this.Connected)
                await this._socketClient.Close();

            this._owningForm.btnClientConnect.Text = "Connect";
        }

        public SocketClient Client { get => this._socketClient; }
        public bool Connected { get => this._socketClient.Connected; }
    }
}
