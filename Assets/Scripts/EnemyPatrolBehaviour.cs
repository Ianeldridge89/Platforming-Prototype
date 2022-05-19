using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolBehaviour : MonoBehaviour
{
    public Vector2 eyePosition;
    [SerializeField] public float raycastOffset;
    [SerializeField] public float lookDistance;
    [SerializeField] public Vector2 lookDirection;

    [Header("Status")]
    public bool inCombat;
    public bool patrolling;
     

    // Start is called before the first frame update

    void Start()
    {
        eyePosition = transform.position;
        raycastOffset = 1.5f;
        lookDistance = 13f;
        lookDirection = new Vector2(lookDistance, 0);
        
        // status variables
        inCombat = false;
        patrolling = true;
    }

    // Update is called once per frame
    void Update()
    {
        eyePosition = transform.position;
        Vector2 rayPosition = new Vector2(eyePosition.x , eyePosition.y - raycastOffset);
        RaycastHit2D hit = Physics2D.Raycast(rayPosition, Vector2.right, lookDistance);
        if (hit.collider != null)
        {
            Debug.DrawRay(eyePosition, lookDirection, Color.red);
            inCombat = true;

        }
        else
        {
            Debug.DrawRay(eyePosition, lookDirection, Color.green);
            inCombat = false;
        }
    }
}
