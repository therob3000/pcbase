

        // save for now
        void NetFace_connectionAccepted(object sender, SockArgs e)
        {
            if (e != null)
            {
                SocketPool.Add(e.Socket);
            }
            if (e.Socket.readline() == "Johnny5")
            {
                ConnectionPool.Add(new Johnny5(e.Socket));
            }
        }

        // new staff
        void CommsSystem_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!CommsSystem.CancellationPending)
            {
                NetFace.StartThread();
                
                foreach (RobotInterface RI in ConnectionPool)
                {
                    if (RI != null)
                    {
                        RI.UpdateSkeleton(SkelArray);
                        RI.SendCommands();
                    }
                }
            }
        }