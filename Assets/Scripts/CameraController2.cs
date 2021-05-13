using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController2 : MonoBehaviour
{
    public float smoothSpeed = 0.3f;
    public Vector3 offset;
    private Transform _playerTransform;
    void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = _playerTransform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position,desiredPosition,smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
        transform.LookAt(_playerTransform);
    }

}

