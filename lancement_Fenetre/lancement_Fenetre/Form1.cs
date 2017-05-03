using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lancement_Fenetre
{
    public partial class Form1 : Form
    {

         float mainDX;
         float mainDY;
         float mainDZ;
         float mainGX;
         float mainGY;
         float mainGZ;
         float teteX;
         float teteY;
         float teteZ;

        public Form1()
        {
            System.Diagnostics.Process.Start(@"..\..\..\..\kinect\kinect\bin\Debug\kinect");
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var fs = WaitForFile(@"../../../../Coord.txt");
            String msg;
            if (fs != null)
            {
                using (StreamReader reader = new StreamReader(fs))
                {
                    msg = reader.ReadLine();
                }
                fs.Dispose();
                if (msg != null)
                {
                    readFrame(msg);
                    if (mainDY != -10000 && teteY != -10000 && mainDY < teteY)
                    {
                        System.Diagnostics.Process.Start(@"..\..\..\..\BreakOutGame");
                    }
                    else if (mainGY != -10000 && teteY != -10000 && mainGY < teteY)
                    {
                        System.Diagnostics.Process.Start(@"..\..\..\..\PACHINKO");
                    }
                }
            }
         }

        public void readFrame(String frame)
        {
            string[] jetons = frame.Split(' ');
            foreach (string jeton in jetons)
            {
                if (jeton.Length > 3)
                {
                    string token = jeton.Substring(0, 3);
                    float valeur = float.Parse(jeton.Substring(3));
                    switch (token)
                    {
                        case ("MDX"): mainDX = valeur; break;
                        case ("MDY"): mainDY = valeur; break;
                        case ("MDZ"): mainDZ = valeur; break;
                        case ("MGX"): mainGX = valeur; break;
                        case ("MGY"): mainGY = valeur; break;
                        case ("MGZ"): mainGZ = valeur; break;
                        case ("TEX"): teteX = valeur; break;
                        case ("TEY"): teteY = valeur; break;
                        case ("TEZ"): teteZ = valeur; break;
                        default: break;
                    }
                }
            }
        }

        static FileStream WaitForFile(string fullPath)
        {
            /*for (int numTries = 0; numTries < 10; numTries++)
            {*/
            FileStream fs = null;
            try
            {
                fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                return fs;
            }
            catch (IOException)
            {
                if (fs != null)
                {
                    fs.Dispose();
                }
                //Thread.Sleep(50);
            }
            //}

            return null;
        }
    }
}
