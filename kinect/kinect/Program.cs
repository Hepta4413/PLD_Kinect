using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;
using System.IO;

namespace kinect
{
    class Program
    {
        static private KinectSensor sensor;
        static private int tour = 0;

        static void Main(string[] args)
        {
            foreach (var potentialSensor in KinectSensor.KinectSensors)
            {
                if (potentialSensor.Status == KinectStatus.Connected)
                {
                    sensor = potentialSensor;
                    break;
                }
            }

            if (null != sensor)
            {
                // Turn on the skeleton stream to receive skeleton frames
                sensor.SkeletonStream.Enable();

                // Add an event handler to be called whenever there is new color frame data
                sensor.SkeletonFrameReady += SensorSkeletonFrameReady;

                // Start the sensor!
                try
                {
                    sensor.Start();
                }
                catch (IOException)
                {
                    sensor = null;
                }
            }

            if (null == sensor)
            {
                Console.WriteLine("B");
                //statusBarText.Text = Properties.Resources.NoKinectReady;
            }
            Console.WriteLine("END");
            Console.Read();
        }

        private static void SensorSkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
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
                    Joint joint = skel.Joints[JointType.HandRight];

                    if (joint.TrackingState == JointTrackingState.NotTracked)
                    {
                        //Console.WriteLine("notTracked");
                        break;
                    }

                    // Don't draw if both points are inferred
                    if (joint.TrackingState == JointTrackingState.Inferred)
                    {
                        //Console.WriteLine("Inferred");
                        break;
                    }

                    // We assume all drawn bones are inferred unless BOTH joints are tracked
                    if (joint.TrackingState == JointTrackingState.Tracked)
                    {
                        Console.WriteLine(joint.Position.X);
                    }
                }
            }
        }        
    }
}
