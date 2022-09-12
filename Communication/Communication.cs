using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communication
{
    public enum CommunicationType
    {
        Serial,
        TCP
    }

    public class Communication
    {
        public event EventHandler<DataReceivedEventArgs> DataRecieved;

        private CommunicationBase _communication;
        private CommunicationType _communicationType;

        public Communication(CommunicationType iCommunicationType)
        {
            if (iCommunicationType == CommunicationType.Serial)
            {
                this._communicationType = CommunicationType.Serial;
                this._communication = new SerialCommunication();
            }
        }

        public bool Open()
        {
            if (this._communicationType == CommunicationType.Serial)
            {
                this._communication.Name = this.Name;
                this._communication.BaudRate = this.BaudRate;
                this._communication.Parity = this.Parity;
                this._communication.DataBits = this.DataBits;
                this._communication.StopBits = this.StopBits;
                this._communication.Handshake = this.Handshake;

                if (!this._communication.Open())
                {
                    return false;
                }

                this._communication.DataRecieved -= new EventHandler<DataReceivedEventArgs>(this.OnDataReceived);
                this._communication.DataRecieved += new EventHandler<DataReceivedEventArgs>(this.OnDataReceived);
            }

            return true;
        }

        public bool IsOpen()
        {
            return this._communication.IsOpen();
        }

        public void SendData(char[] iData)
        {
            bool result = this._communication.SendData(iData);

            if (!result)
            {
                Console.WriteLine("Could not send data.");
            }
        }

        protected void OnDataReceived(object sender, DataReceivedEventArgs e)
        {
            this.DataRecieved?.Invoke(this, e);
        }

        protected void BubbleUpEvent(DataReceivedEventArgs e)
        {
            this.DataRecieved?.Invoke(this, e);
        }

        public Handshake Handshake { get; set; }
        public int BaudRate { get; set; }
        public Parity Parity { get; set; }
        public int DataBits { get; set; }
        public StopBits StopBits { get; set; }
        public string Name { get;  set; }
    }
}
