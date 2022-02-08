using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float fallMultiplier;
    [SerializeField] private float lowJumpMultiplier;

    private bool isGrounded;

    private Rigidbody2D playerBody;
    public BoxCollider2D playerCollider;

    private void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
        playerBody.freezeRotation = true;
    }

    private void Update()
    {
        playerBody.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, playerBody.velocity.y);
        if (Input.GetKey(KeyCode.Space) && isGrounded)
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
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void Fly()
    {
        playerBody.velocity = new Vector2(playerBody.velocity.x, jumpSpeed);
    }

    private bool GroundCheck()
    {
        isGrounded = Physics.Raycast(transform.position, -gameObject.transform.up, playerCollider.bounds.extents.y + 0.1f);
        return isGrounded;
    }
}
