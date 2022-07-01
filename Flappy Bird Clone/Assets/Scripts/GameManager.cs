using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public Text highScoreText;
    public GameObject GameOverScreen;
    public GameObject jumpText;
    public GameObject scoreField;
    public Text finalScoreText;
    public Text finalHighScoreText;
    private int score;
    private bool isDone = false;


    private void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();
    }

    public void Start()
    {
        //To store the highscore
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && !isDone)
        {
            Play();
            isDone = true;
            jumpText.SetActive(false);
        }
    }

    //to play the game
    public void Play()
    {
        
        
            score = 0;
            scoreText.text = score.ToString();
            scoreField.SetActive(true);
            GameOverScreen.SetActive(false);

            Time.timeScale = 1f;
            player.enabled = true;


        // destroy the pipes
            Pipes[] pipes = FindObjectsOfType<Pipes>();

            for (int i = 0; i < pipes.Length; i++)
            {
                Destroy(pipes[i].gameObject);
            }
        
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }
    
    public void IncreaseScore()
    {
        //Scoring
        score++;
        scoreText.text = score.ToString();

        //Set HighScore
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = score.ToString();
        }
    }

    public void GameOver()
    {
        finalScoreText.text = scoreText.text;
        finalHighScoreText.text = highScoreText.text;
        scoreField.SetActive(false);
        GameOverScreen.SetActive(true);
        Pause();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
