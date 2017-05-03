using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHazard : MonoBehaviour {

    private Vector3 rotation;
    public int angle;

	// Use this for initialization
	void Start () {
        rotation = new Vector3(0, 0, angle);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(rotation);
    }
}
