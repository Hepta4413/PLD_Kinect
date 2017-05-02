using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {
    int i = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(i%500 < 250)
            transform.Translate(Vector3.left * Time.deltaTime, Space.World);
        else
            transform.Translate(Vector3.right * Time.deltaTime, Space.World);

        i++;
    }
}
