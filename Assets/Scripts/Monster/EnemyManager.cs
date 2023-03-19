using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private SO_Enemy m_Enemy;
    [SerializeField]
    private SO_MoveTo m_MoveTo;
    [SerializeField]
    private SO_EnemyAttack m_EnemyAttack;

    public bool isDead = false;
    public bool isAttacking = false;

    Animator animator;
    ScoreManager scoreManager;
    Enemy enemy;
    
    void Start()
    {
        animator = GetComponent<Animator>();  
        scoreManager = GameObject.Find("GameManager").GetComponent<ScoreManager>();
        enemy = GetComponent<Enemy>();
    }
    void FixedUpdate()
    {
        if (isDead == false)
        {
            m_MoveTo.MoveTo(this.gameObject, m_Enemy.direction, m_Enemy.speed);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Pool")
        {
            gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Player")
        {
            isAttacking = true;
            animator.SetBool("attack", true);

            PlayerManager playerTarget = collision.gameObject.GetComponent<PlayerManager>();
            m_EnemyAttack.Attack(gameObject, m_Enemy.damage, playerTarget);
        }
    }

    public void TakeDamage(int damage)
    {
        enemy.health -= damage;
        print(enemy.health);

        if (enemy.health <= 0)
        {
            isDead = true;
            animator.SetBool("isDead", true);

            scoreManager.AddScore(100);
            scoreManager.IncreaseMultiplier(0.01f);

            StartCoroutine(DestroyAfterDead()); 
        }
    }

    IEnumerator DestroyAfterDead()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
