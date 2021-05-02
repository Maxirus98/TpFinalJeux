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
                if (targetStats)
                {
                    Debug.Log("startAttack");
                    _animator.SetBool("attacking", true);
                    _combat.Attack(targetStats);
                }
            }
            else
            {
                Debug.Log("stopAttack");
                _animator.SetBool("attacking", false);
                yield break;
            }
        }
    }
}