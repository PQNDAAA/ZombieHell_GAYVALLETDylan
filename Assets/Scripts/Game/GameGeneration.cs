using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGeneration : MonoBehaviour
{
    public GameObject roadsPrefabToSpawn;
    public GameObject spawnersPrefabToSpawn;
    public GameObject playerPrefabToSpawn;

    public int spaceX = 5;

    private int spawnLocationX = 0;

    void Start()
    {
        Generate(roadsPrefabToSpawn, 3, spawnLocationX, 0, 0);
        Generate(spawnersPrefabToSpawn, 3, spawnLocationX,1,-roadsPrefabToSpawn.transform.localScale.z/2);
        Generate(playerPrefabToSpawn, 1, 0, 1, (roadsPrefabToSpawn.transform.localScale.z / 2) - 1);
    }
    private void Generate(GameObject prefabToSpawn,int number,float x,float y, float z)
    {
        x = 0;

        for (int i = 0; i < number; i++)
        {
            Instantiate(prefabToSpawn,new Vector3(x, y, z) , Quaternion.identity);
            x += spaceX;
        }
    }
}
