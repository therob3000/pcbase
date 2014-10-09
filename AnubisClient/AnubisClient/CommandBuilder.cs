using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnubisClient
{
    static class CommandBuilder
    {
        private static string[] Command_to_Be_Sent = new string[17];
        
        

        public static void UpdateCommand(int Channel, int Position)
        {
            Command_to_Be_Sent[Channel] = "#" + Channel + " P" + Position;
            
        }
        public static void UpdateCommand(int Channel, double Angle)
        {
            double angle = Angle;
            int Position = (int)(Angle * 10) + 600;
            Command_to_Be_Sent[Channel] = "#" + Channel + " P" + Position;
        
        }
        public static string GetCurrentCommand()
        {
            string Command = "";
            foreach (string Position in Command_to_Be_Sent)
            {
                Command += Position + " ";
                
            }
            Command += "\r";
            return Command;
            
        }

        public static void ClearCommandList()
        {

            for (int i = 0; i < Command_to_Be_Sent.Length; i++)
            {
                Command_to_Be_Sent[i] = "";
            }
            
        }

        public static void SetToCenter()
        {
            for (int i = 0; i < Command_to_Be_Sent.Length; i++)
            {
                Command_to_Be_Sent[i] = "#" + i + " P1500 ";
            }
        }

        public static void SetToOff()
        {
            for (int i = 0; i < Command_to_Be_Sent.Length; i++)
            {
                if (i == 14 || i == 15)
                {
                    Command_to_Be_Sent[i] = "#" + i + " P1500 ";
                }
                else
                {
                    Command_to_Be_Sent[i] = "#" + i + "L ";
                }
            }

        }
    }
}
