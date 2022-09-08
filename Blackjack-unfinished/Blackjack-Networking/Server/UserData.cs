using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    public class UserData  //is automatically a descendent of object
    {
        public NetworkStream ConnStream;
        public Socket TheSocket;
        public bool Connected;
        public int ClientNumber;
        public string Username;
    }
}
