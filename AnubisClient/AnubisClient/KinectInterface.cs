using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Kinect;
using System.IO;
using System.Windows.Forms;

namespace AnubisClient
{
    class KinectInterface
    {
        #region JointAccessors

        private Point3f _spineBasePos;
        public Point3f SpineBasePos
        {
            get
            {
                return _spineBasePos;
            }
        }

        private Point3f _spineMidPos;
        public Point3f SpineMidPos
        {
            get
            {
                return _spineMidPos;
            }
        }

        private Point3f _headPos;
        public Point3f HeadPos
        {
            get
            {
                return _headPos;
            }
        }

        private Point3f _shoulderLeftPos;
        public Point3f ShoulderLeftPos
        {
            get
            {
                return _shoulderLeftPos;
            }
        }

        private Point3f _elbowLeftPos;
        public Point3f ElbowLeftPos
        {
            get
            {
                return _elbowLeftPos;
            }
        }

        private Point3f _wristLeftPos;
        public Point3f WristLeftPos
        {
            get
            {
                return _wristLeftPos;
            }
        }

        private Point3f _handLeftPos;
        public Point3f HandLeftPos
        {
            get
            {
                return _handLeftPos;
            }
        }

        private Point3f _shoulderRightPos;
        public Point3f ShoulderRightPos
        {
            get
            {
                return _shoulderRightPos;
            }
        }

        private Point3f _elbowRightPos;
        public Point3f ElbowRightPos
        {
            get
            {
                return _elbowRightPos;
            }
        }

        private Point3f _wristRightPos;
        public Point3f WristRightPos
        {
            get
            {
                return _wristRightPos;
            }
        }

        private Point3f _handRightPos;
        public Point3f HandRightPos
        {
            get
            {
                return _handRightPos;
            }
        }

        private Point3f _hipLeftPos;
        public Point3f HipLeftPos
        {
            get
            {
                return _hipLeftPos;
            }
        }

        private Point3f _kneeLeftPos;
        public Point3f KneeLeftPos
        {
            get
            {
                return _kneeLeftPos;
            }
        }

        private Point3f _ankleLeftPos;
        public Point3f AnkleLeftPos
        {
            get
            {
                return _ankleLeftPos;
            }
        }

        private Point3f _footLeftPos;
        public Point3f FootLeftPos
        {
            get
            {
                return _footLeftPos;
            }
        }

        private Point3f _hipRightPos;
        public Point3f HipRightPos
        {
            get
            {
                return _hipRightPos;
            }
        }

        private Point3f _kneeRightPos;
        public Point3f KneeRightPos
        {
            get
            {
                return _kneeRightPos;
            }
        }

        private Point3f _ankleRightPos;
        public Point3f AnkleRightPos
        {
            get
            {
                return _ankleRightPos;
            }
        }

        private Point3f _footRightPos;
        public Point3f FootRightPos
        {
            get
            {
                return _footRightPos;
            }
        }

        private Point3f _spineShoulderPos;
        public Point3f SpineShoulderPos
        {
            get
            {
                return _spineShoulderPos;
            }
        }

#endregion

        private KinectSensor sensor;

        public KinectInterface()
        {
            // Init joint position objects
            _spineBasePos = new Point3f();
            _spineMidPos = new Point3f();
            _headPos = new Point3f();
            _shoulderLeftPos = new Point3f();
            _elbowLeftPos = new Point3f();
            _wristLeftPos = new Point3f();
            _handLeftPos = new Point3f();
            _shoulderRightPos = new Point3f();
            _elbowRightPos = new Point3f();
            _wristRightPos = new Point3f();
            _handRightPos = new Point3f();
            _hipLeftPos = new Point3f();
            _kneeLeftPos = new Point3f();
            _ankleLeftPos = new Point3f();
            _footLeftPos = new Point3f();
            _hipRightPos = new Point3f();
            _kneeRightPos = new Point3f();
            _ankleRightPos = new Point3f();
            _footRightPos = new Point3f();
            _spineShoulderPos = new Point3f();

            // Init sensor
            //Indexes each connected sensor and starts one
            foreach (KinectSensor sense in KinectSensor.KinectSensors)
            {
                if (sense.Status == KinectStatus.Connected)
                {
                    
                    sensor = sense;
                    break;
                }
            }

            if (sensor != null)
            {
                //Begin Skeleton Frame and register with event handler
                sensor.SkeletonStream.Enable();
                sensor.SkeletonFrameReady += new EventHandler<SkeletonFrameReadyEventArgs>(this.SensorSkeletonFrameReady);
                try { sensor.Start(); }
                catch (IOException)
                {
                    sensor = null;
                }
            }

            //Catch if there is no sensor
            if (sensor == null)
            {
                MessageBox.Show("No Kinect");
            }
        }
        /// <summary>
        /// Event Handler for new skeleton frame
        /// </summary>
        /// <param name="sender"> Object that triggered event</param>
        /// <param name="e"> Skeleton Event Arguments</param>
        private void SensorSkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            //Place holder for skeletons
            Skeleton[] skeletons = new Skeleton[0];

            using (SkeletonFrame skeletonFrame = e.OpenSkeletonFrame())
            {
                if (skeletonFrame != null)
                {
                    //Copy Skeleton data to placeholder
                    skeletons = new Skeleton[skeletonFrame.SkeletonArrayLength];
                    skeletonFrame.CopySkeletonDataTo(skeletons);
                }
            }

            //Update joint position information
            if (skeletons.Length != 0)
            {
                if (skeletons[0].TrackingState == SkeletonTrackingState.Tracked)
                {
                    JointCollection jnts = skeletons[0].Joints; // use joints from first skeleton

                    // --Torso--
                    //Spine Base
                    _spineBasePos.update(jnts[JointType.HipCenter]);
                    //Spine Mid
                    _spineMidPos.update(jnts[JointType.Spine]);
                    //Spine
                    _spineShoulderPos.update(jnts[JointType.ShoulderCenter]);
                    //Head
                    _headPos.update(jnts[JointType.Head]);

                    //--Left Arm--
                    //Shoulder
                    _shoulderLeftPos.update(jnts[JointType.ShoulderLeft]);
                    //Elbow
                    _elbowLeftPos.update(jnts[JointType.ElbowLeft]);
                    //Wrist
                    _wristLeftPos.update(jnts[JointType.WristLeft]);
                    //Hand
                    _handLeftPos.update(jnts[JointType.HandLeft]);

                    //--Right Arm--
                    //Shoulder
                    _shoulderRightPos.update(jnts[JointType.ShoulderRight]);
                    //Elbow
                    _elbowRightPos.update(jnts[JointType.ElbowRight]);
                    //Wrist
                    _wristRightPos.update(jnts[JointType.WristRight]);
                    //Hand
                    _handRightPos.update(jnts[JointType.HandRight]);

                    //--Left Leg--
                    //Hip
                    _hipLeftPos.update(jnts[JointType.HipLeft]);
                    //Knee
                    _kneeLeftPos.update(jnts[JointType.KneeLeft]);
                    //Ankle
                    _ankleLeftPos.update(jnts[JointType.AnkleLeft]);
                    //Foot
                    _footLeftPos.update(jnts[JointType.FootLeft]);


                    //--Right Leg--
                    //Hip
                    _hipRightPos.update(jnts[JointType.HipRight]);
                    //Knee
                    _kneeRightPos.update(jnts[JointType.KneeRight]);
                    //Ankle
                    _ankleRightPos.update(jnts[JointType.AnkleRight]);
                    //Foot
                    _footRightPos.update(jnts[JointType.FootRight]);
                }
            }
        }
    }
}
