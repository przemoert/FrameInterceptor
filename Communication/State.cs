using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Communication
{
    internal class State
    {
        public Socket Client { get; set; }
        public bool Success { get; set; }
    }
}
