using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float runningSpeed;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private PlayerHealth health;
    public Transform attackPoint;
    public LayerMask playerLayer;
    public float attackRange;

    public bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        health = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        AttackAnimation();
    }
    private void Movement()
    {
        if (!isDead)
        {
            if (transform.position.x >= player.position.x)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
            transform.position = Vector2.MoveTowards(transform.position, player.position, runningSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y);
        }
    }
    private void AttackAnimation()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
        foreach (Collider2D player in hitPlayer)
        {
            animator.SetTrigger("isAttack");
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    public void DealDamage()
    {
        health.takeDamage(10);
    }
}
