using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private SO_Enemy m_Enemy;

    void Start()
    {
        CreateEnemy(Random.Range(10000, 105200),10,0.1f,Vector3.forward,"Monster");
    }

    void FixedUpdate()
    {
        this.transform.position += m_Enemy.direction * m_Enemy.speed;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Pool")
        {
            gameObject.SetActive(false);
        }
    }

    public void CreateEnemy(int health,int damage,float speed,Vector3 direction, string name)
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

        print("Health: " + enemy.health + " Name: " + enemy.enemyName + " Damage: " + enemy.damage + " Speed: " + enemy.speed);
    }

}
