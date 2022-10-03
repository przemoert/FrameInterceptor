using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Communication;
using FrameInterceptor.Communication;
using FrameInterceptor.CustomControls;


//Connected = -1,
//RefusedByRemoteHost = -2,
//Timeout = -3,
//Failed = -4,
//ForciblyClosed = -5,
//GracefulyClosed = -6,
//ClosedNoReason = -7,
//ZeroLengthByteIgnored = -8,

namespace FrameInterceptor
{
    public partial class FrameInterceptor_v2 : Form
    {
        private TcpClientCommunication _tcpClient;
        private TcpServerCommunication _tcpServer;
        private BindingSource ClientsBindigs = new BindingSource();
        private bool _silentMode;

        public FrameInterceptor_v2()
        {
            InitializeComponent();

            SetupControls();

            this._silentMode = this.chkSilentMode.Checked;

        }

        private void SetupControls()
        {
            this.icServerBufferOptions.DataSource = Enum.GetValues(typeof(BufferOptions));
            this.icClientBufferOptions.DataSource = Enum.GetValues(typeof(BufferOptions));
        }

        private void SetUpClientsDataSource()
        {
            this.dgClients.AutoGenerateColumns = false;

            ClientsBindigs.DataSource = this._tcpServer.Server.Clients;

            dgClients.DataSource = ClientsBindigs;


            //this.dgClients.DataSource = null;
            //this.dgClients.DataSource = this.DgClientsBinding;
        }

        private async void UpdateClientsDataSource()
        {
            await Task.Delay(200);

            if (this._tcpServer != null)
            {
                if (this._tcpServer.Server.Closing)
                {
                    this.dgClients.DataSource = null;
                    this.dgClients.DataSource = ClientsBindigs;
                }

                if (this.dgClients.Rows.Count != this._tcpServer.Clients.Count)
                    if (this._tcpServer.Clients.Count > 0)
                        this.ClientsBindigs.ResetBindings(false);


                this.UpdateClientsDataSource();
            }
        }

        internal void ResetClientsBindings()
        {
            this.ClientsBindigs.ResetBindings(false);
        }

        internal void ResultLog(ConnectionResult result, object sender = null)
        {
            string l_Sender = String.Empty;

            if (sender is SocketClient c)
            {
                l_Sender = c.IpAddressAndPortBuffered;
            }

            this.Log($"{l_Sender} Connection has updated with result code: {(int)result} ({result})".Trim());
        }

        internal void Log(string msg, object sender = null)
        {
            //Invokes no logner required

            //if (InvokeRequired)
            //{
            //    this.Invoke(new Action<string>(Log), new object[] { msg });
            //    return;
            //}

            string l_Sender = String.Empty;

            if (sender is SocketClient c)
            {
                l_Sender = c.IpAddressAndPortBuffered;
            }

            this.tbConnectionLog.AppendText($"{l_Sender} {msg}".Trim() + "\r\n");
        }

        internal async Task ComLog(byte[] iData, int iLength, bool isNotIncomingButOutgoing, SocketClient iSender = null)
        {
            if (this._silentMode)
                return;

            string msg = String.Empty;
            string msgBytes = String.Empty;
            string prefix = String.Empty;
            string sender = String.Empty;

            sender = (iSender == null) ? String.Empty : iSender.IpAddressAndPortBuffered;

            if (isNotIncomingButOutgoing)
            {
                if (iSender != null)
                {
                    prefix = sender + " <- ";
                }

                prefix += $"SNT[{iLength}] ";
            }
            else
            {
                if (iSender != null)
                {
                    prefix = sender + " -> ";
                }

                prefix += $"RCV[{iLength}] ";
            }


            msg = await Task<string>.Run(() =>
            {
                return Encoding.UTF8.GetString(iData);
            });

            if (!isNotIncomingButOutgoing)
            {
                this.tbClearData.AppendText(msg);

                await Task<string>.Run(() =>
                {
                    foreach (byte b in iData)
                        msgBytes += b.ToString() + " ";
                });

                this.tbRawData.AppendText(msgBytes);
            }

            this.tbUserFriendlyData.AppendText(prefix + ControlChars.ReplaceControlChars(msg) + "\r\n");
        }

        private object GetSender()
        {
            object sender = null;

            if (this.tabSettings.SelectedIndex == 2)
            {
                if (this._tcpClient != null && this._tcpClient.Connected)
                {
                    return this._tcpClient;
                }
            }
            if (this.tabSettings.SelectedIndex == 1)
            {
                if (this._tcpServer != null)
                {
                    if (this._tcpServer.Clients.Count > 0)
                    {
                        return this._tcpServer;
                    }
                }
            }

            return sender;
        }

        private void ShortcutManager(byte iByte)
        {
            byte[] data = new byte[] { iByte };

            if (this.chkSend.Checked)
            {
                this.Send(this.GetSender(), data);
            }
            else
            {
                this.tbSend.AppendText(Encoding.UTF8.GetString(data));
                this.tbSend.Focus();
            }
        }

        private void Send(object sender, byte[] iData)
        {
            if (sender is TcpClientCommunication t)
            {
                t.Send(iData, t.Client);
            }
            else if (sender is TcpServerCommunication s)
            {
                s.Send(iData, (SocketClient)this.dgClients.SelectedRows[0].Cells["colSocketClient"].Value);
            }

        }

        private void Send(object sender, string iData)
        {
            this.Send(sender, Encoding.UTF8.GetBytes(this.tbSend.Text));
        }

        private void btnClientSend_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.tbSend.Text))
            {
                this.Send(this.GetSender(), this.tbSend.Text);

                if (this.chkClearSend.Checked && !this.chkAutoResponse.Checked)
                {
                    this.tbSend.Text = String.Empty;
                }
            }
        }

        private void btnShortcut_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            switch (button.Name)
            {
                case "btnSOH":
                    this.ShortcutManager(1);
                    break;
                case "btnSTX":
                    this.ShortcutManager(2);
                    break;
                case "btnETX":
                    this.ShortcutManager(3);
                    break;
                case "btnEOT":
                    this.ShortcutManager(4);
                    break;
                case "btnENQ":
                    this.ShortcutManager(5);
                    break;
                case "btnACK":
                    this.ShortcutManager(6);
                    break;
                case "btnBEL":
                    this.ShortcutManager(7);
                    break;
                case "btnBS":
                    this.ShortcutManager(8);
                    break;
                case "btnHT":
                    this.ShortcutManager(9);
                    break;
                case "btnLF":
                    this.ShortcutManager(10);
                    break;
                case "btnVT":
                    this.ShortcutManager(11);
                    break;
                case "btnFF":
                    this.ShortcutManager(12);
                    break;
                case "btnCR":
                    this.ShortcutManager(13);
                    break;
                case "btnSO":
                    this.ShortcutManager(14);
                    break;
                case "btnSI":
                    this.ShortcutManager(15);
                    break;
                case "btnDLE":
                    this.ShortcutManager(16);
                    break;
                case "btnNAK":
                    this.ShortcutManager(21);
                    break;
                case "btnSYN":
                    this.ShortcutManager(22);
                    break;
                case "btnETB":
                    this.ShortcutManager(23);
                    break;
                case "btnCAN":
                    this.ShortcutManager(24);
                    break;
                case "btnEM":
                    this.ShortcutManager(25);
                    break;
                case "btnSUB":
                    this.ShortcutManager(26);
                    break;
                case "btnESC":
                    this.ShortcutManager(27);
                    break;
                case "btnFS":
                    this.ShortcutManager(28);
                    break;
                case "btnGS":
                    this.ShortcutManager(29);
                    break;
                case "btnRS":
                    this.ShortcutManager(30);
                    break;
                case "btnUS":
                    this.ShortcutManager(31);
                    break;
                case "btnDEL":
                    this.ShortcutManager(127);
                    break;
                default:
                    break;
            }
        }

        private async void btnClientConnect_Click(object sender, EventArgs e)
        {
            if (this.btnClientConnect.Text == "Connect")
            {
                this._tcpClient = new TcpClientCommunication(this, this.ifClientIp.Text, this.ifClientPort.Text, this.ifClientBufferSize.Text, this.ifClientTimeout.Text);
                this._tcpClient.Connect();
            }
            else
            {
                if (this._tcpClient.Client.Connected)
                {
                    await this._tcpClient.Close();
                    this._tcpClient = null;
                }
            }
        }

        private async void btnServerOpen_Click(object sender, EventArgs e)
        {
            if (this.btnServerOpen.Text == "Open")
            {
                try
                {
                    this._tcpServer = new TcpServerCommunication(this, this.ifServerIp.Text, this.ifServerPort.Text, this.ifServerBufferSize.Text, this.ifServerMaxClients.Text, this.ifServerBacklog.Text);
                }
                catch (ArgumentOutOfRangeException)
                {
                    return;
                }

                this._tcpServer.CreateSocket();

                this.SetUpClientsDataSource();
                //this.UpdateClientsDataSource();

                if (this._tcpServer.ConnectionResult != ConnectionResult.Success)
                {
                    this.ResultLog(this._tcpServer.ConnectionResult);

                    return;
                }

                this._tcpServer.InitServer();

                if (this._tcpServer.ConnectionResult != ConnectionResult.ServerListening)
                {
                    this.ResultLog(this._tcpServer.ConnectionResult);

                    return;
                }

                this.ResultLog(this._tcpServer.ConnectionResult);

                this._tcpServer.Open();
            }
            else
            {
                this.btnServerOpen.Enabled = false;

                await this._tcpServer.Close();

                this.btnServerOpen.Text = "Open";
                this.btnServerOpen.Enabled = true;
            }
        }

        private void btnKickClient_Click(object sender, EventArgs e)
        {
            if (this._tcpServer == null)
                return;

            if (this._tcpServer.Clients.Count == 0)
            {
                this.Log("0 clients connected");

                return;
            }

            this._tcpServer.DisconnectClinet((SocketClient)this.dgClients.SelectedRows[0].Cells["colSocketClient"].Value);
        }

        private void chkSilentMode_CheckedChanged(object sender, EventArgs e)
        {
            this._silentMode = ((CheckBox)sender).Checked;
        }
    }
}
