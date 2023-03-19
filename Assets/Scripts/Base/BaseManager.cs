using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BaseManager : MonoBehaviour
{
    //ScriptableObject
    [SerializeField]
    private SO_Base m_Base;

    //Additional Stats
    public int health;
    public float removeScore;

    void Start()
    {
        m_Base.healthText = GameObject.Find("BaseHealth").GetComponent<TMP_Text>();

        health = m_Base.health;
        removeScore = m_Base.removeScore;
    }

    void Update()
    {
        //Update the text
        m_Base.healthText.text = "Base Health: " + health.ToString();
    }

    //Take Damage
    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
