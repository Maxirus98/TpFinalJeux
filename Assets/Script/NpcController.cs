using System.Collections.Generic;
using Script;
using UnityEngine;
using UnityEngine.AI;

public class NpcController : MonoBehaviour
{
    public float lookRadius = 10f;
    private Transform _target;
    private NavMeshAgent _agent;
    private List<Transform> _transforms;
     
    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distance = Vector3.Distance(_target.position, transform.position);
        new DetectionCommand(_target,_agent,lookRadius,distance).Execute();
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,lookRadius);
    }
}

public enum NpcState
{
    Navigation,
    Detection,
    Attacking
}