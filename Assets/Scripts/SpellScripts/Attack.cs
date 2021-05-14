using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Spell
{
    private Animator animator;
    private Targeter targeter;
    
    // Update is called once per frame
    private void Start()
    {
        animator = GetComponent<Animator>();
        targeter = GetComponent<Targeter>();
    }

    void Update()
    {
        offset = transform.up + (transform.right * 2);
        position = transform.position + offset;
        if (Input.GetMouseButton(1) && Time.time >= TimeStamp && animator.GetBool("isAttacking"))
        {
            DoSpell();
        }
    }

    public override void Spawn()
    {
        var cloneAttackArch = Instantiate(go, position, transform.rotation * Quaternion.Euler(90, 0, 0));
        Destroy(cloneAttackArch, cooldown);
    }

    public override void DoSpell()
    {
        Spawn();
        gameObject.transform.LookAt(targeter.currentTarget);
        TimeStamp = Time.time + cooldown;
    }
}
