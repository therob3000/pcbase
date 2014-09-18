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
        public SerialPort SPort;

        public int BaseVal = 1500;
        public const string str_powerOffRobot = "#0L #1L #2L #3L #4L #5L #6L #7L #8L #9L #10L #11L #12L #13L  #14 P1500 #15 P1500\r";
        public const string str_centerRobot = "#0 P1500 #1 P1500 #2 P1500 #3 P1500 #4 P1500 #5 P1500 #6 P1500 #7 P1500 #8 P1500 #9 P1500 #10 P1500 #11 P1500 #12 P1500 #13 P1500 #14 P1500 #15 P1500\r";


        public ClientForm()
        {
            InitializeComponent();
            KI = new KinectInterface();
            KI.RegisterSpeechRecognized(SpeechRecog);
            KI.RegisterSkeletonReadyEvent(NewSkelFrame);
            SPort = new SerialPort("COM1");
            SPort.BaudRate = 115200;
            SPort.Parity = System.IO.Ports.Parity.None;
            SPort.DataBits = 8;
            SPort.StopBits = System.IO.Ports.StopBits.One;
            SPort.Open();
            //If my coding is as good as I think it is,
            //This function is now registered to the event of 
            //New Skeleton Frame Ready
            KI.BeginSensorStream();
            KI.startSpeech();
            SPort.Write(str_centerRobot);
            
            
        }

        private void SpeechRecog(object sender, Microsoft.Speech.Recognition.SpeechRecognizedEventArgs e) 
        {
            MessageBox.Show("Mwahahaha");
        }

        private void NewSkelFrame(object sender, Microsoft.Kinect.SkeletonFrameReadyEventArgs e)
        {
            float DeltaY1 = KI.ElbowLeftPos.Y - KI.ShoulderLeftPos.Y;
            float DeltaX1 = KI.ElbowLeftPos.X - KI.ShoulderLeftPos.X;
            double Angle1 = Math.Atan(DeltaY1 / DeltaX1) * (180 / Math.PI);
            int Pulse1 = (int)(Angle1 * 10) + 600;

            float DeltaY2 = KI.ElbowRightPos.Y - KI.ShoulderRightPos.Y;
            float DeltaX2 = KI.ElbowRightPos.X - KI.ShoulderRightPos.X;
            double Angle2 = Math.Atan(DeltaY2 / DeltaX2) * (180 / Math.PI) + 180;
            int Pulse2 = (int)(Angle2 * 10) + 600;

            SPort.Write("#4 P" + Pulse1 + "#9 P" + Pulse2 + /*"#13 P"+ pulseHead */ "\r");
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SPort.Write(str_powerOffRobot);
            SPort.Close();
            KI.EndSensorStream();
            //KI.stopSpeech();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                //Rotate Base CCW
                case Keys.Q:
                    if (!(BaseVal <= 500))
                        BaseVal -= 20;
                    SPort.Write("#0 P" + BaseVal + "\r");
                    break;
                //Rotate Base CW
                case Keys.E:
                    if (!(BaseVal >= 2500))
                        BaseVal += 20;
                    SPort.Write("#0 P" + BaseVal + "\r");
                    break;

                //Tracks Reverse
                case Keys.S:
                    SPort.Write("#15 P2000 #14 P1000\r");
                    break;

                //Tracks Forward
                case Keys.W:
                    SPort.Write("#15 P1000 #14 P2000\r");
                    break;
                //Tracks Turn Left
                case Keys.A:
                    SPort.Write("#15 P1000 #14 P1000\r");
                    break;
                //Tracks Turn Right
                case Keys.D:
                    SPort.Write("#15 P2000 #14 P2000\r");
                    break;
                //Power Down Code
                case Keys.K:
                    SPort.Write(str_powerOffRobot);
                    break;
                //Power Up and Center
                case Keys.L:
                    SPort.Write(str_centerRobot);
                    break;

                case Keys.B:
                    SPort.Write("#15 P1500 #14 P1500\r");
                    break;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KI.stopSpeech();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KI.startSpeech();
        }
    }
}
