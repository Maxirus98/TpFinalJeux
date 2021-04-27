using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class SprayAndPray : Spell
{
    private GameObject cloneRifle;

    [SerializeField] private Transform currentTarget;
    [SerializeField] private List<Transform> targets;
    
    [SerializeField] private GameObject bullet;
    private float bulletSpeed;
    public float TimeStampFireRate { get; set; }

    public float fireRate;

    private float maxRange;

    private void Start()
    {
        LookForTargets();
    }

    // Update is called once per frame
    void Update()
    {
        offset = new Vector3(1, 1, 0);
        position = transform.position + offset;
        if (cloneRifle)
        {
            
            //Suivre le joueur;
            cloneRifle.transform.position = position;
        
            CheckForClosestTarget();
            //Rotate en fonction des ennemis
            Vector3 direction = currentTarget.position - cloneRifle.transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction) * Quaternion.Euler(90, 0, 0);
            cloneRifle.transform.rotation = rotation;
            StartCoroutine(Cooldown.WaitFor(fireRate));
            Shoot();
            
        }
        if (Input.GetButton("Jump") && Time.time >= TimeStamp)
        {
            DoSpell();
        }
    }

    public override void Spawn()
    {
        cloneRifle = Instantiate(go, position, Quaternion.Euler(90, 180, 0));
        Destroy(cloneRifle, cooldown);
    }

    public override void Shoot()
    {
        maxRange = 10f;
        fireRate = 0.5f;
        
        if (Vector3.Distance(cloneRifle.transform.position, currentTarget.position) <= maxRange &&
            TimeStampFireRate <= Time.time)
        {
            var gunBarrel = cloneRifle.transform.GetChild(3);
            gunBarrel.LookAt(currentTarget.transform);
            var cloneBullet = Instantiate(bullet, gunBarrel.position, Quaternion.Euler(0, 90, 0));
            var bulletRb = cloneBullet.GetComponent<Rigidbody>();
            bulletSpeed = 10;
            
            //Time.deltaTime and normalized ?
            bulletRb.velocity = gunBarrel.transform.rotation * Vector3.forward * bulletSpeed;
            TimeStampFireRate = Time.time + fireRate;
        }
    }

    public override void DoSpell()
    {
        Spawn();
        StartCoroutine(Cooldown.WaitFor(cooldown));
        TimeStamp = Time.time + cooldown;
    }

    public void LookForTargets()
    {
        var others = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var go in others)
        {
            targets.Add(go.transform);
        }

        currentTarget = targets[0];
    }

    public void CheckForClosestTarget()
    {
        foreach(Transform target in targets)
        {
            if (target)
            {
                if (Vector3.Distance(transform.position, target.position) <
                    Vector3.Distance(transform.position, currentTarget.position))
                {
                    currentTarget = target;
                }
            }
                
        }
    }
}
