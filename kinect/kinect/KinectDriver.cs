using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kinect
{
    using System.IO;
    using System.Windows;
    using Microsoft.Kinect;
    using System.Text.RegularExpressions;

    class KinectDriver
    {
        private KinectSensor sensor;
        private Skeleton skeletonTracked;
        private bool envoi = true;
        private int noTracking = -1;
        private int nbSkeletons = 0;

        public void KinectInit()
        {
            foreach (var potentialSensor in KinectSensor.KinectSensors)
            {
                if (potentialSensor.Status == KinectStatus.Connected)
                {
                    this.sensor = potentialSensor;
                    break;
                }
            }

            if (this.sensor != null)
            {
                // Turn on the skeleton stream to receive skeleton frames
                this.sensor.SkeletonStream.Enable();
                //this.sensor.ColorStream.CameraSettings.FrameInterval = 15;

                // Add an event handler to be called whenever there is new color frame data
                this.sensor.SkeletonFrameReady += this.SensorSkeletonFrameReady;

                // Start the sensor!
                try
                {
                    this.sensor.Start();
                }
                catch (IOException)
                {
                    this.sensor = null;
                }
            }

            if (null == this.sensor)
            {
                Console.WriteLine("Pas de Kinect trouvée");
            }

        }

        private void SensorSkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            Skeleton[] skeletons = new Skeleton[0];

            using (SkeletonFrame skeletonFrame = e.OpenSkeletonFrame())
            {
                if (skeletonFrame != null)
                {
                    skeletons = new Skeleton[skeletonFrame.SkeletonArrayLength];
                    skeletonFrame.CopySkeletonDataTo(skeletons);
                }
            }

            if (skeletons.Length != 0)
            {
                bool newSkel = true;
                foreach (Skeleton skel in skeletons)
                {
                    if (skel.TrackingState == SkeletonTrackingState.Tracked && skel.TrackingId == noTracking)
                    {
                        newSkel = false;
                        skeletonTracked = skel;
                        String tmp = writeFrame();
                        Console.WriteLine(tmp);
                        //Serveur.WriteInPipe(tmp);
                        Serveur.WriteInFile(tmp);
                    }
                }

                if(newSkel)
                {
                    foreach (Skeleton skel in skeletons)
                    {
                        if (skel.TrackingState == SkeletonTrackingState.Tracked)
                        {
                            skeletonTracked = skel;
                            noTracking = skel.TrackingId;
                            nbSkeletons++;
                            String tmp = writeFrame();
                            Console.WriteLine(tmp);
                            //Serveur.WriteInPipe(tmp);
                            Serveur.WriteInFile(tmp);
                        }
                    }
                }
            }
        }

        float getJoint(JointType jointType, char coord)
        {
            Joint joint = skeletonTracked.Joints[jointType];

            if (joint.TrackingState == JointTrackingState.Tracked &&
                joint.TrackingState != JointTrackingState.Inferred)
            {
                switch (coord)
                {
                    case ('x'): return sensor.CoordinateMapper.MapSkeletonPointToDepthPoint(joint.Position, DepthImageFormat.Resolution640x480Fps30).X; break;
                    case ('y'): return sensor.CoordinateMapper.MapSkeletonPointToDepthPoint(joint.Position, DepthImageFormat.Resolution640x480Fps30).Y; break;
                    case ('z'): return sensor.CoordinateMapper.MapSkeletonPointToDepthPoint(joint.Position, DepthImageFormat.Resolution640x480Fps30).Depth; break;
                }
            }
            return -10000;
        }

        public String writeFrame()
        {
            string result;
            result = "MDX" + getJoint(JointType.HandRight, 'x')+' ';
            /*result += "MDY" + getJoint(JointType.HandRight, 'y') + ' ';
            result += "MDZ" + getJoint(JointType.HandRight, 'z') + ' ';
            result += "MGX" + getJoint(JointType.HandLeft, 'x') + ' ';
            result += "MGY" + getJoint(JointType.HandLeft, 'y') + ' ';
            result += "MGZ" + getJoint(JointType.HandLeft, 'z') + ' ';
            result += "TEX" + getJoint(JointType.Head, 'x') + ' ';
            result += "TEY" + getJoint(JointType.Head, 'y') + ' ';
            result += "TEZ" + getJoint(JointType.Head, 'z') + ' ';*/

            return result;
        }      
    }
}
