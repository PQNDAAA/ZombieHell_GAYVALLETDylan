using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public float score = 0;
    public float multiplier = 1;

    
    private GameManager gameManager;
    private TMP_Text scoreText;
    void Start()
    {
        gameManager = GetComponent<GameManager>();
        scoreText = GameObject.Find("Score").GetComponent<TMP_Text>();
    }

    void Update()
    {
        //Check if the game is finished to stop the score
        if (gameManager.gameIsFinished == false)
        {
            score += 0.01f * multiplier;

            scoreText.text = Mathf.Round(score).ToString();
        }
    }

    //Different Functions to use the score
    public void IncreaseMultiplier(float value)
    {
        multiplier += value;
    }
    public float AddScore(float value)
    {
        return score += value;
    }
    public float RemoveScore(float value)
    {
        return score -= value;
    }
}
