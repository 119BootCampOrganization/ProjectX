using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMove : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D arb;
    public int damage = 40;
    
    void Start()
    {
        arb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
    
         Debug.Log(hitInfo.name);
         Enemy enemy = hitInfo.GetComponent<Enemy>();
         if (enemy != null)
        {
           enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }

}
