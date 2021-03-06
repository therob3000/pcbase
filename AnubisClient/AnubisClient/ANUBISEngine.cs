﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AnubisClient
{
    static class ANUBISEngine
    {

        private static KinematicsEngine KinemEngine;
        private static BackgroundWorker Engine;
        private static ClientForm form;

        public static void Initialize(ClientForm c) //Already being called by Program.cs
        {
            form = c;
            Engine = new BackgroundWorker();
            CommunicationsEngine.initialize();
            CommunicationsEngine.startServer();
            KinemEngine = new KinematicsEngine(form);
            KinemEngine.StartThread();

        }

        static void Engine_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        static void Engine_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        static void Engine_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!Engine.CancellationPending)
            {
                //CommsEngine.UpdateRoboSkels(KinemEngine.GetSkeleton());
				CommunicationsEngine.publishNewSkeleton(KinemEngine.GetSkeleton());
            }
        }

        static void StartThread()
        {
            if (!Engine.IsBusy)
                Engine.RunWorkerAsync();
        }
    }
}
