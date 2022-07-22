using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;
    public float jumpForce;
    private bool facingRight = true;

    private float moveInput;
    private bool jumpInput;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpValue;

    // Start is called before the first frame update
    void Start()
    {
        extraJumps = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame, for registering Input
    void Update()
    {
        
        

        moveInput = Input.GetAxis("Horizontal");
        Debug.Log(moveInput);
        if(facingRight && moveInput < -0.01f)
        {
            Flip();
        } else if (!facingRight && moveInput > 0.01f) {
            Flip(); 
        }

        if (isGrounded)
        {
            extraJumps = extraJumpValue;
        }
    }

    // Update for Physics, called 50 times a second
    void FixedUpdate()
    {
        //Movement
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        //Not sure if in Update or FixedUpdate
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        //Jump
        jumpInput = Input.GetKeyDown(KeyCode.Space);
        if (jumpInput && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        } 
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
