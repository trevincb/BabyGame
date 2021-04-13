using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BabyMovement : MonoBehaviour
{
    
    public float speed;
    public float jumpForce;
    private float moveInput;
    private Rigidbody2D rb;
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    private int extraJumps;
    public int extraJumpsValue;
    private Animator anim;
    public GameOverScreen gameOverScreen;
    public Door door;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        extraJumps = extraJumpsValue;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();    
    }

    void FixedUpdate()
    {
        // //knowing when character is on the ground
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        //move sideways
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        //turning sides
        if(moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0,0,0);
        }
        else if(moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0,180,0);
        }

        //animation for idle and moving sideways
        if(moveInput == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }

        //animation for jumping 
        if(isGrounded == true && Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.SetTrigger("takeOff");
            rb.velocity = Vector2.up * jumpForce;
        }

        //animation for jumping
        if(isGrounded == true)
        {
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isJumping", true);
        } 
    }

    // Update is called once per frame
    void Update()
    {
        //Reset extraJumps if player hits the ground
        if(isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        //Multiple jumps
        //if extraJumps is > 0, allow jumps, but extraJumps reduces by 1 every jump
        //if extraJumps reaches 0, can't jump anymore. Will fall to the ground.
        if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        //if extraJumps is set to 0, we want player to jump only once
        else if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //if player collides with enemy --> display gameOverScreen and freeze time.
        if(other.gameObject.tag == "Enemy")
        {
            gameOverScreen.ScoreText(ScoreManager.instance.GetScore());
                Time.timeScale = 0;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        //if player collides with Door, and winScore has been reached --> display WinMenu scene and freeze time.
        if(other.gameObject.tag == "Door" && ScoreManager.instance.GetScore() >= door.winScore)
        {
            Time.timeScale = 0; 
            SceneManager.LoadScene("WinMenu"); 
        }
    }
}
