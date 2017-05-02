using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public float speed = 0.07f;

    private Vector3 position = new Vector3(0, -9.5f, 0);

    public float oldX = -9.5f;
    public float oldXInGame = -9.5f;
    public float XInGame;

    public float X;
    public bool firstFrame = true;
    public float xPos;


	// Update is called once per frame
	void Update () {
        //float xPos = transform.position.x + (Input.GetAxis("Horizontal") * speed);
        if (KinectData.mainDX != -10000)
        {
            xPos = ((KinectData.mainDX / 40)*2) - 15f;

            if(Math.Abs(xPos-oldX) < 30)
            {
                transform.position = new Vector3(Mathf.Clamp(xPos, -6.1f, 6.1f), -11f, 0);
                oldX = xPos;
            }
                
            
            /*if ((xPos - oldX) > 0.001)
            {
                transform.position =new Vector3(Mathf.Clamp(oldX + Time.deltaTime*speed * 2, -6.1f, 6.1f), -11f, 0);
            }
            else if ((xPos - oldX) < -0.001)
            {
                transform.position=new Vector3(Mathf.Clamp(oldX - Time.deltaTime*speed * 2, -6.1f, 6.1f), -11f, 0);
            }*/

            //position = new Vector3(Mathf.Clamp(xPos, -6.1f, 6.1f), -11f, 0);
            //transform.position = position;
            
        }
        
	}
}
