using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Script
{
    public class NavigationCommand : Command
    {
        private readonly List<Transform> _transforms;
        private readonly NavMeshAgent _agent;

        public NavigationCommand(NavMeshAgent agent,List<Transform> transforms)
        {
            _transforms = transforms;
            _agent = agent;
            _agent.isStopped = false;
        }

        public override IEnumerator Execute()
        {
            
            foreach (var transform in _transforms)
            { 
                _agent.SetDestination(transform.position); 
                yield return new WaitForSeconds(5f);
            }
        }
    }
}