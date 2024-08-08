using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterHealth : MonoBehaviour
{
    private int currentHealth = 100;
    private Animator animator;
    public AudioSource getHitSound;
    public AudioSource deadSound;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
            deadSound.Play();
        }
    }

    public void takeDamage(int damage)
    {
        animator.SetTrigger("isHurt");
        currentHealth -= damage;
        getHitSound.Play();
    }
    private void Die()
    {
        animator.SetBool("isDead",true);
        GetComponent<Collider2D>().enabled = false;
        GetComponent<MonsterController>().isDead = true;
        Invoke("loadNextScene", 5f);
    }
    private void loadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
