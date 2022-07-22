using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorActivatorScript : MonoBehaviour
{
    public GameObject attachedElevatorScript;

    private void Start()
    {
        attachedElevatorScript = transform.parent.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        attachedElevatorScript.GetComponent<ElevatorMovement>().elevatorActivated = true;
    }

}
