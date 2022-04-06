using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//use inhertiance to connect to combat class
public class PlayerCombat : MonoBehaviour
{
    public static int playerHealth;
    public static bool isAlive;

    public GameObject projectilePrefab;
    public static float projectileSpeed = 20f;
    public Vector3 projectileOrigin;
    public static int projectileDirection;

    private void Start()
    {
        playerHealth = 100;
        isAlive = true;

    }

    private void Update()
    {
        DeathCheck();
        if (Input.GetKeyDown(KeyCode.E))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (PlayerMovement.facingRight)
        {
            projectileDirection = 1;
        }
        else if (!PlayerMovement.facingRight)
        {
            projectileDirection = -1;
        }
        projectileOrigin = new Vector3((transform.position.x + projectileDirection), transform.position.y, transform.position.z) ;
        Instantiate(projectilePrefab, projectileOrigin, projectilePrefab.transform.rotation);

        Debug.Log("SHOT FIRED!");
    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Damage((EnemyCombat.enemyDamage));
        }
    }

//removes the value of attack damage from the player's health
    public static void Damage(int damage)
    {
        playerHealth = playerHealth - damage;
        Debug.Log("HIT! TAKE " + damage + " DAMAGE. REMAINING HEALTH: " + playerHealth);
    }

//checks to see whether the player has taken enough damage to die
    public static void DeathCheck()
    {
        if (playerHealth <= 0)
        {
            isAlive = false;
            Debug.Log("YOU ARE DEAD");
        }
    }

}
