using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellAoeHit : MonoBehaviour
{
    [SerializeField] private CharacterCombat playerCombat;

    private void Start()
    {
        playerCombat = GameObject.FindWithTag("Player").GetComponent<CharacterCombat>();
    }
    
    //Will not destroy on hit
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            print("spell hit");
            playerCombat.AoEAttack(other.GetComponent<CharacterCombat>().Stats, playerCombat.Stats.spellDamage.Value);
            
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
