using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Communication
{
    public enum ConnectionResult
    {
        UnspecifiedError = -1,
        Success = 0,
        Unhandled = 1,
        RefusedByRemoteHost = 1000,
        Timeout = 1001,
        Failed = 1002,
        ForciblyClosed = 1003,
        GracefullyClosed = 1004,
        ClosedNoReason = 1005,
        ZeroLengthByteIgnored = 1006,
        HandlerDisposed = 1007,
        UnhandledSocketError = 1008,
        NonSocketOperationError = 1009,
        SocketAccessDenied = 1010,
        Aborted = 1011,
        ActiveConnectionsLimit = 1012,
        AddressAlreadyInUse = 1013,
        ListenerClosed = 1014,
        AcceptingClients = 1015,
        AcceptingClientsAfterLimit = 1016,
        ServerListening = 1017,
        BufferSizeExceeded = 1018,
        DataReceivedWhileFlushing = 1019,
        UnknownAddressContext = 1020,
        SerialAccessDenied = 1021,
        SerialIOInterrupted = 1022,
        SerialClosed = 2023,
        SerialNotExists = 2024
    }


    internal static class ErrorHandler
    {
        internal static ConnectionResult TranslateSocketError(int iSocketCode)
        {
            return TranslateSocketError((SocketError)iSocketCode);
        }

        internal static ConnectionResult TranslateSocketError(SocketError iSocketError)
        {
            ConnectionResult l_Reuslt = ConnectionResult.Success;

            switch (iSocketError)
            {
                case SocketError.Success:
                    l_Reuslt = ConnectionResult.Success;
                    break;
                case SocketError.SocketError:
                    l_Reuslt = ConnectionResult.UnspecifiedError;
                    break;
                case SocketError.Interrupted:
                    l_Reuslt = ConnectionResult.Unhandled;
                    break;
                case SocketError.AccessDenied:
                    l_Reuslt = ConnectionResult.SocketAccessDenied;
                    break;
                case SocketError.Fault:
                    l_Reuslt = ConnectionResult.Unhandled;
                    break;
                case SocketError.InvalidArgument:
                    l_Reuslt = ConnectionResult.Unhandled;
                    break;
                case SocketError.TooManyOpenSockets:
                    l_Reuslt = ConnectionResult.Unhandled;
                    break;
                case SocketError.WouldBlock:
                    l_Reuslt = ConnectionResult.Unhandled;
                    break;
                case SocketError.InProgress:
                    l_Reuslt = ConnectionResult.Unhandled;
                    break;
                case SocketError.AlreadyInProgress:
                    l_Reuslt = ConnectionResult.Unhandled;
                    break;
                case SocketError.NotSocket:
                    l_Reuslt = ConnectionResult.NonSocketOperationError;
                    break;
                case SocketError.DestinationAddressRequired:
                    l_Reuslt = ConnectionResult.Unhandled;
                    break;
                case SocketError.MessageSize:
                    l_Reuslt = ConnectionResult.Unhandled;
                    break;
                case SocketError.ProtocolType:
                    l_Reuslt = ConnectionResult.Unhandled;
                    break;
                case SocketError.ProtocolOption:
                    l_Reuslt = ConnectionResult.Unhandled;
                    break;
                case SocketError.ProtocolNotSupported:
                    l_Reuslt = ConnectionResult.Unhandled;
                    break;
                case SocketError.SocketNotSupported:
                    l_Reuslt = ConnectionResult.Unhandled;
                    break;
                case SocketError.OperationNotSupported:
                    l_Reuslt = ConnectionResult.Unhandled;
                    break;
                case SocketError.ProtocolFamilyNotSupported:
                    l_Reuslt = ConnectionResult.Unhandled;
                    break;
                case SocketError.AddressFamilyNotSupported:
                    l_Reuslt = ConnectionResult.Unhandled;
                    break;
                case SocketError.AddressAlreadyInUse:
                    l_Reuslt = ConnectionResult.AddressAlreadyInUse;
                    break;
                case SocketError.AddressNotAvailable:
                    l_Reuslt = ConnectionResult.UnknownAddressContext;
                    break;
                case SocketError.NetworkDown:
                    l_Reuslt = ConnectionResult.Unhandled;
                    break;
                case SocketError.NetworkUnreachable:
                    l_Reuslt = ConnectionResult.Unhandled;
                    break;
                case SocketError.NetworkReset:
                    l_Reuslt = ConnectionResult.Unhandled;
                    break;
                case SocketError.ConnectionAborted:
                    l_Reuslt = ConnectionResult.Unhandled;
                    break;
                case SocketError.ConnectionReset:
                    l_Reuslt = ConnectionResult.ForciblyClosed;
                    break;
                case SocketError.NoBufferSpaceAvailable:
                    l_Reuslt = ConnectionResult.Unhandled;
                    break;
                case SocketError.IsConnected:
                    l_Reuslt = ConnectionResult.Unhandled;
                    break;
                case SocketError.NotConnected:
                    l_Reuslt = ConnectionResult.Unhandled;
                    break;
                case SocketError.Shutdown:
                    l_Reuslt = ConnectionResult.Unhandled;
                    break;
                case SocketError.TimedOut:
                    l_Reuslt = ConnectionResult.Timeout;
                    break;
                case SocketError.ConnectionRefused:
                    l_Reuslt = ConnectionResult.RefusedByRemoteHost;
                    break;
                case SocketError.HostDown:
                    l_Reuslt = ConnectionResult.Unhandled;
                    break;
                case SocketError.HostUnreachable:
                    l_Reuslt = ConnectionResult.Unhandled;
                    break;
                case SocketError.ProcessLimit:
                    l_Reuslt = ConnectionResult.Unhandled;
                    break;
                case SocketError.SystemNotReady:
                    l_Reuslt = ConnectionResult.Unhandled;
                    break;
                case SocketError.VersionNotSupported:
                    l_Reuslt = ConnectionResult.Unhandled;
                    break;
                case SocketError.NotInitialized:
                    l_Reuslt = ConnectionResult.Unhandled;
                    break;
                case SocketError.Disconnecting:
                    l_Reuslt = ConnectionResult.Unhandled;
                    break;
                case SocketError.TypeNotFound:
                    l_Reuslt = ConnectionResult.Unhandled;
                    break;
                case SocketError.HostNotFound:
                    l_Reuslt = ConnectionResult.Unhandled;
                    break;
                case SocketError.TryAgain:
                    l_Reuslt = ConnectionResult.Unhandled;
                    break;
                case SocketError.NoRecovery:
                    l_Reuslt = ConnectionResult.Unhandled;
                    break;
                case SocketError.NoData:
                    l_Reuslt = ConnectionResult.Unhandled;
                    break;
                case SocketError.IOPending:
                    l_Reuslt = ConnectionResult.Unhandled;
                    break;
                case SocketError.OperationAborted:
                    l_Reuslt = ConnectionResult.Aborted;
                    break;
                default:
                    break;
            }

            return l_Reuslt;
        }
    }
}
