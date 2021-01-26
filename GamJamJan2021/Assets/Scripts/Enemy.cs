using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
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
