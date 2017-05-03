using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class DestroyOnContact : MonoBehaviour {

    public Text lifesText;
    public Text scoreText;
    public GameObject gameOver;
    public float resetDelay = 1f;
    public int lifes = 10;

    // Use this for initialization
    void Start () {
        UpdateLifes();
        System.Random random = new System.Random();
        int randomNumber = random.Next(-100, 100);
        float randomNumberFloat = (float)randomNumber * 3 / 100;
        Vector3 pos = new Vector3(randomNumberFloat, 6, -0.05f);
		Instantiate((Resources.Load("Botella")) as GameObject, pos, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RemoveLife(int newScoreValue)
    {
        lifes -= newScoreValue;
        UpdateLifes();
    }

    void UpdateLifes()
    {
        lifesText.text = "Vies : " + lifes;
    }

    void OnTriggerEnter(Collider other)
    {
        System.Random random = new System.Random();
        int randomNumber = random.Next(-100, 100);
        float randomNumberFloat = (float)randomNumber * 3 / 100;
        Vector3 pos = new Vector3(randomNumberFloat, 6, -0.05f);
        /*
        other.gameObject.transform.position.x = randomNumber;
        other.gameObject.transform.position.y = 6;
        other.gameObject.transform.position.z = -2;*/
        Destroy(other.gameObject);
        RemoveLife(1);

        if(lifes == 0)
        {
            scoreText.text = "Score : 0";
            gameOver.SetActive(true);
            Time.timeScale = 0.25f;
            Invoke("GameReset", resetDelay);
        }
        else
        {
            Instantiate((Resources.Load("Botella")) as GameObject, pos, Quaternion.identity);
        }
    }

    void GameReset()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync("pachinko1");
    }


}
