using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpellStat))]
public class SpellHit : MonoBehaviour
{
    private CharacterCombat playerCombat;
    private SpellStat damage;

    private void Start()
    {
        damage = GetComponent<SpellStat>();
        playerCombat = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterCombat>();
    }

    //Will destroy on hit
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            print("spell hit");
            playerCombat.PlayerSingleAttack(other.GetComponent<CharacterCombat>().Stats, damage.getValue());
            
        }
    }
}
