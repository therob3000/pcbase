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
       //private StoplightInterface SLI;


        public ClientForm()
        {
            InitializeComponent();
            KI = new KinectInterface();
            KI.RegisterSkeletonReadyEvent(NewSkelFrame);
            //If my coding is as good as I think it is,
            //This function is now registered to the event of 
            //New Skeleton Frame Ready
            CB = new CommandBuilder();
            
        }


        private void NewSkelFrame(object sender, Microsoft.Kinect.SkeletonFrameReadyEventArgs e)
        {
            //Drivetrain
            //This will need some refining in terms of how responsive
            Point3f Hip_Center = KI.SpineBasePos;
            
            //Drive Left
            if (KI.HandLeftPos.Y < Hip_Center.Y && KI.HandRightPos.Y < Hip_Center.Y)
            {
                if (KI.HandLeftPos.Z > Hip_Center.Z)
                {
                    //Send Command to Drive left Forward
                }
                else if (KI.HandLeftPos.Z < Hip_Center.Z)
                {
                    //Send Command to drive left backwards
                }

                if (KI.HandRightPos.Z > Hip_Center.Z)
                {
                    // Send Command to drive Right Forward
                }

                else if (KI.HandRightPos.Z < Hip_Center.Z)
                {
                    //Send Command to drive Right Backward
                }   
            }

            if (KI.HandLeftPos.Y > Hip_Center.Z && KI.HandRightPos.Y > Hip_Center.Z)
            {

            }
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            KI.EndSensorStream();
            //KI.stopSpeech();
        }

        private void Start_Click(object sender, EventArgs e)
        {
        }

        private void Stop_Click(object sender, EventArgs e)
        {
        }
    }
}
