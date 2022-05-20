using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Commented
    [Header("Atrributes")]
    
    [SerializeField] public float lookDistance;
    public Vector2 spawnPosition;
    public static float enemyDamage;

    [Header("RayCast Information")]
    [SerializeField] public Vector2 lookLeftDirection;
    [SerializeField] public Vector2 lookRightDirection;
    [SerializeField] public float raycastOffset;

    [Header("Status")]
    public bool patrolling;
    public bool attacking;
    public Vector2 position;


    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        spawnPosition = transform.position;
        lookLeftDirection = new Vector2(-10.0f, 0);
        lookRightDirection = new Vector2(10f, 0);
        lookDistance = 8;
        patrolling = true;
        attacking = false;
        raycastOffset = 2.0f;
        enemyDamage = 10;
    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position;
        Patrol();
    }

    // Drops down from its current position in an attempt to damage the player


    // Sets the Position for the RayCast and saves it as a variable.
    // Casts the Ray and saves it as a variable.
    // If the RayCasts don't trigger, patrolling becomes false (stopping this current action) and attacking becomes true, triggering the Attack() method.
    void Patrol()
    {
        // Sets the Position for the RayCast and saves it as a variable. 
        Vector2 leftRayPosition = new Vector2(position.x - raycastOffset, position.y);
        Vector2 rightRayPosition = new Vector2(position.x + raycastOffset, position.y);
        // Casts the Ray and saves it as a variable
        RaycastHit2D leftHit = Physics2D.Raycast(leftRayPosition, Vector2.left, lookDistance);
        RaycastHit2D rightHit = Physics2D.Raycast(rightRayPosition, Vector2.right, lookDistance);
        // If the RayCasts don't trigger, patrolling becomes false (stopping this current action) and attacking becomes true, triggering the Attack() method.
        if (leftHit.collider != null)
        {
            Debug.DrawRay(position, lookLeftDirection, Color.red);
        }
        else
        {
            Debug.DrawRay(position, lookLeftDirection, Color.green);
        }
        if (rightHit.collider != null)
        {
            Debug.DrawRay(position, lookRightDirection, Color.red);
        }
        else
        {
            Debug.DrawRay(position, lookRightDirection, Color.green);
        }
    }

    // If the object collides with the Player object, the Player takes damage equal to the object's damage output.
    // The object is then destroyed.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            PlayerCombat.TakeDamage(enemyDamage);
            Debug.Log("HIT BY ENEMY");
            
        }

    }



}



