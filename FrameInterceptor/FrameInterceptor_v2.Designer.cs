
namespace FrameInterceptor
{
    partial class FrameInterceptor_v2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrameInterceptor_v2));
            this.tabSettings = new System.Windows.Forms.TabControl();
            this.tabSerial = new System.Windows.Forms.TabPage();
            this.btnRefreshPorts = new System.Windows.Forms.Button();
            this.chkDTR = new System.Windows.Forms.CheckBox();
            this.chkRTS = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ldCD = new FrameInterceptor.CustomControls.Led();
            this.ldRI = new FrameInterceptor.CustomControls.Led();
            this.ldDSR = new FrameInterceptor.CustomControls.Led();
            this.ldCTS = new FrameInterceptor.CustomControls.Led();
            this.btnSerialOpen = new System.Windows.Forms.Button();
            this.icSerialParity = new FrameInterceptor.CustomControls.InputCombo();
            this.icSerialStopBits = new FrameInterceptor.CustomControls.InputCombo();
            this.icSerialDataBits = new FrameInterceptor.CustomControls.InputCombo();
            this.icSerialHandshake = new FrameInterceptor.CustomControls.InputCombo();
            this.icSerialBaudRate = new FrameInterceptor.CustomControls.InputCombo();
            this.icSerialPort = new FrameInterceptor.CustomControls.InputCombo();
            this.tabServer = new System.Windows.Forms.TabPage();
            this.icServerBufferOptions = new FrameInterceptor.CustomControls.InputCombo();
            this.ifServerBufferSize = new FrameInterceptor.CustomControls.InputFiled();
            this.ifServerBacklog = new FrameInterceptor.CustomControls.InputFiled();
            this.ifServerMaxClients = new FrameInterceptor.CustomControls.InputFiled();
            this.ifServerPort = new FrameInterceptor.CustomControls.InputFiled();
            this.ifServerIp = new FrameInterceptor.CustomControls.InputFiled();
            this.btnServerOpen = new System.Windows.Forms.Button();
            this.tabClient = new System.Windows.Forms.TabPage();
            this.ifClientTimeout = new FrameInterceptor.CustomControls.InputFiled();
            this.icClientBufferOptions = new FrameInterceptor.CustomControls.InputCombo();
            this.ifClientBufferSize = new FrameInterceptor.CustomControls.InputFiled();
            this.ifClientPort = new FrameInterceptor.CustomControls.InputFiled();
            this.ifClientIp = new FrameInterceptor.CustomControls.InputFiled();
            this.btnClientConnect = new System.Windows.Forms.Button();
            this.tabSettingsTab = new System.Windows.Forms.TabPage();
            this.icEncoding = new FrameInterceptor.CustomControls.InputCombo();
            this.chkTranslateSendChars = new System.Windows.Forms.CheckBox();
            this.chkTimestamps = new System.Windows.Forms.CheckBox();
            this.btnSaveLogs = new System.Windows.Forms.Button();
            this.btnClearLogs = new System.Windows.Forms.Button();
            this.chkSilentMode = new System.Windows.Forms.CheckBox();
            this.tabTests = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabChecksum = new System.Windows.Forms.TabPage();
            this.ifSum2sComp = new FrameInterceptor.CustomControls.InputFiled();
            this.ifSum8Xor = new FrameInterceptor.CustomControls.InputFiled();
            this.ifSum8Mod256 = new FrameInterceptor.CustomControls.InputFiled();
            this.tbCheckSumInput = new FrameInterceptor.CustomControls.TranslatedTextBox();
            this.tabAstm = new System.Windows.Forms.TabPage();
            this.tbConnectionLog = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.tbRawData = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbClearData = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbUserFriendlyData = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dgClients = new System.Windows.Forms.DataGridView();
            this.colSocketClient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnKickClient = new System.Windows.Forms.Button();
            this.chkClearSend = new System.Windows.Forms.CheckBox();
            this.chkAutoResponse = new System.Windows.Forms.CheckBox();
            this.gbMacros = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgMacroCommands = new System.Windows.Forms.DataGridView();
            this.colByteData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStringData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbMacroResponses = new System.Windows.Forms.GroupBox();
            this.dgMacroReponses = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panMacroButtonsBottom = new System.Windows.Forms.Panel();
            this.btnMacroAddResponse = new System.Windows.Forms.Button();
            this.btnMacroAddCommand = new System.Windows.Forms.Button();
            this.panMacroButtonsTop = new System.Windows.Forms.Panel();
            this.btnMacroTop = new System.Windows.Forms.Button();
            this.btnMacroBottom = new System.Windows.Forms.Button();
            this.btnMacroRemove = new System.Windows.Forms.Button();
            this.btnRunMacro = new System.Windows.Forms.Button();
            this.panRightRight = new System.Windows.Forms.Panel();
            this.panRightLeft = new System.Windows.Forms.Panel();
            this.panRightLeftBottom = new System.Windows.Forms.Panel();
            this.panSend = new System.Windows.Forms.Panel();
            this.tbSend = new FrameInterceptor.CustomControls.TranslatedTextBox();
            this.panSendOptions = new System.Windows.Forms.Panel();
            this.tpShortcuts = new FrameInterceptor.CustomControls.TypeAreaUC();
            this.panClients = new System.Windows.Forms.Panel();
            this.panRightLeftTop = new System.Windows.Forms.Panel();
            this.panMacro = new System.Windows.Forms.Panel();
            this.panLeftFill = new System.Windows.Forms.Panel();
            this.tabSettings.SuspendLayout();
            this.tabSerial.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabServer.SuspendLayout();
            this.tabClient.SuspendLayout();
            this.tabSettingsTab.SuspendLayout();
            this.tabTests.SuspendLayout();
            this.tabChecksum.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgClients)).BeginInit();
            this.gbMacros.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMacroCommands)).BeginInit();
            this.gbMacroResponses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMacroReponses)).BeginInit();
            this.panMacroButtonsBottom.SuspendLayout();
            this.panMacroButtonsTop.SuspendLayout();
            this.panRightRight.SuspendLayout();
            this.panRightLeft.SuspendLayout();
            this.panRightLeftBottom.SuspendLayout();
            this.panSend.SuspendLayout();
            this.panSendOptions.SuspendLayout();
            this.panClients.SuspendLayout();
            this.panRightLeftTop.SuspendLayout();
            this.panMacro.SuspendLayout();
            this.panLeftFill.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.tabSerial);
            this.tabSettings.Controls.Add(this.tabServer);
            this.tabSettings.Controls.Add(this.tabClient);
            this.tabSettings.Controls.Add(this.tabSettingsTab);
            this.tabSettings.Controls.Add(this.tabTests);
            this.tabSettings.Controls.Add(this.tabChecksum);
            this.tabSettings.Controls.Add(this.tabAstm);
            this.tabSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSettings.Location = new System.Drawing.Point(0, 0);
            this.tabSettings.Margin = new System.Windows.Forms.Padding(2);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.SelectedIndex = 0;
            this.tabSettings.Size = new System.Drawing.Size(488, 122);
            this.tabSettings.TabIndex = 0;
            // 
            // tabSerial
            // 
            this.tabSerial.BackColor = System.Drawing.SystemColors.Control;
            this.tabSerial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabSerial.Controls.Add(this.btnRefreshPorts);
            this.tabSerial.Controls.Add(this.chkDTR);
            this.tabSerial.Controls.Add(this.chkRTS);
            this.tabSerial.Controls.Add(this.groupBox6);
            this.tabSerial.Controls.Add(this.btnSerialOpen);
            this.tabSerial.Controls.Add(this.icSerialParity);
            this.tabSerial.Controls.Add(this.icSerialStopBits);
            this.tabSerial.Controls.Add(this.icSerialDataBits);
            this.tabSerial.Controls.Add(this.icSerialHandshake);
            this.tabSerial.Controls.Add(this.icSerialBaudRate);
            this.tabSerial.Controls.Add(this.icSerialPort);
            this.tabSerial.Location = new System.Drawing.Point(4, 22);
            this.tabSerial.Margin = new System.Windows.Forms.Padding(2);
            this.tabSerial.Name = "tabSerial";
            this.tabSerial.Padding = new System.Windows.Forms.Padding(2);
            this.tabSerial.Size = new System.Drawing.Size(480, 96);
            this.tabSerial.TabIndex = 0;
            this.tabSerial.Text = "Serial";
            // 
            // btnRefreshPorts
            // 
            this.btnRefreshPorts.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRefreshPorts.Location = new System.Drawing.Point(302, 5);
            this.btnRefreshPorts.Name = "btnRefreshPorts";
            this.btnRefreshPorts.Size = new System.Drawing.Size(84, 19);
            this.btnRefreshPorts.TabIndex = 37;
            this.btnRefreshPorts.Text = "Refresh Ports";
            this.btnRefreshPorts.UseVisualStyleBackColor = true;
            this.btnRefreshPorts.Click += new System.EventHandler(this.btnRefreshPorts_Click);
            // 
            // chkDTR
            // 
            this.chkDTR.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chkDTR.Location = new System.Drawing.Point(246, 5);
            this.chkDTR.Name = "chkDTR";
            this.chkDTR.Size = new System.Drawing.Size(44, 19);
            this.chkDTR.TabIndex = 36;
            this.chkDTR.Text = "DTR";
            this.chkDTR.UseVisualStyleBackColor = true;
            this.chkDTR.CheckedChanged += new System.EventHandler(this.chkDTR_CheckedChanged);
            // 
            // chkRTS
            // 
            this.chkRTS.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chkRTS.Location = new System.Drawing.Point(246, 26);
            this.chkRTS.Name = "chkRTS";
            this.chkRTS.Size = new System.Drawing.Size(44, 19);
            this.chkRTS.TabIndex = 35;
            this.chkRTS.Text = "RTS";
            this.chkRTS.UseVisualStyleBackColor = true;
            this.chkRTS.CheckedChanged += new System.EventHandler(this.chkRTS_CheckedChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.ldCD);
            this.groupBox6.Controls.Add(this.ldRI);
            this.groupBox6.Controls.Add(this.ldDSR);
            this.groupBox6.Controls.Add(this.ldCTS);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox6.Location = new System.Drawing.Point(334, 30);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(142, 61);
            this.groupBox6.TabIndex = 24;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Lines";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(113, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "CD";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(81, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "RI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "DSR";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "CTS";
            // 
            // ldCD
            // 
            this.ldCD.Location = new System.Drawing.Point(112, 34);
            this.ldCD.Margin = new System.Windows.Forms.Padding(7, 3, 7, 3);
            this.ldCD.Name = "ldCD";
            this.ldCD.On = false;
            this.ldCD.Size = new System.Drawing.Size(20, 20);
            this.ldCD.TabIndex = 3;
            // 
            // ldRI
            // 
            this.ldRI.Location = new System.Drawing.Point(78, 34);
            this.ldRI.Margin = new System.Windows.Forms.Padding(7, 3, 7, 3);
            this.ldRI.Name = "ldRI";
            this.ldRI.On = false;
            this.ldRI.Size = new System.Drawing.Size(20, 20);
            this.ldRI.TabIndex = 2;
            // 
            // ldDSR
            // 
            this.ldDSR.Location = new System.Drawing.Point(44, 34);
            this.ldDSR.Margin = new System.Windows.Forms.Padding(7, 3, 7, 3);
            this.ldDSR.Name = "ldDSR";
            this.ldDSR.On = false;
            this.ldDSR.Size = new System.Drawing.Size(20, 20);
            this.ldDSR.TabIndex = 1;
            // 
            // ldCTS
            // 
            this.ldCTS.Location = new System.Drawing.Point(10, 34);
            this.ldCTS.Margin = new System.Windows.Forms.Padding(7, 3, 7, 3);
            this.ldCTS.Name = "ldCTS";
            this.ldCTS.On = false;
            this.ldCTS.Size = new System.Drawing.Size(20, 20);
            this.ldCTS.TabIndex = 0;
            // 
            // btnSerialOpen
            // 
            this.btnSerialOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSerialOpen.Location = new System.Drawing.Point(392, 5);
            this.btnSerialOpen.Name = "btnSerialOpen";
            this.btnSerialOpen.Size = new System.Drawing.Size(84, 19);
            this.btnSerialOpen.TabIndex = 23;
            this.btnSerialOpen.Text = "Open";
            this.btnSerialOpen.UseVisualStyleBackColor = true;
            this.btnSerialOpen.Click += new System.EventHandler(this.btnSerialOpen_Click);
            // 
            // icSerialParity
            // 
            this.icSerialParity.DataSource = null;
            this.icSerialParity.Location = new System.Drawing.Point(226, 51);
            this.icSerialParity.Margin = new System.Windows.Forms.Padding(4);
            this.icSerialParity.MaximumSize = new System.Drawing.Size(500, 40);
            this.icSerialParity.MinimumSize = new System.Drawing.Size(20, 40);
            this.icSerialParity.Name = "icSerialParity";
            this.icSerialParity.SelectedIndex = -1;
            this.icSerialParity.Size = new System.Drawing.Size(75, 40);
            this.icSerialParity.TabIndex = 22;
            this.icSerialParity.Title = "Parity";
            // 
            // icSerialStopBits
            // 
            this.icSerialStopBits.DataSource = null;
            this.icSerialStopBits.Location = new System.Drawing.Point(145, 51);
            this.icSerialStopBits.Margin = new System.Windows.Forms.Padding(4);
            this.icSerialStopBits.MaximumSize = new System.Drawing.Size(500, 40);
            this.icSerialStopBits.MinimumSize = new System.Drawing.Size(20, 40);
            this.icSerialStopBits.Name = "icSerialStopBits";
            this.icSerialStopBits.SelectedIndex = -1;
            this.icSerialStopBits.Size = new System.Drawing.Size(75, 40);
            this.icSerialStopBits.TabIndex = 21;
            this.icSerialStopBits.Title = "StopBits";
            // 
            // icSerialDataBits
            // 
            this.icSerialDataBits.DataSource = null;
            this.icSerialDataBits.Location = new System.Drawing.Point(165, 5);
            this.icSerialDataBits.Margin = new System.Windows.Forms.Padding(4);
            this.icSerialDataBits.MaximumSize = new System.Drawing.Size(500, 40);
            this.icSerialDataBits.MinimumSize = new System.Drawing.Size(20, 40);
            this.icSerialDataBits.Name = "icSerialDataBits";
            this.icSerialDataBits.SelectedIndex = -1;
            this.icSerialDataBits.Size = new System.Drawing.Size(75, 40);
            this.icSerialDataBits.TabIndex = 20;
            this.icSerialDataBits.Title = "DataBits";
            // 
            // icSerialHandshake
            // 
            this.icSerialHandshake.DataSource = null;
            this.icSerialHandshake.Location = new System.Drawing.Point(5, 51);
            this.icSerialHandshake.Margin = new System.Windows.Forms.Padding(4);
            this.icSerialHandshake.MaximumSize = new System.Drawing.Size(500, 40);
            this.icSerialHandshake.MinimumSize = new System.Drawing.Size(20, 40);
            this.icSerialHandshake.Name = "icSerialHandshake";
            this.icSerialHandshake.SelectedIndex = -1;
            this.icSerialHandshake.Size = new System.Drawing.Size(134, 40);
            this.icSerialHandshake.TabIndex = 19;
            this.icSerialHandshake.Title = "Handshake";
            // 
            // icSerialBaudRate
            // 
            this.icSerialBaudRate.DataSource = null;
            this.icSerialBaudRate.Location = new System.Drawing.Point(84, 5);
            this.icSerialBaudRate.Margin = new System.Windows.Forms.Padding(4);
            this.icSerialBaudRate.MaximumSize = new System.Drawing.Size(500, 40);
            this.icSerialBaudRate.MinimumSize = new System.Drawing.Size(20, 40);
            this.icSerialBaudRate.Name = "icSerialBaudRate";
            this.icSerialBaudRate.SelectedIndex = -1;
            this.icSerialBaudRate.Size = new System.Drawing.Size(75, 40);
            this.icSerialBaudRate.TabIndex = 18;
            this.icSerialBaudRate.Title = "BaudRate";
            // 
            // icSerialPort
            // 
            this.icSerialPort.DataSource = null;
            this.icSerialPort.Location = new System.Drawing.Point(5, 5);
            this.icSerialPort.Margin = new System.Windows.Forms.Padding(4);
            this.icSerialPort.MaximumSize = new System.Drawing.Size(500, 40);
            this.icSerialPort.MinimumSize = new System.Drawing.Size(20, 40);
            this.icSerialPort.Name = "icSerialPort";
            this.icSerialPort.SelectedIndex = -1;
            this.icSerialPort.Size = new System.Drawing.Size(73, 40);
            this.icSerialPort.TabIndex = 17;
            this.icSerialPort.Title = "Port";
            // 
            // tabServer
            // 
            this.tabServer.BackColor = System.Drawing.SystemColors.Control;
            this.tabServer.Controls.Add(this.icServerBufferOptions);
            this.tabServer.Controls.Add(this.ifServerBufferSize);
            this.tabServer.Controls.Add(this.ifServerBacklog);
            this.tabServer.Controls.Add(this.ifServerMaxClients);
            this.tabServer.Controls.Add(this.ifServerPort);
            this.tabServer.Controls.Add(this.ifServerIp);
            this.tabServer.Controls.Add(this.btnServerOpen);
            this.tabServer.Location = new System.Drawing.Point(4, 22);
            this.tabServer.Margin = new System.Windows.Forms.Padding(2);
            this.tabServer.Name = "tabServer";
            this.tabServer.Padding = new System.Windows.Forms.Padding(2);
            this.tabServer.Size = new System.Drawing.Size(480, 96);
            this.tabServer.TabIndex = 1;
            this.tabServer.Text = "TCP Server";
            // 
            // icServerBufferOptions
            // 
            this.icServerBufferOptions.DataSource = null;
            this.icServerBufferOptions.Location = new System.Drawing.Point(258, 5);
            this.icServerBufferOptions.Margin = new System.Windows.Forms.Padding(4);
            this.icServerBufferOptions.MaximumSize = new System.Drawing.Size(500, 40);
            this.icServerBufferOptions.MinimumSize = new System.Drawing.Size(20, 40);
            this.icServerBufferOptions.Name = "icServerBufferOptions";
            this.icServerBufferOptions.SelectedIndex = -1;
            this.icServerBufferOptions.Size = new System.Drawing.Size(111, 40);
            this.icServerBufferOptions.TabIndex = 16;
            this.icServerBufferOptions.Title = "Buffer Options";
            // 
            // ifServerBufferSize
            // 
            this.ifServerBufferSize.Location = new System.Drawing.Point(7, 48);
            this.ifServerBufferSize.Margin = new System.Windows.Forms.Padding(4);
            this.ifServerBufferSize.MaximumSize = new System.Drawing.Size(500, 37);
            this.ifServerBufferSize.MinimumSize = new System.Drawing.Size(20, 37);
            this.ifServerBufferSize.Name = "ifServerBufferSize";
            this.ifServerBufferSize.ReadOnly = false;
            this.ifServerBufferSize.Size = new System.Drawing.Size(73, 37);
            this.ifServerBufferSize.TabIndex = 15;
            this.ifServerBufferSize.Text = "4096";
            this.ifServerBufferSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ifServerBufferSize.Title = "Buffer Size";
            // 
            // ifServerBacklog
            // 
            this.ifServerBacklog.Location = new System.Drawing.Point(169, 5);
            this.ifServerBacklog.Margin = new System.Windows.Forms.Padding(4);
            this.ifServerBacklog.MaximumSize = new System.Drawing.Size(500, 37);
            this.ifServerBacklog.MinimumSize = new System.Drawing.Size(20, 37);
            this.ifServerBacklog.Name = "ifServerBacklog";
            this.ifServerBacklog.ReadOnly = false;
            this.ifServerBacklog.Size = new System.Drawing.Size(83, 37);
            this.ifServerBacklog.TabIndex = 14;
            this.ifServerBacklog.Text = "1";
            this.ifServerBacklog.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ifServerBacklog.Title = "Backlog";
            // 
            // ifServerMaxClients
            // 
            this.ifServerMaxClients.Location = new System.Drawing.Point(86, 48);
            this.ifServerMaxClients.Margin = new System.Windows.Forms.Padding(4);
            this.ifServerMaxClients.MaximumSize = new System.Drawing.Size(500, 37);
            this.ifServerMaxClients.MinimumSize = new System.Drawing.Size(20, 37);
            this.ifServerMaxClients.Name = "ifServerMaxClients";
            this.ifServerMaxClients.ReadOnly = false;
            this.ifServerMaxClients.Size = new System.Drawing.Size(102, 37);
            this.ifServerMaxClients.TabIndex = 13;
            this.ifServerMaxClients.Text = "10";
            this.ifServerMaxClients.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ifServerMaxClients.Title = "Max Connections";
            // 
            // ifServerPort
            // 
            this.ifServerPort.Location = new System.Drawing.Point(99, 5);
            this.ifServerPort.Margin = new System.Windows.Forms.Padding(4);
            this.ifServerPort.MaximumSize = new System.Drawing.Size(500, 37);
            this.ifServerPort.MinimumSize = new System.Drawing.Size(20, 37);
            this.ifServerPort.Name = "ifServerPort";
            this.ifServerPort.ReadOnly = false;
            this.ifServerPort.Size = new System.Drawing.Size(64, 37);
            this.ifServerPort.TabIndex = 12;
            this.ifServerPort.Text = "4545";
            this.ifServerPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ifServerPort.Title = "Port";
            // 
            // ifServerIp
            // 
            this.ifServerIp.Location = new System.Drawing.Point(7, 5);
            this.ifServerIp.Margin = new System.Windows.Forms.Padding(4);
            this.ifServerIp.MaximumSize = new System.Drawing.Size(500, 37);
            this.ifServerIp.MinimumSize = new System.Drawing.Size(20, 37);
            this.ifServerIp.Name = "ifServerIp";
            this.ifServerIp.ReadOnly = false;
            this.ifServerIp.Size = new System.Drawing.Size(86, 37);
            this.ifServerIp.TabIndex = 11;
            this.ifServerIp.Text = "192.168.2.2";
            this.ifServerIp.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ifServerIp.Title = "IP";
            // 
            // btnServerOpen
            // 
            this.btnServerOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnServerOpen.Location = new System.Drawing.Point(392, 5);
            this.btnServerOpen.Name = "btnServerOpen";
            this.btnServerOpen.Size = new System.Drawing.Size(84, 19);
            this.btnServerOpen.TabIndex = 10;
            this.btnServerOpen.Text = "Open";
            this.btnServerOpen.UseVisualStyleBackColor = true;
            this.btnServerOpen.Click += new System.EventHandler(this.btnServerOpen_Click);
            // 
            // tabClient
            // 
            this.tabClient.BackColor = System.Drawing.SystemColors.Control;
            this.tabClient.Controls.Add(this.ifClientTimeout);
            this.tabClient.Controls.Add(this.icClientBufferOptions);
            this.tabClient.Controls.Add(this.ifClientBufferSize);
            this.tabClient.Controls.Add(this.ifClientPort);
            this.tabClient.Controls.Add(this.ifClientIp);
            this.tabClient.Controls.Add(this.btnClientConnect);
            this.tabClient.Location = new System.Drawing.Point(4, 22);
            this.tabClient.Margin = new System.Windows.Forms.Padding(2);
            this.tabClient.Name = "tabClient";
            this.tabClient.Padding = new System.Windows.Forms.Padding(2);
            this.tabClient.Size = new System.Drawing.Size(480, 96);
            this.tabClient.TabIndex = 2;
            this.tabClient.Text = "TCP Client";
            // 
            // ifClientTimeout
            // 
            this.ifClientTimeout.Location = new System.Drawing.Point(88, 48);
            this.ifClientTimeout.Margin = new System.Windows.Forms.Padding(4);
            this.ifClientTimeout.MaximumSize = new System.Drawing.Size(500, 37);
            this.ifClientTimeout.MinimumSize = new System.Drawing.Size(20, 37);
            this.ifClientTimeout.Name = "ifClientTimeout";
            this.ifClientTimeout.ReadOnly = false;
            this.ifClientTimeout.Size = new System.Drawing.Size(83, 37);
            this.ifClientTimeout.TabIndex = 18;
            this.ifClientTimeout.Text = "5000";
            this.ifClientTimeout.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ifClientTimeout.Title = "Timeout";
            // 
            // icClientBufferOptions
            // 
            this.icClientBufferOptions.DataSource = null;
            this.icClientBufferOptions.Location = new System.Drawing.Point(169, 5);
            this.icClientBufferOptions.Margin = new System.Windows.Forms.Padding(4);
            this.icClientBufferOptions.MaximumSize = new System.Drawing.Size(500, 40);
            this.icClientBufferOptions.MinimumSize = new System.Drawing.Size(20, 40);
            this.icClientBufferOptions.Name = "icClientBufferOptions";
            this.icClientBufferOptions.SelectedIndex = -1;
            this.icClientBufferOptions.Size = new System.Drawing.Size(111, 40);
            this.icClientBufferOptions.TabIndex = 17;
            this.icClientBufferOptions.Title = "Buffer Options";
            // 
            // ifClientBufferSize
            // 
            this.ifClientBufferSize.Location = new System.Drawing.Point(7, 48);
            this.ifClientBufferSize.Margin = new System.Windows.Forms.Padding(4);
            this.ifClientBufferSize.MaximumSize = new System.Drawing.Size(500, 37);
            this.ifClientBufferSize.MinimumSize = new System.Drawing.Size(20, 37);
            this.ifClientBufferSize.Name = "ifClientBufferSize";
            this.ifClientBufferSize.ReadOnly = false;
            this.ifClientBufferSize.Size = new System.Drawing.Size(73, 37);
            this.ifClientBufferSize.TabIndex = 16;
            this.ifClientBufferSize.Text = "4096";
            this.ifClientBufferSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ifClientBufferSize.Title = "Buffer Size";
            // 
            // ifClientPort
            // 
            this.ifClientPort.Location = new System.Drawing.Point(99, 5);
            this.ifClientPort.Margin = new System.Windows.Forms.Padding(4);
            this.ifClientPort.MaximumSize = new System.Drawing.Size(500, 37);
            this.ifClientPort.MinimumSize = new System.Drawing.Size(20, 37);
            this.ifClientPort.Name = "ifClientPort";
            this.ifClientPort.ReadOnly = false;
            this.ifClientPort.Size = new System.Drawing.Size(64, 37);
            this.ifClientPort.TabIndex = 13;
            this.ifClientPort.Text = "4545";
            this.ifClientPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ifClientPort.Title = "Port";
            // 
            // ifClientIp
            // 
            this.ifClientIp.Location = new System.Drawing.Point(7, 5);
            this.ifClientIp.Margin = new System.Windows.Forms.Padding(4);
            this.ifClientIp.MaximumSize = new System.Drawing.Size(500, 37);
            this.ifClientIp.MinimumSize = new System.Drawing.Size(20, 37);
            this.ifClientIp.Name = "ifClientIp";
            this.ifClientIp.ReadOnly = false;
            this.ifClientIp.Size = new System.Drawing.Size(86, 37);
            this.ifClientIp.TabIndex = 12;
            this.ifClientIp.Text = "172.29.92.30";
            this.ifClientIp.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ifClientIp.Title = "IP";
            // 
            // btnClientConnect
            // 
            this.btnClientConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnClientConnect.Location = new System.Drawing.Point(392, 5);
            this.btnClientConnect.Name = "btnClientConnect";
            this.btnClientConnect.Size = new System.Drawing.Size(84, 19);
            this.btnClientConnect.TabIndex = 5;
            this.btnClientConnect.Text = "Connect";
            this.btnClientConnect.UseVisualStyleBackColor = true;
            this.btnClientConnect.Click += new System.EventHandler(this.btnClientConnect_Click);
            // 
            // tabSettingsTab
            // 
            this.tabSettingsTab.BackColor = System.Drawing.SystemColors.Control;
            this.tabSettingsTab.Controls.Add(this.icEncoding);
            this.tabSettingsTab.Controls.Add(this.chkTranslateSendChars);
            this.tabSettingsTab.Controls.Add(this.chkTimestamps);
            this.tabSettingsTab.Controls.Add(this.btnSaveLogs);
            this.tabSettingsTab.Controls.Add(this.btnClearLogs);
            this.tabSettingsTab.Controls.Add(this.chkSilentMode);
            this.tabSettingsTab.Location = new System.Drawing.Point(4, 22);
            this.tabSettingsTab.Name = "tabSettingsTab";
            this.tabSettingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettingsTab.Size = new System.Drawing.Size(480, 96);
            this.tabSettingsTab.TabIndex = 3;
            this.tabSettingsTab.Text = "Settings";
            // 
            // icEncoding
            // 
            this.icEncoding.DataSource = null;
            this.icEncoding.Location = new System.Drawing.Point(406, 52);
            this.icEncoding.Margin = new System.Windows.Forms.Padding(4);
            this.icEncoding.MaximumSize = new System.Drawing.Size(500, 40);
            this.icEncoding.MinimumSize = new System.Drawing.Size(20, 40);
            this.icEncoding.Name = "icEncoding";
            this.icEncoding.SelectedIndex = -1;
            this.icEncoding.Size = new System.Drawing.Size(67, 40);
            this.icEncoding.TabIndex = 39;
            this.icEncoding.Title = "Code Page";
            this.icEncoding.SelectedIndexChanged += new System.EventHandler(this.icEncoding_SelectedIndexChanged);
            // 
            // chkTranslateSendChars
            // 
            this.chkTranslateSendChars.Checked = true;
            this.chkTranslateSendChars.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTranslateSendChars.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chkTranslateSendChars.Location = new System.Drawing.Point(6, 57);
            this.chkTranslateSendChars.Name = "chkTranslateSendChars";
            this.chkTranslateSendChars.Size = new System.Drawing.Size(112, 20);
            this.chkTranslateSendChars.TabIndex = 38;
            this.chkTranslateSendChars.Text = "Translate CTRLS";
            this.chkTranslateSendChars.UseVisualStyleBackColor = true;
            this.chkTranslateSendChars.CheckedChanged += new System.EventHandler(this.chkTranslateSendChars_CheckedChanged);
            // 
            // chkTimestamps
            // 
            this.chkTimestamps.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chkTimestamps.Location = new System.Drawing.Point(6, 31);
            this.chkTimestamps.Name = "chkTimestamps";
            this.chkTimestamps.Size = new System.Drawing.Size(144, 20);
            this.chkTimestamps.TabIndex = 37;
            this.chkTimestamps.Text = "Connection timestamps";
            this.chkTimestamps.UseVisualStyleBackColor = true;
            // 
            // btnSaveLogs
            // 
            this.btnSaveLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSaveLogs.Location = new System.Drawing.Point(390, 6);
            this.btnSaveLogs.Name = "btnSaveLogs";
            this.btnSaveLogs.Size = new System.Drawing.Size(84, 19);
            this.btnSaveLogs.TabIndex = 36;
            this.btnSaveLogs.Text = "Save Logs";
            this.btnSaveLogs.UseVisualStyleBackColor = true;
            this.btnSaveLogs.Click += new System.EventHandler(this.btnSaveLogs_Click);
            // 
            // btnClearLogs
            // 
            this.btnClearLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnClearLogs.Location = new System.Drawing.Point(390, 31);
            this.btnClearLogs.Name = "btnClearLogs";
            this.btnClearLogs.Size = new System.Drawing.Size(84, 19);
            this.btnClearLogs.TabIndex = 35;
            this.btnClearLogs.Text = "Clear Logs";
            this.btnClearLogs.UseVisualStyleBackColor = true;
            this.btnClearLogs.Click += new System.EventHandler(this.btnClearLogs_Click);
            // 
            // chkSilentMode
            // 
            this.chkSilentMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chkSilentMode.Location = new System.Drawing.Point(6, 6);
            this.chkSilentMode.Name = "chkSilentMode";
            this.chkSilentMode.Size = new System.Drawing.Size(87, 19);
            this.chkSilentMode.TabIndex = 34;
            this.chkSilentMode.Text = "Silent Mode";
            this.chkSilentMode.UseVisualStyleBackColor = true;
            this.chkSilentMode.CheckedChanged += new System.EventHandler(this.chkSilentMode_CheckedChanged);
            // 
            // tabTests
            // 
            this.tabTests.BackColor = System.Drawing.SystemColors.Control;
            this.tabTests.Controls.Add(this.richTextBox1);
            this.tabTests.Controls.Add(this.button1);
            this.tabTests.Location = new System.Drawing.Point(4, 22);
            this.tabTests.Name = "tabTests";
            this.tabTests.Padding = new System.Windows.Forms.Padding(3);
            this.tabTests.Size = new System.Drawing.Size(480, 96);
            this.tabTests.TabIndex = 4;
            this.tabTests.Text = "Tests";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(24, 29);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(259, 21);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Sitka Small", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(399, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabChecksum
            // 
            this.tabChecksum.BackColor = System.Drawing.SystemColors.Control;
            this.tabChecksum.Controls.Add(this.ifSum2sComp);
            this.tabChecksum.Controls.Add(this.ifSum8Xor);
            this.tabChecksum.Controls.Add(this.ifSum8Mod256);
            this.tabChecksum.Controls.Add(this.tbCheckSumInput);
            this.tabChecksum.Location = new System.Drawing.Point(4, 22);
            this.tabChecksum.Name = "tabChecksum";
            this.tabChecksum.Padding = new System.Windows.Forms.Padding(3);
            this.tabChecksum.Size = new System.Drawing.Size(480, 96);
            this.tabChecksum.TabIndex = 5;
            this.tabChecksum.Text = "Checksum";
            // 
            // ifSum2sComp
            // 
            this.ifSum2sComp.Location = new System.Drawing.Point(178, 31);
            this.ifSum2sComp.MaximumSize = new System.Drawing.Size(500, 37);
            this.ifSum2sComp.MinimumSize = new System.Drawing.Size(20, 37);
            this.ifSum2sComp.Name = "ifSum2sComp";
            this.ifSum2sComp.ReadOnly = true;
            this.ifSum2sComp.Size = new System.Drawing.Size(80, 37);
            this.ifSum2sComp.TabIndex = 3;
            this.ifSum2sComp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ifSum2sComp.Title = "2s Comp";
            // 
            // ifSum8Xor
            // 
            this.ifSum8Xor.Location = new System.Drawing.Point(92, 31);
            this.ifSum8Xor.MaximumSize = new System.Drawing.Size(500, 37);
            this.ifSum8Xor.MinimumSize = new System.Drawing.Size(20, 37);
            this.ifSum8Xor.Name = "ifSum8Xor";
            this.ifSum8Xor.ReadOnly = true;
            this.ifSum8Xor.Size = new System.Drawing.Size(80, 37);
            this.ifSum8Xor.TabIndex = 2;
            this.ifSum8Xor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ifSum8Xor.Title = "Sum8 Xor";
            // 
            // ifSum8Mod256
            // 
            this.ifSum8Mod256.Location = new System.Drawing.Point(6, 31);
            this.ifSum8Mod256.MaximumSize = new System.Drawing.Size(500, 37);
            this.ifSum8Mod256.MinimumSize = new System.Drawing.Size(20, 37);
            this.ifSum8Mod256.Name = "ifSum8Mod256";
            this.ifSum8Mod256.ReadOnly = true;
            this.ifSum8Mod256.Size = new System.Drawing.Size(80, 37);
            this.ifSum8Mod256.TabIndex = 1;
            this.ifSum8Mod256.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ifSum8Mod256.Title = "Sum8 Mod256";
            // 
            // tbCheckSumInput
            // 
            this.tbCheckSumInput.AcceptsReturn = true;
            this.tbCheckSumInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F);
            this.tbCheckSumInput.Location = new System.Drawing.Point(6, 7);
            this.tbCheckSumInput.Name = "tbCheckSumInput";
            this.tbCheckSumInput.Size = new System.Drawing.Size(468, 17);
            this.tbCheckSumInput.TabIndex = 0;
            this.tbCheckSumInput.TranslateControlChars = false;
            this.tbCheckSumInput.TextChanged += new System.EventHandler(this.tbCheckSumInput_TextChanged);
            // 
            // tabAstm
            // 
            this.tabAstm.AutoScroll = true;
            this.tabAstm.BackColor = System.Drawing.SystemColors.Control;
            this.tabAstm.Location = new System.Drawing.Point(4, 22);
            this.tabAstm.Name = "tabAstm";
            this.tabAstm.Padding = new System.Windows.Forms.Padding(3);
            this.tabAstm.Size = new System.Drawing.Size(480, 96);
            this.tabAstm.TabIndex = 6;
            this.tabAstm.Text = "ASTM Tools";
            // 
            // tbConnectionLog
            // 
            this.tbConnectionLog.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tbConnectionLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbConnectionLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbConnectionLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbConnectionLog.Location = new System.Drawing.Point(0, 0);
            this.tbConnectionLog.Margin = new System.Windows.Forms.Padding(2);
            this.tbConnectionLog.Multiline = true;
            this.tbConnectionLog.Name = "tbConnectionLog";
            this.tbConnectionLog.ReadOnly = true;
            this.tbConnectionLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbConnectionLog.Size = new System.Drawing.Size(348, 126);
            this.tbConnectionLog.TabIndex = 6;
            // 
            // btnSend
            // 
            this.btnSend.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F);
            this.btnSend.Location = new System.Drawing.Point(291, 0);
            this.btnSend.Margin = new System.Windows.Forms.Padding(0);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(57, 19);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnClientSend_Click);
            // 
            // tbRawData
            // 
            this.tbRawData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRawData.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tbRawData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRawData.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbRawData.Location = new System.Drawing.Point(6, 19);
            this.tbRawData.Multiline = true;
            this.tbRawData.Name = "tbRawData";
            this.tbRawData.ReadOnly = true;
            this.tbRawData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbRawData.Size = new System.Drawing.Size(465, 84);
            this.tbRawData.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbRawData);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 327);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(477, 109);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "RAW";
            // 
            // tbClearData
            // 
            this.tbClearData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbClearData.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tbClearData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbClearData.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbClearData.Location = new System.Drawing.Point(6, 19);
            this.tbClearData.Multiline = true;
            this.tbClearData.Name = "tbClearData";
            this.tbClearData.ReadOnly = true;
            this.tbClearData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbClearData.Size = new System.Drawing.Size(465, 94);
            this.tbClearData.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbClearData);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 208);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(477, 119);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Clear Incomming";
            // 
            // tbUserFriendlyData
            // 
            this.tbUserFriendlyData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUserFriendlyData.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tbUserFriendlyData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbUserFriendlyData.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbUserFriendlyData.Location = new System.Drawing.Point(6, 19);
            this.tbUserFriendlyData.Multiline = true;
            this.tbUserFriendlyData.Name = "tbUserFriendlyData";
            this.tbUserFriendlyData.ReadOnly = true;
            this.tbUserFriendlyData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbUserFriendlyData.Size = new System.Drawing.Size(465, 183);
            this.tbUserFriendlyData.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbUserFriendlyData);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(477, 208);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Friendly Log";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dgClients);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(140, 286);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Clients";
            // 
            // dgClients
            // 
            this.dgClients.AllowUserToAddRows = false;
            this.dgClients.AllowUserToDeleteRows = false;
            this.dgClients.AllowUserToResizeColumns = false;
            this.dgClients.AllowUserToResizeRows = false;
            this.dgClients.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgClients.ColumnHeadersVisible = false;
            this.dgClients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSocketClient,
            this.colClientName});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgClients.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgClients.Location = new System.Drawing.Point(3, 16);
            this.dgClients.Name = "dgClients";
            this.dgClients.ReadOnly = true;
            this.dgClients.RowHeadersVisible = false;
            this.dgClients.RowHeadersWidth = 51;
            this.dgClients.RowTemplate.Height = 17;
            this.dgClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgClients.Size = new System.Drawing.Size(134, 267);
            this.dgClients.TabIndex = 0;
            // 
            // colSocketClient
            // 
            this.colSocketClient.DataPropertyName = "Self";
            this.colSocketClient.HeaderText = "ClientBind";
            this.colSocketClient.MinimumWidth = 6;
            this.colSocketClient.Name = "colSocketClient";
            this.colSocketClient.ReadOnly = true;
            this.colSocketClient.Visible = false;
            this.colSocketClient.Width = 125;
            // 
            // colClientName
            // 
            this.colClientName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colClientName.DataPropertyName = "IpAddressAndPort";
            this.colClientName.HeaderText = "Client";
            this.colClientName.MinimumWidth = 6;
            this.colClientName.Name = "colClientName";
            this.colClientName.ReadOnly = true;
            // 
            // btnKickClient
            // 
            this.btnKickClient.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnKickClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnKickClient.Location = new System.Drawing.Point(0, 286);
            this.btnKickClient.Name = "btnKickClient";
            this.btnKickClient.Size = new System.Drawing.Size(140, 23);
            this.btnKickClient.TabIndex = 17;
            this.btnKickClient.Text = "Kick  Client";
            this.btnKickClient.UseVisualStyleBackColor = true;
            this.btnKickClient.Click += new System.EventHandler(this.btnKickClient_Click);
            // 
            // chkClearSend
            // 
            this.chkClearSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chkClearSend.Location = new System.Drawing.Point(0, 0);
            this.chkClearSend.Name = "chkClearSend";
            this.chkClearSend.Size = new System.Drawing.Size(97, 17);
            this.chkClearSend.TabIndex = 32;
            this.chkClearSend.Text = "Clear on send";
            this.chkClearSend.UseVisualStyleBackColor = true;
            // 
            // chkAutoResponse
            // 
            this.chkAutoResponse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chkAutoResponse.Location = new System.Drawing.Point(98, 0);
            this.chkAutoResponse.Name = "chkAutoResponse";
            this.chkAutoResponse.Size = new System.Drawing.Size(75, 17);
            this.chkAutoResponse.TabIndex = 33;
            this.chkAutoResponse.Text = "AutoResp";
            this.chkAutoResponse.UseVisualStyleBackColor = true;
            // 
            // gbMacros
            // 
            this.gbMacros.Controls.Add(this.groupBox4);
            this.gbMacros.Controls.Add(this.gbMacroResponses);
            this.gbMacros.Controls.Add(this.panMacroButtonsBottom);
            this.gbMacros.Controls.Add(this.panMacroButtonsTop);
            this.gbMacros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMacros.Location = new System.Drawing.Point(0, 0);
            this.gbMacros.Name = "gbMacros";
            this.gbMacros.Padding = new System.Windows.Forms.Padding(0);
            this.gbMacros.Size = new System.Drawing.Size(199, 431);
            this.gbMacros.TabIndex = 35;
            this.gbMacros.TabStop = false;
            this.gbMacros.Text = "Macro";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgMacroCommands);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 36);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(199, 270);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Commands";
            // 
            // dgMacroCommands
            // 
            this.dgMacroCommands.AllowUserToAddRows = false;
            this.dgMacroCommands.AllowUserToDeleteRows = false;
            this.dgMacroCommands.AllowUserToResizeColumns = false;
            this.dgMacroCommands.AllowUserToResizeRows = false;
            this.dgMacroCommands.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgMacroCommands.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgMacroCommands.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMacroCommands.ColumnHeadersVisible = false;
            this.dgMacroCommands.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colByteData,
            this.colStringData});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgMacroCommands.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgMacroCommands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgMacroCommands.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgMacroCommands.Location = new System.Drawing.Point(3, 16);
            this.dgMacroCommands.MultiSelect = false;
            this.dgMacroCommands.Name = "dgMacroCommands";
            this.dgMacroCommands.RowHeadersVisible = false;
            this.dgMacroCommands.RowHeadersWidth = 51;
            this.dgMacroCommands.RowTemplate.Height = 17;
            this.dgMacroCommands.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgMacroCommands.Size = new System.Drawing.Size(193, 251);
            this.dgMacroCommands.TabIndex = 0;
            this.dgMacroCommands.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgMacroCommands_CellDoubleClick);
            this.dgMacroCommands.Click += new System.EventHandler(this.MacroDataGrid_Click);
            // 
            // colByteData
            // 
            this.colByteData.DataPropertyName = "ByteData";
            this.colByteData.HeaderText = "ByteData";
            this.colByteData.MinimumWidth = 6;
            this.colByteData.Name = "colByteData";
            this.colByteData.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colByteData.Visible = false;
            // 
            // colStringData
            // 
            this.colStringData.DataPropertyName = "StringData";
            this.colStringData.HeaderText = "StringData";
            this.colStringData.MinimumWidth = 6;
            this.colStringData.Name = "colStringData";
            // 
            // gbMacroResponses
            // 
            this.gbMacroResponses.Controls.Add(this.dgMacroReponses);
            this.gbMacroResponses.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbMacroResponses.Location = new System.Drawing.Point(0, 306);
            this.gbMacroResponses.Name = "gbMacroResponses";
            this.gbMacroResponses.Size = new System.Drawing.Size(199, 102);
            this.gbMacroResponses.TabIndex = 25;
            this.gbMacroResponses.TabStop = false;
            this.gbMacroResponses.Text = "Allowed Responses";
            // 
            // dgMacroReponses
            // 
            this.dgMacroReponses.AllowUserToAddRows = false;
            this.dgMacroReponses.AllowUserToDeleteRows = false;
            this.dgMacroReponses.AllowUserToResizeColumns = false;
            this.dgMacroReponses.AllowUserToResizeRows = false;
            this.dgMacroReponses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgMacroReponses.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgMacroReponses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMacroReponses.ColumnHeadersVisible = false;
            this.dgMacroReponses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgMacroReponses.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgMacroReponses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgMacroReponses.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgMacroReponses.Location = new System.Drawing.Point(3, 16);
            this.dgMacroReponses.MultiSelect = false;
            this.dgMacroReponses.Name = "dgMacroReponses";
            this.dgMacroReponses.RowHeadersVisible = false;
            this.dgMacroReponses.RowHeadersWidth = 51;
            this.dgMacroReponses.RowTemplate.Height = 17;
            this.dgMacroReponses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgMacroReponses.Size = new System.Drawing.Size(193, 83);
            this.dgMacroReponses.TabIndex = 1;
            this.dgMacroReponses.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgMacroCommands_CellDoubleClick);
            this.dgMacroReponses.Click += new System.EventHandler(this.MacroDataGrid_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ByteData";
            this.dataGridViewTextBoxColumn1.HeaderText = "ByteData";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "StringData";
            this.dataGridViewTextBoxColumn2.HeaderText = "StringData";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // panMacroButtonsBottom
            // 
            this.panMacroButtonsBottom.Controls.Add(this.btnMacroAddResponse);
            this.panMacroButtonsBottom.Controls.Add(this.btnMacroAddCommand);
            this.panMacroButtonsBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panMacroButtonsBottom.Location = new System.Drawing.Point(0, 408);
            this.panMacroButtonsBottom.Name = "panMacroButtonsBottom";
            this.panMacroButtonsBottom.Size = new System.Drawing.Size(199, 23);
            this.panMacroButtonsBottom.TabIndex = 29;
            // 
            // btnMacroAddResponse
            // 
            this.btnMacroAddResponse.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMacroAddResponse.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnMacroAddResponse.Location = new System.Drawing.Point(101, 0);
            this.btnMacroAddResponse.Margin = new System.Windows.Forms.Padding(0);
            this.btnMacroAddResponse.Name = "btnMacroAddResponse";
            this.btnMacroAddResponse.Size = new System.Drawing.Size(99, 23);
            this.btnMacroAddResponse.TabIndex = 28;
            this.btnMacroAddResponse.Text = "Add Response";
            this.btnMacroAddResponse.UseVisualStyleBackColor = true;
            this.btnMacroAddResponse.Click += new System.EventHandler(this.btnMacroAddResponse_Click);
            // 
            // btnMacroAddCommand
            // 
            this.btnMacroAddCommand.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMacroAddCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnMacroAddCommand.Location = new System.Drawing.Point(0, 0);
            this.btnMacroAddCommand.Margin = new System.Windows.Forms.Padding(0);
            this.btnMacroAddCommand.Name = "btnMacroAddCommand";
            this.btnMacroAddCommand.Size = new System.Drawing.Size(101, 23);
            this.btnMacroAddCommand.TabIndex = 24;
            this.btnMacroAddCommand.Text = "Queue Command";
            this.btnMacroAddCommand.UseVisualStyleBackColor = true;
            this.btnMacroAddCommand.Click += new System.EventHandler(this.btnMacroAddCommand_Click);
            // 
            // panMacroButtonsTop
            // 
            this.panMacroButtonsTop.Controls.Add(this.btnMacroTop);
            this.panMacroButtonsTop.Controls.Add(this.btnMacroBottom);
            this.panMacroButtonsTop.Controls.Add(this.btnMacroRemove);
            this.panMacroButtonsTop.Controls.Add(this.btnRunMacro);
            this.panMacroButtonsTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panMacroButtonsTop.Location = new System.Drawing.Point(0, 13);
            this.panMacroButtonsTop.Name = "panMacroButtonsTop";
            this.panMacroButtonsTop.Size = new System.Drawing.Size(199, 23);
            this.panMacroButtonsTop.TabIndex = 30;
            // 
            // btnMacroTop
            // 
            this.btnMacroTop.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMacroTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnMacroTop.Location = new System.Drawing.Point(141, 0);
            this.btnMacroTop.Name = "btnMacroTop";
            this.btnMacroTop.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnMacroTop.Size = new System.Drawing.Size(29, 23);
            this.btnMacroTop.TabIndex = 29;
            this.btnMacroTop.Text = "↑";
            this.btnMacroTop.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMacroTop.UseVisualStyleBackColor = true;
            this.btnMacroTop.Click += new System.EventHandler(this.btnMacroTop_Click);
            // 
            // btnMacroBottom
            // 
            this.btnMacroBottom.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMacroBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnMacroBottom.Location = new System.Drawing.Point(170, 0);
            this.btnMacroBottom.Name = "btnMacroBottom";
            this.btnMacroBottom.Size = new System.Drawing.Size(29, 23);
            this.btnMacroBottom.TabIndex = 28;
            this.btnMacroBottom.Text = "↓";
            this.btnMacroBottom.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMacroBottom.UseVisualStyleBackColor = true;
            this.btnMacroBottom.Click += new System.EventHandler(this.btnMacroBottom_Click);
            // 
            // btnMacroRemove
            // 
            this.btnMacroRemove.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMacroRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnMacroRemove.Location = new System.Drawing.Point(51, 0);
            this.btnMacroRemove.Name = "btnMacroRemove";
            this.btnMacroRemove.Size = new System.Drawing.Size(51, 23);
            this.btnMacroRemove.TabIndex = 26;
            this.btnMacroRemove.Text = "Remove";
            this.btnMacroRemove.UseVisualStyleBackColor = true;
            this.btnMacroRemove.Click += new System.EventHandler(this.btnMacroRemove_Click);
            // 
            // btnRunMacro
            // 
            this.btnRunMacro.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRunMacro.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRunMacro.Location = new System.Drawing.Point(0, 0);
            this.btnRunMacro.Name = "btnRunMacro";
            this.btnRunMacro.Size = new System.Drawing.Size(51, 23);
            this.btnRunMacro.TabIndex = 27;
            this.btnRunMacro.Text = "Run";
            this.btnRunMacro.UseVisualStyleBackColor = true;
            this.btnRunMacro.Click += new System.EventHandler(this.btnRunMacro_Click);
            // 
            // panRightRight
            // 
            this.panRightRight.Controls.Add(this.panRightLeft);
            this.panRightRight.Controls.Add(this.panMacro);
            this.panRightRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panRightRight.Location = new System.Drawing.Point(482, 0);
            this.panRightRight.Name = "panRightRight";
            this.panRightRight.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.panRightRight.Size = new System.Drawing.Size(690, 436);
            this.panRightRight.TabIndex = 36;
            // 
            // panRightLeft
            // 
            this.panRightLeft.Controls.Add(this.panRightLeftBottom);
            this.panRightLeft.Controls.Add(this.panRightLeftTop);
            this.panRightLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panRightLeft.Location = new System.Drawing.Point(0, 0);
            this.panRightLeft.Name = "panRightLeft";
            this.panRightLeft.Size = new System.Drawing.Size(488, 431);
            this.panRightLeft.TabIndex = 1;
            // 
            // panRightLeftBottom
            // 
            this.panRightLeftBottom.Controls.Add(this.tbConnectionLog);
            this.panRightLeftBottom.Controls.Add(this.panSend);
            this.panRightLeftBottom.Controls.Add(this.panSendOptions);
            this.panRightLeftBottom.Controls.Add(this.tpShortcuts);
            this.panRightLeftBottom.Controls.Add(this.panClients);
            this.panRightLeftBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panRightLeftBottom.Location = new System.Drawing.Point(0, 122);
            this.panRightLeftBottom.Name = "panRightLeftBottom";
            this.panRightLeftBottom.Size = new System.Drawing.Size(488, 309);
            this.panRightLeftBottom.TabIndex = 1;
            // 
            // panSend
            // 
            this.panSend.Controls.Add(this.tbSend);
            this.panSend.Controls.Add(this.btnSend);
            this.panSend.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panSend.Location = new System.Drawing.Point(0, 126);
            this.panSend.Name = "panSend";
            this.panSend.Size = new System.Drawing.Size(348, 19);
            this.panSend.TabIndex = 38;
            // 
            // tbSend
            // 
            this.tbSend.AcceptsReturn = true;
            this.tbSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F);
            this.tbSend.Location = new System.Drawing.Point(0, 1);
            this.tbSend.Name = "tbSend";
            this.tbSend.Size = new System.Drawing.Size(279, 17);
            this.tbSend.TabIndex = 3;
            this.tbSend.TranslateControlChars = false;
            // 
            // panSendOptions
            // 
            this.panSendOptions.Controls.Add(this.chkClearSend);
            this.panSendOptions.Controls.Add(this.chkAutoResponse);
            this.panSendOptions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panSendOptions.Location = new System.Drawing.Point(0, 145);
            this.panSendOptions.Name = "panSendOptions";
            this.panSendOptions.Size = new System.Drawing.Size(348, 17);
            this.panSendOptions.TabIndex = 39;
            // 
            // tpShortcuts
            // 
            this.tpShortcuts.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tpShortcuts.Location = new System.Drawing.Point(0, 162);
            this.tpShortcuts.Margin = new System.Windows.Forms.Padding(4);
            this.tpShortcuts.Name = "tpShortcuts";
            this.tpShortcuts.SendCheckboxVisible = true;
            this.tpShortcuts.Size = new System.Drawing.Size(348, 147);
            this.tpShortcuts.TabIndex = 34;
            this.tpShortcuts.ButtonClicked += new System.EventHandler<FrameInterceptor.Utils.TypeAreaEventArgs>(this.OnTypeAreaButtonClicked);
            // 
            // panClients
            // 
            this.panClients.Controls.Add(this.groupBox5);
            this.panClients.Controls.Add(this.btnKickClient);
            this.panClients.Dock = System.Windows.Forms.DockStyle.Right;
            this.panClients.Location = new System.Drawing.Point(348, 0);
            this.panClients.Name = "panClients";
            this.panClients.Size = new System.Drawing.Size(140, 309);
            this.panClients.TabIndex = 0;
            // 
            // panRightLeftTop
            // 
            this.panRightLeftTop.Controls.Add(this.tabSettings);
            this.panRightLeftTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panRightLeftTop.Location = new System.Drawing.Point(0, 0);
            this.panRightLeftTop.Name = "panRightLeftTop";
            this.panRightLeftTop.Size = new System.Drawing.Size(488, 122);
            this.panRightLeftTop.TabIndex = 0;
            // 
            // panMacro
            // 
            this.panMacro.Controls.Add(this.gbMacros);
            this.panMacro.Dock = System.Windows.Forms.DockStyle.Right;
            this.panMacro.Location = new System.Drawing.Point(488, 0);
            this.panMacro.Name = "panMacro";
            this.panMacro.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.panMacro.Size = new System.Drawing.Size(202, 431);
            this.panMacro.TabIndex = 0;
            // 
            // panLeftFill
            // 
            this.panLeftFill.Controls.Add(this.groupBox1);
            this.panLeftFill.Controls.Add(this.groupBox2);
            this.panLeftFill.Controls.Add(this.groupBox3);
            this.panLeftFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panLeftFill.Location = new System.Drawing.Point(0, 0);
            this.panLeftFill.Name = "panLeftFill";
            this.panLeftFill.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.panLeftFill.Size = new System.Drawing.Size(482, 436);
            this.panLeftFill.TabIndex = 37;
            // 
            // FrameInterceptor_v2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 436);
            this.Controls.Add(this.panLeftFill);
            this.Controls.Add(this.panRightRight);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(900, 475);
            this.Name = "FrameInterceptor_v2";
            this.Text = "FrameInterceptor";
            this.tabSettings.ResumeLayout(false);
            this.tabSerial.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabServer.ResumeLayout(false);
            this.tabClient.ResumeLayout(false);
            this.tabSettingsTab.ResumeLayout(false);
            this.tabTests.ResumeLayout(false);
            this.tabChecksum.ResumeLayout(false);
            this.tabChecksum.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgClients)).EndInit();
            this.gbMacros.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgMacroCommands)).EndInit();
            this.gbMacroResponses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgMacroReponses)).EndInit();
            this.panMacroButtonsBottom.ResumeLayout(false);
            this.panMacroButtonsTop.ResumeLayout(false);
            this.panRightRight.ResumeLayout(false);
            this.panRightLeft.ResumeLayout(false);
            this.panRightLeftBottom.ResumeLayout(false);
            this.panRightLeftBottom.PerformLayout();
            this.panSend.ResumeLayout(false);
            this.panSend.PerformLayout();
            this.panSendOptions.ResumeLayout(false);
            this.panClients.ResumeLayout(false);
            this.panRightLeftTop.ResumeLayout(false);
            this.panMacro.ResumeLayout(false);
            this.panLeftFill.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabSettings;
        private System.Windows.Forms.TabPage tabSerial;
        private System.Windows.Forms.TabPage tabServer;
        private System.Windows.Forms.TabPage tabClient;
        private System.Windows.Forms.Button btnSend;
        internal System.Windows.Forms.Button btnClientConnect;
        internal System.Windows.Forms.TextBox tbConnectionLog;
        private System.Windows.Forms.TextBox tbRawData;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbClearData;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbUserFriendlyData;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Button btnServerOpen;
        private System.Windows.Forms.GroupBox groupBox5;
        internal System.Windows.Forms.DataGridView dgClients;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSocketClient;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClientName;
        internal System.Windows.Forms.Button btnKickClient;
        private System.Windows.Forms.CheckBox chkClearSend;
        internal System.Windows.Forms.CheckBox chkAutoResponse;
        private System.Windows.Forms.TabPage tabSettingsTab;
        internal System.Windows.Forms.CheckBox chkSilentMode;
        private CustomControls.InputFiled ifServerBufferSize;
        private CustomControls.InputFiled ifServerBacklog;
        private CustomControls.InputFiled ifServerMaxClients;
        private CustomControls.InputFiled ifServerPort;
        private CustomControls.InputFiled ifServerIp;
        internal CustomControls.InputCombo icServerBufferOptions;
        internal CustomControls.InputCombo icClientBufferOptions;
        private CustomControls.InputFiled ifClientBufferSize;
        private CustomControls.InputFiled ifClientPort;
        private CustomControls.InputFiled ifClientIp;
        private CustomControls.InputFiled ifClientTimeout;
        internal System.Windows.Forms.Button btnClearLogs;
        internal CustomControls.InputCombo icSerialPort;
        internal CustomControls.InputCombo icSerialBaudRate;
        internal CustomControls.InputCombo icSerialHandshake;
        internal CustomControls.InputCombo icSerialParity;
        internal CustomControls.InputCombo icSerialStopBits;
        internal CustomControls.InputCombo icSerialDataBits;
        internal System.Windows.Forms.Button btnSerialOpen;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        internal CustomControls.Led ldCD;
        internal CustomControls.Led ldRI;
        internal CustomControls.Led ldDSR;
        internal CustomControls.Led ldCTS;
        internal System.Windows.Forms.CheckBox chkDTR;
        internal System.Windows.Forms.CheckBox chkRTS;
        private CustomControls.TypeAreaUC tpShortcuts;
        private System.Windows.Forms.GroupBox gbMacros;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox gbMacroResponses;
        internal System.Windows.Forms.Button btnMacroAddCommand;
        private System.Windows.Forms.DataGridView dgMacroCommands;
        internal System.Windows.Forms.Button btnMacroRemove;
        private System.Windows.Forms.DataGridViewTextBoxColumn colByteData;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStringData;
        private System.Windows.Forms.DataGridView dgMacroReponses;
        internal System.Windows.Forms.Button btnMacroAddResponse;
        internal System.Windows.Forms.Button btnRunMacro;
        private System.Windows.Forms.Panel panRightRight;
        private System.Windows.Forms.Panel panRightLeft;
        private System.Windows.Forms.Panel panRightLeftBottom;
        private System.Windows.Forms.Panel panClients;
        private System.Windows.Forms.Panel panRightLeftTop;
        private System.Windows.Forms.Panel panMacro;
        private System.Windows.Forms.Panel panSend;
        private System.Windows.Forms.Panel panSendOptions;
        private System.Windows.Forms.Panel panMacroButtonsBottom;
        private System.Windows.Forms.Panel panMacroButtonsTop;
        private System.Windows.Forms.Panel panLeftFill;
        internal System.Windows.Forms.Button btnMacroTop;
        internal System.Windows.Forms.Button btnMacroBottom;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        internal System.Windows.Forms.Button btnRefreshPorts;
        private System.Windows.Forms.TabPage tabTests;
        private System.Windows.Forms.Button button1;
        internal System.Windows.Forms.Button btnSaveLogs;
        internal System.Windows.Forms.CheckBox chkTimestamps;
        internal System.Windows.Forms.CheckBox chkTranslateSendChars;
        internal CustomControls.TranslatedTextBox tbSend;
        internal CustomControls.InputCombo icEncoding;
        private System.Windows.Forms.TabPage tabChecksum;
        private CustomControls.TranslatedTextBox tbCheckSumInput;
        private CustomControls.InputFiled ifSum8Xor;
        private CustomControls.InputFiled ifSum8Mod256;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private CustomControls.InputFiled ifSum2sComp;
        private System.Windows.Forms.TabPage tabAstm;
    }
}

