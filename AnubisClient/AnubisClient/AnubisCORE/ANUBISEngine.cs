using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AnubisClient
{
    static class ANUBISEngine
    {
        public static void Initialize() //Already being called by Program.cs
        {
            CommunicationsEngine.initialize();
            CommunicationsEngine.startServer();

            KinematicsEngine.initialize();
        }

        //static void Engine_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    while (!Engine.CancellationPending)
        //    {
        //        //CommsEngine.UpdateRoboSkels(KinemEngine.GetSkeleton());
        //        CommunicationsEngine.publishNewSkeleton(KinemEngine.GetSkeleton());
        //    }
        //}
    }
}
