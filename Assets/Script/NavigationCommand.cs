using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

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
        
        //Passer le NpcState??
        public override IEnumerator Execute()
        {
            while (true)
            {
                int position = (int)Random.Range(0f,_transforms.Count-1);
                _agent.SetDestination(_transforms[position].position); 
                yield return new WaitForSeconds(10f);
            }
        }
    }
}