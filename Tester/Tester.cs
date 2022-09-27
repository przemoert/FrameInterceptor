using Communication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tester
{
    public partial class Tester : Form
    {
        TcpServer server = null;
        private static int counter = 0;
        private int limit = 2;

        public Tester()
        {
            InitializeComponent();

            server = new TcpServer(new byte[] { 192, 168, 2, 2 }, 4545);
            server.ClientsLimit = 20;
            server.InitListener();

            Start();

            //Testing();
        }

        private void Testing()
        {
            while (counter < limit)
            {
                new Thread(() =>
                {
                    int i = counter++;
                    Thread.CurrentThread.IsBackground = true;
                    Thread.CurrentThread.Name = "TName" + i;

                    ConnectToServer(i);
                }).Start();
            }
        }

        private async void ConnectToServer(int i)
        {
            Communication.TcpClient tcpClient = new Communication.TcpClient();
            tcpClient.ConnetionTimeout = 60000;
            tcpClient.SetRemoteEndPoint(new byte[] { 192, 168, 2, 2 }, 4545);
            await tcpClient.ConnectAsync();
            tcpClient.Write(Encoding.UTF8.GetBytes("Test" + i + " " + Thread.CurrentThread.Name));
        }

        public async void Start()
        {
            SocketClient client = await server.ListenForClient();

            byte[] buffer = new byte[1024];
            client.ReadStream(buffer, 0, 1024);

            string msg = Encoding.UTF8.GetString(buffer) + "\r\n";

            this.textBox1.Text += msg;

            this.Start();
        }

        public async void Read(SocketClient client)
        {
            int test = await server.ReadAsync(client);

            byte[] buffer = new byte[test];

            client.Read(buffer, 0, test);

            string msg = Encoding.UTF8.GetString(buffer) + "\r\n";

            this.textBox1.Text += msg;

            this.Read(client);
        }

        private void OnDataReceived(object sender, TcpDataEventArgs e)
        {
            
        }
    }
}
