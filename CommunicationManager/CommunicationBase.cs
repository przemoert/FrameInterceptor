using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationManager
{
    public enum ManagerConnectionResult
    {
        Connected = -1,
        RefusedByRemoteHost = -2,
        Timeout = -3,
        Failed = -4,
        ForciblyClosed = -5,
        GracefulyClosed = -6,
        ClosedNoReason = -7,
        ZeroLengthByteIgnored = -8,
        HandlerDisposed = -1001
    }

    public interface iCommunication
    {
        event EventHandler<DataReceivedEventArgs> DataRecieved;

        Task<ManagerConnectionResult> Open();
        void Close();
        int SendData(byte[] iData);
        bool IsOpen();
        void OnDataRecieved(DataReceivedEventArgs e);
        void Dispose();

        bool IsConnected { get; }
    }

    internal abstract class CommunicationBase
    {
        internal abstract event EventHandler<DataReceivedEventArgs> DataRecieved;

        protected Handshake _handshake;
        protected int _baudRate;
        protected Parity _parity;
        protected int _dataBits;
        protected StopBits _stopBits;
        protected string _name;
        protected SerialPort _serialPort;

        internal abstract bool Open();
        internal abstract void Close();
        internal abstract bool SendData(char[] iData);
        internal abstract bool IsOpen();
        protected abstract void OnDataRecieved(DataReceivedEventArgs e);

        public Handshake Handshake { get => _handshake; set => _handshake = value; }
        public int BaudRate { get => _baudRate; set => _baudRate = value; }
        public Parity Parity { get => _parity; set => _parity = value; }
        public int DataBits { get => _dataBits; set => _dataBits = value; }
        public StopBits StopBits { get => _stopBits; set => _stopBits = value; }
        public string Name { get => _name; set => _name = value; }
    }

    public class DataReceivedEventArgs : EventArgs
    {
        public byte[] Data;
        public int DataLength;
    }
}
