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
        static private KinectDriver driver;

        static void Main(string[] args)
        {
            driver = new KinectDriver();
            driver.KinectInit();
            Console.Read();
        }
    }
}
