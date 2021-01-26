using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHealth = 1;
    public int enemyAttack = 1;
    private Animator animator;
   


    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        Attack();
    }

    // Update is called once per frame
    void Update()
    {
        //if (!animator.gett("DiyingT"))
        //{
        //    //destruimos al monstruo al acabar la animacion
        //    Destroy(this);
        //}
    }

    private void Attack()
    {
        animator.SetBool("DiyingT", true);
    }

    public void EndEnemy()
    {
        Destroy(gameObject);
    }
}
