using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "EnemyAttack")]
public class SO_EnemyAttack : ScriptableObject
{
    public void Attack(GameObject target, int damage, PlayerManager playerTarget, BaseManager baseTarget)
    {
        if (target == null)
        {
            return;
        }
        else 
        {
            if (baseTarget == null)
            {
                playerTarget.TakeDamage(damage);
            } else
            {
                baseTarget.TakeDamage(damage);
            }
        }
    }
}
