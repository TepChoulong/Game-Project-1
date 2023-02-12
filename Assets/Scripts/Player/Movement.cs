using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Movement System
    public float speed;
    Rigidbody2D rb2d;
    float h_Move;
    float v_Move;
    Animator animator;
    //Jump System
    public float jumpspeed;
    // Grounded System
    public Transform GroundCheck;
    public LayerMask Ground;
    bool IsGrounded;
    //Flip System
    private bool facingRight = true;


    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        JumpAnimationEvent();
        
        h_Move = Input.GetAxis("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(h_Move));

        v_Move = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded)
            {
                Jump();
            }
        }
        
    }

    void FixedUpdate()
    {
        Move();
        IsGroundCheck();

        if (facingRight == false && h_Move > 0)
        {
            FlipPlayer();
        }
        else if (facingRight == true && h_Move < 0)
        {
            FlipPlayer();
        }
    }

    //Method

    void Move()
    {
        rb2d.velocity = new Vector2(h_Move * speed * Time.fixedDeltaTime, rb2d.velocity.y);
         // Play move sound
    }

    void Jump()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpspeed * Time.fixedDeltaTime);
         // Play jump sound
    }

    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void IsGroundCheck()
    {
        IsGrounded = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, Ground);
    }

    void JumpAnimationEvent()
    {
        /*
        Note: You can use this when you have a fall animation and jump animation. This script require these two animation to make it run.
        */
        
        if (rb2d.velocity.y > 0.01)
        {
            animator.SetBool("IsJump", true);
            animator.SetBool("IsFall", false);
        }
        
        if (rb2d.velocity.y < 0.01)
        {
            animator.SetBool("IsJump", false);
            animator.SetBool("IsFall", true);
        }
        
        if (IsGrounded)
        {
            animator.SetBool("IsJump", false);
            animator.SetBool("IsFall", false);
        }
    }
}
