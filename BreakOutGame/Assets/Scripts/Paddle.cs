using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public float speed = 0.7f;

    private Vector3 position = new Vector3(0, -9.5f, 0);

    public float oldX;

	// Update is called once per frame
	void Update () {
        //float xPos = transform.position.x + (Input.GetAxis("Horizontal") * speed);
        if (KinectData.mainDX != -10000)
        {
            float xPos = ((KinectData.mainDX / 40)*2) - 15f;
            if ((xPos - oldX) > 1)
            {
                transform.position =new Vector3(Mathf.Clamp(oldX + speed*2, -6.1f, 6.1f), -11f, 0);
            }
            else if ((xPos - oldX) < 1)
            {
                transform.position=new Vector3(Mathf.Clamp(oldX - speed*2, -6.1f, 6.1f), -11f, 0);
            }
            //position = new Vector3(Mathf.Clamp(xPos, -6.1f, 6.1f), -11f, 0);
            //transform.position = position;
            oldX = xPos;
        }
        
	}
}
