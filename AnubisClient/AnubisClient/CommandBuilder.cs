using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnubisClient
{
    class CommandBuilder
    {
        private string Command_to_Be_Sent;
        
        public CommandBuilder ()
        {

        }

        public void AddCommand(string Commands)
        {
            Command_to_Be_Sent += Commands + "\r";
        }
        public void AddCommand(string[] Commands)
        {
            foreach (string command in Commands)
            {
                Command_to_Be_Sent += command;
            }
            Command_to_Be_Sent += "\r";

        }
        public string GetCurrentCommand()
        {
            string Commands = Command_to_Be_Sent;
            Command_to_Be_Sent = "";
            return Commands;
        }
    }
}
