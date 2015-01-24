﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace AnubisClient {
	public class Sock {
		private Socket sock;
		private string _rmtHost;
		private int _port;

		public string rmtHost {
			get {
				return _rmtHost;
			}
		}

		public int port {
			get {
				return _port;
			}
		}

		public Sock(int port) { // Server Constructor
			sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			_rmtHost = "";
			_port = port;
			sock.ReceiveTimeout = 300000;
			sock.Bind(new IPEndPoint(0, _port));
		}

		public Sock(string rmtHost, int port) { // Client Constructor
			sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			_rmtHost = rmtHost;
			_port = port;
			sock.ReceiveTimeout = 300000;
			IPAddress[] ipas = Dns.GetHostAddresses(_rmtHost);
			sock.Connect(ipas[ipas.Length - 1], _port);
		}

		private Sock(Socket sock, string rmtHost, int port) { // Accept Constructor
			this.sock = sock;
			_rmtHost = rmtHost;
			_port = port;
		}

		public void listen() {
			sock.Listen(10);
		}

		public Sock accept() {
			return new Sock(sock.Accept(), rmtHost, port);
		}

        public void sendline(string line) {
            try
            {
                sock.Send(ASCIIEncoding.ASCII.GetBytes(line + "\n")); // Append a new-line when sending
            }
            catch (Exception ex){}
			
		}

		public string readline() { // blocks
			string message = "";
			while (true) {
				byte[] bytes = new byte[1024];
				int bytesrec = sock.Receive(bytes);
				message += Encoding.ASCII.GetString(bytes, 0, bytesrec);
				if (message.IndexOf("\n") >= 0) break; // Use new-line to identify end-of-message
			}
			message = message.Substring(0, message.Length - 1); // Strip new-line when receiving
			return message;
		}

		public void close() {
			sock.Close();
		}
	}
}
