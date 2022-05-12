using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    public Vector2 position;
    public bool isOpen;
    public int cooldownTime;
    public bool openDoor;
    [SerializeField] public float openHeight;
    [SerializeField] public float heightLimit;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        isOpen = false;
        openDoor = false;
        openHeight = 6;
        heightLimit = position.y + openHeight;

    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position;
        if (openDoor)
        {
            if (position.y <= heightLimit)
            {
                DoorOpen();
            }
            else
            {
                openDoor = false;
                isOpen = true; 
            }
        }
        if (isOpen)
        {
            Debug.Log("DOOR IS OPEN");
        }
    }

    // Checks whether a collision on the door is a player projectile. need to time it so it 
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            openDoor = true;
        }

    }

    public void DoorOpen()
    {
        transform.Translate(Vector2.up * 2 * Time.deltaTime);
    }

    public void DoorClose()
    {
        transform.Translate(Vector2.up * 2 * Time.deltaTime);
    }



}

