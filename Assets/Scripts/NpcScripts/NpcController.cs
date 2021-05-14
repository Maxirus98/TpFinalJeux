using System.Collections.Generic;
using Script;
using UnityEngine;
using UnityEngine.AI;

namespace NpcScripts
{
    public class NpcController : MonoBehaviour
    {
        public float lookRadius = 50f;
        private Transform _target;
        private Animator _animator;
        private NavMeshAgent _agent;
        private CharacterStats _characterStats;
        private List<Transform> _checkpoints;
        private readonly List<Command> _commands = new List<Command>();

        void Start()
        {
            NpcManager.Instance.AddNpcAlive();
            _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            _animator = GetComponent<Animator>();
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
                NpcManager.Instance.RemoveNpcAlive();
                gameObject.SetActive(false);
            }
        }
    
    

        private void SetCommands()
        {
            _commands.Add(new NavigationCommand(_agent, _checkpoints));
            _commands.Add(new DetectionCommand(transform, _target, _agent, lookRadius));
            _commands.Add(new AttackCommand(transform, _target, _agent, GetComponent<CharacterCombat>(), _animator));
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, lookRadius);
        }
    }
}