using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Communication;

namespace FrameInterceptor
{
    public partial class Form1 : Form
    {
        private int _test;
        private byte[] _bytes = new byte[10000];
        private static readonly object _syncRoot = new object();
        ManualResetEvent ShouldRun = new ManualResetEvent(true);
        TcpServer tcp;
        Communication.TcpClient client;
        NetworkStream stream = null;
        int threadLockTest = 0;
        int threadLockTest2 = 0;

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


            client = new Communication.TcpClient();
            client.AutoReconnect = true;

            client.Connect(new byte[] { 192, 168, 2, 2 }, 4545);
            client.DataReceived -= new EventHandler(TcpDataReceived);
            client.DataReceived += new EventHandler(TcpDataReceived);
            client.ConnectionRefused -= new EventHandler(ConnectionRefused);
            client.ConnectionRefused += new EventHandler(ConnectionRefused);

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

        protected void TcpDataReceived(object sender, EventArgs e)
        {
            byte[] bytes = new byte[client.BytesToRead];
            client.Read(bytes, 0, bytes.Length);

            Console.WriteLine(Encoding.UTF8.GetString(bytes));
        }

        protected void ConnectionRefused(object sender, EventArgs e)
        {
            Console.WriteLine("Connection refused by remote host");
        }

        protected void OnDataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine(e.Data.ToString());
        }

        private void ThreadTest()
        {

            while (true)
            {
                Console.WriteLine("Test");

                ShouldRun.WaitOne();

                Thread.Sleep(100);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            client.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tcp = new TcpServer(new byte[] { 192, 168, 2, 2 }, 4545);
            tcp.DataReceived -= new EventHandler(this.TcpDataReceived);
            tcp.DataReceived += new EventHandler(this.TcpDataReceived);

            tcp.StartListener();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte[] data = Encoding.UTF8.GetBytes("Test message");
            client.Write("Test message");
        }
    }
}
