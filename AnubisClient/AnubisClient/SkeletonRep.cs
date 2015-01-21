using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnubisClient
{
    class SkeletonRep
    {
        public Joint3d SpineBase, SpineMiddle, Head, ShoulderLeft, ElbowLeft, WristLeft, HandLeft, ShoulderRight, ElbowRight, WristRight, HandRight, HipLeft, KneeLeft, AnkleLeft, FootLeft, HipRight, KneeRight, AnkleRight;
        public Joint3d FootRight, SpineShoulder;

        public SkeletonRep()
        {
            SpineBase = new Joint3d();
            // etc...
        }
        
    }
}
