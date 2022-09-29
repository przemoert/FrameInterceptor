using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Communication;

namespace CommunicationManager
{
    public class TcpClientCommunication : iCommunication
    {
        public event EventHandler<DataReceivedEventArgs> DataRecieved;

        private SocketClient _client;
        private string _ipAddress;
        private string _port;

        public TcpClientCommunication(string iIpAddress, string iPort)
        {
            this._client = new SocketClient();
            this._ipAddress = iIpAddress;
            this._port = iPort;

            /*
             * !!!!!!!!!!
             */
            this._client.ConnectionTimeout = 10000;
        }

        public void Close()
        {
            this._client.Close();
        }

        public bool IsOpen() => this.IsConnected;

        public void OnDataRecieved(DataReceivedEventArgs e)
        {
            this.DataRecieved?.Invoke(this, e);
        }

        public async Task<int> Open()
        {
            bool result = false;
            try
            {
                result = await Task<bool>.Run(() =>
                {
                    return this._client.Connect(this._ipAddress, this._port);
                });
            }
            catch (ObjectDisposedException ex)
            {

            }
            catch (Exception ex)
            {
                throw;
            }

            if (result)
            {
                this.InternalReadAsync();
            }

            return (int)this._client.ConnectionResult;
        }

        private async void InternalReadAsync()
        {
            int l_BytesToRead = 0;


            //No need for try catch because all socket exception are outed on lower layer and another exception has to be thrown anyway
            l_BytesToRead = await this._client.ReadSocketAsnyc();

            DataReceivedEventArgs args = new DataReceivedEventArgs();

            if (l_BytesToRead > 0)
            {
                args.Data = new byte[l_BytesToRead];
                args.DataLength = this._client.Read(args.Data, 0, l_BytesToRead);

                this.OnDataRecieved(args);

                this.InternalReadAsync();
            }
            else if (l_BytesToRead == 0)
            {
                args.DataLength = 0;

                this.OnDataRecieved(args);
            }
        }

        public int SendData(byte[] iData)
        {
            return this._client.Send(iData, 0, iData.Length);
        }

        public void Dispose()
        {
            if (!this._client.Disposed)
                this._client.Dispose();
        }

        public bool IsConnected { get => this._client.Connected; }
        public ConnectionResult ConnectionResult { get => this._client.ConnectionResult; }
        public SocketClient Client { get => _client; }
    }
}
