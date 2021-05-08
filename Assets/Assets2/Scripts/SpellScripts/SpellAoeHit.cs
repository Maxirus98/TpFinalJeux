using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpellStat))]
public class SpellAoeHit : MonoBehaviour
{
    [SerializeField]private CharacterCombat combat;
    private SpellStat damage;
    public string tag;
    public string targetTag;

    private void Start()
    {
        if (targetTag == null) targetTag = "Enemy";
        if (tag == null) targetTag = "Player";
        damage = GetComponent<SpellStat>();
        combat = GameObject.FindWithTag(tag).GetComponent<CharacterCombat>();
    }
    
    //Will not destroy on hit
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            print("spell hit");
            combat.AoEAttack(other.GetComponent<CharacterCombat>().Stats, damage.getValue());
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            print("spell hit");
            combat.AoEAttack(other.gameObject.GetComponent<CharacterCombat>().Stats, damage.getValue());
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
