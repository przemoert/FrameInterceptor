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
using CommunicationManager;


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
    public partial class Form1 : Form
    {
        private ComManager _comManager;
        private bool _abort = false;

        public Form1()
        {
            InitializeComponent();

        }

        private async void OpenCommunication()
        {
            if (this._abort)
            {
                Log("All actions aborted by user");

                this._abort = false;
                this.SetButtonToConnect();

                return;
            }

            if (this.tabSettings.SelectedIndex == 2)
            {
                this._comManager = new ComManager(this.tbClientIp.Text, this.tbClientPort.Text, true);
            }
            else if (this.tabSettings.SelectedIndex == 1)
            {
                if (String.IsNullOrEmpty(this.tbServerIp.Text))
                {
                    this._comManager = new ComManager(this.tbServerPort.Text);
                }
                else
                {
                    this._comManager = new ComManager(this.tbServerIp.Text, this.tbServerPort.Text, false);
                }
            }

            this._comManager.DataRecieved -= new EventHandler<DataReceivedEventArgs>(this.OnDataReceived);
            this._comManager.DataRecieved += new EventHandler<DataReceivedEventArgs>(this.OnDataReceived);

            ConnectionResult result = (ConnectionResult)await this._comManager.Open();

            this.Log($"Connection completed with result code: {(int)result} ({result})");

            if (result != ConnectionResult.Success && result != ConnectionResult.HandlerDisposed)
            {
                //When not connected
                if (this._comManager.Communication is TcpClientCommunication c)
                {
                    this.Log("Waiting before next connection attempt...");
                    await Task.Delay(5000);

                    this.Log("Retrying...");
                    this.OpenCommunication();
                }
            }
            else if (result == ConnectionResult.HandlerDisposed)
            {
                //Handler disposed. Should only happend when user aborts after object creation. Any other occurence is highly distrubing.
                this.SetButtonToConnect();
            }
            else if (result == ConnectionResult.Success)
            {
                this.SetButtonToDisconnect();
                //When connected, opened or whatever

                if (this._comManager.Communication is TcpClientCommunication c)
                {
                    Log($"Connected to {c.Client.IPAddress}:{c.Client.Port}");
                }
                //else if (this._comManager.Communication is TcpServerCommunication s)
                //{
                //    Log($"Connection from {s.TcpServer.RemoteIpAddress}:{s.TcpServer.RemotePort}");
                //}
            }
        }

        private void OnDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.DataLength > 0)
            {
                this.ComLog(e.Data, e.DataLength, false);
            }
            else
            {
                this.Log($"Connection has ended with result code: {(int)this._comManager.Communication.ConnectionResult} ({this._comManager.Communication.ConnectionResult})");

                this.SetButtonToConnect();
            }
        }

        private void btnClientConnect_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (button.Text == "Abort")
            {
                button.Enabled = false;
                this._abort = true;
                this._comManager.Dispose();
            }
            else if (button.Text == "Disconnect")
            {
                this._comManager.Close();
                this.SetButtonToConnect();
            }
            else if (button.Text == "Connect")
            {
                this.SetButtonToAbort();
                this.OpenCommunication();
            }
        }

        private void SetButtonToConnect()
        {
            this.btnConnect.Enabled = true;
            this.btnConnect.Text = "Connect";
            this._abort = false;
        }

        private void SetButtonToDisconnect()
        {
            this.btnConnect.Enabled = true;
            this.btnConnect.Text = "Disconnect";
            this._abort = false;
        }

        private void SetButtonToAbort()
        {
            this.btnConnect.Enabled = true;
            this.btnConnect.Text = "Abort";
            this._abort = false;
        }

        private void Send(byte[] iData)
        {
            if (this._comManager != null && this._comManager.IsConnected)
            {
                int bytesSend = this._comManager.SendData(iData);
                this.ComLog(iData, bytesSend, true);
            }
        }

        private void Log(string msg)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(Log), new object[] { msg });
                return;
            }

            this.tbConnectionLog.AppendText(msg + "\r\n");
        }

        private void ComLog(byte[] iData, int iLength, bool isNotIncomingButOutgoing)
        {
            string msg = String.Empty;
            string prefix = String.Empty;

            if (isNotIncomingButOutgoing)
            {
                prefix = "SNT[" + iLength + "] ";
            }
            else
            {
                prefix = "RCV[" + iLength + "] ";
            }

            msg = Encoding.UTF8.GetString(iData);

            if (!isNotIncomingButOutgoing)
            {
                this.tbClearData.AppendText(msg);

                foreach (byte b in iData)
                    this.tbRawData.AppendText(b.ToString() + " ");
            }

            this.tbUserFriendlyData.AppendText(prefix + this.ReplaceControlChars(msg) + "\r\n");
        }

        private string ReplaceControlChars(string iMessage)
        {
            iMessage = iMessage.Replace(ControlChars.SOH.ToString(), "<SOH>");
            iMessage = iMessage.Replace(ControlChars.STX.ToString(), "<STX>");
            iMessage = iMessage.Replace(ControlChars.ETX.ToString(), "<ETX>");
            iMessage = iMessage.Replace(ControlChars.EOT.ToString(), "<EOT>");
            iMessage = iMessage.Replace(ControlChars.ENQ.ToString(), "<ENQ>");
            iMessage = iMessage.Replace(ControlChars.ACK.ToString(), "<ACK>");
            iMessage = iMessage.Replace(ControlChars.BEL.ToString(), "<BEL>");
            iMessage = iMessage.Replace(ControlChars.BS.ToString(), "<BS>");
            iMessage = iMessage.Replace(ControlChars.HT.ToString(), "<HT>");
            iMessage = iMessage.Replace(ControlChars.LF.ToString(), "<LF>");
            iMessage = iMessage.Replace(ControlChars.VT.ToString(), "<VT>");
            iMessage = iMessage.Replace(ControlChars.FF.ToString(), "<FF>");
            iMessage = iMessage.Replace(ControlChars.CR.ToString(), "<CR>");
            iMessage = iMessage.Replace(ControlChars.SO.ToString(), "<SO>");
            iMessage = iMessage.Replace(ControlChars.SI.ToString(), "<SI>");
            iMessage = iMessage.Replace(ControlChars.DLE.ToString(), "<DLE>");
            iMessage = iMessage.Replace(ControlChars.NAK.ToString(), "<NAK>");
            iMessage = iMessage.Replace(ControlChars.SYN.ToString(), "<SYN>");
            iMessage = iMessage.Replace(ControlChars.ETB.ToString(), "<ETB>");
            iMessage = iMessage.Replace(ControlChars.CAN.ToString(), "<CAN>");
            iMessage = iMessage.Replace(ControlChars.EM.ToString(), "<EM>");
            iMessage = iMessage.Replace(ControlChars.SUB.ToString(), "<SUB>");
            iMessage = iMessage.Replace(ControlChars.ESC.ToString(), "<ESC>");
            iMessage = iMessage.Replace(ControlChars.FS.ToString(), "<FS>");
            iMessage = iMessage.Replace(ControlChars.GS.ToString(), "<GS>");
            iMessage = iMessage.Replace(ControlChars.RS.ToString(), "<RS>");
            iMessage = iMessage.Replace(ControlChars.US.ToString(), "<US>");
            iMessage = iMessage.Replace(ControlChars.DEL.ToString(), "<DEL>");

            return iMessage;
        }

        private void ShortcutManager(byte iByte)
        {
            byte[] data = new byte[] { iByte };

            if (this.chkSend.Checked)
            {
                this.Send(data);
            }
            else
            {
                this.tbSend.AppendText(Encoding.UTF8.GetString(data));
                this.tbSend.Focus();
            }
        }

        private void btnClientSend_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.tbSend.Text))
            {
                this.Send(Encoding.UTF8.GetBytes(this.tbSend.Text));
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
    }
}
