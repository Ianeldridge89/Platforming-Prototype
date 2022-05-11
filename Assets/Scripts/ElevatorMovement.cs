using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMovement : MonoBehaviour
{
    public float movementSpeed;
    public bool onElevator;
    public float floorDistance;
    public float yPosition;

    [Header("REQUIRED FIELDS")]
    public bool onBottomFloor;
    public float bottomPosition;
    public float topPosition;

    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = 4;
        yPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    { 
        if (onElevator)
        { 
            yPosition = transform.position.y; 
            if (onBottomFloor)
            {
                MovingUp();
            }
            else
            {
                MovingDown();
            }
          
        }
        
    }

    void MovingUp()
    {
        transform.Translate(Vector2.up * movementSpeed * Time.deltaTime);
        if (yPosition >= topPosition)
        {
            onBottomFloor = false;
        }
    }

    void MovingDown()
    {
        transform.Translate(Vector2.down * movementSpeed * Time.deltaTime);
        if (yPosition <= bottomPosition)
        {
            onBottomFloor = true;
        }
    }


}
