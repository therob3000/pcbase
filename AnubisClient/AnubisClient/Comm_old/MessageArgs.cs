using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnubisClient
{
    class MessageArgs: EventArgs
    {
        private string message;

        public MessageArgs(string message)
        {
            this.message = message;
        }

        // This is a straightforward implementation for 
        // declaring a public field
        public string Message
        {
            get
            {
                return message;
            }
        }
    }
}
