using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DeadMenu : MonoBehaviour
{
    private TMP_Text scoreText;
    private ScoreManager scoreManager;
    private GameManager gameManager;

    private void Start()
    {
        scoreText = GameObject.Find("FinalScore").GetComponent<TMP_Text>();
        scoreManager = GameObject.Find("GameManager").GetComponent<ScoreManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        scoreText.text = "Score: " + Mathf.Round(scoreManager.score).ToString();
        gameManager.StopAllAudio();
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
        //Quit game 
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
