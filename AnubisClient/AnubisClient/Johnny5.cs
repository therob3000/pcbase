﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace AnubisClient {
	public class Johnny5 : RobotInterface {
		private int[] servoPositions;

		public Johnny5(Sock sock) : base(sock) {
			servoPositions = new int[17];
            for (int i = 0; i < servoPositions.Length; i++)
            {
                servoPositions[i] = 1500;
            }
		}

		private int angleDecode(double angle) {
            if (angle < 0) return 600;
            if (angle > 180) return 2400;
            return (int)(angle * 10) + 600;
		}

		private string createVector() {
			string vec = "";

			for (int i = 0; i < servoPositions.Length; i++) {
				int pos = servoPositions[i];
				if (pos >= 0) vec += "#" + i.ToString() + " P" + pos + " ";
				else vec += "#" + i.ToString() + "L ";
			}

			vec += "\r";
			return vec;
		}

		private void storeVector() {
			sock_sendline_sync("sv " + createVector());
		}

		public override string getHeloString() {
			return "Johnny5";
		}

		public override void updateSkeleton(Joint3d[] skeleton) {
			servoPositions[3] = angleDecode(skeleton[8].Roll);
			servoPositions[4] = angleDecode(skeleton[8].Pitch);

			servoPositions[8] = angleDecode(skeleton[4].Roll);
			servoPositions[9] = angleDecode(skeleton[4].Pitch);

			servoPositions[14] = angleDecode(skeleton[15].Pitch);
			servoPositions[15] = angleDecode(skeleton[14].Pitch);

			// more to come!

			storeVector();
		}

		public override void useNeutralSkeleton() {
			for (int i = 0; i < servoPositions.Length; i++) {
				servoPositions[i] = 1500;
			}
			storeVector();
		}

		public override void useNullSkeleton() {
			for (int i = 0; i < servoPositions.Length; i++) {
				servoPositions[i] = (i == 14 || i == 15 ? 1500 : -1);
			}
			storeVector();
		}

		public override void verifyRobot(EventHandler<GenericEventArgs<bool>> callback) {
			EventHandler<GenericEventArgs<string>> protocallback = (object sender, GenericEventArgs<string> e) => {
				callback(sender, new GenericEventArgs<bool>(e.payload == createVector()));
			};
			sock_invokeProto_solicitRobotResponse_async("rv", protocallback);
		}

		public override void requestData(string identifier, EventHandler<GenericEventArgs<string>> callback) {
			EventHandler<GenericEventArgs<string>> protocallback = (object sender, GenericEventArgs<string> e) => {
				// process the response, if needed
				callback(sender, e);
			};
			sock_invokeProto_solicitRobotResponse_async("rd " + identifier, protocallback);
		}

		public override void ping(EventHandler<GenericEventArgs<long>> callback) {
			Stopwatch timer = new Stopwatch();
			EventHandler<GenericEventArgs<string>> protocallback = (object sender, GenericEventArgs<string> e) => {
				timer.Stop();
				callback(sender, new GenericEventArgs<long>(timer.ElapsedMilliseconds));
			};
			timer.Start();
			sock_invokeProto_solicitRobotResponse_async("pg", protocallback);
		}
	}
}
