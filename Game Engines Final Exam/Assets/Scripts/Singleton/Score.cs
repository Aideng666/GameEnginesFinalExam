using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    // Score Attributes
    private float score = 0;
    private TextMeshProUGUI scoreText;
    private int scorePerDuck = 1000;

    // Singleton
    public static Score Instance { get; private set; }

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        Instance = this;
    }

    public void AddScore(int value)
    {
        score += value;
        scoreText.text = "Score: " + score.ToString();
    }

    public void SetScorePerDuck(int score)
    {
        scorePerDuck = score;
    }

    public int GetScorePerDuck()
    {
        return scorePerDuck;
    }
}
