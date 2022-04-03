using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//use inhertiance to connect to combat class
public class EnemyCombat : MonoBehaviour
{
    private BoxCollider2D enemyCollider;
    private Rigidbody2D enemyBody;
    static public int enemyDamage;
    private Transform sightStart;
    private Transform sightEnd;

    private void Start()
    {
        enemyCollider = GetComponent<BoxCollider2D>();
        enemyBody = GetComponent<Rigidbody2D>();
        enemyDamage = 10;
    }

    void FixedUpdate()
    {


        /*Vector2 forward = transform.TransformDirection(Vector2.left) * 5;
        Debug.DrawRay(transform.position, forward, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, (forward * 5));

        if (hit.collider != null)
        {
            Debug.Log("PLAYER SEEN!");
        }
        else
        {
            Debug.Log("PLAYER NOT SEEN");
        }*/
    }





    private void ScanRight()
    {
        
    }

    private void ScanLeft()
    {

    }

    // if the player enters the enemy's field of view,
    //  the enemy shoots the player
}
