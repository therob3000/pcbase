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

namespace AnubisClient
{
    public partial class ClientForm : Form
    {
        
        private KinectInterface KI;
        private CommandBuilder CB;


        public ClientForm()
        {
            InitializeComponent();
            KI = new KinectInterface();
            
            //If my coding is as good as I think it is,
            //This function is now registered to the event of 
            //New Skeleton Frame Ready
            KI.RegisterSkeletonReadyEvent(NewSkelFrame);
            
            CB = new CommandBuilder();
            
        }


        private void NewSkelFrame(object sender, Microsoft.Kinect.SkeletonFrameReadyEventArgs e)
        {

            #region Drivetrain
            //This will need some refining in terms of how responsive
            Point3f Hip_Center = KI.SpineBasePos;
            
            //Drive Left
            if (KI.HandLeftPos.Y < Hip_Center.Y && KI.HandRightPos.Y < Hip_Center.Y)
            {
                if (KI.HandLeftPos.Z > Hip_Center.Z)
                {
                    //Send Command to Drive left Forward
                    CB.UpdateCommand(14, 1000); // Need to Confirm Command
                }
                else if (KI.HandLeftPos.Z < Hip_Center.Z)
                {
                    //Send Command to drive left backwards
                    CB.UpdateCommand(14, 2000); //Need to Confirm Command
                }

                if (KI.HandRightPos.Z > Hip_Center.Z)
                {
                    // Send Command to drive Right Forward
                    CB.UpdateCommand(15, 1000); //Need to Confirm Command
                }

                else if (KI.HandRightPos.Z < Hip_Center.Z)
                {
                    //Send Command to drive Right Backward
                    CB.UpdateCommand(15, 2000); //Need to Comfirm Command
                }
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
