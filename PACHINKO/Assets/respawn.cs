using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < 0.5)
        {
            float newy = 5;
            transform.position = new Vector3(transform.position.x,newy, transform.position.z);
        }
	}
}
