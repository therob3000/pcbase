using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AnubisClient
{
    static class ANUBISEngine
    {
        private static CommunicationsEngine CommsEngine;
        private static KinematicsEngine KinemEngine;
        private static BackgroundWorker Engine;

        public static void Initialize() //Already being called by Program.cs
        {
            
            
            CommsEngine = new CommunicationsEngine();
            KinemEngine = new KinematicsEngine(CommsEngine);
            CommsEngine.StartThread();
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
