﻿using System;
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
        //private List<Sock> SocketPool;
        private List<RobotInterface> ConnectionPool;
        private NetworkInterface NetFace;
        private Joint3d[] SkelArray;
        
        public CommunicationsEngine()
        {
            SkelArray = new Joint3d[20]; 
            CommsSystem = new BackgroundWorker();
            CommsSystem.WorkerSupportsCancellation = true;
            CommsSystem.WorkerReportsProgress = true;
            CommsSystem.DoWork += CommsSystem_DoWork;
            CommsSystem.ProgressChanged += CommsSystem_ProgressChanged;
            CommsSystem.RunWorkerCompleted += CommsSystem_RunWorkerCompleted;

            NetFace = new NetworkInterface();
            NetFace.connectionAccepted += NetFace_connectionAccepted;

            //SocketPool = new List<Sock>();
            ConnectionPool = new List<RobotInterface>();
        }

        public void UpdateRoboSkels(Joint3d[] Skel)
        {
            SkelArray = Skel;
        }

        void NetFace_connectionAccepted(object sender, SockArgs e)
        {
            //if (e != null)
            //{
            //    SocketPool.Add(e.Socket);
            //}
            if (e.Socket.readline() == "Johnny5")
            {
                ConnectionPool.Add(new Johnny5(e.Socket));
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

                NetFace.StartThread();

                if (ConnectionPool.Count > 0)
                {
                    int i = 1;
                }

                //foreach (RobotInterface RI in ConnectionPool)
                for (int i = 0; i < ConnectionPool.Count; i++)
                {
                    if (ConnectionPool[i] != null)
                    {
                        ConnectionPool[i].UpdateSkeleton(SkelArray);
                        ConnectionPool[i].SendCommands();
                    }
                }
            }
        }

        public void StartThread()
        {
            if (!CommsSystem.IsBusy)
            {
                CommsSystem.RunWorkerAsync();
            }
        }
    }
}
