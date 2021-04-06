using System.Collections.Generic;
using Script;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class NpcController : MonoBehaviour
{
    public float lookRadius = 50f;
    private Transform _target;
    private float _distance;
    private NavMeshAgent _agent;
    private List<Transform> _checkpoints;
    private NavigationCommand _navigationCommand;
    private DetectionCommand _detectionCommand;

    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _agent = GetComponent<NavMeshAgent>();
        _checkpoints = new List<Transform>(GameObject.Find("CheckPoints").GetComponentsInChildren<Transform>());
        SetDetectionCommand(_target,_agent);
        SetNavigationCommand();
    }

    void Update()
    {
        _distance = Vector3.Distance(_target.position, transform.position);
        if (_distance <= lookRadius)
        {
            StartCoroutine(_detectionCommand.Execute());
        }
    }
    private void SetDetectionCommand(Transform target, NavMeshAgent agent)
    {
        _detectionCommand = new DetectionCommand(transform, target, agent, lookRadius, _distance);
    }

    private void SetNavigationCommand()
    {
        _navigationCommand = new NavigationCommand(_agent, _checkpoints);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,lookRadius);
    }
}
