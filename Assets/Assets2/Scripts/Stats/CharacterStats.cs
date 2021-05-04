using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Serialization;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private HpScript hpBar;
    
    [SerializeField] public Stat damage;
    [SerializeField] public Stat spellDamage;
    [SerializeField] public Stat attackSpeed;
    [SerializeField] public Stat cooldown;
    
    public float currentHp { get; private set; }
    public float maxHp;

    private void Awake()
    {
        currentHp = maxHp;
        hpBar.SetMaxHp(maxHp);
    }

    private void Start()
    {
        spellDamage.Value = 50f;
        cooldown.Value = 0f;
        attackSpeed.Value = 1f;
        damage.Value = 4f;
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
        if (currentHp + bonusLife < maxHp)
        {
            currentHp += bonusLife;
            hpBar.SetHp(currentHp);
        }
    }

    public virtual void Die()
    {
        //Die meant to be over written
        Debug.Log(transform.name  + " died");
    }
}
