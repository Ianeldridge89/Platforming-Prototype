using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMovement : MonoBehaviour
{
    public float movementSpeed;
    public bool elevatorActivated;
    public float floorDistance;
    public float yPosition;

    [Header("REQUIRED FIELDS")]
    public bool onBottomFloor;
    public float bottomPosition;
    public float topPosition;

    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = 5;
        yPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    { 
        if (elevatorActivated)
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
            elevatorActivated = false;
        }
    }

    void MovingDown()
    {
        transform.Translate(Vector2.down * movementSpeed * Time.deltaTime);
        if (yPosition <= bottomPosition)
        {
            onBottomFloor = true;
            elevatorActivated = false;
        }
    }


}
