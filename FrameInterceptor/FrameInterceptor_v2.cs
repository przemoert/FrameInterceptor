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
using FrameInterceptor.Frames;
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
        private bool _formKeyDown = false;

        public FrameInterceptor_v2()
        {
            InitializeComponent();

            this.SetupControls();
            this.SetupMacroBindings();

            Settings.Instance.CodePage = Int32.Parse(this.icEncoding.Value.ToString());

            //this._globalKeys = new GlobalKeys();
            //this._globalKeys.HookKeyboard();
            this.KeyPreview = true;
            this._macroRunning = false;
        }

        private void SetupControls()
        {
#if !DEBUG
    this.tabSettings.TabPages.RemoveAt(6);
    this.tabSettings.TabPages.RemoveAt(4);
#endif
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

            this._silentMode = this.chkSilentMode.Checked;
            this.tbSend.TranslateControlChars = this.chkTranslateSendChars.Checked;
            this.tbCheckSumInput.TranslateControlChars = this.chkTranslateSendChars.Checked;

            this.SetupIcEncodingItems();
        }

        private void SetupIcEncodingItems()
        {
            int[] l_CodePages = { 1250, 1252, 65000, 65001, 1200, 20127 };

            this.icEncoding.DataSource = l_CodePages;
            this.icEncoding.SelectedIndex = 1;
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
        }

        private void SaveLogs()
        {
            if (String.IsNullOrEmpty(tbUserFriendlyData.Text))
                return;

            string l_Directory = @"Logs\" + DateTime.Now.ToString("yyyyMMddHHmmss");

            DFile l_FriendlyFile = new DFile(this.tbUserFriendlyData.Text);
            l_FriendlyFile.Directory = l_Directory;
            l_FriendlyFile.Name = "Friendly.txt";

            DFile l_IncomingFile = new DFile(this.tbClearData.Text);
            l_IncomingFile.Directory = l_Directory;
            l_IncomingFile.Name = "ClearIncoming.txt";

            DFile l_RawFile = new DFile(this.tbRawData.Text);
            l_RawFile.Directory = l_Directory;
            l_RawFile.Name = "Raw.txt";

            l_FriendlyFile.WriteFile();
            l_IncomingFile.WriteFile();
            l_RawFile.WriteFile();

            if (String.IsNullOrEmpty(this.tbConnectionLog.Text))
                return;

            DFile l_ConnectionLogFile = new DFile(this.tbConnectionLog.Text);
            l_ConnectionLogFile.Directory = l_Directory;
            l_ConnectionLogFile.Name = "ConnectionLog.txt";

            l_ConnectionLogFile.WriteFile();
        }

        private void AddMacroCommand()
        {
            if (!String.IsNullOrEmpty(this.tbSend.Text))
            {
                this._macroCommandsBinding.Add(new MacroCommand(this.tbSend.Text));
            }

            this.DeselectMacroGrids();
        }

        private void AddMacroResponse()
        {
            if (!String.IsNullOrEmpty(this.tbSend.Text))
            {
                this._macroResponsesBinding.Add(new MacroCommand(this.tbSend.Text));
            }

            this.DeselectMacroGrids();
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
            string l_Timestamp = String.Empty;

            if (sender is SocketClient c)
            {
                l_Sender = c.IpAddressAndPortBuffered;
            }

            if (this.chkTimestamps.Checked)
            {
                l_Timestamp = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "]";
            }

            this.tbConnectionLog.AppendText($"{l_Timestamp} {l_Sender} {msg}".Trim() + "\r\n");
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
                //return Encoding.UTF8.GetString(iData);
                return Settings.Instance.Encoding.GetString(iData);
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

            this.tbUserFriendlyData.AppendText("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) + "] " + prefix + ControlChars.ReplaceControlChars(msg) + "\r\n");
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
            else
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

        private void Send(byte[] iData)
        {
            object l_Sender = this.GetSender();

            if (l_Sender is TcpClientCommunication t)
            {
                t.Send(iData, t.Client);
            }
            else if (l_Sender is TcpServerCommunication s)
            {
                s.Send(iData, (SocketClient)this.dgClients.SelectedRows[0].Cells["colSocketClient"].Value);
            }
            else if (l_Sender is SerialCommunication r)
            {
                r.Send(iData);
            }

        }

        private void Send(string iData)
        {
            //this.Send(Encoding.UTF8.GetBytes(iData));
            this.Send(Settings.Instance.Encoding.GetBytes(iData));
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
                this.Send(l_DataToSend);
            }

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

        private void DeselectMacroGrids(object iSender = null)
        {
            DataGridView[] l_Grids = FormHelper.GetAllControls<DataGridView>(this.gbMacros);

            foreach (DataGridView d in l_Grids)
            {
                if (!object.ReferenceEquals(d, iSender))
                {
                    //d.ClearSelection();

                    //This is faster
                    if (d.SelectedRows.Count > 0)
                        d.Rows[d.SelectedRows[0].Index].Selected = false;
                }
            }
        }

#region Events

        private void btnClientSend_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.tbSend.Text))
            {
                this.Send(this.tbSend.Text);

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
                this.Send(l_DataToSend);
            }
            else
            {
                //this.tbSend.AppendText(Encoding.UTF8.GetString(l_DataToSend));
                this.tbSend.AppendText(Settings.Instance.Encoding.GetString(l_DataToSend));
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
            this.AddMacroCommand();
        }
        private void btnMacroAddResponse_Click(object sender, EventArgs e)
        {
                this.AddMacroResponse();
        }

        private void btnMacroRemove_Click(object sender, EventArgs e)
        {
            this.RemoveSelectedMacro();
        }

        private void MacroDataGrid_Click(object sender, EventArgs e)
        {
            this.DeselectMacroGrids(sender);
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

        private void btnMacroBottom_Click(object sender, EventArgs e)
        {
            if (this.dgMacroCommands.SelectedRows.Count == 1 && this.dgMacroCommands.Rows.Count > 0)
            {
                int l_Index = this.dgMacroCommands.SelectedRows[0].Index;

                if (l_Index < this.dgMacroCommands.Rows.Count - 1)
                {
                    MacroCommand l_Tempt = this._macroCommandsBinding[l_Index + 1];

                    this._macroCommandsBinding[l_Index + 1] = this._macroCommandsBinding[l_Index];
                    this._macroCommandsBinding[l_Index] = l_Tempt;

                    this.dgMacroCommands.Rows[l_Index + 1].Selected = true;
                }
            }
        }

        private void btnMacroTop_Click(object sender, EventArgs e)
        {
            if (this.dgMacroCommands.SelectedRows.Count == 1 && this.dgMacroCommands.Rows.Count > 0)
            {
                int l_Index = this.dgMacroCommands.SelectedRows[0].Index;

                if (l_Index > 0)
                {
                    MacroCommand l_Temp = this._macroCommandsBinding[l_Index - 1];

                    this._macroCommandsBinding[l_Index - 1] = this._macroCommandsBinding[l_Index];
                    this._macroCommandsBinding[l_Index] = l_Temp;

                    this.dgMacroCommands.Rows[l_Index - 1].Selected = true;
                }
            }
        }

        private void dgMacroCommands_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ((DataGridView)sender).BeginEdit(true);
        }

        private void btnRefreshPorts_Click(object sender, EventArgs e)
        {
            string[] l_PortList = SerialCommunication.GetPortNames();

            this.icSerialPort.DataSource = null;
            this.icSerialPort.DataSource = l_PortList;

            this.Log("Ports found:");

            for (int i = 0; i < l_PortList.Length; i++)
            {
                this.Log(l_PortList[i]);
            }
        }
        private void btnSaveLogs_Click(object sender, EventArgs e)
        {
            this.SaveLogs();
        }
        
        private void chkTranslateSendChars_CheckedChanged(object sender, EventArgs e)
        {
            this.tbSend.TranslateControlChars = this.chkTranslateSendChars.Checked;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (!this._formKeyDown)
            {
                this._formKeyDown = true;

                if (e.KeyCode == Keys.F2)
                {
                    this.AddMacroCommand();
                }
                else if (e.KeyCode == Keys.F12)
                {
                    if (this.dgMacroCommands.Rows.Count > 0)
                    {
                        if (this.dgMacroCommands.SelectedRows.Count == 0)
                            this.dgMacroCommands.Rows[0].Selected = true;

                        int l_Index = this.dgMacroCommands.SelectedRows[0].Index;

                        this.Send(this._macroCommandsBinding[l_Index].ByteData);

                        int l_NextIndex = (l_Index + 1 == this.dgMacroCommands.Rows.Count) ? 0 : l_Index + 1;

                        this.dgMacroCommands.Rows[l_NextIndex].Selected = true;
                    }
                }
            }

            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            this._formKeyDown = false;

            base.OnKeyUp(e);
        }

        private void icEncoding_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Instance.CodePage = Int32.Parse(this.icEncoding.Value.ToString());
        }

        private void tbCheckSumInput_TextChanged(object sender, EventArgs e)
        {
            //if (String.IsNullOrEmpty(this.tbCheckSumInput.Text))
            //    return;

            Checksum l_CheckSum = new Checksum(this.tbCheckSumInput.Text);

            this.ifSum8Mod256.Text = l_CheckSum.CheckSum8Mod256_Hex;
            this.ifSum8Xor.Text = l_CheckSum.CheckSum8Xor_Hex;
            this.ifSum2sComp.Text = l_CheckSum.CheckSum2sComp_Hex;
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            String frame = @"H|^\&|TestPart|^^SubFiled1^|Field1|SubField2^|Costam|ICostam";

            Node node = new Node(frame, new char[] { '|', '^' });

            Node l_Node = node;

            do
            {
                l_Node = l_Node.Next;
            } while (l_Node != null);

            //node.OneByOne(c => 
            //{
            //    c.Value = c.Value?.ToUpper();
            //});
        }
    }
}
