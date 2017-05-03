using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int lives = 3;
    public int bricks = 20;
    public float resetDelay = 1f;
    public Text livesText;
    public GameObject gameOver;
    public GameObject victory;
    public GameObject bricksPrefab;
    public GameObject paddle;
    public GameObject deathParticles;
    public Text PlayingHand;
    public static GameManager instance = null;

    private GameObject clonePaddle;

    // Use this for initialization
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        Setup();
    }

    public void Setup()
    {
        clonePaddle = Instantiate(paddle, paddle.transform.position, Quaternion.identity) as GameObject;
        Instantiate(bricksPrefab, transform.position, Quaternion.identity);
    }

    void CheckGameOver()
    {
        if (bricks < 1)
        {
            victory.SetActive(true);
            Time.timeScale = 0.25f;
            Invoke("GameReset", resetDelay);
        }

        if (lives < 1)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0.25f;
            Invoke("GameReset", resetDelay);
        }
    }

    void GameReset()
    {

        Time.timeScale = 1f;
        //Application.LoadLevel(Application.loadedLevel);
        SceneManager.LoadSceneAsync("mainScene");
        Paddle.mainJoueuse = MainPrincipale.Droite;
        /*if (Paddle.mainJoueuse == MainPrincipale.Gauche)
        {
            PlayingHand.text = "Main directrice : Gauche";
        }
        else
        {
            PlayingHand.text = "Main directrice : Droite";
        }*/

    }

    public void loseLife()
    {
        lives--;
        livesText.text = "Vies : " + lives;
        Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
        Destroy(clonePaddle);
        Invoke("SetupPaddle", resetDelay);
        CheckGameOver();
    }

    void SetupPaddle()
    {
        clonePaddle = Instantiate(paddle, new Vector3(0, -9.5f, 0), Quaternion.identity) as GameObject;
    }

    public void DestroyBrick()
    {
        bricks--;
        CheckGameOver();
    }


}

