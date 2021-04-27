using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent _agent;
    
    float _movementSpeed = 10f;
    private float _rotationSpeed = 999f;
    private float _accelerationSpeed = 999f;
    private float _stoppingDistance = 1f;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = _movementSpeed;
        _agent.angularSpeed = _rotationSpeed;
        _agent.acceleration = _accelerationSpeed;
        _agent.autoBraking = true;
        _agent.stoppingDistance = _stoppingDistance;
    }
}
