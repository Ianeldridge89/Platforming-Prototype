using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Components")]
    private BoxCollider2D enemyCollider;
    private Rigidbody2D enemyBody;
    public LayerMask platformLayerMask;
    public GameObject projectilePrefab;

    [Header("Physics")]
    [SerializeField] public float movementSpeed;
    [SerializeField] private float walkingDistance;
    private Vector2 startingPosition;
    public float walkingDirection = 1f;

    [Header("Abilities")]
    [SerializeField] static public int enemyDamage;

    [Header("Attributes")]
    [SerializeField] float lookDistance = 5;
    public bool isGoingLeft;

    [Header("Status")]
    public bool inCombat;
    public bool isPatrolling;


    private void Start()
    {
        enemyCollider = GetComponent<BoxCollider2D>();
        enemyBody = GetComponent<Rigidbody2D>();
        enemyBody.freezeRotation = true;
        movementSpeed = 1.5f;
        startingPosition = transform.position;
        isGoingLeft = true;
        walkingDistance = 3.0f;
        walkingDirection = 1;
        lookDistance = 5;
    }

    private void Update()
    {
        Move();
        CheckDirection();
        Patrol();
    }

    private void CheckDirection()
    {

        if (transform.position.x < (startingPosition.x - walkingDistance))
        {
            isGoingLeft = false;
        }
        else if (transform.position.x > (startingPosition.x + walkingDistance))
        {
            isGoingLeft = true;
        }
        if (isGoingLeft)
        {
            walkingDirection = -1;
        }
        else
        {
            walkingDirection = 1;
        }
    }
    
    private void Move()
    {
        transform.Translate(Vector2.right * movementSpeed * walkingDirection * Time.deltaTime);

    }

    public void Patrol()
    {
        float raycastOffset = 1 * walkingDirection;
        Vector2 rayPosition = new Vector2(transform.position.x + raycastOffset, transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(rayPosition, Vector2.right * walkingDirection, lookDistance);
        if(hit.collider != null)
        {
            Debug.DrawRay(transform.position, Vector2.right * walkingDirection * lookDistance, Color.red);
            inCombat = true;
            Shoot(walkingDirection);
        }
        else
        {
            Debug.DrawRay(transform.position, Vector2.right * walkingDirection * lookDistance, Color.green);
        }


        //
    }

    public void Shoot(float walkingDirection)
    {
        movementSpeed = 0;
        Vector2 projectileOrigin = new Vector2((transform.position.x + (2 * walkingDirection)), transform.position.y);
        Instantiate(projectilePrefab, projectileOrigin, projectilePrefab.transform.rotation);
        movementSpeed = 1.5f;
    }
    private void WallCheck()
    {

    }


    


}



