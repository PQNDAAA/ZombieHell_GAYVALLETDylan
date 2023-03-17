using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private SO_Enemy m_Enemy;
    [SerializeField]
    private SO_MoveTo m_MoveTo;
    [SerializeField]
    private SO_EnemyAttack m_EnemyAttack;

    void Start()
    {
        SO_Enemy so = ScriptableObject.CreateInstance<SO_Enemy>();
        so.health = Random.Range(450, 1000);
        so.defaultHealth = so.health;
        so.damage = 100;
        so.speed = 0.02f;
        so.enemyName = "Enemy";

        m_Enemy = so;

        m_Enemy.direction = Vector3.forward;

        print("Health: " + m_Enemy.health + " Name: " + m_Enemy.enemyName + " Damage: " + m_Enemy.damage + " Speed: " + m_Enemy.speed);
    }

    void FixedUpdate()
    {
      m_MoveTo.MoveTo(this.gameObject, m_Enemy.direction, m_Enemy.speed);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Pool")
        {
            gameObject.SetActive(false);
        }
        if(collision.gameObject.tag == "Player")
        {
            PlayerManager playerTarget = collision.gameObject.GetComponent<PlayerManager>();
            m_EnemyAttack.Attack(gameObject, m_Enemy.damage, playerTarget);
        }
    }

    public void TakeDamage(int damage)
    {
        m_Enemy.health -= damage;
        print(m_Enemy.health);  

        if (m_Enemy.health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
