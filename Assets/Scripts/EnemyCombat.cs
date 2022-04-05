using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//use inhertiance to connect to combat class
public class EnemyCombat : MonoBehaviour
{
    private BoxCollider2D enemyCollider;
    private Rigidbody2D enemyBody;
    public static int enemyDamage;
    public GameObject projectilePrefab;

    private void Start()
    {
        enemyCollider = GetComponent<BoxCollider2D>();
        enemyBody = GetComponent<Rigidbody2D>();
        enemyDamage = 10;
    }



    private static void Attack(int enemyDamage)
    {

        PlayerCombat.Damage(enemyDamage);

    }


    // if the player enters the enemy's field of view,
    //  the enemy shoots the player
}
