using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpellStat))]
public class SpellAoeHit : MonoBehaviour
{
    [SerializeField] private CharacterCombat playerCombat;
    private SpellStat damage;

    private void Start()
    {
        damage = GetComponent<SpellStat>();
        playerCombat = GameObject.FindWithTag("Player").GetComponent<CharacterCombat>();
    }
    
    //Will not destroy on hit
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            print("spell hit");
            playerCombat.AoEAttack(other.GetComponent<CharacterCombat>().Stats, damage.getValue());
            
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
