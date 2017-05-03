using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinOnContact : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        System.Random random = new System.Random();
        int randomNumber = random.Next(-1, 3);
        Vector3 pos = new Vector3(randomNumber, 6, -0.05f);
        Destroy(other.gameObject);

        Instantiate((Resources.Load("Botella")) as GameObject, pos, Quaternion.identity);

    }
    void OnTriggerExit(Collider other)
    {
       

    }
}
