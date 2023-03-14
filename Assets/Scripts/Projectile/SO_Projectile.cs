using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Projectile", menuName = "CreateProjectile")]
public class SO_Projectile : ScriptableObject
{
    public float speed;
    public Vector3 direction;
}
