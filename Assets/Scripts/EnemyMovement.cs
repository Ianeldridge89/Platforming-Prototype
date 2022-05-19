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
    [SerializeField] private float walkingDistance
    public float walkingDirection = 1f;

    [Header("Abilities")]
    [SerializeField] static public int enemyDamage;

    [Header("Attributes")]
    public bool isGoingLeft;
    private Vector2 startingPosition;

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
        inCombat = false;
        isPatrolling = true;
    }

    private void Update()
    {
        CheckDirection();
        Move(); 
    }

    private void CheckDirection()
    {
        // 
        if (transform.position.x < (startingPosition.x - walkingDistance))
        {
            isGoingLeft = false;
        }
        else if (transform.position.x > (startingPosition.x + walkingDistance))
        {
            isGoingLeft = true;
        }
        // 
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



