using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{

    public int lives;
    public int score;
    public Text livesText;
    public Text scoreText;
    public bool gameOver;
    public GameObject gameOverPanel;
    public int numberOfBricks;
    public GameObject WinningPanel;
 

    // Start is called before the first frame update
    void Start()
    {
        livesText.text = "Lives: " + lives;
        scoreText.text = "Score: " + score;
        numberOfBricks = GameObject.FindGameObjectsWithTag("brick").Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLives(int changeInLives)
    {
        lives += changeInLives;

        //check for no lives and trigger left the end of the game
        if (lives <= 0)
        {
            lives = 0;
            GameOver();
        }

        livesText.text = "Lives:" + lives;
    }

    public void UpdateScore(int points)
    {
        score += points;

        scoreText.text = "Score: " + score;
    }

    public void UpdateNumberOfBricks()
    {
        numberOfBricks--;
        if(numberOfBricks <= 0)
        {
            GameOver();
        }
    }

    public void LoadNextLevel(int x)
    {
        SceneManager.LoadScene("level 2");
    }

     

    void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
    }

    
    public void PlayAgain()
    {
        SceneManager.LoadScene("BrickBreak");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }

}
