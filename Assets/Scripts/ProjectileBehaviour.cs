using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float speed = 40.0f;
    public Rigidbody2D rb;
    public static float projectileDamage;
    
    // Start is called before the first frame update
    void Start()
    {
        projectileDamage = PlayerCombat.playerDamage;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed * PlayerCombat.projectileDirection;

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
