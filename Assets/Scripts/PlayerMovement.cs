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
    public BoxCollider2D playerCollider;

    private void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
        playerBody.freezeRotation = true;        
    }

    private void Update()
    {
        GroundCheck();
        playerBody.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, playerBody.velocity.y);
        if (Input.GetKey(KeyCode.Space) && GroundCheck())
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

    /*private void oncollisionenter2d(collision2d collision)
    {
        if(collision.gameobject.tag == "ground")
        {
            isgrounded = true;
        }
    }*/

    private void Fly()
    {
        playerBody.velocity = new Vector2(playerBody.velocity.x, jumpSpeed);
    }

    private bool GroundCheck()
    {
        RaycastHit2D raycastHit = Physics2D.Raycast(playerCollider.bounds.center, Vector2.down, playerCollider.bounds.extents.y + 0.01f, platformLayerMask);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(playerCollider.bounds.center, Vector2.down * (playerCollider.bounds.extents.y + 0.01f));
        Debug.Log(raycastHit.collider);
        return raycastHit.collider != null;
    }


    //Physics2D.Raycast(playerCollider.bounds.center, Vector2.down, playerCollider.bounds.extents.y + 0.01f);
}
