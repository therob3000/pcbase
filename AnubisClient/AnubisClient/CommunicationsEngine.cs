using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AnubisClient
{
    class CommunicationsEngine
    {
        private BackgroundWorker CommsSystem;
        private List<Sock> SocketPool;
        private List<RobotInterface> ConnectionPool;
        private NetworkInterface NetFace;
        public void Communicationsengine()
        {
            CommsSystem = new BackgroundWorker();
            CommsSystem.WorkerSupportsCancellation = true;
            CommsSystem.WorkerReportsProgress = true;
            CommsSystem.DoWork += CommsSystem_DoWork;
            CommsSystem.ProgressChanged += CommsSystem_ProgressChanged;
            CommsSystem.RunWorkerCompleted += CommsSystem_RunWorkerCompleted;

            NetFace = new NetworkInterface();
            NetFace.connectionAccepted += NetFace_connectionAccepted;

            SocketPool = new List<Sock>();
            ConnectionPool = new List<RobotInterface>();
        }

        void NetFace_connectionAccepted(object sender, Sock e)
        {
            if (e != null)
            {
                SocketPool.Add(e);
            }
            if (e.readline() == "Johnny 5")
            {
                ConnectionPool.Add(new Johnny5());
            }
        }

        void CommsSystem_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
        }

        void CommsSystem_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
        }

        void CommsSystem_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!CommsSystem.CancellationPending)
            {
                foreach (RobotInterface RI in ConnectionPool)
                {
                    RI.SendCommands();
                }
            }
        }
    }
}
