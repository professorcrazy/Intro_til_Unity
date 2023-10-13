using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController2D : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 5f;

    public float jumpVelocity = 5f;
    public int maxJumps = 2;
    int jumpsLeft;
    public Transform groundcheck;
    public float groundRadiousCheck = 0.5f;
    public LayerMask groundMask;
    bool isJumping = false;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float maxJumpTimer = 0.15f;
    float jumpTimer;
    float basegravityScale;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpsLeft = maxJumps;
        basegravityScale = rb.gravityScale;
        jumpTimer = maxJumpTimer;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move;
        move.x = Input.GetAxisRaw("Horizontal") * speed;
        move.y = rb.velocity.y;
        rb.velocity = move;

        if (Physics2D.OverlapCircle(groundcheck.position, groundRadiousCheck, groundMask))
        {
            jumpsLeft = maxJumps;
            isJumping = false;
        }

        if (Input.GetButton("Jump") && jumpsLeft > 0 && jumpTimer > 0)
        {
            isJumping = true;
            rb.gravityScale = basegravityScale;
            jumpTimer -= Time.deltaTime;
        }

        if (Input.GetButtonUp("Jump") && jumpsLeft > 0)
        {
            jumpsLeft -= 1;
            jumpTimer = maxJumpTimer;
        }
    }

    private void FixedUpdate()
    {
        if (isJumping)
        {
            //rb.AddForce(Vector2.up * jumpVelocity); //jumpVelocity = 40
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
            isJumping = false;
        }

        if (rb.velocity.y < 0 && !Input.GetButton("Jump"))
        {
            rb.gravityScale = fallMultiplier * basegravityScale;
        } else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.gravityScale = lowJumpMultiplier * basegravityScale;
        } else { 
            rb.gravityScale = basegravityScale;
        }
    }



}
