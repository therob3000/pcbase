using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Kinect;
using System.IO;
using System.IO.Ports;
using Microsoft.Speech.AudioFormat;
using Microsoft.Speech.Recognition;
using System.Threading;

namespace AnubisClient
{
    public partial class ClientForm : Form
    {
        
        private KinectInterface KI;
        private Sock ssock;


        public ClientForm()
        {
            InitializeComponent();
            KI = new KinectInterface();
            ssock = new Sock(1337);
            ssock.Listen();
            new Thread(() =>
            {
                Sock sssock = ssock.Accept();
                string strign = sssock.readline();
                strign += strign;
                sssock.sendline(strign);
                sssock.close();

            }).Start();
            
            
            //If my coding is as good as I think it is,
            //This function is now registered to the event of 
            //New Skeleton Frame Ready
            KI.RegisterSkeletonReadyEvent(NewSkelFrame);
            
            
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
                    CommandBuilder.UpdateCommand(14, 1000); // Need to Confirm Command
                    
                    lbl_DriveLeft.Text = "Reverse";
                }
                else if (KI.HandLeftPos.Z < Hip_Center.Z - 0.1)
                {
                    //Send Command to drive left Forwards
                    CommandBuilder.UpdateCommand(14, 2000); //Need to Confirm Command
                    lbl_DriveLeft.Text = "Forward";
                }

                else if (KI.HandLeftPos.Z >= Hip_Center.Z - 0.1 && KI.HandLeftPos.Z <= Hip_Center.Z + 0.1)
                {
                    //Send Command to drive left Neutral
                    CommandBuilder.UpdateCommand(14, 1500); //Need to Confirm Command
                    lbl_DriveLeft.Text = "Neutral";
                }

                if (KI.HandRightPos.Z > Hip_Center.Z + 0.1)
                {
                    // Send Command to drive Right Backwards
                    CommandBuilder.UpdateCommand(15, 1000); //Need to Confirm Command
                    lbl_DriveRight.Text = "Reverse";
                }

                else if (KI.HandRightPos.Z < Hip_Center.Z - 0.1)
                {
                    //Send Command to drive Right Forwards
                    CommandBuilder.UpdateCommand(15, 2000); //Need to Comfirm Command
                    lbl_DriveRight.Text = "Forward";
                }

                else if (KI.HandRightPos.Z <= Hip_Center.Z + 0.1 && KI.HandRightPos.Z >= Hip_Center.Z - 0.1) 
                {
                    //Send Command to drive Right Neutral
                    CommandBuilder.UpdateCommand(15, 1500); //Need to Confirm Command
                    lbl_DriveRight.Text = "Neutral";
                }
            }
            else
            {
                lbl_DriveMode.Text = "Arm Mode";

            }
            #endregion
            #region Arm Control

            if (KI.HandLeftPos.Y > Hip_Center.Z && KI.HandRightPos.Y > Hip_Center.Z)
            {

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
    }
}
