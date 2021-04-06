using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Script
{
    public class DetectionCommand : Command
    {
        private readonly Transform _target;
        private readonly Transform _transform;
        private readonly NavMeshAgent _agent;
        private readonly float _lookRadius;
        private float _distance;

        public DetectionCommand(
            Transform transform,
            Transform target,
            NavMeshAgent agent,
            float lookRadius,
            float distance
            )
        {
            _transform = transform;
            _target = target;
            _agent = agent;
            _lookRadius = lookRadius;
            _distance = distance;
        }

        public override IEnumerator Execute()
        {
            //add a sound of war for npc
            if (_distance <= _lookRadius)
            {
                _agent.isStopped = false;
                _agent.SetDestination(_target.position);
            }

            if (_distance >= _lookRadius + 5)
            {
                yield break;
            }
        }
    }
}