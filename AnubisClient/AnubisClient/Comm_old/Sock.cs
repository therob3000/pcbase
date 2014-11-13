using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace AnubisClient
{
    public class Sock
    {
        private Socket sock;
        private int _port;
        private string _rmtHost;

        public string rmtHost
        {
            get
            {
                return _rmtHost;
            }
        }

        public int port
        {
            get
            {
                return _port;
            }
        }

        public Sock(int Port)
        {
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _rmtHost = "";
            _port = Port;
            sock.ReceiveTimeout = 300000;
            sock.Bind(new IPEndPoint(0, _port));
            
        }

        public Sock(string RemoteHost, int Port)
        {
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _rmtHost = RemoteHost;
            _port = Port;
            sock.ReceiveTimeout = 300000;
            IPAddress[] ipas = Dns.GetHostAddresses(_rmtHost);
            sock.Connect(ipas[ipas.Length - 1], _port);
        }

        private Sock(Socket sockt, string RemoteHost, int Port)
        {
            this.sock = sockt;
            _rmtHost = RemoteHost;
            _port = Port;
        }

        public void Listen()
        {
            sock.Listen(10);
        }

        public Sock Accept()
        {
            return new Sock(sock.Accept(), rmtHost, port);
        }

        public void sendline(string line)
        {
            sock.Send(ASCIIEncoding.ASCII.GetBytes(line + "\n"));
        }

        public string readline()
        {
            string message = "";
            while (true)
            {
                byte[] bytes = new byte[1024];
                int bytesrec = sock.Receive(bytes);
                message += Encoding.ASCII.GetString(bytes, 0, bytesrec);
                if (message.IndexOf("\n") > 1) break;
            }
            message = message.Substring(0, message.Length - 1);
            return message;
        }

        public string readData(string Paramater)
        {
            string r_message = "";
            string s_message = "rd " + Paramater;
            sock.Send(ASCIIEncoding.ASCII.GetBytes(s_message + "\n"));
            try
            {
                while (true)
                {
                    byte[] bytes = new byte[1024];
                    int bytesrec = sock.Receive(bytes);
                    r_message += Encoding.ASCII.GetString(bytes, 0, bytesrec);
                    if (r_message.IndexOf("\n") > 1) break;
                }
                r_message = r_message.Substring(0, r_message.Length - 1);
                return r_message;
            }

            catch
            {
                return "Network Error";
            }
        }

        public string readCommand()
        {
            string r_message = "";
            string s_message = "rv";
            sock.Send(ASCIIEncoding.ASCII.GetBytes(s_message + "\n"));
            try
            {
                while (true)
                {
                    byte[] bytes = new byte[1024];
                    int bytesrec = sock.Receive(bytes);
                    r_message += Encoding.ASCII.GetString(bytes, 0, bytesrec);
                    if (r_message.IndexOf("\n") > 1) break;
                }
                r_message = r_message.Substring(0, r_message.Length - 1);
                return r_message;
            }

            catch
            {
                return "Network Error";
            }
        }

        public void close()
        {
            sock.Close();
        }
    }
}
