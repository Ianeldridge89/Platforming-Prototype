using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody2D rb;
    public static float projectileDamage;
    public float fireTime;
    public float destroyTime;

    [Header("Physics")]
    public float speed = 50.0f;



    
    // Start is called before the first frame update
    void Start()
    {
        projectileDamage = PlayerCombat.playerDamage;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed * PlayerCombat.projectileDirection;
        fireTime = Time.time;
        destroyTime = fireTime + 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > destroyTime)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
