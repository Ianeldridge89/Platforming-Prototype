using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public float offsetX;
    public float offsetY;
    public float offsetZ;
    public Vector3 offset;

    public void Start()
    {
        offsetX = 0;
        offsetY = 5;
        offsetZ = -50;
        offset = new Vector3(offsetX, offsetY, offsetZ);
    }


    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        transform.LookAt(target);
    }

}
