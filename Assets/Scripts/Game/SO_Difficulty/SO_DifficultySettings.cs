using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DifficultySettings", menuName = "DifficultySettings/CreateDifficultySettings")]
public class SO_DifficultySettings : ScriptableObject
{
    [Range(1.0f, 10.0f)]
    public float SpawnRateMonster = 1.0f;
    public SO_Spawner.enemyChanceToSpawn ChanceToSpawn;
    public float removeScoreBase;
    public int healthBase;

}
