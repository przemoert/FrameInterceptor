using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Communication;

namespace CommunicationManager
{
    public class TcpServerCommunication : iCommunication
    {
        public event EventHandler<DataReceivedEventArgs> DataRecieved;


        private SocketServer _server;
        private string _ipAddress;
        private string _port;
        private int _maxConnections;

        public bool IsConnected { get => (this._server != null && this._server.Started); }
        public ConnectionResult ConnectionResult { get => this._server.ConnectionResult; }


        public TcpServerCommunication(string iIpAddress, string iPort, int iMaxConnections)
        {
            this._ipAddress = iIpAddress;
            this._port = iPort;
            this._maxConnections = iMaxConnections;
        }

        public async Task<int> Open()
        {
            //This method cant block so it always returns integer representation of ConnectionResult.Success aside exceptions;

            this._server = new SocketServer(this._ipAddress, this._port);
            this._server.MaxConnections = this._maxConnections;

            try
            {
                this._server.Init(10);
            }
            catch (Exception ex)
            {
                return (int)this.ConnectionResult;
            }

            return (int)ConnectionResult.Success;
        }

        private async void InternalListenForClient()
        {
            SocketClient l_Client = await Task<SocketClient>.Run(() =>
            {
                return this._server.OpenToClient(4096);
            });
        }

        public bool IsOpen()
        {
            throw new NotImplementedException();
        }

        public void OnDataRecieved(DataReceivedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public int SendData(byte[] iData)
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
