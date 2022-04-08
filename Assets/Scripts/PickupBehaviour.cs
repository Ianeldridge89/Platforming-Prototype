using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehaviour : MonoBehaviour
{
    public int pointValue;
    
    // Start is called before the first frame update
    void Start()
    {
        pointValue = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.PointScored(pointValue);
            Destroy(gameObject);
        }
    }
}
