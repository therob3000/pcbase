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
    class RobotInterface
    {
        public KinectInterface KI;
        private Sock ssock;
        private Sock sssock;
        private BackgroundWorker NetCommWorker;
        private BackgroundWorker KinectUpdater;
        private Point3f[] JointVals;

        public enum Joints
        {
            SpineBase,
            SpineMid,
            Head,
            ShoulderLeft,
            ElbowLeft,
            WristLeft,
            HandLeft,
            ShoulderRight,
            ElbowRight,
            WristRight,
            HandRight,
            HipLeft,
            KneeLeft,
            AnkleLeft,
            FootLeft,
            HipRight,
            KneeRight,
            AnkleRight,
            FootRight,
            SpineShoulder
        };

        public RobotInterface()
        {
            JointVals = new Point3f[20];

            this.NetCommWorker = new BackgroundWorker();
            NetCommWorker.WorkerReportsProgress = true;
            NetCommWorker.WorkerSupportsCancellation = true;
            NetCommWorker.DoWork += NetCommWorker_DoWork;
            NetCommWorker.ProgressChanged+=NetCommWorker_ProgressChanged;
            NetCommWorker.RunWorkerCompleted+=NetCommWorker_RunWorkerCompleted;

            KinectUpdater = new BackgroundWorker();
            KinectUpdater.WorkerSupportsCancellation = true;
            KinectUpdater.WorkerReportsProgress = true;
            KinectUpdater.DoWork += KinectUpdater_DoWork;
            KinectUpdater.ProgressChanged += KinectUpdater_ProgressChanged;
            KinectUpdater.RunWorkerCompleted += KinectUpdater_RunWorkerCompleted;

            KI = new KinectInterface();

            //Starts the background worker to handle the sending and recieving of Network packets
            NetCommWorker.RunWorkerAsync();

        }



        public Point3f GetJointVal(Joints Joint)
        {
            return JointVals [(int)Joint];
        }

        #region KinematicsCode
        private void KinectUpdater_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!KinectUpdater.CancellationPending)
            {
                JointVals[0] = KI.SpineBasePos;
                JointVals[1] = KI.SpineMidPos;
                JointVals[2] = KI.HeadPos;
                JointVals[3] = KI.ShoulderLeftPos;
                JointVals[4] = KI.ElbowLeftPos;
                JointVals[5] = KI.WristLeftPos;
                JointVals[6] = KI.HandLeftPos;
                JointVals[7] = KI.ShoulderRightPos;
                JointVals[8] = KI.ElbowRightPos;
                JointVals[9] = KI.WristRightPos;
                JointVals[10] = KI.HandRightPos;
                JointVals[11] = KI.HipLeftPos;
                JointVals[12] = KI.KneeLeftPos;
                JointVals[13] = KI.AnkleLeftPos;
                JointVals[14] = KI.FootLeftPos;
                JointVals[15] = KI.HipRightPos;
                JointVals[16] = KI.KneeRightPos;
                JointVals[17] = KI.AnkleRightPos;
                JointVals[18] = KI.FootRightPos;
                JointVals[19] = KI.SpineShoulderPos;

                if (KI.tracked_skeletons > 0)
                {
                    //Prints position values to textboxes
                    //tb_LHZ.Text = KI.HandLeftPos.Z.ToString();
                    //tb_LHY.Text = KI.HandLeftPos.Y.ToString();
                    //tb_HCZ.Text = KI.SpineBasePos.Z.ToString();
                    //tb_HCY.Text = KI.SpineBasePos.Y.ToString();
                    //tb_RHZ.Text = KI.HandRightPos.Z.ToString();
                    //tb_RHY.Text = KI.HandRightPos.Y.ToString();

                    #region Drivetrain
                    //This will need some refining in terms of how responsive
                    Point3f Hip_Center = KI.SpineBasePos;

                    //Drive Mode
                    //When the users hands are below their belly button, the user is in drive mode
                    if (KI.HandLeftPos.Y < Hip_Center.Y + 0.02 && KI.HandRightPos.Y < Hip_Center.Y + 0.02)
                    {
                        //lbl_DriveMode.Text = "Drive Mode";
                        //If the users Left hand is behind the center zone, drive left tread in reverse
                        if (KI.HandLeftPos.Z > Hip_Center.Z + 0.1)
                        {
                            //Send Command to Drive left Reverse
                            CommandBuilder.UpdateCommand(15, 2000); // Need to Confirm Command

                            //lbl_DriveLeft.Text = "Reverse";
                        }
                        //If the users left hand is in front of the center zone, drive left tread forward
                        else if (KI.HandLeftPos.Z < Hip_Center.Z - 0.1)
                        {
                            //Send Command to drive left Forwards
                            CommandBuilder.UpdateCommand(15, 1000); //Need to Confirm Command
                            //lbl_DriveLeft.Text = "Forward";
                        }
                        //If the users left hand is in the center zone, stop the left tread
                        else if (KI.HandLeftPos.Z >= Hip_Center.Z - 0.1 && KI.HandLeftPos.Z <= Hip_Center.Z + 0.1)
                        {
                            //Send Command to drive left Neutral
                            CommandBuilder.UpdateCommand(15, 1500); //Need to Confirm Command
                            //lbl_DriveLeft.Text = "Neutral";
                        }
                        //If the users right hand is behind the center zone, drive right tread backwards
                        if (KI.HandRightPos.Z > Hip_Center.Z + 0.1)
                        {
                            // Send Command to drive Right Backwards
                            CommandBuilder.UpdateCommand(14, 2000); //Need to Confirm Command
                            //lbl_DriveRight.Text = "Reverse";
                        }
                        //If the users right hand is in front of the center zone, drive right tread forward
                        else if (KI.HandRightPos.Z < Hip_Center.Z - 0.1)
                        {
                            //Send Command to drive Right Forwards
                            CommandBuilder.UpdateCommand(14, 1000); //Need to Comfirm Command
                            //lbl_DriveRight.Text = "Forward";
                        }
                        //If the users right hand is in the center zone, stop the right tread
                        else if (KI.HandRightPos.Z >= Hip_Center.Z - 0.1 && KI.HandRightPos.Z <= Hip_Center.Z + 0.1)
                        {
                            //Send Command to drive Right Neutral
                            CommandBuilder.UpdateCommand(14, 1500); //Need to Confirm Command
                            //lbl_DriveRight.Text = "Neutral";
                        }
                    }

                    //If the users hands are above the belly button, stop both treads. They are now in arm mode.
                    else
                    {
                        CommandBuilder.UpdateCommand(14, 1500);
                        CommandBuilder.UpdateCommand(15, 1500);
                    }

                    #endregion
                    #region Arm Control

                    //Arm Control involves trig to identify certain angles between points of refference

                    //else //if (KI.HandLeftPos.Y >= Hip_Center.Y + 0.02 && KI.HandRightPos.Y >= Hip_Center.Y + 0.02)
                    //{
                    //lbl_DriveMode.Text = "Arm Mode";
                    //CommandBuilder.UpdateCommand(14, 1500);
                    //CommandBuilder.UpdateCommand(15, 1500);

                    //Left Arm Pitch
                    float LDX = KI.ElbowLeftPos.X - KI.ShoulderLeftPos.X;
                    float LDY = KI.ElbowLeftPos.Y - KI.ShoulderLeftPos.Y;
                    double AngleL = Math.Atan(LDY / LDX) * (180 / Math.PI);
                    CommandBuilder.UpdateCommand(9, AngleL);

                    //Left Arm Shoulder Roll
                    float RollLDZ = KI.ShoulderLeftPos.Z - KI.HandLeftPos.Z;
                    float RollLDY = KI.ShoulderLeftPos.Y - KI.HandLeftPos.Y;
                    double RollAngleL = Math.Atan(RollLDY / RollLDZ) * (180 / Math.PI);
                    CommandBuilder.UpdateCommand(8, (90 - RollAngleL) + 90);



                    //Right Arm Pitch
                    float RDX = KI.ElbowRightPos.X - KI.ShoulderRightPos.X;
                    float RDY = KI.ElbowRightPos.Y - KI.ShoulderRightPos.Y;
                    double AngleR = Math.Atan(RDY / RDX) * (180 / Math.PI) + 180;
                    CommandBuilder.UpdateCommand(4, AngleR);

                    //Right Arm Shoulder Roll
                    float RollRDZ = KI.ShoulderRightPos.Z - KI.HandRightPos.Z;
                    float RollRDY = KI.ShoulderRightPos.Y - KI.HandRightPos.Y;
                    double RollAngleR = Math.Atan(RollRDY / RollRDZ) * (180 / Math.PI);
                    CommandBuilder.UpdateCommand(3, RollAngleR);


                    //}
                    #endregion

                }
                //If the kinect loses sight of a person, set the robot to center.
                //This acts as a failsafe mechanism.
                else
                {
                    //tb_LHZ.Text = "No tracking!";
                    //tb_LHY.Text = "No tracking!";
                    //tb_HCZ.Text = "No tracking!";
                    //tb_HCY.Text = "No tracking!";
                    //tb_RHZ.Text = "No tracking!";
                    //tb_RHY.Text = "No tracking!";

                    CommandBuilder.SetToCenter();

                }
            }

        }        
        private void KinectUpdater_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Set some kind of message here if needed
            
        }

        private void KinectUpdater_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Set some kind of message here if needed
            
        }
        #endregion
        #region NetworkWorkerCode
        /// <summary>
        /// Event handler for NetCommWorker. This is where the threaded code occurs. This Thread will handle all sending and receiving of TCP messages.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"> e can be a Paramater supplied to the Worker</param>
        private void NetCommWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string ReceivedMessage = "";
            int Interval = 10; //Interval in Miliseconds 
            try
            {
                ssock = new Sock(1337);
                ssock.Listen();
                NetCommWorker.ReportProgress(0, "Waiting for Client Connection");
                sssock = ssock.Accept();
                while (!NetCommWorker.CancellationPending)
                {
                    //string test = CommandBuilder.GetCurrentCommand();
                    sssock.sendline("sv " + CommandBuilder.GetCurrentCommand());
                    NetCommWorker.ReportProgress(0, "Command Sent");
                    /*   NetCommWorker.ReportProgress(0, "Attempting Read");
                       ReceivedMessage = sssock.readline();
                       NetCommWorker.ReportProgress(1, ReceivedMessage);*/

                    System.Threading.Thread.Sleep(Interval);

                }
            }
            catch (Exception ex)
            {
                NetCommWorker.ReportProgress(0, ex.Message);
                NetCommWorker.CancelAsync();
            }

        }

        /// <summary>
        /// Handles reporting information to the front panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"> Contains Percent property and UserState property</param>
        private void NetCommWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 1) // Provides Returned Network Message to the front panel
            {

            }
            else 
            { //Sends error feedback to front panel
                //ts_StatusStrip.Text = e.UserState.ToString();
            } 
        }

        /// <summary>
        /// Is Run when the worker is finished. Handles Cleanup.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NetCommWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //ts_StatusStrip.Text = "Worker Shutdown";
            sssock.sendline("q");
            Thread.Sleep(10);
            ssock.close();
        }

        private string readData(string Paramater)
        {
            try
            {
                sssock.sendline("rd " + Paramater);
                return sssock.readline();
            }
            catch (Exception ex)
            {
                return "Net Error";
            }
        }

        private string readCommand()
        {
            try
            {
                sssock.sendline("rv");
                return sssock.readline();
            }
            catch (Exception ex)
            {
                return "Net Error";
            }
        }

        #endregion

        public void StartInterface()
        {
            if (!KinectUpdater.IsBusy) KinectUpdater.RunWorkerAsync();
            if (!NetCommWorker.IsBusy) NetCommWorker.RunWorkerAsync();
        }
    }
}
