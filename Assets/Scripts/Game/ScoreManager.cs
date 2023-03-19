using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public float score = 0;
    public float multiplier = 1;

    private TMP_Text scoreText;
    void Start()
    {
        scoreText = GameObject.Find("Score").GetComponent<TMP_Text>();
    }

    void Update()
    {
        score += 0.01f * multiplier;

        scoreText.text = Mathf.Round(score).ToString();
    }

    public void IncreaseMultiplier(float value)
    {
        multiplier += value;
    }
    public float AddScore(float value)
    {
        return score += value;
    }
}
