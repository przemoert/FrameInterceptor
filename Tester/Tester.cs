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
        SocketServer socketServer;
        SocketClient client;
        private static int counter = 0;
        private int limit = 100;

        public Tester()
        {
            InitializeComponent();

            socketServer = new SocketServer(new byte[] { 192, 168, 2, 2 }, 4545);
            socketServer.Init();

            Run();

            //Testing();
        }

        //private void Testing()
        //{
        //    while (counter < limit)
        //    {
        //        new Thread(() =>
        //        {
        //            int i = counter++;
        //            Thread.CurrentThread.IsBackground = true;
        //            Thread.CurrentThread.Name = "TName" + i;

        //            ConnectToServer(i);
        //        }).Start();
        //    }
        //}

        private async void Run()
        {
            await Start();
        }

        //private async void ConnectToServer(int i)
        //{
        //    SocketClient tcpClient = new SocketClient();
        //    tcpClient.Connect(new byte[] { 192, 168, 1, 61 }, 4545);

        //    for (int j = 0; j < 3; j++)
        //    {
        //        byte[] msg = Encoding.UTF8.GetBytes("Thread " + i + "; Message no" + j + "\r\n");
        //        tcpClient.Send(msg, 0, msg.Length);
        //    }
        //}

        public async Task Start()
        {
            SocketClient socketClient = null;

            await Task.Run(() =>
            {
                socketClient = socketServer.OpenToClient(4096);
            });

            this.Start();
            this.Read(socketClient);
        }

        public async void Read(SocketClient client)
        {
            int bytesTransfered = 0;

            try
            {
                bytesTransfered = await client.ReadSocketAsnyc();
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.ToString());
            }
            
            if (bytesTransfered > 0)
            {

                client.Send(new byte[] { 6 }, 0, 1);

                byte[] buffer = new byte[bytesTransfered];
                client.Read(buffer, 0, buffer.Length);

                //this.textBox1.AppendText(Encoding.UTF8.GetString(buffer) + "\r\n");

                this.Read(client);

               Console.WriteLine(Encoding.UTF8.GetString(buffer));

            }
        }
    }
}
