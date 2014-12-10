using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StatusStoplight {
	public class Program {
		private static Stoplight stl;

		public static void Main(string[] args) {
			// Read server information from host file
			if (!File.Exists("host.conf")) {
				Console.WriteLine("Error: Host file missing");
				return;
			}

			string[] lines = File.ReadAllLines("host.conf");
			if (lines.Length < 2) {
				Console.WriteLine("Error: Mailformed host file");
				return;
			}
			string server = lines[0];
			int port;
			try {
				port = int.Parse(lines[1]);
			}
			catch {
				Console.WriteLine("Error: Could not parse port to an integer");
				return;
			}

			// Init stoplight
			stl = new Stoplight();

			// Register an event handler
			Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);

			// Server connection Loop
			while (true) {
				stl.red();
				Sock s = connectToServer(server, port);
				processNet(s);
				s.close();
				s = null;
			}
		}

		private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e) {
			stl.close();
		}

		private static Sock connectToServer(string server, int port) {
			while (true) {
				try {
					Sock s = new Sock(server, port);
					return s;
				}
				catch { }
			}
		}

		private static void processNet(Sock s) {
			stl.yellow();
			try {
				while (true) {
					string line = s.readline();
					if (line == "s") {
						stl.green();
					}

					else if (line == "e") {
						stl.yellow();
					}

					else if (line == "pg") {
						s.sendline("pg");
					}

					else {
						s.sendline("err");
					}
				}
			}
			catch { }
		}
	}
}
