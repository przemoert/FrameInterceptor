using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace Communication
{
    internal class SerialCommunication : CommunicationBase
    {
        internal override event EventHandler<DataReceivedEventArgs> DataRecieved;

        public SerialCommunication()
        {
            this._serialPort = new SerialPort();
        }

        internal override void Close()
        {
            throw new NotImplementedException();
        }

        internal override bool Open()
        {
            this._serialPort.PortName = this._name;
            this._serialPort.BaudRate = this._baudRate;
            this._serialPort.Parity = this._parity;
            this._serialPort.DataBits = this._dataBits;
            this._serialPort.StopBits = this._stopBits;
            this._serialPort.Handshake = this._handshake;

            this._serialPort.DataReceived -= new SerialDataReceivedEventHandler(this.OnSerialDataRecieved);
            this._serialPort.DataReceived += new SerialDataReceivedEventHandler(this.OnSerialDataRecieved);

            try
            {
                this._serialPort.Open();
                this._serialPort.DiscardOutBuffer();
                this._serialPort.DiscardInBuffer();

                Console.WriteLine("Serial port opened. Waiting for data...");
            }
            catch(UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Port {this._serialPort.PortName} is busy.");

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

                return false;
            }

            return true;
        }

        internal override bool IsOpen()
        {
            return this._serialPort.IsOpen;
        }

        internal override bool SendData(char[] iData)
        {
            if (this._serialPort.IsOpen)
            {
                this._serialPort.Write(iData, 0, iData.Length);

                return true;
            }
            else
            {
                Console.WriteLine($"{this._serialPort.PortName} is closed");
            }


            return false;
        }

        protected void OnSerialDataRecieved(object sender, SerialDataReceivedEventArgs e)
        {
            int bytesToRead = this._serialPort.BytesToRead;
            byte[] bytes = new byte[bytesToRead];

            this._serialPort.Read(bytes, 0, bytesToRead);

            this._serialPort.DiscardOutBuffer();
            this._serialPort.DiscardInBuffer();

            DataReceivedEventArgs dataRecieved = new DataReceivedEventArgs();
            dataRecieved.Data = bytes;

            this.OnDataRecieved(dataRecieved);
        }

        protected override void OnDataRecieved(DataReceivedEventArgs e)
        {
            DataRecieved?.Invoke(this, e);
        }
    }
}
