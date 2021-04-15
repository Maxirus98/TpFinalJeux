using System.Collections;
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
    private readonly List<Command> _commands = new List<Command>() ;
    private DetectionCommand _detectionCommand;
    private NavigationCommand _navigationCommand;

    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _agent = GetComponent<NavMeshAgent>();
        _checkpoints = new List<Transform>(GameObject.Find("CheckPoints").GetComponentsInChildren<Transform>());
        _commands.Add(new NavigationCommand(_agent, _checkpoints));
        _commands.Add(new DetectionCommand(transform,_target, _agent, lookRadius));
        StartCoroutine(_commands[0].Execute());
    }

    void Update()
    {
       StartCoroutine(_commands[1].Execute());
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
