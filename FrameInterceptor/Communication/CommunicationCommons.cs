﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Communication;

namespace FrameInterceptor.Communication
{
    public class CommunicationCommons
    {
        protected FrameInterceptor_v2 _owningForm;
        private IDisposer _handler = null;


        public CommunicationCommons(FrameInterceptor_v2 iOwningForm)
        {
            this._owningForm = iOwningForm;
        }

        protected void SetHandler(object iCallerHandler)
        {
            if (iCallerHandler is IDisposer)
            { 
                this._handler = (IDisposer)iCallerHandler;
            }
            else
            {
                throw new ArgumentOutOfRangeException("iCallerHandler");
            }
        }

        protected async void Receive(SocketClient iClient)
        {
            if (this._handler.Disposed)
                return;

            ConnectionResult l_ConnectionResult = ConnectionResult.Unhandled;

            int l_BytesTransfered = await Task<int>.Run(() =>
            {
                return iClient.ReadSocket(out l_ConnectionResult);
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
                        byte[] l_ToSend = Encoding.UTF8.GetBytes(this._owningForm.tbSend.Text);

                        this.Send(l_ToSend, iClient);
                    }
                }
            }
            else if (l_BytesTransfered == 0)
            {
                this._owningForm.ResetClientsBindings();
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
                        this._owningForm.ResetClientsBindings();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }

        protected async void ReadClientBuffer(SocketClient iClient, int iBytesToRead)
        {
            byte[] l_Buffer = new byte[iBytesToRead];

            iClient.Read(l_Buffer, 0, iBytesToRead);
            await this._owningForm.ComLog(l_Buffer, iBytesToRead, false, iClient);
        }

        public async void Send(byte[] iData, SocketClient iClient)
        {
            int l_BytesTransfered = await Task<int>.Run(() =>
            {
                return iClient.Send(iData, 0, iData.Length);
            });

            this._owningForm.ComLog(iData, l_BytesTransfered, true, iClient);
        }
    }
}