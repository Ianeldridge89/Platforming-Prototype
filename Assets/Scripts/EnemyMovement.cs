using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    static public float movementSpeed;
    private BoxCollider2D enemyCollider;
    private Rigidbody2D enemyBody;
    static public int enemyDamage;
    private Vector2 startingPosition;
    private bool isGoingLeft;
    private float walkingDistance;

    private void Start()
    {
        enemyCollider = GetComponent<BoxCollider2D>();
        enemyBody = GetComponent<Rigidbody2D>();
        enemyBody.freezeRotation = true;
        movementSpeed = 1.5f;
        startingPosition = transform.position;
        isGoingLeft = true;
        walkingDistance = 3.0f;
    }

    private void Update()
    {
        Patrol();
    }

    private void Position()
    {
        Debug.Log("Position is: " + startingPosition);
    }

    private void Patrol()
    {
        if (isGoingLeft == true)
        {
            MoveLeft();
        }
        else
        {
            MoveRight();
        }
        CheckDirection();
    }

    private void CheckDirection()
    {

        if (transform.position.x < (startingPosition.x - walkingDistance))
        {
            isGoingLeft = false;
        }
        else if (transform.position.x > (startingPosition.x + walkingDistance))
        {
            isGoingLeft = true;
        }
    }

    private void MoveLeft()
    {
        transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
        Debug.DrawRay(transform.position, Vector2.left * 6, Color.green);
    }

    private void MoveRight()
    {
        transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
        Debug.DrawRay(transform.position, Vector2.right * 6, Color.green);
    }

    


}



