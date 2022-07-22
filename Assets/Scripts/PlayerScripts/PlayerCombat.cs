using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//use inhertiance to connect to combat class
public class PlayerCombat : MonoBehaviour
{
    [Header("Components")]
    public GameObject projectilePrefab;

    [Header("Physics")]
    public static float projectileSpeed = 20f;
    public Vector3 projectileOrigin;
    public static float projectileDirection;

    [Header("Abilities")]
    public static bool hasGun;

    [Header("Atrributes")]
    public static float playerHealth;
    public static bool isAlive;
    public static float playerDamage;

    private void Start()
    {
        playerHealth = 100;
        playerDamage = 34;
        isAlive = true;
        hasGun = true;
    }

    private void Update()
    {

        if (Input.GetButtonDown("Fire1") && hasGun)
        {
            Shoot();
        }
    }

    //creates a new projectile that will be fired in the determined direction.
    public void Shoot()
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


//removes the value of attack damage from the player's health
    public static void TakeDamage(float damage)
    {
        playerHealth -= damage;
        Debug.Log("YOU ARE HIT! TAKE " + damage + " DAMAGE. REMAINING HEALTH: " + playerHealth);
        DeathCheck();
    }

//checks to see whether the player has taken enough damage to die
    public static void DeathCheck()
    {
        if (playerHealth <= 0 && isAlive)
        {
            playerHealth = 0;
            isAlive = false;
            Debug.Log("YOU ARE DEAD");
        }
    }

}
