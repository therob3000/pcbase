using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Threading;

namespace StatusStoplight {
	public class Stoplight {
		public const string PORT_NAME = "COM10";
		private SerialPort sport;

		private enum col {r, g, b, s}

		public Stoplight() {
			sport = new SerialPort(PORT_NAME);
			changeState(col.s);
			Thread.Sleep(500); // 0.5 secs
			sport.Close();
		}

		private void changeState(col c) {
			sport.Close();
			sport.Open();
			if (c == col.r) sport.Write("0100");
			if (c == col.g) sport.Write("0010");
			if (c == col.b) sport.Write("0001");
			if (c == col.s) sport.Write("1111");
		}

		public void red() {
			changeState(col.r);
		}

		public void green() {
			changeState(col.g);
		}

		public void yellow() {
			changeState(col.b);
		}

		public void close() {
			sport.Close();
		}
	}
}
