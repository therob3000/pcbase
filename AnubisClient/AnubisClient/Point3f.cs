using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Kinect;

namespace AnubisClient
{
    class Point3f
    {
        public float X, Y, Z;

        public Point3f()
        {
            X = Y = Z = 0f;
        }

        public Point3f(Joint j)
        {
            update(j);
        }

        public Point3f(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public void update(Joint j)
        {
            X = j.Position.X;
            Y = j.Position.Y;
            Z = j.Position.Z;
        }
    }
}
