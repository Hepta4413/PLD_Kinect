using UnityEngine;
using System;
using System.IO;
using System.IO.Pipes;


public class NewBehaviourScript : MonoBehaviour {

    // Use this for initialization
    NamedPipeClientStream client;
    StreamReader reader;

    void Start () {
        client = new NamedPipeClientStream(".", "testpipe", PipeDirection.InOut);
        client.Connect();
        reader = new StreamReader(client);
    }
	
	// Update is called once per frame
	void Update () {
        readFrame(reader.ReadLine());
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
