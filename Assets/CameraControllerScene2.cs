using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerScene2 : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Transform playerTransform;
    public Vector3 cameraOffset;
    public float smoothFactor = 0.5f;

     void Start()
     {
         cameraOffset = transform.position - playerTransform.position; 
     }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPosition = playerTransform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position,newPosition,smoothFactor);
    }
}
