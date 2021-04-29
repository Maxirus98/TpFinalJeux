using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    private CharacterStats stats;
    
    private void Start()
    {
        stats = GetComponent<CharacterStats>();
    }

    public void Attack(CharacterStats targetStats)
    {
        /*if (cd <= 0f)
        {
           
        }*/
        Debug.Log(stats.damage.GetValue());
        targetStats.TakeDamage(stats.damage.GetValue());
        //cd = 1f / atkSpeed;
    }
}
