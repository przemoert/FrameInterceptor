using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Communication
{
    public class SocketServer : IDisposable
    {
        private Socket _socket;
        private IPEndPoint _socketEP;
        private int _disposed = 0;
        private bool _started = false;

        public bool Disposed { get => this._disposed != 0; }


        public SocketServer(IPEndPoint iLocalEP)
        {
            if (iLocalEP == null)
                throw new ArgumentNullException("iLocalEP");

            this._socketEP = iLocalEP;
            this._socket = new Socket(this._socketEP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }

        public SocketServer(IPAddress iIpAddress, int iPort)
        {
            if (iIpAddress == null)
                throw new ArgumentNullException("iIpAddress");

            if (!Validation.ValidatePort(iPort))
                throw new ArgumentOutOfRangeException("iPort");

            this._socketEP = new IPEndPoint(iIpAddress, iPort);
            this._socket = new Socket(this._socketEP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }

        public SocketServer(byte[] iIpAddress, int iPort)
        {
            if (!Validation.ValidateIp(iIpAddress))
                throw new ArgumentOutOfRangeException("iIpAddress");

            if (!Validation.ValidatePort(iPort))
                throw new ArgumentOutOfRangeException("iPort");

            this._socketEP = new IPEndPoint(new IPAddress(iIpAddress), iPort);
            this._socket = new Socket(this._socketEP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Init()
        {
            this.Init((int)SocketOptionName.MaxConnections);
        }

        public void Init(int iBacklog)
        {
            if (this._socket == null)
                throw new ArgumentNullException("_socket");

            if (this._started)
                return;

            try
            {
                this._socket.Bind(this._socketEP);
                this._socket.Listen(iBacklog);
            }
            catch (Exception ex)
            {
                this.Undo();
                throw;
            }

            this._started = true;
        }

        public void Undo()
        {
            if (this._socket != null)
            {
                this._socket.Close();
                this._socket.Dispose();
                this._socket = null;
            }

            this._started = false;
        }

        public SocketClient OpenToClient()
        {
            if (!this._started)
                throw new InvalidOperationException();

            SocketClient l_client = new SocketClient(this, 4096);
            l_client.Client = this._socket.Accept();

            return l_client;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
