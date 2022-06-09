using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkAttack : MonoBehaviour
{
    public Animator animator;
    public Transform FirePoint;
    public GameObject ArrowPrefabR;
    //public GameObject ArrowPrefabL;
    //public GameObject ArrowPrefabU;
    //public GameObject ArrowPrefabD;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
        Instantiate(ArrowPrefabR, FirePoint.position, FirePoint.rotation);
    }


}
