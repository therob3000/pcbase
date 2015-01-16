using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Threading;

namespace StatusStoplight
{
    public class Stoplight
    {
        public const string PORT_NAME = "COM3";
        private SerialPort sport;

        private enum col { r, g, y, s, c }

        public Stoplight()
        {
            sport = new SerialPort(PORT_NAME);
            changeState(col.s);
            Thread.Sleep(500); // 0.5 secs
        }

        private void changeState(col c)
        {
            sport.Open();
            if (c == col.r) sport.Write(BitConverter.GetBytes(4), 0, 1);
            if (c == col.g) sport.Write(BitConverter.GetBytes(1), 0, 1);
            if (c == col.y) sport.Write(BitConverter.GetBytes(2), 0, 1);
            if (c == col.s) sport.Write(BitConverter.GetBytes(15),0, 1);
            if (c == col.c) sport.Write(BitConverter.GetBytes(0), 0, 1);
            sport.Close();
        }

        public void red()
        {
            changeState(col.r);
        }

        public void green()
        {
            changeState(col.g);
        }

        public void yellow()
        {
            changeState(col.y);
        }

        public void close()
        {
            changeState(col.c);
            sport.Close();
        }
    }
}
