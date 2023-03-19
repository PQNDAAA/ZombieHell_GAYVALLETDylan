using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private SO_Projectile m_Projectile;
    [SerializeField]
    private SO_MoveTo m_MoveTo;
    [SerializeField]
    private SO_PlayerAttack m_PlayerAttack;
    void Start()
    {
        m_Projectile.direction = -Vector3.forward;
    }

    void FixedUpdate()
    {
            m_MoveTo.MoveTo(this.gameObject, m_Projectile.direction, m_Projectile.speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            EnemyManager enemyTarget = collision.gameObject.GetComponent<EnemyManager>();

            m_PlayerAttack.Attack(gameObject, m_Projectile.damage, enemyTarget);
            Destroy(this.gameObject);
            
        }
    }
}
