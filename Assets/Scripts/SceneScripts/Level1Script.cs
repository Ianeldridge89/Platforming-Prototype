using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Script : MonoBehaviour
{
    public float xPosition;
    public float yPosition;

    // Start is called before the first frame update
    void Start()
    {
        xPosition = 90;
        yPosition = 240;
        PlayerMovement.MovePlayer(xPosition, yPosition);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
