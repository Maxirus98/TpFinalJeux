using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Script
{
    public class DetectionCommand : Command
    {
        private readonly Transform _transform;
        private readonly Transform _target;
        private readonly NavMeshAgent _agent;
        private readonly float _lookRadius;
        private float _distance;

        public DetectionCommand(
            Transform transform,
            Transform target,
            NavMeshAgent agent,
            float lookRadius
            )
        {
            _transform = transform;
            _target = target;
            _agent = agent;
            _lookRadius = lookRadius;
        }

        public override IEnumerator Execute()
        {
            _distance = Vector3.Distance(_target.position, _transform.position);
            //add a sound of war for npc
            if (_distance <= _lookRadius && _agent)
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