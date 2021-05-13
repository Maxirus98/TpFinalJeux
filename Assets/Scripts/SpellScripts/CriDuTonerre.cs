using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class CriDuTonerre : Spell
{
    private void Update()
    {
        position = transform.position;
        if (Input.GetButton("Jump") && Time.time >= TimeStamp)
        {
            DoSpell();
        }
    }

    public override void Spawn()
    {
        var cloneNuage = Instantiate(go, position,
            Quaternion.AngleAxis(90, new Vector3(1, 0, 0)));
        Destroy(cloneNuage, 1f);
        
    }

    public override void DoSpell()
    {
        Spawn();
        StartCoroutine(Cooldown.WaitFor(cooldown));
        TimeStamp = Time.time + cooldown;
    }
    
    
    
}
