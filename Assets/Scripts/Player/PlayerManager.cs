using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    GameManager gameManager;

    [SerializeField]
    private SO_Player player;

    void Start()
    {       
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
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
    }

    private void GenerationPlayerForms(int formIndex)
    {
        Instantiate(gameManager.playerPrefabForms[formIndex], new Vector3(this.gameObject.transform.position.x
            , this.gameObject.transform.position.y, this.gameObject.transform.position.z),PlayerRotation());
        Destroy(gameObject);
    }

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
            Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
        }
            print(player.health);
    }

    private void OnDisable()
    {
        player.ResetValues();
    }
}
