using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Communication;

namespace CommunicationManager
{
    public class ComManager
    {
        public event EventHandler<DataReceivedEventArgs> DataRecieved;

        private iCommunication _communication;


        public ComManager(string iIpAddress, string iPort, bool isClient)
        {
            if (isClient)
                this._communication = new TcpClientCommunication(iIpAddress, iPort);
            //else
                //this._communication = new TcpServerCommunication(iIpAddress, iPort);
        }

        public ComManager(string iPort)
        {
            //this._communication = new TcpServerCommunication(Int32.Parse(iPort));
        }

        public async Task<int> Open()
        {
            this._communication.DataRecieved -= new EventHandler<DataReceivedEventArgs>(this.OnDataReceived);
            this._communication.DataRecieved += new EventHandler<DataReceivedEventArgs>(this.OnDataReceived);

            int result = await this._communication.Open();

            return result;
        }

        public int SendData(byte[] iData)
        {
            return this._communication.SendData(iData);
        }

        public void Close()
        {
            this._communication.Close();
        }

        protected void OnDataReceived(object sender, DataReceivedEventArgs e)
        {
            this.DataRecieved?.Invoke(this, e);
        }

        public void Dispose()
        {
            this._communication.Dispose();
        }

        public bool IsConnected { get => this._communication.IsConnected; }
        public iCommunication Communication { get => this._communication; }
    }
}
