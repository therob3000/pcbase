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

        public void update(double _Pitch)
        {
            Pitch = _Pitch;
        }

        public void update(double _Yaw)
        {
            Yaw = _Yaw;
        }

        public void update(double _Roll)
        {
            Roll = _Roll;
        }
    }
}
