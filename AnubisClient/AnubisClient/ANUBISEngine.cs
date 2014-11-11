using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AnubisClient
{
    static class ANUBISEngine
    {
        private static CommunicationsEngine CommsEngine = new CommunicationsEngine();
        private static KinematicsEngine KinemEngine = new KinematicsEngine();
        private static BackgroundWorker Engine = new BackgroundWorker();

        public static void Initialize() //Already being called by Program.cs
        {
            Engine.DoWork += Engine_DoWork;
            Engine.WorkerSupportsCancellation = true;
            Engine.WorkerReportsProgress = true;
            Engine.ProgressChanged += Engine_ProgressChanged;
            Engine.RunWorkerCompleted += Engine_RunWorkerCompleted;
            KinemEngine = new KinematicsEngine();
            CommsEngine = new CommunicationsEngine();

            CommsEngine.StartThread();
            KinemEngine.StartThread();
            ANUBISEngine.StartThread();
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
                CommsEngine.UpdateRoboSkels(KinemEngine.GetSkeleton());
            }
        }

        static void StartThread()
        {
            if (!Engine.IsBusy)
                Engine.RunWorkerAsync();
        }
    }
}
