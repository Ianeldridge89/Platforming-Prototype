using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//use inhertiance to connect to combat class
public class EnemyCombat : MonoBehaviour
{
    [Header("Components")]
    public BoxCollider2D enemyCollider;
    public Rigidbody2D enemyBody;


    //private static bool isDead;

    private void Start()
    {
        // Components
        enemyCollider = GetComponent<BoxCollider2D>();
        enemyBody = GetComponent<Rigidbody2D>();

        //Attributes


    }

    private void Update()
    {

    }

}
