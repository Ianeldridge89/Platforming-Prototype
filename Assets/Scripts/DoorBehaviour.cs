using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    public Vector2 position;
    public bool isOpen;
    public float cooldownTime;
    public float cooldownStartTime;
    public bool openDoor;
    public bool doorIsClosing;
    [SerializeField] public float openHeight;
    [SerializeField] public float heightLimit;
    [SerializeField] public float closeHeight;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        isOpen = false;
        openDoor = false;
        openHeight = 6;
        heightLimit = position.y + openHeight;
        doorIsClosing = false;
        closeHeight = .15621f;
        closeHeight = position.y + closeHeight; 

    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position;
        
        if (openDoor)
        {
            DoorOpen();
            if (position.y >= heightLimit)
            {
                openDoor = false;
                isOpen = true;
                cooldownStartTime = Time.time;
            }
        }
        if (!openDoor && isOpen)
        {
            cooldownTime = Time.time;
            if (cooldownTime > cooldownStartTime + 2)
            {
                doorIsClosing = true;
            }
        }
        if (doorIsClosing)
        {
            DoorClose();
            if (position.y <= closeHeight)
            {
                doorIsClosing = false;
                isOpen = false;
            }
        }

        
    }

    // Checks whether a collision on the door is a player projectile. need to time it so it 
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            if (!doorIsClosing)
            {
                openDoor = true;
            }
            
        }

    }

    public void DoorOpen()
    {
        transform.Translate(Vector2.up * 2 * Time.deltaTime);
    }

    public void DoorClose()
    {
        transform.Translate(Vector2.down * 2 * Time.deltaTime);
    }



}

