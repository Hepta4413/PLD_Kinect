using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WinOnContact : MonoBehaviour {

    public Text scoreText;
    public int score = 0;

	// Use this for initialization
	void Start () {
        UpdateScore();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score : " + score;
    }

    void OnTriggerEnter(Collider other)
    {
        System.Random random = new System.Random();
        int randomNumber = random.Next(-100, 100);
        float randomNumberFloat = (float) randomNumber*3 / 100;
        Vector3 pos = new Vector3(randomNumberFloat, 7.5f, -0.05f);
        Destroy(other.gameObject);

        AddScore(1);

        Instantiate((Resources.Load("Botella")) as GameObject, pos, Quaternion.identity);

    }
    void OnTriggerExit(Collider other)
    {
       

    }
}
