using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingHazards : MonoBehaviour {

    public float speed = 1.5f;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        transform.position += Vector3.right * speed * Time.deltaTime;

        if (transform.position.x < -1.1f)
        {
            speed = -speed;
        }
        else if(transform.position.x > 1.55f)
        {
            speed = -speed;
        }
    }
}
