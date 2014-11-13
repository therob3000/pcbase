

        // put somewhere else
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

        // put somewhere else
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