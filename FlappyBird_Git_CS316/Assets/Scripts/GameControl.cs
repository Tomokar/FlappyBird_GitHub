using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;

    [SerializeField] GameObject gameOverText;
    [SerializeField] HeartBar healthBar;
    [SerializeField] Bord playControl;

    public bool gameOver = false;

    private int score = 0;

    public Text scoreText;

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
    }

    void Update()
    {
        if (gameOver == true && Input.GetButtonDown("Flap"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void BirdScored()
    {
        if(gameOver)
        {
            return;
        }
        
        score++;
        scoreText.text = "Score: " + score.ToString();
    }

    public void BirdDied()
    {
        healthBar.health = 0;
        playControl.Lives = 0;
        gameOverText.SetActive(true);
        gameOver = true;
    }
}
