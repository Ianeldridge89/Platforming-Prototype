using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehaviour : MonoBehaviour
{
    public Vector2 position;
    public int pointValue;
    public float moveTime;
    public float spawnTime;
    public static List<Vector2> spawnPositions;
    public Vector2 spawnPos0;
    public Vector2 spawnPos1;
    public Vector2 spawnPos2;
    public Vector2 spawnPos3;
    public Vector2 spawnPos4;
    public Vector2 spawnPos5;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        pointValue = 5;
        moveTime = 2;

        // Spawn Values
        spawnTime = Time.time;
        spawnPos0 = new Vector2(145.9f, -17.2f);
        spawnPos1 = new Vector2(160.3f, -18.5f);
        spawnPos2 = new Vector2(194.7f, -18.2f);
        spawnPos3 = new Vector2(223.8f, -18.8f);
        spawnPos4 = new Vector2(137.7f, -24.1f);
        spawnPos5 = new Vector2(190.3f, -12.3f);

        spawnPositions = new List<Vector2>();
        spawnPositions.Add(spawnPos0);
        spawnPositions.Add(spawnPos1);
        spawnPositions.Add(spawnPos2);
        spawnPositions.Add(spawnPos3);
        spawnPositions.Add(spawnPos4);
        spawnPositions.Add(spawnPos5);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Time.time > (spawnTime + moveTime))
        {
            transform.position = spawnPositions[Random.Range(0, 5)];
            spawnTime = Time.time;
        }


    }

    public void addSpawnPositions()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        { 
            Destroy(gameObject);
        }
    }
}
