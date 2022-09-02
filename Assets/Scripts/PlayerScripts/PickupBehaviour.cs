using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehaviour : MonoBehaviour
{
    public Vector2 position;
    public int pointsValue;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        pointsValue = 1;
    }

    // Update is called once per frame
    void Update()
    {
        


    }

    public void PointCollected()
    {
        GameManager.playerScore += 1;
        Debug.Log(pointsValue + " POINT SCORED.");
        Debug.Log("TOTAL POINTS SCORED " + GameManager.playerScore);

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PointCollected();
            Destroy(gameObject);
        }
    }
}
