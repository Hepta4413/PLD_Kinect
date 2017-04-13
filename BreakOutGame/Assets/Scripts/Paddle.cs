using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public float speed = 0.7f;

    private Vector3 position = new Vector3(0, -9.5f, 0);

	// Update is called once per frame
	void Update () {
        float xPos = transform.position.x + (Input.GetAxis("Horizontal") * speed);
        position = new Vector3(Mathf.Clamp(xPos, -6.1f, 6.1f), -11f, 0);
        transform.position = position;
	}
}
