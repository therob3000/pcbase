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
    //Mwahahahah
    //This comment shall remain!
    public partial class ClientForm : Form
    {

        private KinectInterface KI;
        private Sock ssock;
        private Sock sssock;

        
        public ClientForm()
        {
            InitializeComponent();
            KI = new KinectInterface();
            //ssock = new Sock(1337);
            //ssock.Listen();
            //new Thread(() =>
            //{
            //    Sock sssock = ssock.Accept();
            //    string strign = sssock.readline();
            //    strign += strign;
            //    CommandBuilder.SetToCenter();
            //    sssock.sendline(CommandBuilder.GetCurrentCommand());
            //    sssock.close();
                
            //}).Start();


            //If my coding is as good as I think it is,
            //This function is now registered to the event of 
            //New Skeleton Frame Ready
            KI.RegisterSkeletonReadyEvent(NewSkelFrame);
            NetCommWorker.RunWorkerAsync();


        }



        private void NewSkelFrame(object sender, Microsoft.Kinect.SkeletonFrameReadyEventArgs e)
        {
            tb_LHZ.Text = KI.HandLeftPos.Z.ToString();
            tb_LHY.Text = KI.HandLeftPos.Y.ToString();
            tb_HCZ.Text = KI.SpineBasePos.Z.ToString();
            tb_HCY.Text = KI.SpineBasePos.Y.ToString();
            tb_RHZ.Text = KI.HandRightPos.Z.ToString();
            tb_RHY.Text = KI.HandRightPos.Y.ToString();
            


            #region Drivetrain
            //This will need some refining in terms of how responsive
            Point3f Hip_Center = KI.SpineBasePos;

            //Drive Mode
            if (KI.HandLeftPos.Y < Hip_Center.Y + 0.02 && KI.HandRightPos.Y < Hip_Center.Y + 0.02)
            {
                lbl_DriveMode.Text = "Drive Mode";
                if (KI.HandLeftPos.Z > Hip_Center.Z + 0.1)
                {
                    //Send Command to Drive left Reverse
                    CommandBuilder.UpdateCommand(15, 2000); // Need to Confirm Command

                    lbl_DriveLeft.Text = "Reverse";
                }
                else if (KI.HandLeftPos.Z < Hip_Center.Z - 0.1)
                {
                    //Send Command to drive left Forwards
                    CommandBuilder.UpdateCommand(15, 1000); //Need to Confirm Command
                    lbl_DriveLeft.Text = "Forward";
                }

                else if (KI.HandLeftPos.Z >= Hip_Center.Z - 0.1 && KI.HandLeftPos.Z <= Hip_Center.Z + 0.1)
                {
                    //Send Command to drive left Neutral
                    CommandBuilder.UpdateCommand(15, 1500); //Need to Confirm Command
                    lbl_DriveLeft.Text = "Neutral";
                }

                if (KI.HandRightPos.Z > Hip_Center.Z + 0.1)
                {
                    // Send Command to drive Right Backwards
                    CommandBuilder.UpdateCommand(14, 2000); //Need to Confirm Command
                    lbl_DriveRight.Text = "Reverse";
                }

                else if (KI.HandRightPos.Z < Hip_Center.Z - 0.1)
                {
                    //Send Command to drive Right Forwards
                    CommandBuilder.UpdateCommand(14, 1000); //Need to Comfirm Command
                    lbl_DriveRight.Text = "Forward";
                }

                else if (KI.HandRightPos.Z <= Hip_Center.Z + 0.1 && KI.HandRightPos.Z >= Hip_Center.Z - 0.1)
                {
                    //Send Command to drive Right Neutral
                    CommandBuilder.UpdateCommand(14, 1500); //Need to Confirm Command
                    lbl_DriveRight.Text = "Neutral";
                }
            }

            #endregion
            #region Arm Control

            else if (KI.HandLeftPos.Y >= Hip_Center.Y + 0.02 && KI.HandRightPos.Y >= Hip_Center.Y + 0.02)
            {
                lbl_DriveMode.Text = "Arm Mode";
                CommandBuilder.UpdateCommand(14, 1500);
                CommandBuilder.UpdateCommand(15, 1500);

                //Left Arm Pitch
                float LDX = KI.ElbowLeftPos.X;
                float LDY = KI.ElbowLeftPos.Y;
                double AngleL = Math.Atan(LDY / LDX) * (180 / Math.PI);
                CommandBuilder.UpdateCommand(4, AngleL);

                //Right Arm Pitch
                float RDX = KI.ElbowRightPos.X;
                float RDY = KI.ElbowRightPos.Y;
                double AngleR = Math.Atan(RDY / RDX) * (180 / Math.PI) + 180;
                CommandBuilder.UpdateCommand(9, AngleR);

            }
            #endregion
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            KI.EndSensorStream();
            //KI.stopSpeech();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            KI.BeginSensorStream();
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            KI.EndSensorStream();
        }

        /// <summary>
        /// Event handler for NetCommWorker. This is where the threaded code occurs. This Thread will handle all sending and receiving of TCP messages.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"> e can be a Paramater supplied to the Worker</param>
        private void NetCommWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string ReceivedMessage = "";
            int Interval = 100; //Interval in Miliseconds 
            try
            {       ssock = new Sock(1337);
                    ssock.Listen();
                    NetCommWorker.ReportProgress(0, "Waiting for Client Connection");
                    sssock = ssock.Accept();
                while (!NetCommWorker.CancellationPending)
                {
                    sssock.sendline(CommandBuilder.GetCurrentCommand());
                    NetCommWorker.ReportProgress(0, "Command Sent");
                    NetCommWorker.ReportProgress(0, "Attempting Read");
                    ReceivedMessage = sssock.readline();
                    NetCommWorker.ReportProgress(1, ReceivedMessage);
                    
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
            else //Sends error feedback to front panel
                ts_StatusStrip.Text = e.UserState.ToString();
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

        private void btn_ShutDownRobot_Click(object sender, EventArgs e)
        {
            NetCommWorker.CancelAsync();
        }
    }
}
