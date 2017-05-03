using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public float speed = 0.7f;
    public float oldX;
    public GameObject leftStreetLamp;
    public GameObject rightStreetLamp;
    private float delta;
    

    // Update is called once per frame
    void FixedUpdate () {
        
       
        //float xPos = transform.position.x + (Input.GetAxis("Horizontal") * speed);
        if (KinectData.mainDX != -10000)
        {

            float xPos = ((KinectData.mainDX / 80f)-1.3f);
            Debug.Log(xPos);
            //float xPos = KinectData.mainDX;

            //if (Math.Abs(xPos - oldX) < 30000000)
            {
                //transform.position += Vector3.left * speed * Time.deltaTime;
                transform.position=new Vector3(Mathf.Clamp(xPos, (leftStreetLamp.transform.position.x - leftStreetLamp.transform.localScale.x), (rightStreetLamp.transform.position.x + rightStreetLamp.transform.localScale.x)),0, -1.93f);
                oldX = xPos;
            }
            //position = new Vector3(Mathf.Clamp(xPos, -6.1f, 6.1f), -11f, 0);
            //transform.position = position;
            
        }
       
	}
}
