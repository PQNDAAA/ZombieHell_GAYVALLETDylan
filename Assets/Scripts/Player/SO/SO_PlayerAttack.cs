using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "PlayerAttack")]
public class SO_PlayerAttack : ScriptableObject
{
    public void Attack(GameObject target, int damage, EnemyManager monsterTarget)
    {
        if (target == null)
        {
            return;
        }
        else
        {
            monsterTarget.TakeDamage(damage);
        }
    }
}
