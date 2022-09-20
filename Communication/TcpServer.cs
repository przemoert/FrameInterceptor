using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Communication
{
    public class TcpServer : TcpBase
    {
        const int BUFFER_SIZE = 1024;

        private IPEndPoint _endPoint;
        private Socket _listener = null;
        private Socket _handler = null;
        private int _listenPort;
        private ManualResetEvent _shouldRun = new ManualResetEvent(true);
        private bool _bufferSizeCanBeChanged = true;


        public TcpServer(byte[] iIpAddress, int iPort)
        {
            if (iIpAddress.Length == 4 && iPort > 0)
            {
                base._ipAddress = new IPAddress(iIpAddress);
                this._listenPort = iPort;
                this._endPoint = new IPEndPoint(base._ipAddress, this._listenPort);
                base._bufferSize = BUFFER_SIZE;
            }
            else
            {
                throw new ArgumentException("Bad input provided");
            }

        }

        public void StartListener()
        {
            if (this._ipAddress != null && this._endPoint != null && this._listenPort > 0)
            {
                bool noError = false;

                try
                {
                    base._internalBuffer = new byte[this._bufferSize];
                    base._internalBufferSize = 0;
                    this._bufferSizeCanBeChanged = false;

                    this._listener = new Socket(this._ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    this._listener.Bind(this._endPoint);
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
                                if (base.Disposed)
                                    break;

                                this._shouldRun.WaitOne(0);

                                base.ClearBuffer();
                                this._handler = this._listener.Accept();
                                this._handler.ReceiveTimeout = base._IOTimeout;
                                this._handler.SendTimeout = base._IOTimeout;

                                if (this._handler != null)
                                {
                                    Console.WriteLine($"Got connection: {((IPEndPoint)this._handler.RemoteEndPoint).Address.ToString()}:{((IPEndPoint)this._handler.RemoteEndPoint).Port.ToString()} <- {((IPEndPoint)this._endPoint).Address.ToString()}:{((IPEndPoint)this._endPoint).Port.ToString()}");
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
                                if (!base.Disposed)
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
                    base._byteData = new byte[base._bufferSize];
                    int bytesLength = this._handler.Receive(base._byteData);

                    base.AddToBuffer(base._byteData, bytesLength);
                }
            }
        }

        public int Write(byte[] data)
        {
            if (!this.IsConnected)
                return -1;

            try
            {
                int bytesSent = this._handler.Send(data);

                return bytesSent;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public override void Dispose()
        {
            if (Interlocked.CompareExchange(ref base._disposed, 1, 0) == 0)
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

        public int BufferSize 
        { 
            get => base._bufferSize;
            set
            {
                if (this._bufferSizeCanBeChanged)
                {
                    base._bufferSize = value;
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
