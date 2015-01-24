﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;

namespace AnubisClient
{
    class KinematicsEngine
    {
        private KinectInterface KI;
        private BackgroundWorker KinectUpdater;
        private Point3f[] JointVals;
        private Joint3d[] JointAngles;
        private ClientForm form;
        private GestureEngine gesture_eng;

        public KinematicsEngine(ClientForm c)
        {
            form = c;
            KI = new KinectInterface();
            JointVals = new Point3f[20];
            JointAngles = new Joint3d[20];
            KinectUpdater = new BackgroundWorker();
            KinectUpdater.WorkerSupportsCancellation = true;
            KinectUpdater.WorkerReportsProgress = true;
            KinectUpdater.DoWork += KinectUpdater_DoWork;
            KinectUpdater.ProgressChanged += KinectUpdater_ProgressChanged;
            KinectUpdater.RunWorkerCompleted += KinectUpdater_RunWorkerCompleted;
            gesture_eng = new GestureEngine();
        }
        #region KinematicCode
        private void KinectUpdater_DoWork(object sender, DoWorkEventArgs e)
        {

            KI.BeginSensorStream();

            while (!KinectUpdater.CancellationPending)
            {
                JointVals[0] = KI.SpineBasePos;
                JointVals[1] = KI.SpineMidPos;
                JointVals[2] = KI.HeadPos;
                JointVals[3] = KI.ShoulderLeftPos;
                JointVals[4] = KI.ElbowLeftPos;
                JointVals[5] = KI.WristLeftPos;
                JointVals[6] = KI.HandLeftPos;
                JointVals[7] = KI.ShoulderRightPos;
                JointVals[8] = KI.ElbowRightPos;
                JointVals[9] = KI.WristRightPos;
                JointVals[10] = KI.HandRightPos;
                JointVals[11] = KI.HipLeftPos;
                JointVals[12] = KI.KneeLeftPos;
                JointVals[13] = KI.AnkleLeftPos;
                JointVals[14] = KI.FootLeftPos;
                JointVals[15] = KI.HipRightPos;
                JointVals[16] = KI.KneeRightPos;
                JointVals[17] = KI.AnkleRightPos;
                JointVals[18] = KI.FootRightPos;
                JointVals[19] = KI.SpineShoulderPos;

                JointAngles[1] = new Joint3d();
                JointAngles[2] = new Joint3d();
                JointAngles[3] = new Joint3d();
                JointAngles[4] = new Joint3d();
                JointAngles[5] = new Joint3d();
                JointAngles[6] = new Joint3d();
                JointAngles[7] = new Joint3d();
                JointAngles[8] = new Joint3d();
                JointAngles[9] = new Joint3d();
                JointAngles[10] = new Joint3d();
                JointAngles[11] = new Joint3d();
                JointAngles[12] = new Joint3d();
                JointAngles[13] = new Joint3d();
                JointAngles[14] = new Joint3d();
                JointAngles[15] = new Joint3d();
                JointAngles[16] = new Joint3d();
                JointAngles[17] = new Joint3d();
                JointAngles[18] = new Joint3d();
                JointAngles[19] = new Joint3d();

                if (KI.tracked_skeletons > 0)
                {
                    
                    #region Drivetrain
                    //This will need some refining in terms of how responsive
                    Point3f Hip_Center = KI.SpineBasePos;

                    

                    //Drive Mode
                    //When the users hands are below their belly button, the user is in drive mode
                    if (KI.HandLeftPos.Y < Hip_Center.Y + 0.02 && KI.HandRightPos.Y < Hip_Center.Y + 0.02)
                    {
                        
                        //If the users Left hand is behind the center zone, drive left tread in reverse
                        if (KI.HandLeftPos.Z > Hip_Center.Z + 0.1)
                        {
                            //Send Command to Drive left Reverse
                            JointAngles[15].Pitch = 120; // Need to Confirm Command
                            
                        }
                        //If the users left hand is in front of the center zone, drive left tread forward
                        else if (KI.HandLeftPos.Z < Hip_Center.Z - 0.1)
                        {
                            //Send Command to drive left Forwards
                            JointAngles[15].Pitch = 60; //Need to Confirm Command
                        }
                        //If the users left hand is in the center zone, stop the left tread
                        else if (KI.HandLeftPos.Z >= Hip_Center.Z - 0.1 && KI.HandLeftPos.Z <= Hip_Center.Z + 0.1)
                        {
                            //Send Command to drive left Neutral
                            JointAngles[15].Pitch = 90; //Need to Confirm Command
                        }
                        //If the users right hand is behind the center zone, drive right tread backwards
                        if (KI.HandRightPos.Z > Hip_Center.Z + 0.1)
                        {
                            // Send Command to drive Right Backwards
                            JointAngles[14].Pitch = 120; //Need to Confirm Command
                        }
                        //If the users right hand is in front of the center zone, drive right tread forward
                        else if (KI.HandRightPos.Z < Hip_Center.Z - 0.1)
                        {
                            //Send Command to drive Right Forwards
                            JointAngles[14].Pitch = 60; //Need to Comfirm Command
                        }
                        //If the users right hand is in the center zone, stop the right tread
                        else if (KI.HandRightPos.Z >= Hip_Center.Z - 0.1 && KI.HandRightPos.Z <= Hip_Center.Z + 0.1)
                        {
                            //Send Command to drive Right Neutral
                            JointAngles[14].Pitch = 90; //Need to Confirm Command
                        }
                    }

                    //If the users hands are above the belly button, stop both treads. They are now in arm mode.
                    else
                    {
                        JointAngles[15].Pitch = 90;
                        JointAngles[14].Pitch = 90;
                    }

                    #endregion
                    #region Arm Control

                    //Arm Control involves trig to identify certain angles between points of refference

                    //Left Arm Pitch
                    float LDX = KI.ElbowLeftPos.X - KI.ShoulderLeftPos.X;
                    float LDY = KI.ElbowLeftPos.Y - KI.ShoulderLeftPos.Y;
                    double AngleL = Math.Atan(LDY / LDX) * (180 / Math.PI);
                    JointAngles[4].Pitch = AngleL;

                    //Left Arm Shoulder Roll
                    float RollLDZ = KI.ShoulderLeftPos.Z - KI.HandLeftPos.Z;
                    float RollLDY = KI.ShoulderLeftPos.Y - KI.HandLeftPos.Y;
                    double RollAngleL = Math.Atan(RollLDY / RollLDZ) * (180 / Math.PI);
                    JointAngles[4].Roll =((90 - RollAngleL) + 90);



                    //Right Arm Pitch
                    float RDX = KI.ElbowRightPos.X - KI.ShoulderRightPos.X;
                    float RDY = KI.ElbowRightPos.Y - KI.ShoulderRightPos.Y;
                    double AngleR = Math.Atan(RDY / RDX) * (180 / Math.PI) + 180;
                    JointAngles[8].Pitch = (AngleR);

                    //Right Arm Shoulder Roll
                    float RollRDZ = KI.ShoulderRightPos.Z - KI.HandRightPos.Z;
                    float RollRDY = KI.ShoulderRightPos.Y - KI.HandRightPos.Y;
                    double RollAngleR = Math.Atan(RollRDY / RollRDZ) * (180 / Math.PI);
                    JointAngles[8].Roll =(RollAngleR);


                    //TODO: Add code to call CommEngine event handler?
                    CommunicationsEngine.publishNewSkeleton(JointAngles);

                    //This could be a really bad idea...  But it works!
                    //Relieves network congestion by slowing down direct calls to sock.send.
                    //However this will also slow down our own processing.
                    Thread.Sleep(100);


                    KinectUpdater.ReportProgress(0, JointAngles);

                    #endregion

                }
                //If the kinect loses sight of a person, set the robot to center.
                //This acts as a failsafe mechanism.
                else
                {
                    //Need Suitable Replacement
                    //CommandBuilder.SetToCenter();

                }
            }

        }        
        private void KinectUpdater_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Set some kind of message here if needed
            
        }

        private void KinectUpdater_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Set some kind of message here if needed
            
        }
        #endregion

        public void StartThread()
        {
            if (!KinectUpdater.IsBusy)
            {
                KinectUpdater.RunWorkerAsync();
            }
        }

        public Joint3d[] GetSkeleton()
        {
                return JointAngles;
        }
    }
}
