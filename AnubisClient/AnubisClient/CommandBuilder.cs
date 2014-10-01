using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnubisClient
{
    class CommandBuilder
    {
        private int[] Command_to_Be_Sent;
        
        public CommandBuilder ()
        {
            Command_to_Be_Sent = new int[17];

        }

        public void UpdateCommand(int Channel, int Position)
        {
            Command_to_Be_Sent[Channel] = Position;
            
        }
        public void UpdateCommand(int Channel, float Angle)
        {
            float angle = Angle;
            int Position = (int)(Angle * 10) + 600;
            Command_to_Be_Sent[Channel] = Position;
        
        }
        public string GetCurrentCommand()
        {
            int i = 0;
            string Command = "";
            foreach (int Position in Command_to_Be_Sent)
            {
                Command += "#" + i + "P" + Command_to_Be_Sent[i];
                i++;
            }
            Command += "\r";
            return Command;
            
        }

        public void ClearCommandList()
        {
            
        }
    }
}
