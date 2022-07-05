using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishingPlatformBehaviour : MonoBehaviour

{
    [Header("SpawnPosition")]
    public Vector2 spawnPosition;
    public float spawnXPosition;
    public float spawnYPosition;

    [Header("Position")]
    public Vector2 position;
    public float xPosition;
    public float yPosition;
    public float fallDistance;
    public bool isActive;
    public float movementSpeed;

    public float activateTime;
    public float activateLength;
    public Color color;
    public SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = transform.position;
        spawnXPosition = spawnPosition.x;
        spawnYPosition = spawnPosition.y;
        fallDistance = 10;
        isActive = false;
        movementSpeed = 10;
        activateLength = 1f;
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position;
        xPosition = position.x;
        yPosition = position.y;
        if (isActive)
        {
            if (Time.time > (activateTime + activateLength))
            {
                MovePlatform();
            }
            else if (Time.time > (activateTime + (activateLength / 2)))
            {
                sprite.color = Color.red;
            }
            else
            {
                sprite.color = Color.green;
            }
        }
    }

    void MovePlatform()
    {
        transform.position = new Vector2(100, -100);
        if (Time.time > activateTime + 2)
        {
            isActive = false;
            transform.position = spawnPosition;
            activateTime = 0;
            sprite.color = Color.white;
        }

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        isActive = true;
        if (activateTime == 0)
        {
            activateTime = Time.time;
        }
    }















}
