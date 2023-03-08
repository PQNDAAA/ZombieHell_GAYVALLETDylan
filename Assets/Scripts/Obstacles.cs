using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public float speed = 1.0f;
    public Vector3 direction;
    public GameObject spawner;

    void Start()
    {
        direction = Vector3.forward;
    }

    void FixedUpdate()
    {
        this.transform.position += direction * speed;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Pool")
        {
            gameObject.SetActive(false);
        }
    }

}
