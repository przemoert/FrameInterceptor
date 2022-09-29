
namespace FrameInterceptor
{
    partial class Form1
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
            this.tabSettings = new System.Windows.Forms.TabControl();
            this.tabSerial = new System.Windows.Forms.TabPage();
            this.tabServer = new System.Windows.Forms.TabPage();
            this.tbServerPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbServerIp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabClient = new System.Windows.Forms.TabPage();
            this.tbClientPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbClientIp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbConnectionLog = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.tbSend = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.tbUserFriendlyData = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbClearData = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbRawData = new System.Windows.Forms.TextBox();
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
            this.tabSettings.SuspendLayout();
            this.tabServer.SuspendLayout();
            this.tabClient.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.tabSerial);
            this.tabSettings.Controls.Add(this.tabServer);
            this.tabSettings.Controls.Add(this.tabClient);
            this.tabSettings.Location = new System.Drawing.Point(630, 11);
            this.tabSettings.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.SelectedIndex = 0;
            this.tabSettings.Size = new System.Drawing.Size(452, 122);
            this.tabSettings.TabIndex = 0;
            // 
            // tabSerial
            // 
            this.tabSerial.BackColor = System.Drawing.SystemColors.Control;
            this.tabSerial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabSerial.Location = new System.Drawing.Point(4, 22);
            this.tabSerial.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabSerial.Name = "tabSerial";
            this.tabSerial.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabSerial.Size = new System.Drawing.Size(444, 96);
            this.tabSerial.TabIndex = 0;
            this.tabSerial.Text = "Serial";
            // 
            // tabServer
            // 
            this.tabServer.BackColor = System.Drawing.SystemColors.Control;
            this.tabServer.Controls.Add(this.tbServerPort);
            this.tabServer.Controls.Add(this.label3);
            this.tabServer.Controls.Add(this.tbServerIp);
            this.tabServer.Controls.Add(this.label4);
            this.tabServer.Location = new System.Drawing.Point(4, 22);
            this.tabServer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabServer.Name = "tabServer";
            this.tabServer.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabServer.Size = new System.Drawing.Size(444, 96);
            this.tabServer.TabIndex = 1;
            this.tabServer.Text = "TCP Server";
            // 
            // tbServerPort
            // 
            this.tbServerPort.Location = new System.Drawing.Point(213, 12);
            this.tbServerPort.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbServerPort.Name = "tbServerPort";
            this.tbServerPort.Size = new System.Drawing.Size(56, 20);
            this.tbServerPort.TabIndex = 8;
            this.tbServerPort.Text = "4545";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(180, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Port:";
            // 
            // tbServerIp
            // 
            this.tbServerIp.Location = new System.Drawing.Point(32, 11);
            this.tbServerIp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbServerIp.Name = "tbServerIp";
            this.tbServerIp.Size = new System.Drawing.Size(121, 20);
            this.tbServerIp.TabIndex = 6;
            this.tbServerIp.Text = "192.168.2.2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 13);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "IP:";
            // 
            // tabClient
            // 
            this.tabClient.BackColor = System.Drawing.SystemColors.Control;
            this.tabClient.Controls.Add(this.tbClientPort);
            this.tabClient.Controls.Add(this.label2);
            this.tabClient.Controls.Add(this.tbClientIp);
            this.tabClient.Controls.Add(this.label1);
            this.tabClient.Location = new System.Drawing.Point(4, 22);
            this.tabClient.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabClient.Name = "tabClient";
            this.tabClient.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabClient.Size = new System.Drawing.Size(444, 96);
            this.tabClient.TabIndex = 2;
            this.tabClient.Text = "TCP Client";
            // 
            // tbClientPort
            // 
            this.tbClientPort.Location = new System.Drawing.Point(213, 12);
            this.tbClientPort.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbClientPort.Name = "tbClientPort";
            this.tbClientPort.Size = new System.Drawing.Size(56, 20);
            this.tbClientPort.TabIndex = 4;
            this.tbClientPort.Text = "4545";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port:";
            // 
            // tbClientIp
            // 
            this.tbClientIp.Location = new System.Drawing.Point(32, 11);
            this.tbClientIp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbClientIp.Name = "tbClientIp";
            this.tbClientIp.Size = new System.Drawing.Size(121, 20);
            this.tbClientIp.TabIndex = 2;
            this.tbClientIp.Text = "192.168.2.2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP:";
            // 
            // tbConnectionLog
            // 
            this.tbConnectionLog.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tbConnectionLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbConnectionLog.Location = new System.Drawing.Point(630, 137);
            this.tbConnectionLog.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbConnectionLog.Multiline = true;
            this.tbConnectionLog.Name = "tbConnectionLog";
            this.tbConnectionLog.ReadOnly = true;
            this.tbConnectionLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbConnectionLog.Size = new System.Drawing.Size(448, 84);
            this.tbConnectionLog.TabIndex = 6;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(12, 11);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(92, 31);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnClientConnect_Click);
            // 
            // tbSend
            // 
            this.tbSend.Location = new System.Drawing.Point(630, 225);
            this.tbSend.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbSend.Name = "tbSend";
            this.tbSend.Size = new System.Drawing.Size(362, 20);
            this.tbSend.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(996, 225);
            this.btnSend.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(82, 21);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnClientSend_Click);
            // 
            // tbUserFriendlyData
            // 
            this.tbUserFriendlyData.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tbUserFriendlyData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbUserFriendlyData.Location = new System.Drawing.Point(6, 19);
            this.tbUserFriendlyData.Multiline = true;
            this.tbUserFriendlyData.Name = "tbUserFriendlyData";
            this.tbUserFriendlyData.ReadOnly = true;
            this.tbUserFriendlyData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbUserFriendlyData.Size = new System.Drawing.Size(600, 98);
            this.tbUserFriendlyData.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbUserFriendlyData);
            this.groupBox1.Location = new System.Drawing.Point(12, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(612, 123);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Friendly Log";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbClearData);
            this.groupBox2.Location = new System.Drawing.Point(13, 173);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(612, 123);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Clear Incomming";
            // 
            // tbClearData
            // 
            this.tbClearData.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tbClearData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbClearData.Location = new System.Drawing.Point(6, 19);
            this.tbClearData.Multiline = true;
            this.tbClearData.Name = "tbClearData";
            this.tbClearData.ReadOnly = true;
            this.tbClearData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbClearData.Size = new System.Drawing.Size(600, 98);
            this.tbClearData.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbRawData);
            this.groupBox3.Location = new System.Drawing.Point(12, 302);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(612, 123);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "RAW";
            // 
            // tbRawData
            // 
            this.tbRawData.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tbRawData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRawData.Location = new System.Drawing.Point(6, 19);
            this.tbRawData.Multiline = true;
            this.tbRawData.Name = "tbRawData";
            this.tbRawData.ReadOnly = true;
            this.tbRawData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbRawData.Size = new System.Drawing.Size(600, 98);
            this.tbRawData.TabIndex = 3;
            // 
            // btnSOH
            // 
            this.btnSOH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSOH.Location = new System.Drawing.Point(17, 32);
            this.btnSOH.Name = "btnSOH";
            this.btnSOH.Size = new System.Drawing.Size(54, 23);
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
            this.groupBox4.Location = new System.Drawing.Point(630, 251);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(448, 147);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Shortcuts";
            // 
            // btnDEL
            // 
            this.btnDEL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDEL.Location = new System.Drawing.Point(377, 118);
            this.btnDEL.Name = "btnDEL";
            this.btnDEL.Size = new System.Drawing.Size(54, 23);
            this.btnDEL.TabIndex = 16;
            this.btnDEL.Text = "DEL";
            this.btnDEL.UseVisualStyleBackColor = true;
            this.btnDEL.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnUS
            // 
            this.btnUS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnUS.Location = new System.Drawing.Point(317, 118);
            this.btnUS.Name = "btnUS";
            this.btnUS.Size = new System.Drawing.Size(54, 23);
            this.btnUS.TabIndex = 37;
            this.btnUS.Text = "US";
            this.btnUS.UseVisualStyleBackColor = true;
            this.btnUS.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnRS
            // 
            this.btnRS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRS.Location = new System.Drawing.Point(257, 118);
            this.btnRS.Name = "btnRS";
            this.btnRS.Size = new System.Drawing.Size(54, 23);
            this.btnRS.TabIndex = 36;
            this.btnRS.Text = "RS";
            this.btnRS.UseVisualStyleBackColor = true;
            this.btnRS.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnGS
            // 
            this.btnGS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnGS.Location = new System.Drawing.Point(197, 118);
            this.btnGS.Name = "btnGS";
            this.btnGS.Size = new System.Drawing.Size(54, 23);
            this.btnGS.TabIndex = 35;
            this.btnGS.Text = "GS";
            this.btnGS.UseVisualStyleBackColor = true;
            this.btnGS.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnFS
            // 
            this.btnFS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnFS.Location = new System.Drawing.Point(137, 118);
            this.btnFS.Name = "btnFS";
            this.btnFS.Size = new System.Drawing.Size(54, 23);
            this.btnFS.TabIndex = 34;
            this.btnFS.Text = "FS";
            this.btnFS.UseVisualStyleBackColor = true;
            this.btnFS.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnESC
            // 
            this.btnESC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnESC.Location = new System.Drawing.Point(77, 118);
            this.btnESC.Name = "btnESC";
            this.btnESC.Size = new System.Drawing.Size(54, 23);
            this.btnESC.TabIndex = 33;
            this.btnESC.Text = "ESC";
            this.btnESC.UseVisualStyleBackColor = true;
            this.btnESC.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnEM
            // 
            this.btnEM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnEM.Location = new System.Drawing.Point(377, 90);
            this.btnEM.Name = "btnEM";
            this.btnEM.Size = new System.Drawing.Size(54, 23);
            this.btnEM.TabIndex = 32;
            this.btnEM.Text = "EM";
            this.btnEM.UseVisualStyleBackColor = true;
            this.btnEM.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // chkSend
            // 
            this.chkSend.AutoSize = true;
            this.chkSend.Location = new System.Drawing.Point(380, 9);
            this.chkSend.Name = "chkSend";
            this.chkSend.Size = new System.Drawing.Size(51, 17);
            this.chkSend.TabIndex = 31;
            this.chkSend.Text = "Send";
            this.chkSend.UseVisualStyleBackColor = true;
            // 
            // btnSUB
            // 
            this.btnSUB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSUB.Location = new System.Drawing.Point(17, 118);
            this.btnSUB.Name = "btnSUB";
            this.btnSUB.Size = new System.Drawing.Size(54, 23);
            this.btnSUB.TabIndex = 30;
            this.btnSUB.Text = "SUB";
            this.btnSUB.UseVisualStyleBackColor = true;
            this.btnSUB.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnCAN
            // 
            this.btnCAN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCAN.Location = new System.Drawing.Point(317, 90);
            this.btnCAN.Name = "btnCAN";
            this.btnCAN.Size = new System.Drawing.Size(54, 23);
            this.btnCAN.TabIndex = 29;
            this.btnCAN.Text = "CAN";
            this.btnCAN.UseVisualStyleBackColor = true;
            this.btnCAN.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnETB
            // 
            this.btnETB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnETB.Location = new System.Drawing.Point(257, 90);
            this.btnETB.Name = "btnETB";
            this.btnETB.Size = new System.Drawing.Size(54, 23);
            this.btnETB.TabIndex = 28;
            this.btnETB.Text = "ETB";
            this.btnETB.UseVisualStyleBackColor = true;
            this.btnETB.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnSYN
            // 
            this.btnSYN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSYN.Location = new System.Drawing.Point(197, 90);
            this.btnSYN.Name = "btnSYN";
            this.btnSYN.Size = new System.Drawing.Size(54, 23);
            this.btnSYN.TabIndex = 27;
            this.btnSYN.Text = "SYN";
            this.btnSYN.UseVisualStyleBackColor = true;
            this.btnSYN.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnNAK
            // 
            this.btnNAK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnNAK.Location = new System.Drawing.Point(137, 90);
            this.btnNAK.Name = "btnNAK";
            this.btnNAK.Size = new System.Drawing.Size(54, 23);
            this.btnNAK.TabIndex = 26;
            this.btnNAK.Text = "NAK";
            this.btnNAK.UseVisualStyleBackColor = true;
            this.btnNAK.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnDLE
            // 
            this.btnDLE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDLE.Location = new System.Drawing.Point(77, 90);
            this.btnDLE.Name = "btnDLE";
            this.btnDLE.Size = new System.Drawing.Size(54, 23);
            this.btnDLE.TabIndex = 25;
            this.btnDLE.Text = "DLE";
            this.btnDLE.UseVisualStyleBackColor = true;
            this.btnDLE.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnSI
            // 
            this.btnSI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSI.Location = new System.Drawing.Point(17, 90);
            this.btnSI.Name = "btnSI";
            this.btnSI.Size = new System.Drawing.Size(54, 23);
            this.btnSI.TabIndex = 24;
            this.btnSI.Text = "SI";
            this.btnSI.UseVisualStyleBackColor = true;
            this.btnSI.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnSO
            // 
            this.btnSO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSO.Location = new System.Drawing.Point(377, 61);
            this.btnSO.Name = "btnSO";
            this.btnSO.Size = new System.Drawing.Size(54, 23);
            this.btnSO.TabIndex = 23;
            this.btnSO.Text = "SO";
            this.btnSO.UseVisualStyleBackColor = true;
            this.btnSO.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnCR
            // 
            this.btnCR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCR.Location = new System.Drawing.Point(317, 61);
            this.btnCR.Name = "btnCR";
            this.btnCR.Size = new System.Drawing.Size(54, 23);
            this.btnCR.TabIndex = 22;
            this.btnCR.Text = "CR";
            this.btnCR.UseVisualStyleBackColor = true;
            this.btnCR.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnFF
            // 
            this.btnFF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnFF.Location = new System.Drawing.Point(257, 61);
            this.btnFF.Name = "btnFF";
            this.btnFF.Size = new System.Drawing.Size(54, 23);
            this.btnFF.TabIndex = 21;
            this.btnFF.Text = "FF";
            this.btnFF.UseVisualStyleBackColor = true;
            this.btnFF.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnVT
            // 
            this.btnVT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnVT.Location = new System.Drawing.Point(197, 61);
            this.btnVT.Name = "btnVT";
            this.btnVT.Size = new System.Drawing.Size(54, 23);
            this.btnVT.TabIndex = 20;
            this.btnVT.Text = "VT";
            this.btnVT.UseVisualStyleBackColor = true;
            this.btnVT.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnLF
            // 
            this.btnLF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnLF.Location = new System.Drawing.Point(137, 61);
            this.btnLF.Name = "btnLF";
            this.btnLF.Size = new System.Drawing.Size(54, 23);
            this.btnLF.TabIndex = 19;
            this.btnLF.Text = "LF";
            this.btnLF.UseVisualStyleBackColor = true;
            this.btnLF.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnHT
            // 
            this.btnHT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnHT.Location = new System.Drawing.Point(77, 61);
            this.btnHT.Name = "btnHT";
            this.btnHT.Size = new System.Drawing.Size(54, 23);
            this.btnHT.TabIndex = 18;
            this.btnHT.Text = "HT";
            this.btnHT.UseVisualStyleBackColor = true;
            this.btnHT.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnBS
            // 
            this.btnBS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnBS.Location = new System.Drawing.Point(17, 61);
            this.btnBS.Name = "btnBS";
            this.btnBS.Size = new System.Drawing.Size(54, 23);
            this.btnBS.TabIndex = 17;
            this.btnBS.Text = "BS";
            this.btnBS.UseVisualStyleBackColor = true;
            this.btnBS.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnBEL
            // 
            this.btnBEL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnBEL.Location = new System.Drawing.Point(377, 32);
            this.btnBEL.Name = "btnBEL";
            this.btnBEL.Size = new System.Drawing.Size(54, 23);
            this.btnBEL.TabIndex = 16;
            this.btnBEL.Text = "BEL";
            this.btnBEL.UseVisualStyleBackColor = true;
            this.btnBEL.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnACK
            // 
            this.btnACK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnACK.Location = new System.Drawing.Point(317, 32);
            this.btnACK.Name = "btnACK";
            this.btnACK.Size = new System.Drawing.Size(54, 23);
            this.btnACK.TabIndex = 15;
            this.btnACK.Text = "ACK";
            this.btnACK.UseVisualStyleBackColor = true;
            this.btnACK.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnENQ
            // 
            this.btnENQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnENQ.Location = new System.Drawing.Point(257, 32);
            this.btnENQ.Name = "btnENQ";
            this.btnENQ.Size = new System.Drawing.Size(54, 23);
            this.btnENQ.TabIndex = 14;
            this.btnENQ.Text = "ENQ";
            this.btnENQ.UseVisualStyleBackColor = true;
            this.btnENQ.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnEOT
            // 
            this.btnEOT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnEOT.Location = new System.Drawing.Point(197, 32);
            this.btnEOT.Name = "btnEOT";
            this.btnEOT.Size = new System.Drawing.Size(54, 23);
            this.btnEOT.TabIndex = 13;
            this.btnEOT.Text = "EOT";
            this.btnEOT.UseVisualStyleBackColor = true;
            this.btnEOT.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnETX
            // 
            this.btnETX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnETX.Location = new System.Drawing.Point(137, 32);
            this.btnETX.Name = "btnETX";
            this.btnETX.Size = new System.Drawing.Size(54, 23);
            this.btnETX.TabIndex = 12;
            this.btnETX.Text = "ETX";
            this.btnETX.UseVisualStyleBackColor = true;
            this.btnETX.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // btnSTX
            // 
            this.btnSTX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSTX.Location = new System.Drawing.Point(77, 32);
            this.btnSTX.Name = "btnSTX";
            this.btnSTX.Size = new System.Drawing.Size(54, 23);
            this.btnSTX.TabIndex = 11;
            this.btnSTX.Text = "STX";
            this.btnSTX.UseVisualStyleBackColor = true;
            this.btnSTX.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 450);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbConnectionLog);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.tbSend);
            this.Controls.Add(this.tabSettings);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabSettings.ResumeLayout(false);
            this.tabServer.ResumeLayout(false);
            this.tabServer.PerformLayout();
            this.tabClient.ResumeLayout(false);
            this.tabClient.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabSettings;
        private System.Windows.Forms.TabPage tabSerial;
        private System.Windows.Forms.TabPage tabServer;
        private System.Windows.Forms.TabPage tabClient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbClientIp;
        private System.Windows.Forms.TextBox tbClientPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbConnectionLog;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox tbSend;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox tbUserFriendlyData;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbClearData;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbRawData;
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
        private System.Windows.Forms.TextBox tbServerPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbServerIp;
        private System.Windows.Forms.Label label4;
    }
}

