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

        private TcpServer _tcpServer;

        public TcpServerCommunication(int iPort)
        {
            this._tcpServer = new TcpServer(iPort);
        }

        public TcpServerCommunication(string iIpAddress, string iPort)
        {
            this._tcpServer = new TcpServer(iIpAddress, iPort);
        }

        public void Close()
        {
            this._tcpServer.Close();
        }

        public bool IsOpen()
        {
            throw new NotImplementedException();
        }

        public void OnDataRecieved(DataReceivedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public async Task<ManagerConnectionResult> Open()
        {
            ConnectionResult result = this._tcpServer.InitListener();

            if (result != ConnectionResult.Listening)
                return (ManagerConnectionResult)result;

            //result = await this._tcpServer.ListenForClient();

            return (ManagerConnectionResult)result;
        }

        public int SendData(byte[] iData)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            if (!this._tcpServer.Disposed)
                this._tcpServer.Dispose();
        }

        public bool IsConnected => throw new NotImplementedException();
        public TcpServer TcpServer { get => this._tcpServer; }
    }
}
