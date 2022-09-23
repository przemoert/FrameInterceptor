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

namespace FrameInterceptor
{
    public partial class Form1 : Form
    {
        private TcpClient _tcpClient;
        private string _clientIpAddress = String.Empty;
        private string _clientPort = String.Empty;

        public Form1()
        {
            InitializeComponent();

            //Communication.Communication comm = new Communication.Communication(CommunicationType.Serial);
            //comm.Name = "COM5";
            //comm.BaudRate = 9600;
            //comm.DataBits = 8;
            //comm.StopBits = System.IO.Ports.StopBits.One;
            //comm.Parity = System.IO.Ports.Parity.None;

            //comm.DataRecieved -= new EventHandler<DataReceivedEventArgs>(this.OnDataReceived);
            //comm.DataRecieved += new EventHandler<DataReceivedEventArgs>(this.OnDataReceived);


            //Console.WriteLine(comm.IsOpen());
            //comm.Open();
            //Console.WriteLine(comm.IsOpen());

            //new Thread(() =>
            //{
            //    Thread.CurrentThread.IsBackground = true;

            //    lock(_syncRoot)
            //    {
            //        Thread.Sleep(10000);
            //        threadLockTest = 1;
            //    }
            //}).Start();

            //tcp = new TcpServer(new byte[] { 192, 168, 2, 2 }, 4545);
            //tcp.DataReceived -= new EventHandler(this.TcpDataReceived);
            //tcp.DataReceived += new EventHandler(this.TcpDataReceived);

            //tcp.StartListener();


            //client = new Communication.TcpClient();
            //client.AutoReconnect = true;

            //client.Connect(new byte[] { 192, 168, 2, 2 }, 4545);
            //client.DataReceived -= new EventHandler(TcpDataReceived);
            //client.DataReceived += new EventHandler(TcpDataReceived);
            //client.ConnectionRefused -= new EventHandler(ConnectionRefused);
            //client.ConnectionRefused += new EventHandler(ConnectionRefused);

            //try
            //{
            //    client.StartTalking();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //}

            //client.Close();

            //int test = client.Write("Test message");

            //client.Connect(new byte[] { 192, 168, 2, 2 }, 4545);

            //client.Write("Test message");

            //client.Connect(new byte[] { 192, 168, 2, 2 }, 4545);
            //client.Read(0, 1024);

        }

        private void btnClientConnect_Click(object sender, EventArgs e)
        {
            this._clientIpAddress = tbClientIp.Text;
            this._clientPort = tbClientPort.Text;

            if (!String.IsNullOrEmpty(this._clientIpAddress) && !String.IsNullOrEmpty(this._clientPort))
            {
                this._tcpClient = new TcpClient();
                this._tcpClient.Connected -= new EventHandler(this.OnTcpClientConnected);
                this._tcpClient.Connected += new EventHandler(this.OnTcpClientConnected);

                if (!this._tcpClient.Connect(this._clientIpAddress, this._clientPort, true))
                {
                    this.TcpClientLog("Connection failed");
                }
            }
        }

        private void OnTcpClientConnected(object sender, EventArgs e)
        {
            this.TcpClientLog("Connected to: " + this._clientIpAddress);
        }

        private void TcpClientLog(string msg)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(TcpClientLog), new object[] { msg });
                return;
            }

            this.tbTcpClientLog.Text += msg + "\r\n";
        }

        private void btnClientSend_Click(object sender, EventArgs e)
        {
            int bytes = this._tcpClient.Write(this.tbClientSend.Text);
        }
    }
}
