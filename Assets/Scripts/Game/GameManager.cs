using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] playerPrefabForms;
    public GameObject deathMenu;

    private AudioSource[] allAudioSources;

    public bool gameIsFinished = false;

    private void Start()
    {
        //Get all objects which have the type AudioSource
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
    }

    private void Update()
    {
        //Check base & player to stop the game
        CheckGameObject(FindPlayer());
        CheckGameObject(FindBase());
    }

    //Checking function
    public bool CheckGameObject(GameObject go)
    {
        if(go == null)
        {
            deathMenu.SetActive(true);
            Time.timeScale = 0;
            return gameIsFinished = true;
        }
        return gameIsFinished = false;
    }
    public GameObject FindPlayer()
    {
        return GameObject.FindGameObjectWithTag("Player");
    }

    //Function to stop all AudioSource
    public void StopAllAudio()
    {
        foreach(AudioSource source in allAudioSources)
        {
            source.Stop();  
        }
    }
    public GameObject FindBase()
    {
        return GameObject.FindGameObjectWithTag("Base");
    }
}
