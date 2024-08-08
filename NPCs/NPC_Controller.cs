using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    SpriteRenderer spriteRenderer;

    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private float RunningSpeed;
    private int currentWaypointIndex = 0;

    public bool checkMoving = true;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator.SetBool("isWalking", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (checkMoving)
        {
            Movement();
        }
    }

    public void Movement()
    {
        if (Vector2.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) < 0.1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
            if (currentWaypointIndex == 0)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, RunningSpeed * Time.deltaTime);
    }
}
