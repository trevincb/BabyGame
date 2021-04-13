using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float moveSpeed;
    public float jumpForce;
    public Transform ceilingCheck;
    public Transform groundCheck;
    public LayerMask groundObjects;
    public float checkRadius;
    public int maxJumpCount;

    private Rigidbody2D rb;
    private bool facingRight = true;
    private float moveDirection;
    private bool isJumping = false;
    private bool isGrounded;
    private int jumpCount;

    //Awake is called after all objects are initiated. Called in a random order.
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); //will look for a component on this GameObject (what the script is attached to) of type Rigidbody2D
    }
    
    //Start
    private void Start()
    {
        jumpCount = maxJumpCount;
    }
    // Update is called once per frame
    void Update()
    {
        //Get Inputs
        ProcessInputs();
        
        //Animate character when turning
        Animate();
    }

    //Better for handling Physics, can be called multiple times per update frame.
    private void FixedUpdate()
    {
        //Check if grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObjects);
        if(isGrounded)
        {
            jumpCount = maxJumpCount;
        }

        //Move character
        Move();
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y); 
        if(isJumping)
        {
            rb.AddForce(new Vector2(0f,jumpForce),ForceMode2D.Impulse);
            jumpCount--;
        }
        isJumping = false;
    }

    private void Animate()
    {
        if (moveDirection > 0 && !facingRight)
        {
            FlipCharacter();
        }
        else if (moveDirection < 0 && facingRight)
        {
            FlipCharacter();
        }
    }

    private void ProcessInputs()
    {
        moveDirection = Input.GetAxis("Horizontal"); //scale of -1 -> 1.
        if(Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            isJumping = true;
        }
    }

    private void FlipCharacter()
    {
        facingRight = !facingRight; //inverse bool
        transform.Rotate(0f,180f,0f);
    }
}
