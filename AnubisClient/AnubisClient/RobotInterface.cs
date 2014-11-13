using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;

namespace AnubisClient {
	public abstract class RobotInterface {
		private Sock robotsock;

		public RobotInterface(Sock robotsock) {
			this.robotsock = robotsock;
		}

		public static RobotInterface getNewROIFromHeloString(Sock sock) {
			string helo = sock.readline(); // blocks

			Type[] types = Assembly.GetAssembly(typeof(RobotInterface)).GetTypes();
			for (int i = 0; i < types.Length; i++) {
				Type t = types[i];
				if (t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(RobotInterface))) {
					RobotInterface roi = (RobotInterface)Activator.CreateInstance(t, sock);
					if (roi.getHeloString() == helo) return roi;
				}
			}

			sock.sendline("err Your helo string is not recognized.");
			sock.close();
			return null;
		}

		protected void sock_sendline_sync(string line) {
			robotsock.sendline(line);
		}

		protected void sock_invokeProto_solicitRobotResponse_async(string message, EventHandler<string> callback) {
			BackgroundWorker transactor = new BackgroundWorker();
			transactor.DoWork += (object sender, DoWorkEventArgs e) => {
				string response = robotsock.readline(); // blocks
				callback(this, response);
			};
			sock_sendline_sync(message);
			transactor.RunWorkerAsync();
		}

		public void sock_close() {
			robotsock.close();
		}

		public abstract string getHeloString();
		public abstract void updateSkeleton(Joint3d[] skeleton);
		public abstract void useNeutralSkeleton();
		public abstract void useNullSkeleton();
		public abstract bool verifyRobot();
		public abstract string requestData(string identifier);
		public abstract int ping();
	}
}
