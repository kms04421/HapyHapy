using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;
    public Text scoreText;
    public Text highScoreText;

    public int score = 0;
    private int highScore = 0;
    private bool isGameover;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        isGameover = false;
        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = highScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        scoreText.text = score.ToString();
        if (isGameover == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {

                SceneManager.LoadScene("EnemyScene");
            }
        }

    }


    public void AddScore(int scoreIncrement)
    {
        score += scoreIncrement;
    }
    public void EndGame()
    {
        isGameover = true;
        gameoverText.SetActive(true);


        highScore = PlayerPrefs.GetInt("HighScore");
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            highScoreText.text = highScore.ToString();
        }

    }
}
