using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGeneration : MonoBehaviour
{
    //Various gameobject to appear
    public GameObject roadsPrefabToSpawn;
    public GameObject spawnersPrefabToSpawn;
    public GameObject playerPrefabToSpawn;

    //The space between two roads for the player movement
    public int spaceX = 5;

    private int spawnLocationX = 0;

    void Start()
    {
        Generate(roadsPrefabToSpawn, 3, spawnLocationX, 0, 0,Quaternion.identity);
        Generate(spawnersPrefabToSpawn, 3, spawnLocationX,0.5f,-roadsPrefabToSpawn.transform.localScale.z/2 + 1, Quaternion.identity);
        Generate(playerPrefabToSpawn, 1, 0, 0.5f, (roadsPrefabToSpawn.transform.localScale.z / 2) - 1, playerPrefabToSpawn.transform.rotation);
    }
    private void Generate(GameObject prefabToSpawn,int number,float x,float y, float z,Quaternion rotation)
    {
        x = 0;

        for (int i = 0; i < number; i++)
        {
            Instantiate(prefabToSpawn,new Vector3(x, y, z) , rotation);
            x += spaceX;
        }
    }
}
