using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        //if (Input.GetButtonDown("Fire1") && inMovement == false)
        if (KinectData.teteY != -10000 && KinectData.mainDY != -10000 && KinectData.mainDY < KinectData.teteY && inMovement == false)
        {
            transform.parent = null;
            inMovement = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(initialVelocity, initialVelocity, 0));
            Paddle.mainJoueuse = MainPrincipale.Droite;
            GameManager.instance.PlayingHand.text = "Main directrice : Droite";

        }
        else if (KinectData.teteY != -10000 && KinectData.mainGY != -10000 && KinectData.mainGY < KinectData.teteY && inMovement == false)
        {
            transform.parent = null;
            inMovement = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(initialVelocity, initialVelocity, 0));
            Paddle.mainJoueuse = MainPrincipale.Gauche;
            GameManager.instance.PlayingHand.text = "Main directrice : Gauche";
        }

    }
}
