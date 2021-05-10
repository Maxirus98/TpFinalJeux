using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Script
{
    public class AttackCommand : Command
    {
        private readonly Transform _transform;
        private readonly Transform _target;
        private readonly NavMeshAgent _agent;
        private readonly CharacterCombat _combat;
        private readonly Animator _animator;

        public AttackCommand(
            Transform transform,
            Transform target,
            NavMeshAgent agent,
            CharacterCombat combat,
            Animator animator
        )
        {
            _animator = animator;
            _transform = transform;
            _target = target;
            _agent = agent;
            _combat = combat;
        }


        public override IEnumerator Execute()
        {
            float distance = Vector3.Distance(_target.position, _transform.position);

            if (distance <= _agent.stoppingDistance)
            {
                CharacterStats targetStats = _target.GetComponent<CharacterStats>();

                if (distance <= _agent.stoppingDistance )
                {
                    _animator.SetBool("isAttacking", true);
                    _combat.Attack(targetStats);
                }
            }

            if (distance > _agent.stoppingDistance && _animator.GetBool("isAttacking"))
            {
                _animator.SetBool("isAttacking", false);
            }

            yield break;
        }
    }
}