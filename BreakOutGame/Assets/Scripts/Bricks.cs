using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour {

    public GameObject brickParticle;

	public void OnCollisionEnter (Collision other)
    {
        Instantiate(brickParticle, transform.position, Quaternion.identity);
        GameManager.instance.DestroyBrick();
        Destroy(gameObject);
    }
}
