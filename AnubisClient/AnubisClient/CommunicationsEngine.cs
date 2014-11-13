using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace AnubisClient {
	public static class CommunicationsEngine {
		public static const int SERVER_PORT = 1337;

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
				// todo
			}
			cleanupServer();
		}

		public static void publishNewSkeleton(Joint3d[] skeleton) {
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
			serversock.close();
			serversock = null;
		}
	}
}
