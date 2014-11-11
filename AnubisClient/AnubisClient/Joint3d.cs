using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnubisClient
{
    class Joint3d
    {
        public double Pitch, Roll, Yaw;

        public Joint3d()
        {
            Pitch = Roll = Yaw = 0;
        }

        public void updateP(double _Pitch)
        {
            Pitch = _Pitch;
        }

        public void updateY(double _Yaw)
        {
            Yaw = _Yaw;
        }

        public void updateR(double _Roll)
        {
            Roll = _Roll;
        }
    }
}
