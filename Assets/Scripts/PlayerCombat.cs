using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//use inhertiance to connect to combat class
public class PlayerCombat : MonoBehaviour
{
    public static int playerHealth;
    public static bool isAlive;
    public GameObject projectilePrefab;

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
        Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
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
