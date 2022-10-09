using FrameInterceptor.Utils;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Communication;
using System.IO;

namespace FrameInterceptor.Communication
{
    internal class SerialCommunication : IDisposable
    {
        private static readonly int[] BAUD_RATES = { 300, 600, 1200, 2400, 9600, 14400, 19200, 38400, 57600, 115200 };
        private static readonly int[] DATA_BITS = { 5, 6, 7, 8 };

        private SerialPort _serialPort;
        private string _portName;
        private int _baudRate;
        private int _dataBits;
        private StopBits _stopBits;
        private Handshake _handshake;
        private Parity _parity;

        private FrameInterceptor_v2 _owningForm;
        private ConnectionResult _conenctionResult;
        private byte[] _buffer = new byte[0];
        private bool _closing = false;
        private int _disposed = 0;
        private bool _rtsAllowed;
        

        public SerialCommunication(FrameInterceptor_v2 iOwner)
        {
            this._owningForm = iOwner;

            this._portName = this._owningForm.icSerialPort.Value.ToString();
            this._baudRate = (int)this._owningForm.icSerialBaudRate.Value;
            this._dataBits = (int)this._owningForm.icSerialDataBits.Value;
            this._stopBits = (StopBits)this._owningForm.icSerialStopBits.Value;
            this._handshake = (Handshake)this._owningForm.icSerialHandshake.Value;
            this._parity = (Parity)this._owningForm.icSerialParity.Value;

            this._serialPort = new SerialPort(this._portName, this._baudRate, this._parity, this._dataBits, this._stopBits);
            this._serialPort.Handshake = this._handshake;

            this._rtsAllowed = this._handshake != Handshake.RequestToSend && this._handshake != Handshake.RequestToSendXOnXOff;

            if (this._rtsAllowed)
                this._serialPort.RtsEnable = this._owningForm.chkRTS.Checked;
            
            this._serialPort.DtrEnable = this._owningForm.chkRTS.Checked;

            this._serialPort.PinChanged -= new SerialPinChangedEventHandler(this.OnPinStateChange);
            this._serialPort.PinChanged += new SerialPinChangedEventHandler(this.OnPinStateChange);
        }

        private void OnPinStateChange(object sender, SerialPinChangedEventArgs e)
        {
            SerialPinChange l_PinChange = e.EventType;

            if (l_PinChange == SerialPinChange.Break)
            {
                
            }
            else if (l_PinChange == SerialPinChange.CDChanged)
            {
                this._owningForm.ldCD.On = (this._owningForm.ldCD.On) ? false : true;
            }
            else if (l_PinChange == SerialPinChange.CtsChanged)
            {
                this._owningForm.ldCTS.On = (this._owningForm.ldCTS.On) ? false : true;
            }
            else if (l_PinChange == SerialPinChange.DsrChanged)
            {
                this._owningForm.ldDSR.On = (this._owningForm.ldDSR.On) ? false : true;
            }
            else if (l_PinChange == SerialPinChange.Ring)
            {
                this._owningForm.ldRI.On = (this._owningForm.ldRI.On) ? false : true;
            }
        }

        public void Open()
        {


            try
            {
                this._serialPort.Open();

                this._owningForm.ldCD.On = this._serialPort.CDHolding;
                this._owningForm.ldCTS.On = this._serialPort.CtsHolding;
                this._owningForm.ldDSR.On = this._serialPort.DsrHolding;

                this._conenctionResult = ConnectionResult.Success;
            }
            catch (UnauthorizedAccessException)
            {
                this._conenctionResult = ConnectionResult.SerialAccessDenied;
            }
            catch (IOException)
            {
                this._conenctionResult = ConnectionResult.SerialNotExists;
            }

            if (this._conenctionResult != ConnectionResult.Success)
            {
                this._owningForm.ResultLog(this._conenctionResult);

                return;
            }

            this.Receive();
        }

        public async void Receive()
        {
            //Temporary buffer to fill with first byte when data arrives.
            byte[] l_TempBuffer = new byte[1];
            int l_BytesTransfered = 0;

            try
            {
                l_BytesTransfered = await Task<int>.Run(() =>
                {
                    return this._serialPort.Read(l_TempBuffer, 0, 1);
                });
            }
            catch (IOException)
            {
                if (this._closing)
                {
                    this._owningForm.ResultLog(ConnectionResult.SerialClosed);
                }
                else
                {
                    this._owningForm.ResultLog(ConnectionResult.SerialIOInterrupted);
                }

                this._owningForm.SerialChangeStatus(true);

                return;
            }

            //Cant tell if this is possible
            if (l_BytesTransfered == 0)
                this.Receive();

            //Wait short ammount of time to check if more data will arrive.
            await Task.Delay(50);

            //if no more data available spit l_TempBuffer out and recursive call;
            if (this._serialPort.BytesToRead == 0)
            {
                await this._owningForm.ComLog(l_TempBuffer, 1, false);
                this.Receive();
            }

            //Create new buffer with size of l_TempBuffer.Length(1) + SerialPort.BytesToRead + this._buffer.Length and copy data from temporary buffer.
            int l_DataAvailable = this._serialPort.BytesToRead;
            this.ResizeBuffer(l_TempBuffer, l_TempBuffer.Length + l_DataAvailable + this._buffer.Length);

            this._serialPort.Read(this._buffer, l_TempBuffer.Length, l_DataAvailable);

            await this._owningForm.ComLog(this._buffer, this._buffer.Length, false);
            
            this.ResetBuffer();

            this.Receive();
        }

        private void ResizeBuffer(byte[] iData, int iNewSize)
        {
            byte[] l_TempBuffer = new byte[this._buffer.Length];
            
            if (l_TempBuffer.Length > 0)
            {
                Array.Copy(this._buffer, 0, l_TempBuffer, 0, l_TempBuffer.Length);
            }

            this._buffer = new byte[iNewSize];
            Array.Copy(iData, 0, this._buffer, l_TempBuffer.Length, iData.Length);
        }

        private void ResetBuffer()
        {
            this._buffer = new byte[0];
        }

        public static string[] GetPortNames()
        {
            SerialPortComparer l_Comparer = new SerialPortComparer();

            string[] l_SerialPorts = SerialPort.GetPortNames();

            Array.Sort(l_SerialPorts, l_Comparer);

            return l_SerialPorts;
        }

        public static bool SerialPortExists(string iName)
        {
            string[] l_AvailablePorts = SerialPort.GetPortNames();

            if (!l_AvailablePorts.Contains(iName))
                return false;

            return true;
        }

        public void Close()
        {
            this._closing = true;

            this._serialPort.Close();
            this.Dispose();
        }

        public void Dispose()
        {
            if (Interlocked.CompareExchange(ref this._disposed, 1, 0) == 0)
            {
                this._serialPort.Dispose();
            }
        }

        public static int[] BaudRatesArray { get => BAUD_RATES; }
        public static int[] DataBits { get => DATA_BITS; }
        public ConnectionResult ConenctionResult { get => _conenctionResult; }
        public bool SerialDtr { get => this._serialPort.DtrEnable; set => this._serialPort.DtrEnable = value; }
        public bool SerialRts 
        {
            get => this._serialPort.RtsEnable;
            set
            {
                if (this._rtsAllowed)
                    this._serialPort.RtsEnable = value;
            }
        }
        public bool RtsAllowed { get => this._rtsAllowed; }
    }
}
