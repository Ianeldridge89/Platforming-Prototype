using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    static public float movementSpeed;
    private BoxCollider2D enemyCollider;
    private Rigidbody2D enemyBody;
    static public int enemyDamage;

    private void Start()
    {
        enemyCollider = GetComponent<BoxCollider2D>();
        enemyBody = GetComponent<Rigidbody2D>();
        enemyBody.freezeRotation = true;
        movementSpeed = 1.0f;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
    }
}
