using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "CreateEnemy")]
public class SO_Enemy : ScriptableObject
{
    public int defaultHealth;
    public int damage;
    public int health;
    public float speed;
    public Vector3 direction;
    public string enemyName;
}
