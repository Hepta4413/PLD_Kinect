using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DestroyOnContact : MonoBehaviour {
	// Use this for initialization
	void Start () {
		Vector3 pos = new Vector3(1, 6, -2);
		Instantiate((Resources.Load("Sphere")) as GameObject, pos, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        System.Random random = new System.Random();
        int randomNumber = random.Next(-1, 3);
        Vector3 pos = new Vector3(randomNumber, 6, -2);/*
        other.gameObject.transform.position.x = randomNumber;
        other.gameObject.transform.position.y = 6;
        other.gameObject.transform.position.z = -2;*/
        Destroy(other.gameObject);
        //GameObject.ge
        //GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //other.transform.position = new Vector3(randomNumber, 6, -2);
        //other.transform.

        Instantiate((Resources.Load("Sphere")) as GameObject, pos, Quaternion.identity);
        //other.gameObject.transform.Translate(Vector3.left * 10);
       
    }
    
}
