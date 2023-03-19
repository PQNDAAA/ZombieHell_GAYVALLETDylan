using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ThrowProjectile : MonoBehaviour
{
    public Timer timer;

    public GameObject projectile;

    public bool canThrowProjectile = true;

    //ScriptableObject
    [SerializeField]
    private SO_Projectile m_Projectile;

    void Start()
    {
        timer = GameObject.Find("Timer").GetComponent<Timer>();
    }

    void Update()
    {
        //Throw projectile with a cooldown each time
        //If the player will try to throw a projectile if the bool is false then nothing will happen
        if (canThrowProjectile && Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectile,new Vector3(this.gameObject.transform.position.x,1.5f,this.gameObject.transform.position.z),projectile.transform.rotation);
            StartCoroutine(Cooldown());
        }
    }
    //In this function, the cooldown and the timer will launch each time 
    IEnumerator Cooldown()
    {
        canThrowProjectile = false;
        timer.StartTimer(m_Projectile.projectileCooldown);
        yield return new WaitForSeconds(m_Projectile.projectileCooldown);
        canThrowProjectile = true;
    }
}
