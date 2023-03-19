using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject difficultySettingsMenu;

    //To launch the difficulty settings menu
    public void DifficultySettingsMenu()
    {
        gameObject.SetActive(false);
        difficultySettingsMenu.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
