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

		protected void sock_invokeProto_solicitRobotResponse_async(string message, EventHandler<GenericEventArgs<string>> callback) {
			BackgroundWorker transactor = new BackgroundWorker();
			transactor.DoWork += (object sender, DoWorkEventArgs e) => {
				string response = robotsock.readline(); // blocks
				callback(this, new GenericEventArgs<string>(response));
			};
			sock_sendline_sync(message);
			transactor.RunWorkerAsync();
		}

		public void sock_close() {
			robotsock.close();
		}

		public abstract string getHeloString();
		public abstract void updateSkeleton(SkeletonRep mod);
		public abstract void useNeutralSkeleton();
		public abstract void useNullSkeleton();
		public abstract void verifyRobot(EventHandler<GenericEventArgs<bool>> callback);
		public abstract void requestData(string identifier, EventHandler<GenericEventArgs<string>> callback);
		public abstract void ping(EventHandler<GenericEventArgs<long>> callback);
	}
}
