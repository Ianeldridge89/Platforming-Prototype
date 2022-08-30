using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float positionZ;

    private void Start()
    {
        positionZ = transform.position.z;
    }

    void Update()
    {

        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, positionZ);
    }
























    /*
    //current options
    public Transform target;
    public float smoothSpeed = 0.125f;
    public float offsetX;
    public float offsetY;
    public float offsetZ;
    public Vector3 offset;

    public void Start()
    {
        //current options
        offsetX = 0;
        offsetY = 5;
        offsetZ = -50;
        offset = new Vector3(offsetX, offsetY, offsetZ);
        //new options

    }


    private void FixedUpdate()
    {
        
    }

    public void newCameraMethod()
    {

    }

    public void currentCameraMethod()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        transform.LookAt(target);
    }
    */

}
