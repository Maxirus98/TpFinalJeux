using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerAnimator : MonoBehaviour
{
    private const float LOCOMOTION_SMOOTH_TIME = .1f;
    private Animator _animator;
    private NavMeshAgent _agent;
    [SerializeField] private GameObject nuage;
    [SerializeField] private GameObject rifle;
    public bool _isAttacking = false;
    private float _attackNumber;
    
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            CallCriDuTonnerre();
        }
        //agent current speed / agent maximum speed
        float speedPercent = _agent.velocity.magnitude / _agent.speed * 10;
        //Will take 0.1 sec to change animation
        _animator.SetFloat("speedPercent", speedPercent, LOCOMOTION_SMOOTH_TIME, Time.deltaTime);
        
    }
    public void Attack()
    {
        _isAttacking = true;
        _animator.SetBool("isAttacking", _isAttacking);
        _animator.SetFloat("AttackNumber", _attackNumber);
        SetAttackNumber();
        //StartCoroutine(CoroutineAttack());
        
    }
    private void CallCriDuTonnerre()
    {
        var cloneNuage = Instantiate(nuage, transform.position,
            Quaternion.AngleAxis(90, new Vector3(1, 0, 0)));
        Destroy(cloneNuage, 1f);
    }    
    public IEnumerator CoroutineAttack()
    {
        yield return new WaitForSeconds(0.5f);
        _isAttacking = false;
        _animator.SetBool("isAttacking", _isAttacking);
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