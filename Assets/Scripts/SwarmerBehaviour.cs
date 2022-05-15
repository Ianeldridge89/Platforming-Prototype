using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmerBehaviour : MonoBehaviour
{
    public Vector2 spawnPosition;
    [SerializeField] public Vector2 lookLeftDirection;
    [SerializeField] public Vector2 lookRightDirection;
    [SerializeField] public float lookDistance;
    public float attackSpeed;
    public bool patrolling;
    public bool attacking;
    [SerializeField] public float raycastOffset;


    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = transform.position;
        lookLeftDirection = new Vector2(-2.0f, -7.5f);
        lookRightDirection = new Vector2(lookLeftDirection.x * -1, lookLeftDirection.y);
        attackSpeed = 8;
        patrolling = true;
        attacking = false;
        raycastOffset = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Attack();
        Patrol();
        if (attacking)
        {
            //Attack();
        }
    }

    void Attack()
    {
        transform.Translate(Vector2.down * attackSpeed * Time.deltaTime);
    }

    void Patrol()
    {
        Vector2 leftRayPosition = new Vector2(spawnPosition.x - raycastOffset, spawnPosition.y);
        Vector2 rightRayPosition = new Vector2(spawnPosition.x + raycastOffset, spawnPosition.y);
        RaycastHit2D leftHit = Physics2D.Raycast(leftRayPosition, Vector2.down, lookDistance);
        RaycastHit2D rightHit = Physics2D.Raycast(rightRayPosition, Vector2.down, lookDistance);
        if (leftHit.collider != null)
        {
            Debug.DrawRay(spawnPosition, lookLeftDirection, Color.red);
            attacking = true;
        }
        else
        {
            Debug.DrawRay(spawnPosition, lookLeftDirection, Color.green);
        }
        if (rightHit.collider != null)
        {
            Debug.DrawRay(spawnPosition, lookRightDirection, Color.red);
            attacking = true;
        }
        else
        {
            Debug.DrawRay(spawnPosition, lookRightDirection, Color.green);
        }




    } 
    
}
