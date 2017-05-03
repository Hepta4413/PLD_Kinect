using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public enum MainPrincipale { Droite, Gauche };

public class Paddle : MonoBehaviour {

    public float speed = 0.07f;

    private Vector3 position = new Vector3(0, -9.5f, 0);

    public float oldX = -9.5f;

    public bool firstFrame = true;
    public float xPos;

    public float xMain;

    public static MainPrincipale mainJoueuse = MainPrincipale.Droite;

    // Update is called once per frame
    void Update () {
        //float xPos = transform.position.x + (Input.GetAxis("Horizontal") * speed);
        if (mainJoueuse == MainPrincipale.Droite)
        {
            xMain = KinectData.mainDX;
        }
        else
        {
            xMain = KinectData.mainGX;
        }

        if (xMain != -10000)
        {
            xPos = ((xMain / 40)*2) - 15f;

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
