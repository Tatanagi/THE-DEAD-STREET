using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    private float playerSpeed;
    public Rigidbody2D rigidBody;
    private Vector2 movementInput;
    public Animator anim;
    private bool isGrounded;
    private bool hasPressedJump = false;
    public AudioSource jumpSound;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerSpeed = moveSpeed;
    }

    void Update()
    {
        movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        anim.SetFloat("X", movementInput.x);
        anim.SetFloat("Y", movementInput.y);
        anim.SetFloat("Speed", movementInput.sqrMagnitude);

        // Check for jump input and if the player is grounded
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            hasPressedJump = true;
        }

        if (movementInput.x < 0f)
        {
            transform.localScale = new Vector2(-10, 10);
        }

        if (movementInput.x > 0f)
        {
            transform.localScale = new Vector2(10, 10);
        }
    }

    private void FixedUpdate()
    {
        // Perform grounded check
        GroundedCheck();

        // Player movement
        rigidBody.velocity = new Vector2(movementInput.x * playerSpeed, rigidBody.velocity.y);

        // Check and perform jump
        if (hasPressedJump)
        {
            Jump();
            jumpSound.Play();
            hasPressedJump = false; 
        }
    }

    void Jump()
    {
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
    }

    void GroundedCheck()
    {
       
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
    }
}