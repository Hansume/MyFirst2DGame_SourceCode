using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Angel_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    public GameObject[] waypoints;
    public GameObject fireball;
    public GameObject player;
    public int currentHealth = 200;
    public AudioSource teleportSound;
    public AudioSource fireballSound;
    public AudioSource getHitSound;
    private int index = 1;
    private float timer = 0f;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 2f && anim.GetBool("isDead")!= true)
        {
            anim.SetTrigger("isAttacking");
            fireballSound.Play();
            Instantiate(fireball, new Vector3(player.transform.position.x, 6, 0), transform.rotation);
            timer = 0f;
        }
        IsDead();
    }
    public void teleport()
    {
        teleportSound.Play();
        if (index >= waypoints.Length)
        {
            index = 0;
        }
        Debug.Log(index);
        if (transform.position != waypoints[index].transform.position)
        {
            transform.position = waypoints[index].transform.position;
            index++;
        }
        else
        {
            index++;
        }
    }
    public void takeDamage(int damage)
    {
        getHitSound.Play();
        currentHealth -= damage;
        anim.SetTrigger("disapear");
    }
    private void IsDead()
    {
        if (currentHealth <= 0)
        {
            anim.SetBool("isDead", true);
            Invoke("loadNext", 5f);
        }
    }
    private void loadNext()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
