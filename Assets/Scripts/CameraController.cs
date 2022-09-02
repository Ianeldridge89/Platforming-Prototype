using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float positionX;
    public float positionY;
    public float positionZ;

    private void Start()
    {
        positionX = player.transform.position.x;
        positionY = player.transform.position.y;
        positionZ = player.transform.position.z - 1;
    }

    void Update()
    {
        positionX = player.transform.position.x;
        positionY = player.transform.position.y;
        positionZ = player.transform.position.z - 1;
        transform.position = new Vector3(positionX, positionY, positionZ);
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
