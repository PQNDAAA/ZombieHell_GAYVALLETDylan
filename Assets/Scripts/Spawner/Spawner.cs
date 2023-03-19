using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private SO_Spawner m_Spawner;

    public Pool pool;

    void Start()
    {
        pool = GameObject.Find("GameManager").GetComponent<Pool>();

        //Spawn Enemies
        StartCoroutine(spawnEnemies());
    }

    IEnumerator spawnEnemies()
    {
        //Search if a enemy is inactive or not 
        GameObject availaibleObject = pool.GetAvailaibleObject();

        //Check if the enemy can spawn & availaible 
        if (EnemyCanSpawn() && availaibleObject != null)
        {
            availaibleObject.transform.position = this.transform.position;
            availaibleObject.transform.rotation = this.transform.rotation;
            availaibleObject.SetActive(true);
        }
        //To Repeat it according to the variable "spawn rate"  
        yield return new WaitForSeconds(m_Spawner.spawnRate);

        StartCoroutine(spawnEnemies());
    }

    //Function to know if the enemy can spawn or not  
    //We take the chance selected in the enum and the random number between 0 & 100
    //Then we compare 
    private bool EnemyCanSpawn()
    {
        int randomInt = Random.Range(0, 100);

        int enemyChanceSelected = (int)System.Enum.Parse(m_Spawner.e_EnemyChanceToSpawn.GetType(),m_Spawner.e_EnemyChanceToSpawn.ToString());

        if(randomInt < enemyChanceSelected)
        {
            return true;
        } 
        else
        {
            return false;
        }
       

    }

    
}
