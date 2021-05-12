using System;
using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[Serializable]
public class OnBossDeath : UnityEvent<Vector3>
{
    //ICI : Vector3 est le paramètre pour le handler event qui va se faire appeler
    //1. déFINIR LA CLASSE D'ÉVÉNEMENT avec les param qu'on veut passer
}
public class NpcController : MonoBehaviour
{
    //Repasser pour voir ce qui n'ont pas besoin d'être private
    public float lookRadius = 50f;
    private Transform _target;
    private Animator _animator;
    private AudioSource _audioSource;
    private NavMeshAgent _agent;
    private CharacterStats _characterStats;
    private List<Transform> _checkpoints;
    private readonly List<Command> _commands = new List<Command>();

    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _agent = GetComponent<NavMeshAgent>();
        _characterStats = GetComponent<CharacterStats>();
        _checkpoints = new List<Transform>(GameObject.Find("CheckPoints").GetComponentsInChildren<Transform>());

        SetCommands();
        StartCoroutine(_commands[0].Execute());
    }
    
    

    void Update()
    {
        StartCoroutine(_commands[1].Execute());
        StartCoroutine(_commands[2].Execute());
        if (_characterStats.currentHp <= 0)
        {
            //animation or effect
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
    
    

    private void SetCommands()
    {
        _commands.Add(new NavigationCommand(_agent, _checkpoints));
        _commands.Add(new DetectionCommand(transform, _target, _agent, lookRadius));
        _commands.Add(new AttackCommand(transform, _target, _agent, GetComponent<CharacterCombat>(), _animator, _audioSource));
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}