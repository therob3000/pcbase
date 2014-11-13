






        //abstract public void UpdateCommand(int Channel, int Position);
        //abstract public void UpdateCommand(int Channel, double Angle);
        //abstract public void UpdateCommand(int Channel, double Angle, int Speed);
        //abstract public void UpdateCommand(int Channel, int Position, int Speed);
        //abstract public void ClearCommandList();
        //abstract public string[] GetCurrentCommandArray();
        //abstract public string GetCurrentCommand();
        
    public class Johnny5 : RobotInterface
    {

        public Johnny5(Sock ConnectionSock)
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
        public override int Ping()
        {
            try
            {
                Stopwatch time = new Stopwatch();
                time.Start();
                RobotConnection.sendline("pg");
                string message = RobotConnection.readline();
                time.Stop();
                return (int)time.ElapsedMilliseconds;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public override void SendCommands()
        {
            try
            {
                RobotConnection.sendline(GetCurrentCommand());
            }
            catch (Exception ex)
            {

            }
        }
        public override string RequestCommand()
        {
            try
            {
                RobotConnection.sendline("rv");
                return RobotConnection.readline();
            }
            catch (Exception ex)
            {
                return "Net Error";
            }  
        }
        public override string RequestData(string Paramater)
        {
            try
            {
                RobotConnection.sendline("rd " + Paramater);
                return RobotConnection.readline();
            }
            catch (Exception ex)
            {
                return "Net Error";
            }
            
        }
    }
}
