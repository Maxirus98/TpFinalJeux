using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
[RequireComponent(typeof(Targeter))]
public class SprayAndPray : Spell
{
    private GameObject cloneRifle;
    private Targeter targeter;
    

    [SerializeField] private GameObject bullet;
    private float bulletSpeed;
    public float TimeStampFireRate { get; set; }

    public float fireRate = 0.5f;

    private float maxRange;
    
    private void Start()
    {
        targeter = GetComponent<Targeter>();
        fireRate = 0.5f;

    }   
    
    void Update()
    {
        offset = new Vector3(1, 1, 0);
        position = transform.position + offset;
        if (cloneRifle)
        {
            
            
            cloneRifle.transform.position = position;
        
            targeter.CheckForClosestTarget();
            
            Vector3 direction = targeter.currentTarget.position - cloneRifle.transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction) * Quaternion.identity;
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
        cloneRifle = Instantiate(go, position, Quaternion.identity);
        Destroy(cloneRifle, cooldown);
    }

    public override void Shoot()
    {
        maxRange = 10f;
        bulletSpeed = 20;
        
        if (targeter.currentTarget.gameObject.activeInHierarchy)
        {
            if (Vector3.Distance(cloneRifle.transform.position, targeter.currentTarget.position) <= maxRange &&
                TimeStampFireRate <= Time.time)
            {
                var gunBarrel = cloneRifle.transform.GetChild(3);
                gunBarrel.LookAt(targeter.currentTarget.transform);
                var cloneBullet = Instantiate(bullet, gunBarrel.position, Quaternion.Euler(0, 90, 0));
                var bulletRb = cloneBullet.GetComponent<Rigidbody>();
                
                
                bulletRb.velocity = gunBarrel.transform.rotation * Vector3.forward.normalized * bulletSpeed;
                TimeStampFireRate = Time.time + fireRate;
                Destroy(cloneBullet, 1f);
                
            }
        }
    }

    public override void DoSpell()
    {
        Spawn();
        StartCoroutine(Cooldown.WaitFor(cooldown));
        TimeStamp = Time.time + cooldown;
    }
    
    public GameObject GetBulletGo()
    {
        return bullet;
    }
}
