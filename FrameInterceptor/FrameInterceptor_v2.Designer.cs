
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
            this.tabSettings = new System.Windows.Forms.TabControl();
            this.tabSerial = new System.Windows.Forms.TabPage();
            this.tabServer = new System.Windows.Forms.TabPage();
            this.btnServerOpen = new System.Windows.Forms.Button();
            this.tabClient = new System.Windows.Forms.TabPage();
            this.btnClientConnect = new System.Windows.Forms.Button();
            this.tabSettingsTab = new System.Windows.Forms.TabPage();
            this.chkSilentMode = new System.Windows.Forms.CheckBox();
            this.tbConnectionLog = new System.Windows.Forms.TextBox();
            this.tbSend = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnSOH = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnDEL = new System.Windows.Forms.Button();
            this.btnUS = new System.Windows.Forms.Button();
            this.btnRS = new System.Windows.Forms.Button();
            this.btnGS = new System.Windows.Forms.Button();
            this.btnFS = new System.Windows.Forms.Button();
            this.btnESC = new System.Windows.Forms.Button();
            this.btnEM = new System.Windows.Forms.Button();
            this.chkSend = new System.Windows.Forms.CheckBox();
            this.btnSUB = new System.Windows.Forms.Button();
            this.btnCAN = new System.Windows.Forms.Button();
            this.btnETB = new System.Windows.Forms.Button();
            this.btnSYN = new System.Windows.Forms.Button();
            this.btnNAK = new System.Windows.Forms.Button();
            this.btnDLE = new System.Windows.Forms.Button();
            this.btnSI = new System.Windows.Forms.Button();
            this.btnSO = new System.Windows.Forms.Button();
            this.btnCR = new System.Windows.Forms.Button();
            this.btnFF = new System.Windows.Forms.Button();
            this.btnVT = new System.Windows.Forms.Button();
            this.btnLF = new System.Windows.Forms.Button();
            this.btnHT = new System.Windows.Forms.Button();
            this.btnBS = new System.Windows.Forms.Button();
            this.btnBEL = new System.Windows.Forms.Button();
            this.btnACK = new System.Windows.Forms.Button();
            this.btnENQ = new System.Windows.Forms.Button();
            this.btnEOT = new System.Windows.Forms.Button();
            this.btnETX = new System.Windows.Forms.Button();
            this.btnSTX = new System.Windows.Forms.Button();
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
            this.icServerBufferOptions = new FrameInterceptor.CustomControls.InputCombo();
            this.ifServerBufferSize = new FrameInterceptor.CustomControls.InputFiled();
            this.ifServerBacklog = new FrameInterceptor.CustomControls.InputFiled();
            this.ifServerMaxClients = new FrameInterceptor.CustomControls.InputFiled();
            this.ifServerPort = new FrameInterceptor.CustomControls.InputFiled();
            this.ifServerIp = new FrameInterceptor.CustomControls.InputFiled();
            this.ifClientTimeout = new FrameInterceptor.CustomControls.InputFiled();
            this.icClientBufferOptions = new FrameInterceptor.CustomControls.InputCombo();
            this.ifClientBufferSize = new FrameInterceptor.CustomControls.InputFiled();
            this.ifClientPort = new FrameInterceptor.CustomControls.InputFiled();
            this.ifClientIp = new FrameInterceptor.CustomControls.InputFiled();
            this.btnClearLogs = new System.Windows.Forms.Button();
            this.tabSettings.SuspendLayout();
            this.tabServer.SuspendLayout();
            this.tabClient.SuspendLayout();
            this.tabSettingsTab.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgClients)).BeginInit();
            this.SuspendLayout();
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.tabSerial);
            this.tabSettings.Controls.Add(this.tabServer);
            this.tabSettings.Controls.Add(this.tabClient);
            this.tabSettings.Controls.Add(this.tabSettingsTab);
            this.tabSettings.Location = new System.Drawing.Point(595, 11);
            this.tabSettings.Margin = new System.Windows.Forms.Padding(2);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.SelectedIndex = 0;
            this.tabSettings.Size = new System.Drawing.Size(489, 122);
            this.tabSettings.TabIndex = 0;
            // 
            // tabSerial
            // 
            this.tabSerial.BackColor = System.Drawing.SystemColors.Control;
            this.tabSerial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabSerial.Location = new System.Drawing.Point(4, 22);
            this.tabSerial.Margin = new System.Windows.Forms.Padding(2);
            this.tabSerial.Name = "tabSerial";
            this.tabSerial.Padding = new System.Windows.Forms.Padding(2);
            this.tabSerial.Size = new System.Drawing.Size(481, 96);
            this.tabSerial.TabIndex = 0;
            this.tabSerial.Text = "Serial";
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
            this.tabServer.Size = new System.Drawing.Size(481, 96);
            this.tabServer.TabIndex = 1;
            this.tabServer.Text = "TCP Server";
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
            this.tabClient.Size = new System.Drawing.Size(481, 96);
            this.tabClient.TabIndex = 2;
            this.tabClient.Text = "TCP Client";
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
            this.tabSettingsTab.Controls.Add(this.btnClearLogs);
            this.tabSettingsTab.Controls.Add(this.chkSilentMode);
            this.tabSettingsTab.Location = new System.Drawing.Point(4, 22);
            this.tabSettingsTab.Name = "tabSettingsTab";
            this.tabSettingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettingsTab.Size = new System.Drawing.Size(481, 96);
            this.tabSettingsTab.TabIndex = 3;
            this.tabSettingsTab.Text = "Settings";
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
            // tbConnectionLog
            // 
            this.tbConnectionLog.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tbConnectionLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbConnectionLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbConnectionLog.Location = new System.Drawing.Point(595, 138);
            this.tbConnectionLog.Margin = new System.Windows.Forms.Padding(2);
            this.tbConnectionLog.Multiline = true;
            this.tbConnectionLog.Name = "tbConnectionLog";
            this.tbConnectionLog.ReadOnly = true;
            this.tbConnectionLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbConnectionLog.Size = new System.Drawing.Size(336, 97);
            this.tbConnectionLog.TabIndex = 6;
            // 
            // tbSend
            // 
            this.tbSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbSend.Location = new System.Drawing.Point(595, 239);
            this.tbSend.Margin = new System.Windows.Forms.Padding(2);
            this.tbSend.Name = "tbSend";
            this.tbSend.Size = new System.Drawing.Size(275, 17);
            this.tbSend.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSend.Location = new System.Drawing.Point(874, 238);
            this.btnSend.Margin = new System.Windows.Forms.Padding(2);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(57, 19);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnClientSend_Click);
            // 
            // btnSOH
            // 
            this.btnSOH.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSOH.Location = new System.Drawing.Point(11, 32);
            this.btnSOH.Name = "btnSOH";
            this.btnSOH.Size = new System.Drawing.Size(40, 20);
            this.btnSOH.TabIndex = 10;
            this.btnSOH.Text = "SOH";
            this.btnSOH.UseVisualStyleBackColor = true;
            this.btnSOH.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnDEL);
            this.groupBox4.Controls.Add(this.btnUS);
            this.groupBox4.Controls.Add(this.btnRS);
            this.groupBox4.Controls.Add(this.btnGS);
            this.groupBox4.Controls.Add(this.btnFS);
            this.groupBox4.Controls.Add(this.btnESC);
            this.groupBox4.Controls.Add(this.btnEM);
            this.groupBox4.Controls.Add(this.chkSend);
            this.groupBox4.Controls.Add(this.btnSUB);
            this.groupBox4.Controls.Add(this.btnCAN);
            this.groupBox4.Controls.Add(this.btnETB);
            this.groupBox4.Controls.Add(this.btnSYN);
            this.groupBox4.Controls.Add(this.btnNAK);
            this.groupBox4.Controls.Add(this.btnDLE);
            this.groupBox4.Controls.Add(this.btnSI);
            this.groupBox4.Controls.Add(this.btnSO);
            this.groupBox4.Controls.Add(this.btnCR);
            this.groupBox4.Controls.Add(this.btnFF);
            this.groupBox4.Controls.Add(this.btnVT);
            this.groupBox4.Controls.Add(this.btnLF);
            this.groupBox4.Controls.Add(this.btnHT);
            this.groupBox4.Controls.Add(this.btnBS);
            this.groupBox4.Controls.Add(this.btnBEL);
            this.groupBox4.Controls.Add(this.btnACK);
            this.groupBox4.Controls.Add(this.btnENQ);
            this.groupBox4.Controls.Add(this.btnEOT);
            this.groupBox4.Controls.Add(this.btnETX);
            this.groupBox4.Controls.Add(this.btnSTX);
            this.groupBox4.Controls.Add(this.btnSOH);
            this.groupBox4.Location = new System.Drawing.Point(595, 284);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(336, 147);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Shortcuts";
            // 
            // btnDEL
            // 
            this.btnDEL.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDEL.Location = new System.Drawing.Point(287, 110);
            this.btnDEL.Name = "btnDEL";
            this.btnDEL.Size = new System.Drawing.Size(40, 20);
            this.btnDEL.TabIndex = 16;
            this.btnDEL.Text = "DEL";
            this.btnDEL.UseVisualStyleBackColor = true;
            this.btnDEL.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnUS
            // 
            this.btnUS.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnUS.Location = new System.Drawing.Point(241, 110);
            this.btnUS.Name = "btnUS";
            this.btnUS.Size = new System.Drawing.Size(40, 20);
            this.btnUS.TabIndex = 37;
            this.btnUS.Text = "US";
            this.btnUS.UseVisualStyleBackColor = true;
            this.btnUS.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnRS
            // 
            this.btnRS.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRS.Location = new System.Drawing.Point(195, 110);
            this.btnRS.Name = "btnRS";
            this.btnRS.Size = new System.Drawing.Size(40, 20);
            this.btnRS.TabIndex = 36;
            this.btnRS.Text = "RS";
            this.btnRS.UseVisualStyleBackColor = true;
            this.btnRS.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnGS
            // 
            this.btnGS.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnGS.Location = new System.Drawing.Point(149, 110);
            this.btnGS.Name = "btnGS";
            this.btnGS.Size = new System.Drawing.Size(40, 20);
            this.btnGS.TabIndex = 35;
            this.btnGS.Text = "GS";
            this.btnGS.UseVisualStyleBackColor = true;
            this.btnGS.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnFS
            // 
            this.btnFS.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnFS.Location = new System.Drawing.Point(103, 110);
            this.btnFS.Name = "btnFS";
            this.btnFS.Size = new System.Drawing.Size(40, 20);
            this.btnFS.TabIndex = 34;
            this.btnFS.Text = "FS";
            this.btnFS.UseVisualStyleBackColor = true;
            this.btnFS.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnESC
            // 
            this.btnESC.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnESC.Location = new System.Drawing.Point(57, 110);
            this.btnESC.Name = "btnESC";
            this.btnESC.Size = new System.Drawing.Size(40, 20);
            this.btnESC.TabIndex = 33;
            this.btnESC.Text = "ESC";
            this.btnESC.UseVisualStyleBackColor = true;
            this.btnESC.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnEM
            // 
            this.btnEM.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnEM.Location = new System.Drawing.Point(287, 84);
            this.btnEM.Name = "btnEM";
            this.btnEM.Size = new System.Drawing.Size(40, 20);
            this.btnEM.TabIndex = 32;
            this.btnEM.Text = "EM";
            this.btnEM.UseVisualStyleBackColor = true;
            this.btnEM.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // chkSend
            // 
            this.chkSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chkSend.Location = new System.Drawing.Point(279, 9);
            this.chkSend.Name = "chkSend";
            this.chkSend.Size = new System.Drawing.Size(51, 17);
            this.chkSend.TabIndex = 31;
            this.chkSend.Text = "Send";
            this.chkSend.UseVisualStyleBackColor = true;
            // 
            // btnSUB
            // 
            this.btnSUB.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSUB.Location = new System.Drawing.Point(11, 110);
            this.btnSUB.Name = "btnSUB";
            this.btnSUB.Size = new System.Drawing.Size(40, 20);
            this.btnSUB.TabIndex = 30;
            this.btnSUB.Text = "SUB";
            this.btnSUB.UseVisualStyleBackColor = true;
            this.btnSUB.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnCAN
            // 
            this.btnCAN.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCAN.Location = new System.Drawing.Point(241, 84);
            this.btnCAN.Name = "btnCAN";
            this.btnCAN.Size = new System.Drawing.Size(40, 20);
            this.btnCAN.TabIndex = 29;
            this.btnCAN.Text = "CAN";
            this.btnCAN.UseVisualStyleBackColor = true;
            this.btnCAN.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnETB
            // 
            this.btnETB.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnETB.Location = new System.Drawing.Point(195, 84);
            this.btnETB.Name = "btnETB";
            this.btnETB.Size = new System.Drawing.Size(40, 20);
            this.btnETB.TabIndex = 28;
            this.btnETB.Text = "ETB";
            this.btnETB.UseVisualStyleBackColor = true;
            this.btnETB.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnSYN
            // 
            this.btnSYN.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSYN.Location = new System.Drawing.Point(149, 84);
            this.btnSYN.Name = "btnSYN";
            this.btnSYN.Size = new System.Drawing.Size(40, 20);
            this.btnSYN.TabIndex = 27;
            this.btnSYN.Text = "SYN";
            this.btnSYN.UseVisualStyleBackColor = true;
            this.btnSYN.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnNAK
            // 
            this.btnNAK.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnNAK.Location = new System.Drawing.Point(103, 84);
            this.btnNAK.Name = "btnNAK";
            this.btnNAK.Size = new System.Drawing.Size(40, 20);
            this.btnNAK.TabIndex = 26;
            this.btnNAK.Text = "NAK";
            this.btnNAK.UseVisualStyleBackColor = true;
            this.btnNAK.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnDLE
            // 
            this.btnDLE.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDLE.Location = new System.Drawing.Point(57, 84);
            this.btnDLE.Name = "btnDLE";
            this.btnDLE.Size = new System.Drawing.Size(40, 20);
            this.btnDLE.TabIndex = 25;
            this.btnDLE.Text = "DLE";
            this.btnDLE.UseVisualStyleBackColor = true;
            this.btnDLE.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnSI
            // 
            this.btnSI.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSI.Location = new System.Drawing.Point(11, 84);
            this.btnSI.Name = "btnSI";
            this.btnSI.Size = new System.Drawing.Size(40, 20);
            this.btnSI.TabIndex = 24;
            this.btnSI.Text = "SI";
            this.btnSI.UseVisualStyleBackColor = true;
            this.btnSI.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnSO
            // 
            this.btnSO.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSO.Location = new System.Drawing.Point(287, 58);
            this.btnSO.Name = "btnSO";
            this.btnSO.Size = new System.Drawing.Size(40, 20);
            this.btnSO.TabIndex = 23;
            this.btnSO.Text = "SO";
            this.btnSO.UseVisualStyleBackColor = true;
            this.btnSO.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnCR
            // 
            this.btnCR.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCR.Location = new System.Drawing.Point(241, 58);
            this.btnCR.Name = "btnCR";
            this.btnCR.Size = new System.Drawing.Size(40, 20);
            this.btnCR.TabIndex = 22;
            this.btnCR.Text = "CR";
            this.btnCR.UseVisualStyleBackColor = true;
            this.btnCR.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnFF
            // 
            this.btnFF.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnFF.Location = new System.Drawing.Point(195, 58);
            this.btnFF.Name = "btnFF";
            this.btnFF.Size = new System.Drawing.Size(40, 20);
            this.btnFF.TabIndex = 21;
            this.btnFF.Text = "FF";
            this.btnFF.UseVisualStyleBackColor = true;
            this.btnFF.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnVT
            // 
            this.btnVT.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnVT.Location = new System.Drawing.Point(149, 58);
            this.btnVT.Name = "btnVT";
            this.btnVT.Size = new System.Drawing.Size(40, 20);
            this.btnVT.TabIndex = 20;
            this.btnVT.Text = "VT";
            this.btnVT.UseVisualStyleBackColor = true;
            this.btnVT.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnLF
            // 
            this.btnLF.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnLF.Location = new System.Drawing.Point(103, 58);
            this.btnLF.Name = "btnLF";
            this.btnLF.Size = new System.Drawing.Size(40, 20);
            this.btnLF.TabIndex = 19;
            this.btnLF.Text = "LF";
            this.btnLF.UseVisualStyleBackColor = true;
            this.btnLF.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnHT
            // 
            this.btnHT.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnHT.Location = new System.Drawing.Point(57, 58);
            this.btnHT.Name = "btnHT";
            this.btnHT.Size = new System.Drawing.Size(40, 20);
            this.btnHT.TabIndex = 18;
            this.btnHT.Text = "HT";
            this.btnHT.UseVisualStyleBackColor = true;
            this.btnHT.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnBS
            // 
            this.btnBS.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnBS.Location = new System.Drawing.Point(11, 58);
            this.btnBS.Name = "btnBS";
            this.btnBS.Size = new System.Drawing.Size(40, 20);
            this.btnBS.TabIndex = 17;
            this.btnBS.Text = "BS";
            this.btnBS.UseVisualStyleBackColor = true;
            this.btnBS.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnBEL
            // 
            this.btnBEL.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnBEL.Location = new System.Drawing.Point(287, 32);
            this.btnBEL.Name = "btnBEL";
            this.btnBEL.Size = new System.Drawing.Size(40, 20);
            this.btnBEL.TabIndex = 16;
            this.btnBEL.Text = "BEL";
            this.btnBEL.UseVisualStyleBackColor = true;
            this.btnBEL.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnACK
            // 
            this.btnACK.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnACK.Location = new System.Drawing.Point(241, 32);
            this.btnACK.Name = "btnACK";
            this.btnACK.Size = new System.Drawing.Size(40, 20);
            this.btnACK.TabIndex = 15;
            this.btnACK.Text = "ACK";
            this.btnACK.UseVisualStyleBackColor = true;
            this.btnACK.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnENQ
            // 
            this.btnENQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnENQ.Location = new System.Drawing.Point(195, 32);
            this.btnENQ.Name = "btnENQ";
            this.btnENQ.Size = new System.Drawing.Size(40, 20);
            this.btnENQ.TabIndex = 14;
            this.btnENQ.Text = "ENQ";
            this.btnENQ.UseVisualStyleBackColor = true;
            this.btnENQ.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnEOT
            // 
            this.btnEOT.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnEOT.Location = new System.Drawing.Point(149, 32);
            this.btnEOT.Name = "btnEOT";
            this.btnEOT.Size = new System.Drawing.Size(40, 20);
            this.btnEOT.TabIndex = 13;
            this.btnEOT.Text = "EOT";
            this.btnEOT.UseVisualStyleBackColor = true;
            this.btnEOT.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnETX
            // 
            this.btnETX.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnETX.Location = new System.Drawing.Point(103, 32);
            this.btnETX.Name = "btnETX";
            this.btnETX.Size = new System.Drawing.Size(40, 20);
            this.btnETX.TabIndex = 12;
            this.btnETX.Text = "ETX";
            this.btnETX.UseVisualStyleBackColor = true;
            this.btnETX.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnSTX
            // 
            this.btnSTX.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSTX.Location = new System.Drawing.Point(57, 32);
            this.btnSTX.Name = "btnSTX";
            this.btnSTX.Size = new System.Drawing.Size(40, 20);
            this.btnSTX.TabIndex = 11;
            this.btnSTX.Text = "STX";
            this.btnSTX.UseVisualStyleBackColor = true;
            this.btnSTX.Click += new System.EventHandler(this.btnShortcut_Click);
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
            this.tbRawData.Size = new System.Drawing.Size(566, 107);
            this.tbRawData.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbRawData);
            this.groupBox3.Location = new System.Drawing.Point(12, 299);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(578, 132);
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
            this.tbClearData.Size = new System.Drawing.Size(566, 110);
            this.tbClearData.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbClearData);
            this.groupBox2.Location = new System.Drawing.Point(11, 158);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(578, 135);
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
            this.tbUserFriendlyData.Size = new System.Drawing.Size(566, 116);
            this.tbUserFriendlyData.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbUserFriendlyData);
            this.groupBox1.Location = new System.Drawing.Point(12, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(578, 141);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Friendly Log";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dgClients);
            this.groupBox5.Location = new System.Drawing.Point(937, 138);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(147, 272);
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
            this.dgClients.RowTemplate.Height = 17;
            this.dgClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgClients.Size = new System.Drawing.Size(141, 253);
            this.dgClients.TabIndex = 0;
            // 
            // colSocketClient
            // 
            this.colSocketClient.DataPropertyName = "Self";
            this.colSocketClient.HeaderText = "ClientBind";
            this.colSocketClient.Name = "colSocketClient";
            this.colSocketClient.ReadOnly = true;
            this.colSocketClient.Visible = false;
            // 
            // colClientName
            // 
            this.colClientName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colClientName.DataPropertyName = "IpAddressAndPort";
            this.colClientName.HeaderText = "Client";
            this.colClientName.Name = "colClientName";
            this.colClientName.ReadOnly = true;
            // 
            // btnKickClient
            // 
            this.btnKickClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnKickClient.Location = new System.Drawing.Point(937, 412);
            this.btnKickClient.Name = "btnKickClient";
            this.btnKickClient.Size = new System.Drawing.Size(147, 19);
            this.btnKickClient.TabIndex = 17;
            this.btnKickClient.Text = "Kick  Client";
            this.btnKickClient.UseVisualStyleBackColor = true;
            this.btnKickClient.Click += new System.EventHandler(this.btnKickClient_Click);
            // 
            // chkClearSend
            // 
            this.chkClearSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chkClearSend.Location = new System.Drawing.Point(595, 261);
            this.chkClearSend.Name = "chkClearSend";
            this.chkClearSend.Size = new System.Drawing.Size(97, 17);
            this.chkClearSend.TabIndex = 32;
            this.chkClearSend.Text = "Clear on send";
            this.chkClearSend.UseVisualStyleBackColor = true;
            // 
            // chkAutoResponse
            // 
            this.chkAutoResponse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chkAutoResponse.Location = new System.Drawing.Point(687, 261);
            this.chkAutoResponse.Name = "chkAutoResponse";
            this.chkAutoResponse.Size = new System.Drawing.Size(75, 17);
            this.chkAutoResponse.TabIndex = 33;
            this.chkAutoResponse.Text = "AutoResp";
            this.chkAutoResponse.UseVisualStyleBackColor = true;
            // 
            // icServerBufferOptions
            // 
            this.icServerBufferOptions.DataSource = null;
            this.icServerBufferOptions.Location = new System.Drawing.Point(258, 5);
            this.icServerBufferOptions.MaximumSize = new System.Drawing.Size(500, 40);
            this.icServerBufferOptions.MinimumSize = new System.Drawing.Size(20, 40);
            this.icServerBufferOptions.Name = "icServerBufferOptions";
            this.icServerBufferOptions.Size = new System.Drawing.Size(111, 40);
            this.icServerBufferOptions.TabIndex = 16;
            this.icServerBufferOptions.Title = "Buffer Options";
            // 
            // ifServerBufferSize
            // 
            this.ifServerBufferSize.Location = new System.Drawing.Point(7, 48);
            this.ifServerBufferSize.MaximumSize = new System.Drawing.Size(500, 37);
            this.ifServerBufferSize.MinimumSize = new System.Drawing.Size(20, 37);
            this.ifServerBufferSize.Name = "ifServerBufferSize";
            this.ifServerBufferSize.Size = new System.Drawing.Size(73, 37);
            this.ifServerBufferSize.TabIndex = 15;
            this.ifServerBufferSize.Text = "4096";
            this.ifServerBufferSize.Title = "Buffer Size";
            // 
            // ifServerBacklog
            // 
            this.ifServerBacklog.Location = new System.Drawing.Point(169, 5);
            this.ifServerBacklog.MaximumSize = new System.Drawing.Size(500, 37);
            this.ifServerBacklog.MinimumSize = new System.Drawing.Size(20, 37);
            this.ifServerBacklog.Name = "ifServerBacklog";
            this.ifServerBacklog.Size = new System.Drawing.Size(83, 37);
            this.ifServerBacklog.TabIndex = 14;
            this.ifServerBacklog.Text = "1";
            this.ifServerBacklog.Title = "Backlog";
            // 
            // ifServerMaxClients
            // 
            this.ifServerMaxClients.Location = new System.Drawing.Point(86, 48);
            this.ifServerMaxClients.MaximumSize = new System.Drawing.Size(500, 37);
            this.ifServerMaxClients.MinimumSize = new System.Drawing.Size(20, 37);
            this.ifServerMaxClients.Name = "ifServerMaxClients";
            this.ifServerMaxClients.Size = new System.Drawing.Size(102, 37);
            this.ifServerMaxClients.TabIndex = 13;
            this.ifServerMaxClients.Text = "10";
            this.ifServerMaxClients.Title = "Max Connections";
            // 
            // ifServerPort
            // 
            this.ifServerPort.Location = new System.Drawing.Point(99, 5);
            this.ifServerPort.MaximumSize = new System.Drawing.Size(500, 37);
            this.ifServerPort.MinimumSize = new System.Drawing.Size(20, 37);
            this.ifServerPort.Name = "ifServerPort";
            this.ifServerPort.Size = new System.Drawing.Size(64, 37);
            this.ifServerPort.TabIndex = 12;
            this.ifServerPort.Text = "4545";
            this.ifServerPort.Title = "Port";
            // 
            // ifServerIp
            // 
            this.ifServerIp.Location = new System.Drawing.Point(7, 5);
            this.ifServerIp.MaximumSize = new System.Drawing.Size(500, 37);
            this.ifServerIp.MinimumSize = new System.Drawing.Size(20, 37);
            this.ifServerIp.Name = "ifServerIp";
            this.ifServerIp.Size = new System.Drawing.Size(86, 37);
            this.ifServerIp.TabIndex = 11;
            this.ifServerIp.Text = "192.168.2.2";
            this.ifServerIp.Title = "IP";
            // 
            // ifClientTimeout
            // 
            this.ifClientTimeout.Location = new System.Drawing.Point(88, 48);
            this.ifClientTimeout.MaximumSize = new System.Drawing.Size(500, 37);
            this.ifClientTimeout.MinimumSize = new System.Drawing.Size(20, 37);
            this.ifClientTimeout.Name = "ifClientTimeout";
            this.ifClientTimeout.Size = new System.Drawing.Size(83, 37);
            this.ifClientTimeout.TabIndex = 18;
            this.ifClientTimeout.Text = "5000";
            this.ifClientTimeout.Title = "Timeout";
            // 
            // icClientBufferOptions
            // 
            this.icClientBufferOptions.DataSource = null;
            this.icClientBufferOptions.Location = new System.Drawing.Point(169, 5);
            this.icClientBufferOptions.MaximumSize = new System.Drawing.Size(500, 40);
            this.icClientBufferOptions.MinimumSize = new System.Drawing.Size(20, 40);
            this.icClientBufferOptions.Name = "icClientBufferOptions";
            this.icClientBufferOptions.Size = new System.Drawing.Size(111, 40);
            this.icClientBufferOptions.TabIndex = 17;
            this.icClientBufferOptions.Title = "Buffer Options";
            // 
            // ifClientBufferSize
            // 
            this.ifClientBufferSize.Location = new System.Drawing.Point(7, 48);
            this.ifClientBufferSize.MaximumSize = new System.Drawing.Size(500, 37);
            this.ifClientBufferSize.MinimumSize = new System.Drawing.Size(20, 37);
            this.ifClientBufferSize.Name = "ifClientBufferSize";
            this.ifClientBufferSize.Size = new System.Drawing.Size(73, 37);
            this.ifClientBufferSize.TabIndex = 16;
            this.ifClientBufferSize.Text = "4096";
            this.ifClientBufferSize.Title = "Buffer Size";
            // 
            // ifClientPort
            // 
            this.ifClientPort.Location = new System.Drawing.Point(99, 5);
            this.ifClientPort.MaximumSize = new System.Drawing.Size(500, 37);
            this.ifClientPort.MinimumSize = new System.Drawing.Size(20, 37);
            this.ifClientPort.Name = "ifClientPort";
            this.ifClientPort.Size = new System.Drawing.Size(64, 37);
            this.ifClientPort.TabIndex = 13;
            this.ifClientPort.Text = "4545";
            this.ifClientPort.Title = "Port";
            // 
            // ifClientIp
            // 
            this.ifClientIp.Location = new System.Drawing.Point(7, 5);
            this.ifClientIp.MaximumSize = new System.Drawing.Size(500, 37);
            this.ifClientIp.MinimumSize = new System.Drawing.Size(20, 37);
            this.ifClientIp.Name = "ifClientIp";
            this.ifClientIp.Size = new System.Drawing.Size(86, 37);
            this.ifClientIp.TabIndex = 12;
            this.ifClientIp.Text = "172.29.92.30";
            this.ifClientIp.Title = "IP";
            // 
            // btnClearLogs
            // 
            this.btnClearLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnClearLogs.Location = new System.Drawing.Point(391, 6);
            this.btnClearLogs.Name = "btnClearLogs";
            this.btnClearLogs.Size = new System.Drawing.Size(84, 19);
            this.btnClearLogs.TabIndex = 35;
            this.btnClearLogs.Text = "Clear Logs";
            this.btnClearLogs.UseVisualStyleBackColor = true;
            this.btnClearLogs.Click += new System.EventHandler(this.btnClearLogs_Click);
            // 
            // FrameInterceptor_v2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 456);
            this.Controls.Add(this.chkAutoResponse);
            this.Controls.Add(this.chkClearSend);
            this.Controls.Add(this.btnKickClient);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbConnectionLog);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.tbSend);
            this.Controls.Add(this.tabSettings);
            this.Name = "FrameInterceptor_v2";
            this.Text = "FrameInterceptor";
            this.tabSettings.ResumeLayout(false);
            this.tabServer.ResumeLayout(false);
            this.tabClient.ResumeLayout(false);
            this.tabSettingsTab.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgClients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabSettings;
        private System.Windows.Forms.TabPage tabSerial;
        private System.Windows.Forms.TabPage tabServer;
        private System.Windows.Forms.TabPage tabClient;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnSOH;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkSend;
        private System.Windows.Forms.Button btnSUB;
        private System.Windows.Forms.Button btnCAN;
        private System.Windows.Forms.Button btnETB;
        private System.Windows.Forms.Button btnSYN;
        private System.Windows.Forms.Button btnNAK;
        private System.Windows.Forms.Button btnDLE;
        private System.Windows.Forms.Button btnSI;
        private System.Windows.Forms.Button btnSO;
        private System.Windows.Forms.Button btnCR;
        private System.Windows.Forms.Button btnFF;
        private System.Windows.Forms.Button btnVT;
        private System.Windows.Forms.Button btnLF;
        private System.Windows.Forms.Button btnHT;
        private System.Windows.Forms.Button btnBS;
        private System.Windows.Forms.Button btnBEL;
        private System.Windows.Forms.Button btnACK;
        private System.Windows.Forms.Button btnENQ;
        private System.Windows.Forms.Button btnEOT;
        private System.Windows.Forms.Button btnETX;
        private System.Windows.Forms.Button btnSTX;
        private System.Windows.Forms.Button btnDEL;
        private System.Windows.Forms.Button btnUS;
        private System.Windows.Forms.Button btnRS;
        private System.Windows.Forms.Button btnGS;
        private System.Windows.Forms.Button btnFS;
        private System.Windows.Forms.Button btnESC;
        private System.Windows.Forms.Button btnEM;
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
        internal System.Windows.Forms.TextBox tbSend;
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
    }
}

