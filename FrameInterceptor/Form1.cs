using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        private int _test;
        private byte[] _bytes = new byte[10000];
        private static readonly object _syncRoot = new object();
        ManualResetEvent ShouldRun = new ManualResetEvent(true);
        TcpServer tcp;

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

            //    while (true)
            //    {
            //        Console.WriteLine("Before thread lock");
            //        //ShouldRun.WaitOne();

            //        lock (_bytes)
            //        {
            //            _bytes[0] = 2;
            //            Console.WriteLine(_bytes[0]);
            //        }
            //        Console.WriteLine("After thread lock");

            //        ShouldRun.Reset();

            //        Thread.Sleep(1000);
            //    }
            //}).Start();

            tcp = new TcpServer(new byte[] { 192, 168, 2, 2 }, 4545);
            tcp.DataReceived -= new EventHandler(this.TcpDataReceived);
            tcp.DataReceived += new EventHandler(this.TcpDataReceived);

            tcp.StartListener();
        }

        protected void TcpDataReceived(object sender, EventArgs e)
        {
            byte[] bytes = new byte[tcp.BytesToRead];
            tcp.Read(bytes, 2, 2);
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
            //string test = "Test message";
            //byte[] bytes = Encoding.UTF8.GetBytes(test);
            //tcp.Send(bytes);
            tcp.Close();
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
            tcp.Send(Encoding.UTF8.GetBytes("Test Message"));
        }
    }
}
