using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Communication
{
    public class TcpClient
    {
        const int BUFFER_SIZE = 1024;

        private IPEndPoint _remoteEndPoint;
        private Socket _client;
        private int _remotePort = 0;
        private int _bufferSize;
        private AddressFamily? _family = null;
        private NetworkStream _stream = null;
        private byte[] _remoteAddress = new byte[4];


        public TcpClient() : this(AddressFamily.InterNetwork) { }

        private TcpClient(AddressFamily family)
        {
            this._family = family;
            //this._client = new Socket(family, SocketType.Stream, ProtocolType.Tcp);
        }

        public bool Connect(byte[] iIpAddress, int iPort)
        {
            this._remoteAddress = iIpAddress;
            this._remotePort = iPort;

            if (this._family == null)
            {
                throw new NullReferenceException();
            }

            if (this._client == null && this._family != null)
            {
                this.InitializeClient();
            }

            if (this._client != null && this._family != null && this._client.RemoteEndPoint != null)
            {
                if (!this.IsConnected)
                {
                    this.InitializeClient();
                }
            }

            if (!this.IsConnected)
            {
                IPAddress ipAddress = new IPAddress(this._remoteAddress);
                try
                {
                    this._client.Connect(ipAddress, iPort);
                }
                catch (SocketException)
                {
                    return false;
                }
            }

            return true;
        }

        private void InitializeClient()
        {
            this._client = new Socket((AddressFamily)this._family, SocketType.Stream, ProtocolType.Tcp);
        }

        private NetworkStream GetStream()
        {
            return new NetworkStream(this._client, true);
        }

        private void CompareStream()
        {
            NetworkStream tmpStream = this.GetStream();

            if (!object.ReferenceEquals(this._stream, tmpStream))
            {
                this._stream = tmpStream;
            }
        }

        public void Write(string message)
        {
            if (!this.IsConnected)
            {
                this.Connect(this._remoteAddress, this._remotePort);
            }

            this.CompareStream();

            
            byte[] data = Encoding.UTF8.GetBytes(message);
            this._stream.Write(data, 0, data.Length);
        }

        public bool IsConnected
        {
            get
            {
                if (this._client == null || (this._client != null && !this._client.Connected))
                {
                    return false;
                }

                try
                {
                    return !(this._client.Poll(1000, SelectMode.SelectRead) && this._client.Available == 0);
                }
                catch (SocketException)
                {
                    return false;
                }
                catch (NullReferenceException)
                {
                    return false;
                }
                catch (ObjectDisposedException)
                {
                    return false;
                }
            }
        }
    }
}
