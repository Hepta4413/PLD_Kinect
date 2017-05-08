using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LockTimer : MonoBehaviour {
    private float lifetime;
    public float lifetimeLimit = 5f;

	// Use this for initialization
	void Start () {
        lifetime = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        lifetime += Time.deltaTime;
        if(lifetime >= lifetimeLimit)
        {
            System.Random random = new System.Random();
            int randomNumber = random.Next(-100, 100);
            float randomNumberFloat = (float)randomNumber * 3 / 100;
            Vector3 pos = new Vector3(randomNumberFloat, 6, -0.05f);
            Destroy(this.gameObject);

            Instantiate((Resources.Load("Botella")) as GameObject, pos, Quaternion.identity);
        }
    }
}
