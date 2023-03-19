using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private SO_Enemy m_Enemy;

    public float health;

    void Start()
    {
        print("Health: " + m_Enemy.health + " Name: " + m_Enemy.enemyName + " Damage: " + m_Enemy.damage + " Speed: " + m_Enemy.speed);
    }
    private void OnEnable()
    {
        m_Enemy.ResetValues();
        health = m_Enemy.health;
    }

}
