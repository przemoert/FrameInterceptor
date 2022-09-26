using Communication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tester
{
    public partial class Tester : Form
    {
        public Tester()
        {
            InitializeComponent();

            Start();
        }

        public async void Start()
        {
            TcpServer server = new TcpServer(new byte[] { 192, 168, 1, 61 }, 4545);
            server.TcpDataReceived += new EventHandler<TcpDataEventArgs>(OnDataReceived);
            server.InitListener();
            await server.ListenForClient();
            server.ReadAsync(server.Handler);
        }

        private void OnDataReceived(object sender, TcpDataEventArgs e)
        {
            
        }
    }
}
