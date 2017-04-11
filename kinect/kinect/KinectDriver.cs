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


    class KinectDriver
    {
        private KinectSensor sensor;
        private Skeleton skeletonTracked;

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
                //Console.WriteLine(skeletons.Length);
                foreach (Skeleton skel in skeletons)
                {
                    if (skel.TrackingState == SkeletonTrackingState.Tracked)
                    {
                        skeletonTracked = skel;
                    }
                }
            }
        }

        #region getter

        float getXMainD()
        {
            return getJoint(JointType.HandRight, 'x');
        }

        float getYMainD()
        {
            return getJoint(JointType.HandRight, 'y');
        }

        float getZMainD()
        {
            return getJoint(JointType.HandRight, 'z');
        }

        float getXMainG()
        {
            return getJoint(JointType.HandLeft, 'x');
        }

        float getYMainG()
        {
            return getJoint(JointType.HandLeft, 'y');
        }

        float getZMainG()
        {
            return getJoint(JointType.HandLeft, 'z');
        }

        float getXTete()
        {
            return getJoint(JointType.Head, 'x');
        }

        float getYTete()
        {
            return getJoint(JointType.Head, 'y');
        }

        float getZTete()
        {
            return getJoint(JointType.Head, 'z');
        }

        float getJoint(JointType jointType, char coord)
        {
            Joint joint = skeletonTracked.Joints[jointType];

            if (joint.TrackingState == JointTrackingState.Tracked &&
                joint.TrackingState != JointTrackingState.Inferred)
            {
                switch (coord)
                {
                    case ('x'): return joint.Position.X; break;
                    case ('y'): return joint.Position.Y; break;
                    case ('z'): return joint.Position.Z; break;
                }
            }
            return -10000;
        }

        #endregion
    }
}
