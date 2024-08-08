using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacking : MonoBehaviour
{
    public AudioSource attack2Sfx;
    public AudioSource attack3Sfx;
    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayer;
    public LayerMask bossLayer;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("Attack2");
            attack2Sfx.Play();
            Attack();
            AttackBoss();
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            animator.SetTrigger("Attack3");
            attack3Sfx.Play();
            Attack();
            AttackBoss();
        }
    }
    private void Attack()
    {
        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        foreach (Collider2D enemy in hitEnemy)
        {
            enemy.GetComponent<MonsterHealth>().takeDamage(20);
        }
    }
    private void AttackBoss()
    {
        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, bossLayer);
        foreach (Collider2D enemy in hitEnemy)
        { 
            enemy.GetComponent<Angel_Controller>().takeDamage(10);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
