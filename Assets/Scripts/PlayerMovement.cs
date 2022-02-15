using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float fallMultiplier;
    [SerializeField] private float lowJumpMultiplier;



    [SerializeField] private LayerMask platformLayerMask;
    private Rigidbody2D playerBody;
    private BoxCollider2D playerCollider;

    // collects the rigidbody and collider.
    private void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
        playerBody.freezeRotation = true;        
    }

    // changes the velocity and direction of the player.  
    private void Update()
    {
        playerBody.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, playerBody.velocity.y);
        if (Input.GetKey(KeyCode.Space) && IsGrounded())
        {
            Jump();
        }
        if (playerBody.velocity.y < 0)
        {
            playerBody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (playerBody.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            playerBody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }


    }

    private void Jump()
    {
        playerBody.velocity = new Vector2(playerBody.velocity.x, jumpSpeed);
    }

    private void Fly()
    {
        playerBody.velocity = new Vector2(playerBody.velocity.x, jumpSpeed);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f, Vector2.down, .1f, platformLayerMask);
    }


}
