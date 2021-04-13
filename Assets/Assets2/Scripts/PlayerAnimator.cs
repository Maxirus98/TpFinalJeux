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
    private GameObject cloneRifle;
    [SerializeField] private GameObject bullet;
    
    public bool _isAttacking = false;
    private float _attackNumber;
    private  static readonly float coolDownPeriodSpells = 5f;
    

    public float TimeStamp { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump") && TimeStamp <= Time.time)
        {
            CallCriDuTonnerre();
        }

        if (Input.GetButton("Fire2") && TimeStamp <= Time.time)
        {
            SprayAndPray();
        }

        //agent current speed / agent maximum speed
        float speedPercent = _agent.velocity.magnitude / _agent.speed * 10;
        //Will take 0.1 sec to change animation
        _animator.SetFloat("speedPercent", speedPercent, LOCOMOTION_SMOOTH_TIME, Time.deltaTime);

    }

    private IEnumerator WaitFor(float coolDownPeriod)
    {
        yield return new WaitForSeconds(coolDownPeriod);
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
        //StartCoroutine(waitFor(coolDownPeriodSpells));
        TimeStamp = Time.time + coolDownPeriodSpells;
    }

    private void SprayAndPray()
    {
        SprayAndPraySpawnGun();
        StartCoroutine(WaitFor(coolDownPeriodSpells));
        TimeStamp = Time.time + coolDownPeriodSpells;
    }
    
    private void SprayAndPraySpawnGun()
    {
        cloneRifle = Instantiate(rifle, transform.position, Quaternion.identity);
        Destroy(cloneRifle, 5);
    }
    private void SprayAndPrayShooting()
    {
        var cloneBullet = Instantiate(bullet, cloneRifle.transform.GetChild(3).position, Quaternion.Euler(90, 0, 0));
        var bulletRb = cloneBullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(Vector3.back * 10, ForceMode.Impulse);
        Destroy(cloneBullet, 1f);
    }

    private void SprayAndPrayRotateAround()
    {
        
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