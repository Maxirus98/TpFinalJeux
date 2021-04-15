using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

public class PlayerAnimator : MonoBehaviour
{
    private const float LOCOMOTION_SMOOTH_TIME = .1f;
    private Animator _animator;
    private NavMeshAgent _agent;
    [SerializeField] private GameObject nuage;
    [SerializeField] private GameObject rifle;
    private Vector3 riflePosition;
    private Quaternion rifleQuaternion;
    private Vector3 rifleOffset;
    private GameObject cloneRifle;
    [SerializeField] private GameObject bullet;

    private Quaternion riflePivot;
    
    public bool _isAttacking = false;
    private float _attackNumber;
    private  static readonly float coolDownPeriodSpells = 5f;
    

    public float TimeStamp { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
        riflePivot = Quaternion.FromToRotation (Vector3.back, Vector3.left);
    }

    // Update is called once per frame
    void Update()
    {
        if (cloneRifle)
        {
            var position = transform.position;
            riflePosition = position + rifleOffset;
            cloneRifle.transform.position = riflePosition;
            cloneRifle.transform.rotation = Quaternion.FromToRotation (Vector3.forward, Vector3.left);

            cloneRifle.transform.localPosition = Quaternion.RotateTowards(transform.rotation, riflePivot, 20 * Time.deltaTime)
                                                 * cloneRifle.transform.localPosition;
            cloneRifle.transform.localPosition = Quaternion.LookRotation(cloneRifle.transform.localPosition * -1, Vector3.left) * cloneRifle.transform.localPosition;
        }
        if (Input.GetButton("Jump") && TimeStamp <= Time.time)
        {
            CallCriDuTonnerre();
        }

        if (Input.GetButton("Fire3") && TimeStamp <= Time.time)
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
        StartCoroutine(Cooldown.WaitFor(coolDownPeriodSpells));
        TimeStamp = Time.time + coolDownPeriodSpells;
    }
    
    private void SprayAndPraySpawnGun()
    {
        cloneRifle = Instantiate(rifle, riflePosition, Quaternion.Euler(90, 180, 0));
        Destroy(cloneRifle, 5);
    }
    private void SprayAndPrayShooting()
    {
        var cloneBullet = Instantiate(bullet, cloneRifle.transform.GetChild(3).position, Quaternion.Euler(90, 0, 0));
        var bulletRb = cloneBullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(Vector3.back * 10, ForceMode.Impulse);
        Destroy(cloneBullet, 1f);
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