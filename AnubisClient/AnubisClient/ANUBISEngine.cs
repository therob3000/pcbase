using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnubisClient
{
    static class ANUBISEngine
    {
        public static CommunicationsEngine CommsEngine = new CommunicationsEngine();
        public static KinematicsEngine KinemEngine = new KinematicsEngine();

        public static void Initialize() //Already being called by Program.cs
        {
            KinemEngine = new KinematicsEngine();
            CommsEngine = new CommunicationsEngine();

            CommsEngine.StartThread();
        }
    }
}
