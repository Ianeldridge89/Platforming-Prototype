using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryPlayerScript : MonoBehaviour
{
    [Header("Components")]
    public GameObject player;
    public Rigidbody2D playerBody;
    public BoxCollider2D playerCollider;
    public float movement;
    public static bool facingRight;
    public float walkingSpeed;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        //Components
        //player = GetComponent<GameObject>(); /*IS THIS NEEDED?*/
        playerBody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
        playerBody.freezeRotation = true;
        facingRight = true;
        walkingSpeed = 6.0f;
        speed = walkingSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        Move();
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

}
