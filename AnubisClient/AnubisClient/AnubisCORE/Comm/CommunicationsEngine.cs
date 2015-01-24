using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace AnubisClient {
	public static class CommunicationsEngine {
		public const int SERVER_PORT = 1337;

		private static BackgroundWorker server;
		private static Sock serversock;
		private static List<RobotInterface> activeRobots;

		public static void initialize() {
			server = new BackgroundWorker();
			server.WorkerSupportsCancellation = true;
			server.DoWork += new DoWorkEventHandler(server_acceptConnections);
			activeRobots = new List<RobotInterface>();
			// do not need to init serversock here
		}

		private static void server_acceptConnections(object sender, DoWorkEventArgs e) {
			while (!server.CancellationPending) {
				Sock newconnection = serversock.accept(); // blocks
				RobotInterface roi = RobotInterface.getNewROIFromHeloString(newconnection);
				if (roi == null) continue; // socket was cleaned up for us in the getNewROI.... method
				activeRobots.Add(roi);
			}
			cleanupServer();
		}


		public static void publishNewSkeleton(SkeletonRep mod) {
			for (int i = 0; i < activeRobots.Count; i++) {
				activeRobots[i].updateSkeleton(mod);
			}
		}


		public static RobotInterface[] getROIsFromHeloString(string helostring) {
			List<RobotInterface> lst = new List<RobotInterface>();

			for (int i = 0; i < activeRobots.Count; i++) {
				RobotInterface roi = activeRobots[i];
				if (roi.getHeloString() == helostring) lst.Add(roi);
			}

			return lst.ToArray();
		}


		public static bool startServer() {
			if (server.IsBusy) return false;


			try {
				serversock = new Sock(SERVER_PORT);
				serversock.listen();
				server.RunWorkerAsync();
			}
			catch {
				cleanupServer();
				return false;
			}

			return true;
		}


		public static bool stopServer() {
			if (!server.IsBusy) return false;
			server.CancelAsync();
			return true;
		}

		private static void cleanupServer() {
			while (activeRobots.Count > 0) {
				activeRobots[0].sock_close();
				activeRobots.RemoveAt(0);
			}
			serversock.close();
			serversock = null;
		}
	}
}
