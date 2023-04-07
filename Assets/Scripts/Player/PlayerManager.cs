using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerManager : MonoBehaviour
{
    GameManager gameManager;

    //ScriptableObject
    [SerializeField]
    private SO_Player player;

    void Start()
    {       
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //Search the health text on the scene
        player.healthText = GameObject.Find("PlayerHealth").GetComponent<TMP_Text>();
    }

    void Update()
    {
        //Transform the player into another form with one different power 
        //We check if the form index of the player to change the player 
        if (Input.GetKeyDown(KeyCode.Alpha1) && player.indexForms != 1)
        {
            GenerationPlayerForms(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && player.indexForms != 2)
        {
            GenerationPlayerForms(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && player.indexForms != 3)
        {
            GenerationPlayerForms(2);
        }

        //Set the player health on the scene
        player.healthText.text = "Health: " + player.health.ToString();
    }

    //Function to spawn the new form of the player 
    private void GenerationPlayerForms(int formIndex)
    {
        Instantiate(gameManager.playerPrefabForms[formIndex], new Vector3(this.gameObject.transform.position.x
            , this.gameObject.transform.position.y, this.gameObject.transform.position.z),PlayerRotation());
        Destroy(gameObject);
    }

    //Get the player rotation
    public Quaternion PlayerRotation()
    {
        return this.gameObject.transform.rotation;
    }

    public void TakeDamage(int damage)
    {
        player.health -= damage;

        if (player.health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDisable()
    {
        player.ResetValues();
    }
}
