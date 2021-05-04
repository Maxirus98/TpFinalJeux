using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Serialization;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private HpScript hpBar;
<<<<<<< HEAD
    
    [SerializeField] public Stat damage;
    [SerializeField] public Stat spellDamage;
    [SerializeField] public Stat attackSpeed;
    [SerializeField] public Stat cooldown;
=======

    public Stat damage;
    public Stat spellDamage;
    public Stat attackSpeed;
    public Stat cooldown;
    public HealEffect healEffect;

>>>>>>> b6cf4f8333ada9fa1611bace1f8eb0546762524c
    public float currentHp { get; private set; }
    public float maxHp;

    private void Awake()
    {
        currentHp = maxHp;
        hpBar.SetMaxHp(maxHp);
    }

    private void Start()
    {
        spellDamage.setValue(50f);
        cooldown.setValue(0f);
        attackSpeed.setValue(1f);
    }

    public void TakeDamage(float damage)
    {
        currentHp -= damage;
        hpBar.SetHp(currentHp);
        Debug.Log(transform.name + "takes " + damage + " damage");
        if (currentHp <= 0)
        {
            Die();
        }
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

    public virtual void Die()
    {
        //Die meant to be over written
        Debug.Log(transform.name + " died");
    }
}