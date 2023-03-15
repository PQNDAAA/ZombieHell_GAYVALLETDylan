using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowProjectile : MonoBehaviour
{
    public GameObject projectile;   
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectile,new Vector3(this.gameObject.transform.position.x,1.5f,this.gameObject.transform.position.z),Quaternion.identity);
        }
    }
}
