using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructiblePlatformBehaviour : MonoBehaviour
{
    [Header("SpawnPosition")]
    public Vector2 spawnPosition;
    public float spawnXPosition;
    public float spawnYPosition;

    [Header("Position")]
    public Vector2 position;
    public float xPosition;
    public float yPosition;
    public bool isActive;

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
        isActive = false;
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
                Destroy(gameObject);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isActive = true;
        activateTime = Time.time;
    }



}
