using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMovement : MonoBehaviour
{
    public float movementSpeed;
    public static bool onElevator;

    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = 5;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (onElevator)
        {
            transform.Translate(Vector2.up * movementSpeed * Time.deltaTime);
        }
    }

}
