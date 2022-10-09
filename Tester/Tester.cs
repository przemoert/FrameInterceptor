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
using FrameInterceptor;
using FrameInterceptor.Communication;
using System.IO.Ports;

namespace Tester
{
    public partial class Tester : Form
    {
        private Test _test;

        public Tester()
        {
            InitializeComponent();

            this.Testings();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private async void Testings()
        {
            await Testsss();
        }

        private async Task Testsss()
        {
            Test test = new Test();
            //WeakReference wr = new WeakReference(test);
            test.Dispose();
            test = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _test = new Test();
            this.button1.Enabled = false;
        }
    }

    class Test
    {
        public int a;
        public string b;
        public bool c;
        //public List<String> _list = new List<String>();
        //public SocketServer _server;
        //private int _disposed = 0;

        public Test()
        {
            a = 5;
            b = "trasdfasdf";
            c = true;

            //_list.Add("test");

            //_server = new SocketServer("192.168.2.2", "4545");
        }

        public void Dispose()
        {
            
        }
    }
}
