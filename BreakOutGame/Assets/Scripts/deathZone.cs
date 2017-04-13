using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathZone : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.loseLife();
    }
}
