using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileBehaviour : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody2D rb;
    
    [Header("Physics")]
    public float speed = 40.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * speed;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
