﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class PlayerAnimator : MonoBehaviour
{
    private const float LOCOMOTION_SMOOTH_TIME = .1f;
    private Animator _animator;
    private NavMeshAgent _agent;
    [SerializeField] private GameObject nuage;
    
    [SerializeField] private GameObject rifle;
    [SerializeField] private Transform target;
    private Vector3 riflePosition;
    private Vector3 rifleOffset;
    private GameObject cloneRifle;
    private int bulletSpeed;
    private float rifleRange = 3f;
    
    [SerializeField] private GameObject bullet;

    public bool _isAttacking = false;
    private float _attackNumber;

    private  static readonly float coolDownPeriodSpells = 5f;
    private  static readonly float coolDownPeriodAttacks = 0.5f;
    private  static readonly float fireRate = 0.5f;


    public float TimeStampSpells { get; set; }
    public float TimeStampAttacks { get; set; }
    public float TimeStampFireRate { get; set; }
    

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
        rifleOffset = new Vector3(1, 1, 0);

    }
    // Pour faire apparaitre les items en tournant dans le World
    //cloneRifle.transform.Rotate(Vector3.up, Space.World);

    // Update is called once per frame
    void Update()
    {
        if (cloneRifle)
        {
            //Suivre le joueur
            riflePosition = transform.position + rifleOffset;
            cloneRifle.transform.position = riflePosition;
            
            //Rotate en fonction des ennemis
            Vector3 direction = target.position - cloneRifle.transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction) * Quaternion.Euler(90, 0, 0);
            cloneRifle.transform.rotation = rotation;
            StartCoroutine(Cooldown.WaitFor(0.1f));

            SprayAndPrayShooting();
        }
        if (Input.GetButton("Jump") && TimeStampSpells <= Time.time)
        {
            CallCriDuTonnerre();
        }

        if (Input.GetButton("Fire3") && TimeStampSpells <= Time.time)
        {
            SprayAndPray();
        }

        //agent current speed / agent maximum speed
        float speedPercent = _agent.velocity.magnitude / _agent.speed * 10;
        //Will take 0.1 sec to change animation
        _animator.SetFloat("speedPercent", speedPercent, LOCOMOTION_SMOOTH_TIME, Time.deltaTime);

    }

    public void Attack()
    {
        if (TimeStampSpells <= Time.time)
        {
            _isAttacking = true;
            _animator.SetBool("isAttacking", _isAttacking);
            _animator.SetFloat("AttackNumber", _attackNumber);
            StartCoroutine(CoroutineAttack());
        }
       
    }

    private void CallCriDuTonnerre()
    {
        var cloneNuage = Instantiate(nuage, transform.position,
            Quaternion.AngleAxis(90, new Vector3(1, 0, 0)));
        Destroy(cloneNuage, 1f);
        StartCoroutine(Cooldown.WaitFor(coolDownPeriodSpells));
        TimeStampSpells = Time.time + coolDownPeriodSpells;
    }

    private void SprayAndPray()
    {
        SprayAndPraySpawnGun();
        StartCoroutine(Cooldown.WaitFor(coolDownPeriodSpells));
        TimeStampSpells = Time.time + coolDownPeriodSpells;
    }
    
    private void SprayAndPraySpawnGun()
    {
        cloneRifle = Instantiate(rifle, riflePosition, Quaternion.Euler(90, 180, 0));
            Destroy(cloneRifle, 5);
        
    }
    private void SprayAndPrayShooting()
    {
        if (Vector3.Distance(cloneRifle.transform.position, target.position) <= 6f && TimeStampFireRate <= Time.time)
        {
            var gunBarrel = cloneRifle.transform.GetChild(3);
            var cloneBullet = Instantiate(bullet, gunBarrel.position, Quaternion.identity);
            var bulletRb = cloneBullet.GetComponent<Rigidbody>();
            bulletSpeed = 300;
            bulletRb.AddForce(bulletRb.transform.right * bulletSpeed); 
            TimeStampFireRate = Time.time + fireRate;
            
            Destroy(cloneBullet, 1f);
           
        }
    }

    public IEnumerator CoroutineAttack()
    {
        yield return new WaitForSeconds(coolDownPeriodAttacks);
        TimeStampAttacks= Time.time + coolDownPeriodAttacks;
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