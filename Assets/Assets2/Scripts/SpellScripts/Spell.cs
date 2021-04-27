using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Parent class for all spells
public class Spell : MonoBehaviour
{
    public GameObject go;
    public float cooldown;
    public Vector3 position;
    public Vector3 offset;
    
    public float TimeStamp { get; set; }
    public virtual void Spawn()
    {
        //Instantiate
    }

    public virtual void Shoot()
    {
        //apply velocity
    }

    public virtual void DoSpell()
    {
        //Instantiate
        //Apply velocity
        //Apply Cooldowns
    }
}
