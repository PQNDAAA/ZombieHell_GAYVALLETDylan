using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float spawnRate = 1.0f;
    void Start()
    {
        StartCoroutine(spawnObstacles());
    }

    IEnumerator spawnObstacles()
    {
        Instantiate(prefabToSpawn,this.transform.position,Quaternion.identity);

        yield return new WaitForSeconds(spawnRate);

        StartCoroutine(spawnObstacles());
    }

    
}
