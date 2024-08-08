using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float hzInput;
    bool check;
    private enum Movementstate { idling, running, jumping, falling }
    
    [SerializeField] private float runningSpeed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private LayerMask jumpable;
    [SerializeField] private float LowerRange;
    [SerializeField] private float UpperRange;

    [SerializeField] private AudioSource jumpingAudio;
    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private BoxCollider2D boxcollider;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        boxcollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    //Di chuyen
    private void PlayerMovement()
    {
        hzInput = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * runningSpeed * hzInput * Time.deltaTime);
        Movementstate movementstate;
        //chay
        if (hzInput < 0)
        {
            check = true;
            spriteRenderer.flipX = check;
            movementstate = Movementstate.running;
        }
        else if (hzInput > 0)
        {
            check = false;
            spriteRenderer.flipX = check;
            movementstate = Movementstate.running;
        }
        else
        {
            spriteRenderer.flipX = check;
            movementstate = Movementstate.idling;
        }
        //nhay
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            jumpingAudio.Play();
            rigidBody.velocity = new Vector2 (rigidBody.velocity.x, jumpHeight);
        }
        if (rigidBody.velocity.y > .1f)
        {
            movementstate = Movementstate.jumping;
        }
        else if (rigidBody.velocity.y < -.1f)
        {
            movementstate = Movementstate.falling;
        }
        animator.SetInteger ("state",(int)movementstate);
        //keep in range
        if (transform.position.x <= LowerRange)
        {
            transform.position = new Vector3 (LowerRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x >= UpperRange)
        {
            transform.position = new Vector3(UpperRange, transform.position.y, transform.position.z);
        }
    }
    private bool isGrounded()
    {
        return Physics2D.BoxCast(boxcollider.bounds.center, boxcollider.bounds.size, 0f, Vector2.down, .1f, jumpable);
    }
    
}
