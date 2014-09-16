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
        public KinectSensor sensor;
        public KinectSpeech kSpeech;

        public ClientForm()
        {
            InitializeComponent();
            sensor = KinectSensor.KinectSensors[0];
            kSpeech = new KinectSpeech();
            sensor.Start();
            kSpeech.startListening();
        }
        
        

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            sensor.Stop();
        }
    }
}
