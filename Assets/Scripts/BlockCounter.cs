using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlockCounter : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    private int score;

    private void Start()
    {
        score = 0;
        UpdateScoreText();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Block"))
        {
            // Increment the score when a block with the tag "Block" enters the collider
            score += 1;

            // Update the Score Text
            UpdateScoreText();
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Piezas: " + score.ToString();
    }
    public void SaveAndDisplayHighScore()
    {
        // Save the high score to PlayerPrefs
        PlayerPrefs.SetInt("HighScore", score);
        PlayerPrefs.Save();

        // Update the high score
        UpdateHighScore();
    }
    private void UpdateHighScore()
    {
        // Display the high score from PlayerPrefs
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
    }

}