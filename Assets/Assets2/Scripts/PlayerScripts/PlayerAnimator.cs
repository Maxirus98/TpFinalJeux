using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.AI;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

[RequireComponent(typeof(Targeter))]
public class PlayerAnimator : MonoBehaviour
{
    private Targeter targeter;
    private Animator _animator;
    private NavMeshAgent _agent;

    public bool _isAttacking = false;
    private float _attackNumber;
    private static readonly float coolDownPeriodAttacks = 1f;
    private float attackMaxRange;
    private CharacterCombat combat;
    
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
        targeter = GetComponent<Targeter>();
        combat = GetComponent<CharacterCombat>();
    }
    // Pour faire apparaitre les items en tournant dans le World
    //cloneRifle.transform.Rotate(Vector3.up, Space.World);

    // Update is called once per frame
    void Update()
    {
        //agent current speed / agent maximum speed
        
            float speedPercent = _agent?_agent.velocity.magnitude / _agent.speed * 10:0f; 
            //Will take 0.1 sec to change animation
            _animator.SetFloat("speedPercent", speedPercent);
        
    }

    public void Attack()
    {
        attackMaxRange = 6f;
        if (combat.stats.cooldown.Value <= 0f && Vector3.Distance(transform.position, targeter.currentTarget.position) <= attackMaxRange)
        {
            _isAttacking = true;
            _animator.SetBool("isAttacking", _isAttacking);
            _animator.SetFloat("AttackNumber", _attackNumber);
            StartCoroutine(CoroutineAttack());
        }
    }
    public IEnumerator CoroutineAttack()
    {
        //Change for Animation Time?
        yield return new WaitForSeconds(combat.stats.cooldown.Value);
        print(combat.stats.cooldown.Value);
        _isAttacking = false;
        _animator.SetBool("isAttacking", _isAttacking);
        SetAttackNumber();
    }
    void SetAttackNumber()
    {
        if (_attackNumber < 2)
        {
            _attackNumber++;
        }
        else
        {
            _attackNumber = 0;
        }
    }
}