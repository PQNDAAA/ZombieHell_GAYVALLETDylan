using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private SO_Enemy m_Enemy;
    [SerializeField]
    private SO_MoveTo m_MoveTo;

    void Start()
    {
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
    }

/*    public void CreateEnemy(int health,int damage,float speed,Vector3 direction, string name)
    {

        SO_Enemy enemy = ScriptableObject.CreateInstance<SO_Enemy>();
        enemy.health = health;
        enemy.defaultHealth = enemy.health;
        enemy.enemyName = name;
        enemy.damage = damage;
        enemy.speed = speed;
        enemy.direction = direction;

        this.name = enemy.enemyName;

        m_Enemy = enemy;

    }*/

}
