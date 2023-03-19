using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private SO_Enemy m_Enemy;

    public int health;

    void Start()
    {
        //Debug test to know the enemy stats 
       // print("Health: " + m_Enemy.health + " Name: " + m_Enemy.enemyName + " Damage: " + m_Enemy.damage + " Speed: " + m_Enemy.speed);
    }

    //To set the health 
    private void OnEnable()
    {
        health = m_Enemy.health;
    }

}
