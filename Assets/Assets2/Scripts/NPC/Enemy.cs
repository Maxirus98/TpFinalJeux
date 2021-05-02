using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable
{
    private PlayerManager playerManager;
    private CharacterStats enemyStats;
    private void Start()
    {
        playerManager = PlayerManager.Instance;
        enemyStats = GetComponent<CharacterStats>();
    }

    public override void Interact()
    {
        base.Interact();
        var playerCombat = playerManager.player.GetComponent<CharacterCombat>();
        if (playerCombat != null)
        {
            Debug.Log("Attack");
            playerCombat.Attack(enemyStats);
        }
    }
}
