using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnubisClient
{
   public class SockArgs : EventArgs
    {
        private Sock sock;

        public SockArgs(Sock Socket)
        {
            sock = Socket;
        }

        public Sock Socket
        {
            get
            {
                return sock;
            }
        }

    }
}
