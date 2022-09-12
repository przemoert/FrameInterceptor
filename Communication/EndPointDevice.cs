using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Communication
{
    public enum ConnectionDirection
    {
        IN,
        OUT
    }

    public class EndPointDevice
    {
        public EndPointDevice(IPEndPoint iIpData)
        {
            this.IpAddress = iIpData.Address.ToString();
            this.Port = iIpData.Port;
        }

        public static string GetConnectionLog(EndPointDevice localDevice, EndPointDevice remoteDevice, ConnectionDirection direction)
        {
            string output = String.Empty;

            output += $"{localDevice.IpAddress}:{localDevice.Port} {((direction == ConnectionDirection.IN) ? "<-" : "->")} {remoteDevice.IpAddress}:{remoteDevice.Port}";

            return output;
        }

        public string IpAddress { get; set; }
        public int Port { get; set; }
        public string PortString { get => this.Port.ToString(); }
    }
}
