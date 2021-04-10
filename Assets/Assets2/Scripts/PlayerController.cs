using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent _agent;
    
    private float hp = 200f;
    public string abilityName = String.Empty;
    float _movementSpeed = 10f;
    private float _rotationSpeed = 999f;
    private float _accelerationSpeed = 999f;
    private float _stoppingDistance = 1f;
    private float _attackRange = 1f;
    
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
    
    private void OnDrawGizmos()
    {
        //callback function in unity
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _attackRange);
    }
    
}
