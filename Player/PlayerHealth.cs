using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private int maxHealth = 100;
    public int currentHealth = 100;
    private Animator animator;
    private Rigidbody2D rigidBody;
    public AudioSource getHitSound;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void takeDamage(int damage)
    {
        animator.SetTrigger("isHurt");
        
        currentHealth -= damage;
        getHitSound.Play();
    }
    public void Die()
    {
        rigidBody.bodyType = RigidbodyType2D.Static;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<PlayerController>().enabled = false;
        animator.SetBool("isDead", true);
        Invoke("loadNext", 2f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fireball"))
        {
            takeDamage(30);
        }
    }
    private void loadNext()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
