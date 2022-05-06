using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // variables
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI youWinText;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        // a statement setting the score to zero initailly
        // and a reference to the below function which updates the score
        score = 0;
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // a function which updates the score when a collectable
    // is collected
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    // a function which makes the game over text appear when
    // the player loses the game
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
    }
    // a function which makes the winning text appear when
    // the player reaches the end goal
    public void YouWin()
    {
        youWinText.gameObject.SetActive(true);
    }
}
