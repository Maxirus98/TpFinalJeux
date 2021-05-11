using System;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class CameraController : MonoBehaviour
{
    public float smoothSpeed = 0.3f;
    private Transform _playerTransform;
    public Vector3 offset;
    private bool firstPersonMax = false;
    private bool thirdPersonMax;
    
    void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 desiredPosition = _playerTransform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position,desiredPosition,smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
        transform.LookAt(_playerTransform);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, 10))
        {
            if (!hit.collider.CompareTag("Player"))
            {
                hit.collider.GetComponent<MeshRenderer>().enabled = false;
                hit.collider.enabled = false;
                print(hit.collider.GetComponent<MeshRenderer>().enabled);
            }
        }
    }
    
}
