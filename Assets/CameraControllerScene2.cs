using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraControllerScene2 : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Transform playerTransform;
    public Vector3 cameraOffset;
    public float speed = 0.5f;

    void LateUpdate()
    {
        Vector3 desiredPosition = playerTransform.position + cameraOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position,desiredPosition,speed * Time.deltaTime);
        transform.position = smoothedPosition;
        var horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        transform.Rotate(horizontal * Vector3.up,Space.World);
    }


    /*
     * public Transform capsule;
public int speed = 10;
// Update is called once per frame
void Update()
{    var horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
    transform.Translate(Vector3.right * horizontal);
    var vertical = Input.GetAxis("Vertical") * Time.deltaTime * speed;
    transform.Translate(Vector3.forward * vertical);
    var axe3 = Input.GetAxis("AxeLeftRight") * Time.deltaTime * speed;
    //Up = Vecteur sur la verticale
    transform.Rotate(Vector3.up * axe3);
    transform.position = capsule.position;
    //transform.LookAt(capsule);
}
     */
}
