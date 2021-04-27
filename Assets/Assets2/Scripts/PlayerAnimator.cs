using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.AI;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class PlayerAnimator : MonoBehaviour
{

    // TODO : Enlever les méthodes qui n'ont pas rapport avec l'animation du personnage
    private Animator _animator;
    private NavMeshAgent _agent;
    //[SerializeField] private GameObject nuage;

    [SerializeField] private List<Transform> targets;
    public Transform currentTarget;

    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject rifle;
    private Vector3 riflePosition;
    private Vector3 rifleOffset;
    private GameObject cloneRifle;
    private int bulletSpeed;
    private float rifleRange = 3f;


    public bool _isAttacking = false;
    private float _attackNumber;

    private static readonly float coolDownPeriodSpells = 5f;
    private static readonly float coolDownPeriodAttacks = 1f;
    private static readonly float fireRate = 0.5f;

    [SerializeField] private GameObject empaler;
    private GameObject empalerClone;
    private Vector3 empalerPosition;
    private float vitesseEmpaler = 20000f;

    public float TimeStampSpells { get; set; }
    public float TimeStampAttacks { get; set; }
    public float TimeStampFireRate { get; set; }


    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
        rifleOffset = new Vector3(1, 1, 0); // should'nt be there
        targets = new List<Transform>(); // should'nt be there
        
        // should'nt be there
        LookForTargets(); //Il va falloir ajouter a chaque spawn d'ennemi à la liste de target

    }
    // Pour faire apparaitre les items en tournant dans le World
    //cloneRifle.transform.Rotate(Vector3.up, Space.World);

    // Update is called once per frame
    void Update()
    {
        // should'nt be there
        /*if (Input.GetButton("Fire3") && TimeStampSpells <= Time.time)
        {
            //SprayAndPray();
            Empaler();
        }*/

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
// should'nt be there Spell Method
    public void SprayAndPray()
    {
        SprayAndPraySpawnGun();
        StartCoroutine(Cooldown.WaitFor(coolDownPeriodSpells));
        TimeStampSpells = Time.time + coolDownPeriodSpells;
        
        if (cloneRifle)
        {
            //Suivre le joueur
            riflePosition = transform.position + rifleOffset;
            cloneRifle.transform.position = riflePosition;

            CheckForClosestTarget();
            //Rotate en fonction des ennemis
            Vector3 direction = currentTarget.position - cloneRifle.transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction) * Quaternion.Euler(90, 0, 0);
            cloneRifle.transform.rotation = rotation;
            StartCoroutine(Cooldown.WaitFor(0.1f));

            SprayAndPrayShooting();
        }
    }
// should'nt be there Spawn
    private void SprayAndPraySpawnGun()
    {
        cloneRifle = Instantiate(rifle, riflePosition, Quaternion.Euler(90, 180, 0));
        Destroy(cloneRifle, coolDownPeriodSpells);

    }
// should'nt be there Shoot Many until disappear
    private void SprayAndPrayShooting()
    {
        if (Vector3.Distance(cloneRifle.transform.position, currentTarget.position) <= 6f &&
            TimeStampFireRate <= Time.time)
        {
            var gunBarrel = cloneRifle.transform.GetChild(3);
            gunBarrel.LookAt(currentTarget.transform);
            var cloneBullet = Instantiate(bullet, gunBarrel.position, Quaternion.identity);
            var bulletRb = cloneBullet.GetComponent<Rigidbody>();
            bulletSpeed = 10;
            
            //Time.deltaTime and normalized ?
            bulletRb.velocity = gunBarrel.transform.rotation * Vector3.forward * bulletSpeed;
            TimeStampFireRate = Time.time + fireRate;
        }
    }
// should'nt be there SpellMethod
    public void Empaler()
    {
        SpawnEmpaler();
        ThrustEmpaler();
        StartCoroutine(Cooldown.WaitFor(coolDownPeriodSpells));
        TimeStampSpells = Time.time + coolDownPeriodSpells;
    }
// should'nt be there Spawn
    private void SpawnEmpaler()
    {
        empalerClone = Instantiate(empaler, (transform.position + transform.forward), transform.rotation);
        Destroy(empalerClone, 2);
    }
// should'nt be there Shooting Once
    private void ThrustEmpaler()
    {
        empalerClone.GetComponent<Rigidbody>().velocity = (transform.forward * (vitesseEmpaler * Time.deltaTime));
    }
// should'nt be there SprayAndPray only
    public void LookForTargets()
    {
        var others = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var go in others)
        {
            targets.Add(go.transform);
        }

        currentTarget = targets[0];
    }
// should'nt be there SprayAndPray only
    public void CheckForClosestTarget()
    {
        foreach(Transform target in targets)
        {
            if (Vector3.Distance(transform.position, target.position) <
                Vector3.Distance(transform.position, currentTarget.position))
            {
                if(target != null)
                currentTarget = target;
            }
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