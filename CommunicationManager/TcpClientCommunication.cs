using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Communication;

namespace CommunicationManager
{
    public class TcpClientCommunication : iCommunication
    {
        public event EventHandler<DataReceivedEventArgs> DataRecieved;
        private TcpClient _client;
        private string _ipAddress;
        private string _port;

        public TcpClientCommunication(string iIpAddress, string iPort)
        {
            this._client = new TcpClient();
            this._ipAddress = iIpAddress;
            this._port = iPort;

            this._client.ConnetionTimeout = 10000;
            this._client.ClearBufferOnRead = true;
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

        public async Task<ManagerConnectionResult> Open()
        {
            try
            {
                this._client.SetRemoteEndPoint(this._ipAddress, this._port);
            }
            catch (ArgumentException ex)
            {
                return ManagerConnectionResult.Failed;
            }

            ConnectionResult result = 0;
            try
            {
                result = await this._client.ConnectAsync();
            }
            catch (ObjectDisposedException)
            {
                return ManagerConnectionResult.HandlerDisposed;
            }
            catch (Exception)
            {
                throw;
            }

            if (result == ConnectionResult.Connected)
            {
                this.InternalReadAsync();
            }

            return (ManagerConnectionResult)result;
        }

        private async void InternalReadAsync()
        {
            int bytesToRead = await this._client.ReadStreamAsync();

            DataReceivedEventArgs args = new DataReceivedEventArgs();

            if (bytesToRead > 0)
            {
                args.Data = new byte[bytesToRead];
                args.DataLength = this._client.Read(args.Data, 0, bytesToRead);

                this.OnDataRecieved(args);

                this.InternalReadAsync();
            }
            else
            {
                args.DataLength = bytesToRead;
                this.OnDataRecieved(args);
            }
        }

        public int SendData(byte[] iData)
        {
            return this._client.Write(iData);
        }

        public void Dispose()
        {
            if (!this._client.Disposed)
                this._client.Dispose();
        }

        public bool IsConnected { get => this._client.IsConnected; }
        public TcpClient Client { get => _client; }
    }
}
