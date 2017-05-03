using UnityEngine;
using System;
using System.IO;
using System.IO.Pipes;
using UnityEngine.UI;
using System.Threading;

public class ClientHub : MonoBehaviour {

    // Use this for initialization
    NamedPipeClientStream client;
    StreamReader reader;
    //public Text Xposition;
    bool update =true;

    void Awake () {
        DontDestroyOnLoad(this);
        /*client = new NamedPipeClientStream(".", "testpipe", PipeDirection.InOut);
        client.Connect();
        reader = new StreamReader(client);*/
        //reader.BaseStream.ReadTimeout = 20;
        InvokeRepeating("GetPosByFile", 0, 0.05f);
        //Thread workerThread = new Thread(new ThreadStart(DoWork));
        // workerThread.Start();
    }

    /* public void DoWork()
     {
         while (true)
         {
             string msg = reader.ReadLine();
             Xposition.text = msg;
             //Console.WriteLine(msg);
             if (msg != null)
             {
                 readFrame(msg);
                 client.Flush();
             }
         }


     }*/

    void GetPosByFile()
    {
        string msg;
        var fs = WaitForFile(@"C:\Users\Anthony\Documents\PLD_Kinect\PACHINKO\Coord.txt");
        if (fs != null)
        {
            using (StreamReader reader = new StreamReader(fs))
            {
                msg = reader.ReadLine();
            }
            //Xposition.text = msg;
            fs.Dispose();
            if (msg != null)
            {
                readFrame(msg);
            }
        }
        


    }


    // Update before
    void GetPos () {

        string msg = reader.ReadLine();
        //string line;
        //string msg = null;
        /*while ((line = reader.ReadLine()) != null)
        {
            msg = line;
        }*/

        //Xposition.text = msg;
        //Console.WriteLine(msg);
        if (msg != null)
        {
            readFrame(msg);
            client.Flush();
        }
        

    }

    FileStream WaitForFile(string fullPath)
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

    public void readFrame(String frame)
    {
        string[] jetons = frame.Split(' ');
        foreach (string jeton in jetons)
        {
            if (jeton != null && jeton.Trim().Length > 0)
            {
                string token = jeton.Substring(0, 3);
                float valeur = float.Parse(jeton.Substring(3));
                switch (token)
                {
                    case ("MDX"): KinectData.mainDX = valeur; break;
                    case ("MDY"): KinectData.mainDY = valeur; break;
                    case ("MDZ"): KinectData.mainDZ = valeur; break;
                    case ("MGX"): KinectData.mainGX = valeur; break;
                    case ("MGY"): KinectData.mainGY = valeur; break;
                    case ("MGZ"): KinectData.mainGZ = valeur; break;
                    case ("TEX"): KinectData.teteX = valeur; break;
                    case ("TEY"): KinectData.teteY = valeur; break;
                    case ("TEZ"): KinectData.teteZ = valeur; break;
                    default: break;
                } 
            }
        }
    }

    public void closePipe()
    {
        
    }
}
