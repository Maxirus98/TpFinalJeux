using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Serialization;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private HpScript hpBar;
    
    public Stat damage;
    public Stat attackSpeed;
    public Stat cooldown;
    
    [SerializeField] private HealEffect healEffect;
    public float currentHp { get; private set; }
    public float maxHp;

    private void Awake()
    {
        currentHp = maxHp;
        hpBar.SetMaxHp(maxHp);
    }

    private void Start()
    {
        cooldown.setValue(0f);
        attackSpeed.setValue(1f);
    }

    public void TakeDamage(float damage)
    {
        currentHp -= damage;
        hpBar.SetHp(currentHp);
    }

    public void Heal(float bonusLife)
    {
        if (currentHp + bonusLife > maxHp)
        {
            currentHp = maxHp;
        }
        else
        {
            currentHp += bonusLife;
        }

        StartCoroutine(healEffect.Effect());
        hpBar.SetHp(currentHp);
    }
}