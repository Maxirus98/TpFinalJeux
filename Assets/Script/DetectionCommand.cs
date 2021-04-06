using UnityEngine;
using UnityEngine.AI;

namespace Script
{
    public class DetectionCommand : Command
    {
        private readonly Transform _target;
        private readonly NavMeshAgent _agent;
        private readonly float _lookRadius;
        private readonly float _distance;

        public DetectionCommand(
            Transform target,
            NavMeshAgent agent,
            float lookRadius,
            float distance
            )
        {
            _target = target;
            _agent = agent;
            _lookRadius = lookRadius;
            _distance = distance;
        }

        public override void Execute()
        {
            //add a sound of war
            if (_distance <= _lookRadius)
            {
                _agent.isStopped = false;
                _agent.SetDestination(_target.position);
            }

            if (_distance >= _lookRadius + 5)
            {
                _agent.isStopped = true;
            }
        }
    }
}