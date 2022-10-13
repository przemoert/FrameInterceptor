using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Communication;
using FrameInterceptor.Communication;
using FrameInterceptor.CustomControls;
using FrameInterceptor.Utils;


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
        private SerialCommunication _serial;
        //private BindingSource ClientsBindigs = null;
        private bool _silentMode;
        private BindingList<MacroCommand> _macroCommandsBinding = new BindingList<MacroCommand>();
        private BindingList<MacroCommand> _macroResponsesBinding = new BindingList<MacroCommand>();
        private bool _macroRunning;
        private MacroRun _macroRun;

        public FrameInterceptor_v2()
        {
            InitializeComponent();

            this.SetupControls();
            this.SetupMacroBindings();

            this._silentMode = this.chkSilentMode.Checked;
            this._macroRunning = false;
        }

        private void SetupControls()
        {
            this.icServerBufferOptions.DataSource = Enum.GetValues(typeof(BufferOptions));
            this.icClientBufferOptions.DataSource = Enum.GetValues(typeof(BufferOptions));
            
            this.icSerialPort.DataSource = SerialCommunication.GetPortNames();

            this.icSerialBaudRate.DataSource = SerialCommunication.BaudRatesArray;
            this.icSerialBaudRate.SelectedIndex = 4;

            this.icSerialDataBits.DataSource = SerialCommunication.DataBits;
            this.icSerialDataBits.SelectedIndex = 3;

            this.icSerialHandshake.DataSource = Enum.GetValues(typeof(Handshake));

            this.icSerialStopBits.DataSource = Enum.GetValues(typeof(StopBits));
            this.icSerialStopBits.SelectedIndex = 1;

            this.icSerialParity.DataSource = Enum.GetValues(typeof(Parity));

            this.chkRTS.Enabled = false;
            this.chkDTR.Enabled = false;
        }

        private void SetUpClientsDataSource()
        {
            this.dgClients.AutoGenerateColumns = false;
            dgClients.DataSource = this._tcpServer.Clients;
        }

        private void SetupMacroBindings()
        {
            this.dgMacroCommands.AutoGenerateColumns = false;
            this.dgMacroCommands.DataSource = this._macroCommandsBinding;

            this.dgMacroReponses.AutoGenerateColumns = false;
            this.dgMacroReponses.DataSource = this._macroResponsesBinding;

            //TESTS
            //this.AddMacroCommand("Test1");
            //this.AddMacroCommand("Test2");
            //this.AddMacroCommand("Test3");
            //this.AddMacroCommand("Test4");
            //this.AddMacroCommand("Test5");
            //this.AddMacroCommand("Test6");

            //byte[] t = new byte[] { 6 };
            //this.AddMacroResponse(Encoding.UTF8.GetString(t));
        }

        private void AddMacroCommand(string iCommand)
        {
            this._macroCommandsBinding.Add(new MacroCommand(iCommand));
        }

        private void AddMacroResponse(string iCommand)
        {
            this._macroResponsesBinding.Add(new MacroCommand(iCommand));
        }

        private void RemoveSelectedMacro()
        {
            if (this.dgMacroCommands.SelectedRows.Count > 0)
            {
                this.dgMacroCommands.Rows.RemoveAt(this.dgMacroCommands.SelectedRows[0].Index);
            }
            else if (this.dgMacroReponses.SelectedRows.Count > 0)
            {
                this.dgMacroReponses.Rows.RemoveAt(this.dgMacroReponses.SelectedRows[0].Index);
            }

            this.DeselectMacroGrids();
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
            string l_Sender = String.Empty;

            if (sender is SocketClient c)
            {
                l_Sender = c.IpAddressAndPortBuffered;
            }

            this.tbConnectionLog.AppendText($"{l_Sender} {msg}".Trim() + "\r\n");
        }

        internal async Task ComLog(byte[] iData, int iLength, bool isNotIncomingButOutgoing, SocketClient iSender = null)
        {
            if (this._macroRunning && !this._macroRun.SerialSending && !isNotIncomingButOutgoing)
                this.MacroNext(iData);

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
            else if (this.tabSettings.SelectedIndex == 1)
            {
                if (this._tcpServer != null)
                {
                    if (this._tcpServer.Clients.Count > 0)
                    {
                        return this._tcpServer;
                    }
                }
            }
            else if (this.tabSettings.SelectedIndex == 0)
            {
                if (this._serial != null)
                {
                    if (this._serial.IsOpen)
                    {
                        return this._serial;
                    }
                }
            }

            return sender;
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
            else if (sender is SerialCommunication r)
            {
                r.Send(iData);
            }

        }

        private void Send(object sender, string iData)
        {
            this.Send(sender, Encoding.UTF8.GetBytes(this.tbSend.Text));
        }

        public void SerialChangeStatus(bool IsClosing)
        {
            if (!IsClosing)
            {
                this.btnSerialOpen.Text = "Close";
                this.chkDTR.Enabled = true;

                if (this._serial.RtsAllowed)
                    this.chkRTS.Enabled = true;
            }
            else
            {
                this.btnSerialOpen.Text = "Open";
                this.chkDTR.Enabled = false;
                this.chkRTS.Enabled = false;

                this.ldCD.On = false;
                this.ldCTS.On = false;
                this.ldDSR.On = false;
                this.ldRI.On = false;
            }
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

        private void OnTypeAreaButtonClicked(object sender, TypeAreaEventArgs e)
        {
            byte[] l_DataToSend = new byte[] { e.Code };

            if (this.tpShortcuts.SendCheckboxChecked)
            {
                this.Send(this.GetSender(), l_DataToSend);
            }
            else
            {
                this.tbSend.AppendText(Encoding.UTF8.GetString(l_DataToSend));
                this.tbSend.Focus();
            }
        }

        private void btnSerialOpen_Click(object sender, EventArgs e)
        {
            if (this.btnSerialOpen.Text == "Open")
            {
                if (this.icSerialPort.Count > 0)
                {
                    this._serial = new SerialCommunication(this);
                    this._serial.Open();

                    if (this._serial.ConenctionResult == ConnectionResult.Success)
                        this.SerialChangeStatus(false);
                }
            }
            else
            {
                this._serial.Close();

                this.SerialChangeStatus(true);
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
                await this._tcpClient.Close();
                this._tcpClient = null;
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
                this.dgClients.DataSource = null;
                this._tcpServer = null;

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

        private void btnClearLogs_Click(object sender, EventArgs e)
        {
            this.tbUserFriendlyData.Text = String.Empty;
            this.tbClearData.Text = String.Empty;
            this.tbRawData.Text = String.Empty;

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private void chkDTR_CheckedChanged(object sender, EventArgs e)
        {
            this._serial.SerialDtr = ((CheckBox)sender).Checked;
        }

        private void chkRTS_CheckedChanged(object sender, EventArgs e)
        {
            this._serial.SerialRts = ((CheckBox)sender).Checked;
        }

        private void btnMacroAddCommand_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.tbSend.Text))
            {
                this.AddMacroCommand(this.tbSend.Text);
            }

            this.DeselectMacroGrids();
        }
        private void btnMacroAddResponse_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.tbSend.Text))
            {
                this.AddMacroResponse(this.tbSend.Text);
            }

            this.DeselectMacroGrids();
        }

        private void btnMacroRemove_Click(object sender, EventArgs e)
        {
            this.RemoveSelectedMacro();
        }

        private void MacroDataGrid_Click(object sender, EventArgs e)
        {
            this.DeselectMacroGrids(sender);
        }

        private void DeselectMacroGrids(object iSender = null)
        {
            DataGridView[] l_Grids = FormHelper.GetAllControls<DataGridView>(this.gbMacros);

            foreach (DataGridView d in l_Grids)
            {
                if (!object.ReferenceEquals(d, iSender))
                {
                    d.ClearSelection();
                }
            }
        }

        private void btnRunMacro_Click(object sender, EventArgs e)
        {
            if (this._macroCommandsBinding.Count > 0)
            {
                if (this._macroRun != null && !this._macroRun.Disposed)
                    this._macroRun.Dispose();

                this._macroRunning = true;

                this.RunMacro();
            }
        }

        private void RunMacro()
        {
            this._macroRun = new MacroRun(this._macroCommandsBinding.ToList(), this._macroResponsesBinding.ToList());

            this.MacroNext();
        }

        private void MacroNext(byte[] iMessage = null)
        {
            if (this._macroRun == null)
                throw new ArgumentNullException();

            byte[] l_DataToSend = new byte[this._macroRun.NextLength];

            if (this._macroRun.FirstRun || this._macroRun.IsAccepted(iMessage))
            {
                this._macroRun.Next(out l_DataToSend);
                this.Send(this.GetSender(), l_DataToSend);
            }
            //else if (this._macroRun.IsAccepted(iMessage))
            //{
            //    this._macroRun.Next(out l_DataToSend);
            //    this.Send(this.GetSender(), l_DataToSend);
            //}

            if (this._macroRun.Completed)
            {
                this._macroRunning = false;
                this._macroRun = null;
            }
            else
            {
                if (this._macroRun.SerialSending)
                    this.MacroNext();
            }
        }
    }
}
