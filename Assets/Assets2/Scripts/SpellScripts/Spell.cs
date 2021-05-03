using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Parent class for all spells
public class Spell : MonoBehaviour
{
    [SerializeField] protected GameObject go;
    [SerializeField] public Sprite sprite;
    [SerializeField] protected float cooldown;
    protected Vector3 position;
    protected Vector3 offset;
    
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
        //Call other methods
        //Apply Cooldowns
    }
}
