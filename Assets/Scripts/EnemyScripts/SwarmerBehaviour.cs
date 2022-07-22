using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmerBehaviour : MonoBehaviour
{
    // Commented
    [Header("Atrributes")]
    public float attackSpeed;
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


    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = transform.position;
        lookLeftDirection = new Vector2(-2.0f, -7.5f);
        lookRightDirection = new Vector2(lookLeftDirection.x * -1, lookLeftDirection.y);
        attackSpeed = 12;
        patrolling = true;
        attacking = false;
        raycastOffset = 2.0f;
        enemyDamage = 25;
    }

    // Update is called once per frame
    void Update()
    {
        if (attacking)
        {
            Attack();
        }
        else if (patrolling)
        {
            Patrol();
        }
    }

    // Drops down from its current position in an attempt to damage the player
    void Attack()
    {
        transform.Translate(Vector2.down * attackSpeed * Time.deltaTime);
    }

    // Sets the Position for the RayCast and saves it as a variable.
    // Casts the Ray and saves it as a variable.
    // If the RayCasts don't trigger, patrolling becomes false (stopping this current action) and attacking becomes true, triggering the Attack() method.
    void Patrol()
    {
        // Sets the Position for the RayCast and saves it as a variable. 
        Vector2 leftRayPosition = new Vector2(spawnPosition.x - raycastOffset, spawnPosition.y);
        Vector2 rightRayPosition = new Vector2(spawnPosition.x + raycastOffset, spawnPosition.y);
        // Casts the Ray and saves it as a variable
        RaycastHit2D leftHit = Physics2D.Raycast(leftRayPosition, Vector2.down, lookDistance);
        RaycastHit2D rightHit = Physics2D.Raycast(rightRayPosition, Vector2.down, lookDistance);
        // If the RayCasts don't trigger, patrolling becomes false (stopping this current action) and attacking becomes true, triggering the Attack() method.
        if (leftHit.collider != null)
        {
            Debug.DrawRay(spawnPosition, lookLeftDirection, Color.red);
            attacking = true;
            patrolling = false;
        }
        else
        {
            Debug.DrawRay(spawnPosition, lookLeftDirection, Color.green);
        }
        if (rightHit.collider != null)
        {
            Debug.DrawRay(spawnPosition, lookRightDirection, Color.red);
            attacking = true;
            patrolling = false;
        }
        else
        {
            Debug.DrawRay(spawnPosition, lookRightDirection, Color.green);
        }
    }

    // If the object collides with the Player object, the Player takes damage equal to the object's damage output.
    // The object is then destroyed.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            PlayerCombat.TakeDamage(enemyDamage);
            Debug.Log("HIT BY SWARMER");
            Destroy(gameObject);
        }
        
    }
    

}
    
    

