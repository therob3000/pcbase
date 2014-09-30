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

namespace AnubisClient
{
    public class StoplightInterface
    {
        public SerialPort SerPort;

        public StoplightInterface()
        {
            
        }

        public string[] GetSerialPorts() 
        {
            string[] ports = SerialPort.GetPortNames();
            return ports;
        }

        public void flashGreenLightAndMakeSound()
        {
            SerPort = new SerialPort("COM10");
            SerPort.Open();
            SerPort.Write("1111");//write the port bytes, not a string (convert binary string to bytes
            //close port then re-open it before sending it the next command

        }

    }
}
