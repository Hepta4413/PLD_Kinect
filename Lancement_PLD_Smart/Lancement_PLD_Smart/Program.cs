using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lancement_PLD_Smart
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Diagnostics.Process.Start(@"..\..\..\..\kinect\kinect\bin\Debug\kinect");
            System.Threading.Thread.Sleep(2000);
            System.Diagnostics.Process.Start(@"..\..\..\..\BreakOutGame");
        }
    }
}
