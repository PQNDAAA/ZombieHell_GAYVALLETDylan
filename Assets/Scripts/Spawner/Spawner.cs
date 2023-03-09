using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemyPrefabToSpawn;

    [Range(1.0f,10.0f)]
    public float spawnRate = 1.0f;
    public enum enemyChanceToSpawn { verylow = 15, low = 35, medium = 55, high = 75,perfect = 100};
     public enemyChanceToSpawn e_EnemyChanceToSpawn;

    void Start()
    {
        StartCoroutine(spawnEnemies());
    }

    IEnumerator spawnEnemies()
    {
        if (EnemyCanSpawn())
        {
            int indexEnemyPrefab = Random.Range(0, enemyPrefabToSpawn.Length);

            Instantiate(enemyPrefabToSpawn[indexEnemyPrefab], this.transform.position, Quaternion.identity);
        }

        yield return new WaitForSeconds(spawnRate);

        StartCoroutine(spawnEnemies());
    }

    private bool EnemyCanSpawn()
    {
        int randomInt = Random.Range(0, 100);

        int enemyChanceSelected = (int)System.Enum.Parse(e_EnemyChanceToSpawn.GetType(), e_EnemyChanceToSpawn.ToString());

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
