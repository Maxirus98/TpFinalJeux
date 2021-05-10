using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpellAoeHit : MonoBehaviour
{
    [SerializeField]protected CharacterCombat combat;
    [SerializeField]protected float damage;
    [SerializeField]protected string tag;
    [SerializeField]protected  string targetTag;
    public float tmpDamage;

    public float GetSpellDamage()
    {
        return damage;
    }
    public void DoubleSpellDamage()
    {
        tmpDamage = damage * 2;
    }

    private void Start()
    {
        if (targetTag == null) targetTag = "Enemy";
        if (tag == null) targetTag = "Player";
        combat = GameObject.FindWithTag(tag).GetComponent<CharacterCombat>();
    }
    
    //Will not destroy on hit
    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            print("spell hit for " + damage);
            combat.Attack(other.GetComponent<CharacterCombat>().Stats, tmpDamage);
        }
    }

    //Used for meteors and buses
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            print("spell hit");
            combat.Attack(other.gameObject.GetComponent<CharacterCombat>().Stats, tmpDamage);
        }
    }

    //Works on fixed update, which isn't good 
    /*private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            print("tear hit");
        }
    }*/
}
