using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    public CharacterStats stats;

    private void Start()
    {
        stats = GetComponent<CharacterStats>();
    }

    private void Update()
    {
        stats.cooldown.Value -= Time.deltaTime;
    }

    public void AttackTarget(CharacterStats targetStats)
    {
        if (stats.cooldown.Value <= 0f)
        {
            targetStats.TakeDamage(stats.damage.Value);
            stats.cooldown.Value = 1f / stats.attackSpeed.Value;
        }
    }
}
