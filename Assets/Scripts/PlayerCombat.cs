using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//use inhertiance to connect to combat class
public class PlayerCombat : MonoBehaviour
{
    public int playerHealth;

    private void Start()
    {
        playerHealth = 100;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Damage((EnemyCombat.enemyDamage));
         
        }
    }

    public void Damage(int attackDamage)
    {
        playerHealth = playerHealth - attackDamage;
        Debug.Log("HIT! TAKE " + attackDamage + " DAMAGE. REMAINING HEALTH: " + playerHealth);
        if (playerHealth <= 0)
        {
            Dead();
        }

    }

    public static void Dead()
    {
        Debug.Log("YOU ARE DEAD");
    }

}
