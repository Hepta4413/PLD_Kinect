using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float initialVelocity = 1f;

    private Rigidbody rb;
    private bool inMovement = false;

	// Use this for initialization
	void Awake () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetButtonDown("Fire1") && inMovement == false)
        {
            transform.parent = null;
            inMovement = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(initialVelocity, initialVelocity, 0));

        }
	}
}
