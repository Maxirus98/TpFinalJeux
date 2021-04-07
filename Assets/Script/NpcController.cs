using System.Collections.Generic;
using Script;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class NpcController : MonoBehaviour
{
    //Repasser pour voir ce qui n'ont pas besoin d'être private
    public float lookRadius = 50f;
    private NpcState _npcState;
    private Transform _target;
    private float _distance;
    private NavMeshAgent _agent;
    private List<Transform> _checkpoints;
    private DetectionCommand _detectionCommand;

    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _agent = GetComponent<NavMeshAgent>();
        _checkpoints = new List<Transform>(GameObject.Find("CheckPoints").GetComponentsInChildren<Transform>());
        SetDetectionCommand(_target,_agent);
    }

    void Update()
    {
        StartCoroutine(_detectionCommand.Execute());
    }
    private void SetDetectionCommand(Transform target,  NavMeshAgent agent)
    {
        _detectionCommand = new DetectionCommand(  transform,target, agent, lookRadius);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,lookRadius);
    }
    
}

public enum NpcState
{
    Detecting,
    Navigating
}
