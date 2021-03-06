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
    private float yOrigin;

    private void Start()
    {
        yOrigin = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate () {


        //float xPos = transform.position.x + (Input.GetAxis("Horizontal") * speed);
        if (KinectData.mainDX != -10000)
        {

            float xPos = (((KinectData.mainDX - 350)*3.5f/100f));
            Debug.Log(xPos);
            //float xPos = KinectData.mainDX;

            if (Math.Abs(xPos - oldX) < 30)
            {
                //transform.position += Vector3.left * speed * Time.deltaTime;
                transform.position = new Vector3(Mathf.Clamp(xPos, (leftStreetLamp.transform.position.x - leftStreetLamp.transform.localScale.x * 1.3f), (rightStreetLamp.transform.position.x + rightStreetLamp.transform.localScale.x * 1.3f)), yOrigin, 0);
                oldX = xPos;
            }
            //position = new Vector3(Mathf.Clamp(xPos, -6.1f, 6.1f), -11f, 0);
            //transform.position = position;
        }
       /* else
        {
            float xPos = 0;
            transform.position = new Vector3(0, -1, 0);
            oldX = xPos;
        }
       */
	}
}
