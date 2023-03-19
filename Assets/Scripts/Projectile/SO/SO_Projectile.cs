using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Projectile", menuName = "CreateProjectile")]
public class SO_Projectile : ScriptableObject
{
    public float speed;
    public Vector3 direction;
    [Range(1.0f, 10.0f)]
    public float projectileCooldown;
    public int damage;
}
