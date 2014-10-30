using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace AnubisClient
{
    //Will become the specific drivers to each robot
    abstract class RobotInterface
    {
        abstract public void UpdateSkeleton();
        abstract public void UpdateCommand();
        abstract public void ClearCommandList();
        abstract public string[] GetCurrentCommandArray();
        abstract public string GetCurrentCommand();
        abstract public void SetToCenter();
        abstract public void SetToOff();

        abstract public void SendCommands();
        abstract public string RequestData();
        abstract public string RequestCommand();
        abstract public int Ping();


        protected Sock RobotConnection;
        protected string[] Command_to_Be_Sent;

    }
        
    public class Johnny5 : RobotInterface
    {

        public void Johnny5(Sock ConnectionSock)
        {
            Command_to_Be_Sent = new string[17];
            RobotConnection = ConnectionSock;
            
        }

        public override void UpdateSkeleton(Joint3d[] Skeleton)
        {
            UpdateCommand(3, Skeleton[4].Roll);
            UpdateCommand(4, Skeleton[4].Pitch);

            UpdateCommand(8, Skeleton[8].Roll);
            UpdateCommand(9, Skeleton[8].Pitch);

            UpdateCommand(14, Skeleton[15].Pitch);
            UpdateCommand(15, Skeleton[14].Pitch);

            //More can be Added as Code is added

        }

        public override void UpdateCommand(int Channel, int Position)
        {
            Command_to_Be_Sent[Channel] = "#" + Channel + " P" + Position;

        }
        public override void UpdateCommand(int Channel, double Angle)
        {
            double angle = Angle;
            int Position = (int)(Angle * 10) + 600;
            Command_to_Be_Sent[Channel] = "#" + Channel + " P" + Position;

        }

        public override string[] GetCurrentCommandArray()
        {
            return Command_to_Be_Sent;
        }

        public override void UpdateCommand(int Channel, int Position, int Speed)
        {
            Command_to_Be_Sent[Channel] = "#" + Channel + " P" + Position + " S" + Speed;
        }

        public override void UpdateCommand(int Channel, double Angle, int Speed)
        {
            double angle = Angle;
            int Position = (int)(Angle * 10) + 600;
            Command_to_Be_Sent[Channel] = "#" + Channel + " P" + Position + " S" + Speed;
        }

        public override string GetCurrentCommand()
        {
            string Command = "";
            foreach (string Position in Command_to_Be_Sent)
            {
                Command += Position + " ";

            }
            Command += "\r";
            return Command;

        }

        public override void ClearCommandList()
        {

            for (int i = 0; i < Command_to_Be_Sent.Length; i++)
            {
                Command_to_Be_Sent[i] = "";
            }

        }

        public override void SetToCenter()
        {
            for (int i = 0; i < Command_to_Be_Sent.Length; i++)
            {
                Command_to_Be_Sent[i] = "#" + i + " P1500 ";
            }
        }

        public override void SetToOff()
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
