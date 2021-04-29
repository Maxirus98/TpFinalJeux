using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Spell
{
    private Animator animator;
    // Update is called once per frame
    private void Start()
    {
        animator = GetComponent<Animator>();
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
        TimeStamp = Time.time + cooldown;
    }
}
