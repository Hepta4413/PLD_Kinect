using UnityEngine;
using System;
using System.IO;
using System.IO.Pipes;
using UnityEngine.UI;

public class ClientHub : MonoBehaviour {

    // Use this for initialization
    NamedPipeClientStream client;
    StreamReader reader;
    public Text Xposition;
    bool update =true;

    void Awake () {
        DontDestroyOnLoad(this);
        client = new NamedPipeClientStream(".", "testpipe", PipeDirection.InOut);
        client.Connect();
        reader = new StreamReader(client);
    }
	
	// Update is called once per frame
	void Update () {
        if (update)
        {
            update = false;

            string msg = reader.ReadLine();
            Console.WriteLine(msg);
            if (msg != null)
            {
                readFrame(msg);
                client.Flush();
            } 
        }
        else
        {
            update = true;
        }
        
	}

    public void readFrame(String frame)
    {
        string[] jetons = frame.Split(' ');
        foreach (string jeton in jetons)
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
