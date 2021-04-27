using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.AI;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private NavMeshAgent _agent;

    public bool _isAttacking = false;
    private float _attackNumber;
    private static readonly float coolDownPeriodAttacks = 1f;
    public float TimeStampAttacks { get; set; }
    
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
    }
    // Pour faire apparaitre les items en tournant dans le World
    //cloneRifle.transform.Rotate(Vector3.up, Space.World);

    // Update is called once per frame
    void Update()
    {
        //agent current speed / agent maximum speed
        float speedPercent = _agent.velocity.magnitude / _agent.speed * 10; 
        //Will take 0.1 sec to change animation
        _animator.SetFloat("speedPercent", speedPercent);
    }

    public void Attack()
    {
        if (TimeStampAttacks <= Time.time)
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
        yield return new WaitForSeconds(coolDownPeriodAttacks);
        _isAttacking = false;
        _animator.SetBool("isAttacking", _isAttacking);
        TimeStampAttacks= Time.time + coolDownPeriodAttacks;
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