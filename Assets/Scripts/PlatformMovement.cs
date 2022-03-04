using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    static public float movementSpeed;
    private Vector2 startingPosition;
    private bool isGoingLeft;
    private float walkingDistance;

    private void Start()
    {

        movementSpeed = 1.5f;
        startingPosition = transform.position;
        isGoingLeft = true;
        walkingDistance = 3.0f;
    }

    private void Update()
    {
        HorizontalMovement();
    }

    private void Position()
    {
        Debug.Log("Position is: " + startingPosition);
    }

    private void HorizontalMovement()
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
    }

    private void MoveRight()
    {
        transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
    }
}
