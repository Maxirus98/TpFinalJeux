using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpellHit : SpellAoeHit
{
    //Will destroy on hit
    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        Destroy(gameObject);
    }
}
