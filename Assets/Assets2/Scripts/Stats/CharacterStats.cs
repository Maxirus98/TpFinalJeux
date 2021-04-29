using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CharacterStats : MonoBehaviour
{
    public Stat damage;
    [SerializeField] private Stat attackSpeed;
    [SerializeField] private Stat cooldown;
    public int currentHp { get; protected set; }
    public int maxHp;

    private void Awake()
    {
        currentHp = maxHp;
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        Debug.Log(transform.name + "takes " + damage + " damage");
        if (currentHp <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        //Die meant to be over written
        Debug.Log(transform.name  + " died");
    }
}
