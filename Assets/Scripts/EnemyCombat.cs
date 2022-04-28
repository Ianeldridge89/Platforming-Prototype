using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//use inhertiance to connect to combat class
public class EnemyCombat : MonoBehaviour
{
    public BoxCollider2D enemyCollider;
    public Rigidbody2D enemyBody;
    public float enemyDamage;

    private float enemyHealth;
    public static int pointsValue;
    public Vector2 projectileOrigin;
    //private static bool isDead;

    private void Start()
    {
        enemyCollider = GetComponent<BoxCollider2D>();
        enemyBody = GetComponent<Rigidbody2D>();
        enemyDamage = 20.0f;
        enemyHealth = 100.0f;
        pointsValue = 25;
        //isDead = false;

    }

    private void Update()
    {
        DeathCheck();
    }

    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;
        Debug.Log("ENEMY HIT! TAKE " + damage + " DAMAGE. REMAINING HEALTH: " + enemyHealth);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            TakeDamage(ProjectileBehaviour.projectileDamage);
        }
        else if (collision.gameObject.tag == "Player")
        {
            PlayerCombat.TakeDamage(enemyDamage);
        }
    }



    public void DeathCheck()
    {
        if (enemyHealth <= 0)
        {
            enemyHealth = 0;
            Destroy(gameObject);
            GameManager.PointScored(pointsValue);
        }
    }

    // if the player enters the enemy's field of view,
    //  the enemy shoots the player
}
