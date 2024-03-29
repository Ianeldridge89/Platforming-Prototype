using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    public GameObject player;
    public static Rigidbody2D playerBody;
    public BoxCollider2D playerCollider;
    [SerializeField] public LayerMask platformLayerMask;

    [Header("Physics")]
    public bool isGrounded;
    [SerializeField] public float playerMass;
    public static bool facingRight;
    [SerializeField] public float speed;
    [SerializeField] public float defaultJumpSpeed;
    [SerializeField] public float jumpSpeed;
    [SerializeField] public float fallMultiplier;
    [SerializeField] public float lowJumpMultiplier;
    public float movement;
    public float walkingSpeed;
    public float sprintSpeed;

    [Header("Abilities")]
    public bool hasDoubleJump;
    public bool doubleJumpAvailable;
    public float dashSpeed;
    public bool dashIsAvailable;

    [Header("TEST")]
    [SerializeField] public float wallCast = 1f;
    [SerializeField] public float castDirection = 1f;
    public bool hitWall = false;
    [SerializeField] public float wallOffset = 0.5f;
    public bool onMovingPlatform;

    // collects the rigidbody and collider.
    private void Start()
    {
        // Components
        playerBody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
        playerBody.freezeRotation = true;

        //Physics
        playerBody.mass = 2;
        facingRight = true;
        walkingSpeed = 8.5f;
        sprintSpeed = 10f;
        speed = walkingSpeed;
        defaultJumpSpeed = 12.0f;
        jumpSpeed = defaultJumpSpeed;
        fallMultiplier = 2.5f;
        lowJumpMultiplier = 8.0f;

        //Abilities
        hasDoubleJump = true;
        doubleJumpAvailable = true;
        dashSpeed = 20.0f;

        //TEST
        wallCast = 1f;
        wallOffset = 0.5f;
        dashIsAvailable = true;
        hitWall = false;
    }

    // changes the velocity and direction of the player.  
    private void Update()
    {
        isGrounded = IsGrounded();
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
        if (facingRight)
        {
            castDirection = 1;
        }
        else
        {
            castDirection = -1;
        }
        bool hitObstacle = Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f, Vector2.right * castDirection, 0.1f, platformLayerMask);
        if (hitObstacle)
        {
            hitWall = true;
        }
        else
        {
            hitWall = false;
            jumpSpeed = defaultJumpSpeed;
        }
    }

    public static void MovePlayer(float xPosition, float yPosition)
    {
        playerBody.position = new Vector3(xPosition, yPosition);
    }

    public bool WallCheck()
    {
        return Physics2D.BoxCast(playerCollider.bounds.center - (new Vector3 (0, 1, 0)), playerCollider.bounds.size, 0f, Vector2.right, .1f, platformLayerMask);
    }

    public void Move()
    {
        movement = Input.GetAxis("Horizontal");
        if (movement < 0 && facingRight || movement > 0 && !facingRight)
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
        if (hasDoubleJump)
        {
            playerBody.velocity = Vector2.up * jumpSpeed;
            doubleJumpAvailable = false;
        }

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("MovingPlatform") || collision.gameObject.tag == ("Elevator"))
        {
            transform.parent = collision.transform;
            onMovingPlatform = true;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("MovingPlatform") || collision.gameObject.tag == ("Elevator"))
        {
            transform.parent = null;
            onMovingPlatform = false;
        }
    }



}
