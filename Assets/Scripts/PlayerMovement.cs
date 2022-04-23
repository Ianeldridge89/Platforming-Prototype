using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody2D playerBody;
    public BoxCollider2D playerCollider;
    [SerializeField] public LayerMask platformLayerMask;

    [Header("Physics")]
    [SerializeField] public float playerMass;
    public static bool facingRight;
    [SerializeField] public float speed;
    [SerializeField] public float jumpSpeed;
    [SerializeField] public float fallMultiplier;
    [SerializeField] public float lowJumpMultiplier;
    public float movement;

    [Header("Abilities")]
    public bool doubleJumpAvailable;
    public float dashSpeed;
    public bool dashIsAvailable;


    // collects the rigidbody and collider.
    private void Start()
    {
        
        playerBody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
        playerBody.freezeRotation = true;
        playerBody.mass = 2;
        facingRight = true;
        speed = 8.5f;
        dashSpeed = 20.0f;
        jumpSpeed = 10.0f;
        fallMultiplier = 2.5f;
        lowJumpMultiplier = 8.0f;

        doubleJumpAvailable = true;
        dashIsAvailable = true;
    }

    // changes the velocity and direction of the player.  
    private void Update()
    {
        Move();        
        Jump();
        Dash();
        if (IsGrounded())
        {
            doubleJumpAvailable = true;
        }
        if (!IsGrounded())
        {
            if (Input.GetButtonDown("Jump"))
            {
                if (doubleJumpAvailable)
                {
                    DoubleJump();
                }
            }
        }
    }


    public void Move()
    {
        movement = Input.GetAxis("Horizontal");
        if (movement < 0 && facingRight)
        {
            Flip();
        }
        else if (movement > 0 && !facingRight)
        {
            Flip();
        }
        if (movement > 0)
        {
            facingRight = true;
        }
        else if (movement < 0)
        {
            facingRight = false;
        }
        playerBody.velocity = new Vector2(movement * speed, playerBody.velocity.y);
    }


    public void Flip()
    { 
        transform.Rotate(0f, 180f, 0f);
    }


    public void Jump()
    {
        if (Input.GetButton("Jump"))
        {
            if (IsGrounded())
            {
                playerBody.velocity = new Vector2(playerBody.velocity.x, jumpSpeed);
            }
        }
        if (playerBody.velocity.y < 0)
        {
            playerBody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (playerBody.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            playerBody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }


    public void DoubleJump()
    {
        playerBody.velocity = Vector2.up * jumpSpeed;
        doubleJumpAvailable = false;
    }


    public void Dash()
    {
        if (Input.GetButton("Dash") && dashIsAvailable)
        {
            float dashDirection;
            if (facingRight)
            {
                dashDirection = 1;
            }
            else
            {
                dashDirection = -1;
            }
            playerBody.velocity = Vector2.right * dashSpeed * dashDirection;
            StartCoroutine(DashLengthCheck());
        }

    }

    IEnumerator DashLengthCheck()
    {
        yield return new WaitForSeconds(0.5f);
        dashIsAvailable = false;
        yield return new WaitForSeconds(3);
        dashIsAvailable = true;
    }

    public bool IsGrounded()
    {
        return Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f, Vector2.down, .1f, platformLayerMask);
    }


}
