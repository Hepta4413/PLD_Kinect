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

        Vector3 futurPosition = transform.position + Vector3.right * speed * Time.deltaTime;

        if (futurPosition.x < -0.8f)
        {
            speed = -speed;
            futurPosition = transform.position + Vector3.right * speed * Time.deltaTime;
        }
        else if(futurPosition.x > 1.35f)
        {
            speed = -speed;
            futurPosition = transform.position + Vector3.right * speed * Time.deltaTime;
        }

        transform.position = futurPosition;
    }
}
