using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Communication;
using FrameInterceptor.Utils;

namespace FrameInterceptor.Communication
{
    public class CommunicationCommons
    {
        protected FrameInterceptor_v2 _owningForm;
        private object _handler = null;

        public FrameInterceptor_v2 OwningForm { get => _owningForm; set => _owningForm = value; }

        public CommunicationCommons(FrameInterceptor_v2 iOwningForm)
        {
            this._owningForm = iOwningForm;
        }

        protected void SetHandler(object iCallerHandler)
        {
            this._handler = iCallerHandler;
        }

        protected void RemoveHandler()
        {
            this._handler = null;
        }

        protected virtual async void Receive(SocketClient iClient)
        {
            if (iClient == null)
                throw new ArgumentNullException();

            if (this._handler is TcpClientCommunication c && c.Client.Disposed)
                return;

            if (this._handler is TcpServerCommunication s && s.Server.Disposed)
                return;

            ConnectionResult l_ConnectionResult = ConnectionResult.Unhandled;

            int l_BytesTransfered = await Task<int>.Run(() =>
            {
                int l_InternalBytesTransfered = 0;

                try
                {
                    l_InternalBytesTransfered = iClient.ReadSocket(out l_ConnectionResult);
                }
                catch (ObjectDisposedException)
                {

                }

                return l_InternalBytesTransfered;
            });


            if (iClient.ConnectionResult != ConnectionResult.Success)
                this._owningForm.ResultLog(iClient.ConnectionResult, iClient);


            if (l_BytesTransfered > 0)
            {
                //Read client buffer
                this.ReadClientBuffer(iClient, l_BytesTransfered);


                //Recursive call
                this.Receive(iClient);

                if (this._owningForm.chkAutoResponse.Checked)
                {
                    if (!String.IsNullOrEmpty(this._owningForm.tbSend.Text))
                    {
                        //byte[] l_ToSend = Encoding.UTF8.GetBytes(this._owningForm.tbSend.Text);
                        byte[] l_ToSend = Settings.Instance.Encoding.GetBytes(this._owningForm.tbSend.Text);

                        this.Send(l_ToSend, iClient);
                    }
                }
            }
            else if (l_BytesTransfered == 0)
            {
                if (this._handler is TcpServerCommunication ss)
                    ss.Clients.Remove(iClient);

                if (this._handler is TcpClientCommunication cc)
                {
                    await cc.Close();
                }

                //this._owningForm.ResetClientsBindings();
                //this._owningForm.ResultLog(l_ConnectionResult, iClient);
            }
            else
            {
                if (iClient.ConnectionResult == ConnectionResult.BufferSizeExceeded)
                {
                    this.ReadClientBuffer(iClient, iClient.BufferLength);

                    try
                    {
                        await iClient.Close();

                        if (this._handler is TcpServerCommunication ss)
                            ss.Clients.Remove(iClient);

                        //this._owningForm.ResetClientsBindings();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }

        protected virtual async void ReadClientBuffer(SocketClient iClient, int iBytesToRead)
        {
            byte[] l_Buffer = new byte[iBytesToRead];

            iClient.Read(l_Buffer, 0, iBytesToRead);
            await this._owningForm.ComLog(l_Buffer, iBytesToRead, false, iClient);

            //TESTS
            //string l_Response = Encoding.UTF8.GetString(l_Buffer);
            //int l_Hashcode = l_Response.GetHashCode();

            //byte[] l_Bytes = Encoding.UTF8.GetBytes(l_Hashcode.ToString());
            //this.Send(l_Bytes, iClient);
        }

        public virtual async void Send(byte[] iData, SocketClient iClient)
        {
            int l_BytesTransfered = await Task<int>.Run(() =>
            {
                return iClient.Send(iData, 0, iData.Length);
            });

            await this._owningForm.ComLog(iData, l_BytesTransfered, true, iClient);
        }
    }
}
