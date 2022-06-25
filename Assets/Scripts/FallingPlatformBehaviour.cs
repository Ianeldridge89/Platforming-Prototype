using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatformBehaviour : MonoBehaviour
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
        fallDistance = 7;
        isActive = false;
        movementSpeed = 4;
        activateLength = 2;
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
                DropPlatform();
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

    void DropPlatform()
    {
        transform.Translate(Vector2.down * movementSpeed * Time.deltaTime);
        BoundaryChecker();
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        isActive = true;
        if (activateTime == 0)
        {
            activateTime = Time.time;
        }
    }



    void BoundaryChecker()
    {
        if (yPosition <= (spawnYPosition - fallDistance))
        {
            Destroy(gameObject);
        }
    }















}
