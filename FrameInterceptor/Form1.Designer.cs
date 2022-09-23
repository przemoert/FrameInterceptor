
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSerial = new System.Windows.Forms.TabPage();
            this.tabServer = new System.Windows.Forms.TabPage();
            this.tabClient = new System.Windows.Forms.TabPage();
            this.tbTcpClientLog = new System.Windows.Forms.TextBox();
            this.btnClientConnect = new System.Windows.Forms.Button();
            this.tbClientPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbClientIp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbClientSend = new System.Windows.Forms.TextBox();
            this.btnClientSend = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSerial);
            this.tabControl1.Controls.Add(this.tabServer);
            this.tabControl1.Controls.Add(this.tabClient);
            this.tabControl1.Location = new System.Drawing.Point(453, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(602, 203);
            this.tabControl1.TabIndex = 0;
            // 
            // tabSerial
            // 
            this.tabSerial.BackColor = System.Drawing.SystemColors.Control;
            this.tabSerial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabSerial.Location = new System.Drawing.Point(4, 25);
            this.tabSerial.Name = "tabSerial";
            this.tabSerial.Padding = new System.Windows.Forms.Padding(3);
            this.tabSerial.Size = new System.Drawing.Size(594, 174);
            this.tabSerial.TabIndex = 0;
            this.tabSerial.Text = "Serial";
            // 
            // tabServer
            // 
            this.tabServer.BackColor = System.Drawing.SystemColors.Control;
            this.tabServer.Location = new System.Drawing.Point(4, 25);
            this.tabServer.Name = "tabServer";
            this.tabServer.Padding = new System.Windows.Forms.Padding(3);
            this.tabServer.Size = new System.Drawing.Size(594, 174);
            this.tabServer.TabIndex = 1;
            this.tabServer.Text = "TCP Server";
            // 
            // tabClient
            // 
            this.tabClient.BackColor = System.Drawing.SystemColors.Control;
            this.tabClient.Controls.Add(this.tbTcpClientLog);
            this.tabClient.Controls.Add(this.btnClientConnect);
            this.tabClient.Controls.Add(this.tbClientPort);
            this.tabClient.Controls.Add(this.label2);
            this.tabClient.Controls.Add(this.tbClientIp);
            this.tabClient.Controls.Add(this.label1);
            this.tabClient.Location = new System.Drawing.Point(4, 25);
            this.tabClient.Name = "tabClient";
            this.tabClient.Padding = new System.Windows.Forms.Padding(3);
            this.tabClient.Size = new System.Drawing.Size(594, 174);
            this.tabClient.TabIndex = 2;
            this.tabClient.Text = "TCP Client";
            // 
            // tbTcpClientLog
            // 
            this.tbTcpClientLog.Location = new System.Drawing.Point(6, 66);
            this.tbTcpClientLog.Multiline = true;
            this.tbTcpClientLog.Name = "tbTcpClientLog";
            this.tbTcpClientLog.Size = new System.Drawing.Size(582, 102);
            this.tbTcpClientLog.TabIndex = 6;
            // 
            // btnClientConnect
            // 
            this.btnClientConnect.Location = new System.Drawing.Point(513, 7);
            this.btnClientConnect.Name = "btnClientConnect";
            this.btnClientConnect.Size = new System.Drawing.Size(75, 38);
            this.btnClientConnect.TabIndex = 5;
            this.btnClientConnect.Text = "Connect";
            this.btnClientConnect.UseVisualStyleBackColor = true;
            this.btnClientConnect.Click += new System.EventHandler(this.btnClientConnect_Click);
            // 
            // tbClientPort
            // 
            this.tbClientPort.Location = new System.Drawing.Point(284, 15);
            this.tbClientPort.Name = "tbClientPort";
            this.tbClientPort.Size = new System.Drawing.Size(74, 22);
            this.tbClientPort.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(240, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port:";
            // 
            // tbClientIp
            // 
            this.tbClientIp.Location = new System.Drawing.Point(43, 13);
            this.tbClientIp.Name = "tbClientIp";
            this.tbClientIp.Size = new System.Drawing.Size(160, 22);
            this.tbClientIp.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP:";
            // 
            // tbClientSend
            // 
            this.tbClientSend.Location = new System.Drawing.Point(463, 221);
            this.tbClientSend.Name = "tbClientSend";
            this.tbClientSend.Size = new System.Drawing.Size(481, 22);
            this.tbClientSend.TabIndex = 1;
            // 
            // btnClientSend
            // 
            this.btnClientSend.Location = new System.Drawing.Point(951, 220);
            this.btnClientSend.Name = "btnClientSend";
            this.btnClientSend.Size = new System.Drawing.Size(100, 24);
            this.btnClientSend.TabIndex = 2;
            this.btnClientSend.Text = "Send";
            this.btnClientSend.UseVisualStyleBackColor = true;
            this.btnClientSend.Click += new System.EventHandler(this.btnClientSend_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.btnClientSend);
            this.Controls.Add(this.tbClientSend);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabClient.ResumeLayout(false);
            this.tabClient.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSerial;
        private System.Windows.Forms.TabPage tabServer;
        private System.Windows.Forms.TabPage tabClient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbClientIp;
        private System.Windows.Forms.TextBox tbClientPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbTcpClientLog;
        private System.Windows.Forms.Button btnClientConnect;
        private System.Windows.Forms.TextBox tbClientSend;
        private System.Windows.Forms.Button btnClientSend;
    }
}

