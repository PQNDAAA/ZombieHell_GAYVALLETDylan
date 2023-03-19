using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //ScriptableObject
    [SerializeField]
    private SO_Enemy m_Enemy;
    [SerializeField]
    private SO_MoveTo m_MoveTo;
    [SerializeField]
    private SO_EnemyAttack m_EnemyAttack;

    //Actions in bool's
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
        //Check if the enemy is dead to stop it 
        if (isDead == false)
        {
            m_MoveTo.MoveTo(this.gameObject, m_Enemy.direction, m_Enemy.speed);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        //If the enemy collide with Pool (Base) 
        //Enemy attacks the base 
        if (collision.gameObject.tag == "Pool")
        {
            isAttacking = true;
            BaseManager baseTarget = GameObject.Find("Base").GetComponent<BaseManager>();
            m_EnemyAttack.Attack(gameObject, m_Enemy.damage, null, baseTarget);

            scoreManager.RemoveScore(baseTarget.removeScore);

            isAttacking = false;
            gameObject.SetActive(false);
        }
        //If the enemy collide the player 
       // Attack anim is true and he attacks the player 
        if (collision.gameObject.tag == "Player")
        {
            isAttacking = true;
            animator.SetBool("attack", true);

            StartCoroutine(FalseAttack());

            PlayerManager playerTarget = collision.gameObject.GetComponent<PlayerManager>();
            m_EnemyAttack.Attack(gameObject, m_Enemy.damage, playerTarget, null);

            isAttacking = false;
        }
    }

    //Take Damage
    public void TakeDamage(int damage)
    {
        enemy.health -= damage;
        print(enemy.health);

        if (enemy.health <= 0)
        {
            //isDead true and the anim dead is activated 
            isDead = true;
            animator.SetBool("isDead", true);

            scoreManager.AddScore(m_Enemy.enemyScore);
            scoreManager.IncreaseMultiplier(0.01f);

            StartCoroutine(HideAfterDead()); 
        }
    }

    //To hide the target enemy
    IEnumerator HideAfterDead()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
        isDead = false;
    }

    //To stop the attack anim
    IEnumerator FalseAttack()
    {
        yield return new WaitForSeconds(1f);
        animator.SetBool("attack", false);
    }
}
