using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.AI;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

[RequireComponent(typeof(Targeter), typeof(CharacterStats))]
public class PlayerAnimator : MonoBehaviour
{
    private Targeter targeter;
    private Animator _animator;
    private NavMeshAgent _agent;

    public bool _isAttacking = false;
    private float _attackNumber;
    private static readonly float coolDownPeriodAttacks = 0.5f;
    private float attackMaxRange;
    private CharacterStats stats;
    public float TimeStampAttacks { get; set; }

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        stats = GetComponent<CharacterStats>();
        _animator = GetComponentInChildren<Animator>();
        targeter = GetComponent<Targeter>();
    }

    // Update is called once per frame
    void Update()
    {
        targeter.CheckForClosestTarget();
       
        float speedPercent = _agent.velocity.magnitude / _agent.speed * 10;
        _animator.SetFloat("speedPercent", speedPercent);
        
        if (stats.currentHp <= 0)
        {
            _animator.SetBool("isDead", true);
            GameManager.Instance.LoadLevel("GameOver");
        }
    }

    public void Attack()
    {
        attackMaxRange = 6f;
        if (TimeStampAttacks <= Time.time && Vector3.Distance(transform.position, targeter.currentTarget.position) <= attackMaxRange)
        {
            _isAttacking = true;
            _animator.SetBool("isAttacking", _isAttacking);
            _animator.SetFloat("AttackNumber", _attackNumber);
            StartCoroutine(CoroutineAttack());
        }
    }
    public IEnumerator CoroutineAttack()
    {
        yield return new WaitForSeconds(coolDownPeriodAttacks);
        _isAttacking = false;
        _animator.SetBool("isAttacking", _isAttacking);
        TimeStampAttacks = Time.time + coolDownPeriodAttacks;
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