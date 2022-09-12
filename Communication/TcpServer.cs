using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Globals;

namespace Communication
{
    public class TcpServer : IDisposable
    {
        const int BUFFER_SIZE = 1024;

        public EventHandler DataReceived;

        private IPAddress _ipAddress;
        private IPEndPoint _localEndPoint;
        private Socket _listener = null;
        private Socket _handler = null;
        private int _listenPort;
        private byte[] _byteData = null;
        private int _bufferSize = -1;
        private byte[] _internalBuffer = null;
        private int _internalBufferSize;
        private ManualResetEvent _shouldRun = new ManualResetEvent(true);
        private bool _bufferSizeCanBeChanged = true;
        private static readonly object _syncRoot = new object();
        private int _disposed;

        public TcpServer(byte[] iIpAddress, int iPort)
        {
            if (iIpAddress.Length == 4 && iPort > 0)
            {
                this._ipAddress = new IPAddress(iIpAddress);
                this._listenPort = iPort;
                this._localEndPoint = new IPEndPoint(this._ipAddress, this._listenPort);
                this._bufferSize = BUFFER_SIZE;
            }
            else
            {
                throw new ArgumentException("Bad input provided");
            }

        }

        public void StartListener()
        {
            if (this._ipAddress != null && this._localEndPoint != null && this._listenPort > 0)
            {
                bool noError = false;

                try
                {
                    this._internalBuffer = new byte[this._bufferSize];
                    this._internalBufferSize = 0;
                    this._bufferSizeCanBeChanged = false;

                    this._listener = new Socket(this._ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    this._listener.Bind(this._localEndPoint);
                    this._listener.Listen(1);

                    noError = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    noError = false;
                }

                if (noError)
                {
                    new Thread(() =>
                    {
                        Thread.CurrentThread.IsBackground = true;

                        while (true)
                        {
                            try
                            {
                                if (this.Disposed)
                                    break;

                                this._shouldRun.WaitOne(0);

                                this.ClearBuffer();
                                this._handler = this._listener.Accept();

                                if (this._handler != null)
                                {
                                    Console.WriteLine($"Got connection: {((IPEndPoint)this._handler.RemoteEndPoint).Address.ToString()}:{((IPEndPoint)this._handler.RemoteEndPoint).Port.ToString()} <- {((IPEndPoint)this._localEndPoint).Address.ToString()}:{((IPEndPoint)this._localEndPoint).Port.ToString()}");
                                }

                                this.RunServer();

                                this._shouldRun.Reset();
                            }
                            catch (SocketException ex)
                            {
                                if (ex.ErrorCode == 10054)
                                {
                                    Console.WriteLine("Connection has been broken from client side.");
                                }
                                else if (ex.ErrorCode == 10004)
                                {
                                    Console.WriteLine("Listener disposed while waiting for client");
                                }
                                else
                                {
                                    Console.WriteLine("SOCKET EXCEPTION INTERCEPTED: " + ex.ToString());
                                }
                            } 
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.ToString());
                            }
                            finally
                            {
                                if (!this.Disposed)
                                {
                                    this._handler.Shutdown(SocketShutdown.Both);
                                    this._handler.Close();

                                    this._shouldRun.Set();
                                }
                            }
                        }
                    }).Start();
                }
                else
                {
                    Console.WriteLine("Could not run server");
                }
            }
        }

        private void RunServer()
        {
            while (true)
            {
                if (!this.Disposed)
                {
                    this._byteData = new byte[this._bufferSize];
                    int bytesLength = this._handler.Receive(this._byteData);

                    this.AddToBuffer(this._byteData, bytesLength);
                }
            }
        }

        public void Close() => this.Dispose();

        public int Send(byte[] data)
        {
            if (this.IsConnected)
            {
                int bytesSent = this._handler.Send(data);

                return bytesSent;
            }

            return -1;
        }

        public int Read(byte[] buffer, int offset, int numBytes)
        {
            if (this._internalBufferSize == 0)
                return 0;

            int bytesRead = 0;

            lock (_syncRoot)
            {
                int bytesToRead = Math.Min(this._internalBufferSize - offset, numBytes);

                for (int i = offset; i < offset + bytesToRead; i++)
                {
                    buffer[bytesRead] = this._internalBuffer[i];
                    bytesRead++;
                }

                this.ShiftLeft(offset + bytesToRead);
            }

            return bytesRead;
        }

        private int ShiftLeft(int offset)
        {
            if (offset >= this._internalBufferSize)
            {
                this.ClearBuffer();
                return 0;
            }

            //byte[] tempArray = new byte[this._bufferSize];
            int tempPtr = offset;

            while (tempPtr > 0)
            {
                for (int i = tempPtr; i < this._internalBufferSize; i++)
                {
                    this._internalBuffer[i - 1] = this._internalBuffer[i];
                }

                this._internalBufferSize--;
                tempPtr--;
            }

            return this._internalBufferSize;
        }

        private void ClearBuffer()
        {
            this._internalBuffer = new byte[this._bufferSize];
            this._internalBufferSize = 0;
        }

        private void AddToBuffer(byte[] iData, int numBytes)
        {
            if (numBytes == 0)
                return;

            lock (_syncRoot)
            {
                if (iData.Length < numBytes)
                    throw new IndexOutOfRangeException("Input length is less than bytes to read");

                if (this._internalBufferSize + numBytes > this._bufferSize)
                    throw new IndexOutOfRangeException("Buffer size exceeded");

                for (int i = 0; i < numBytes; i++)
                {
                    this._internalBuffer[this._internalBufferSize] = iData[i];
                    this._internalBufferSize++;
                }

                this.OnDataReceived();
            }
        }

        private void OnDataReceived()
        {
            this.DataReceived?.Invoke(this, new EventArgs());
        }

        public void Dispose()
        {
            if (Interlocked.CompareExchange(ref this._disposed, 1, 0) == 0)
            {
                if (this._handler != null)
                {
                    if (this.IsConnected)
                    {
                        this._handler.Shutdown(SocketShutdown.Both);
                    }

                    this._handler.Close();
                    this._handler.Dispose();
                }

                if (this._listener != null)
                {
                    this._listener.Close();
                    this._listener.Dispose();
                }
            }
        }

        public bool Disposed { get => this._disposed != 0; }
        public int BytesToRead { get => this._internalBufferSize; }
        public int BufferSize 
        { 
            get => this._bufferSize;
            set
            {
                if (this._bufferSizeCanBeChanged)
                {
                    this._bufferSize = value;
                }
                else
                {
                    throw new AccessViolationException("Tried to change buffer size while server is running");
                }
            }
        }

        public bool IsConnected
        {
            get
            {
                if (this._handler == null)
                {
                    return false;
                }

                try
                {
                    return !(this._handler.Poll(1, SelectMode.SelectRead) && this._handler.Available == 0);
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
