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
    private NavigationCommand _navigationCommand;

    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _agent = GetComponent<NavMeshAgent>();
        _checkpoints = new List<Transform>(GameObject.Find("CheckPoints").GetComponentsInChildren<Transform>());
        //SetDetectionCommand();
        SetNavigationCommand(_agent,_checkpoints);
        StartCoroutine(_navigationCommand.Execute());
    }

    void Update()
    {
        //StartCoroutine(_detectionCommand.Execute());
    }
    private void SetDetectionCommand()
    {
        _detectionCommand = new DetectionCommand(transform,_target, _agent, lookRadius);
    }

    private void SetNavigationCommand(NavMeshAgent agent, List<Transform> checkpoints)
    {
        _navigationCommand = new NavigationCommand(agent, checkpoints);
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
