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
    public partial class FrameInterceptor : Form
    {
        private bool _abort = false;
        private TcpClientCommunication _tcpClient;

        public FrameInterceptor()
        {
            InitializeComponent();

        }

        internal void ResultLog(ConnectionResult result)
        {
            this.Log($"Connection has completed with result code: {(int)result} ({result})");
        }

        internal void Log(string msg)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(Log), new object[] { msg });
                return;
            }

            this.tbConnectionLog.AppendText(msg + "\r\n");
        }

        internal void ComLog(byte[] iData, int iLength, bool isNotIncomingButOutgoing)
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
                t.Send(iData);
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
                this._tcpClient = new TcpClientCommunication(this, this.tbClientIp.Text, this.tbClientPort.Text);
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
    }
}
