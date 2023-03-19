using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spawner", menuName = "Spawner/CreateSpawner")]
public class SO_Spawner : ScriptableObject
{
    public GameObject[] enemyPrefabToSpawn;

    [Range(1.0f, 10.0f)]
    public float spawnRate = 1.0f;
    public enum enemyChanceToSpawn { verylow = 15, low = 35, medium = 55, high = 75, perfect = 100 };
    public enemyChanceToSpawn e_EnemyChanceToSpawn;
}
