using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CharacterStats : MonoBehaviour
{
    public Stat damage;
    [SerializeField] public Stat attackSpeed;
    [SerializeField] public Stat cooldown;
    public float currentHp { get; protected set; }
    public float maxHp;

    private void Awake()
    {
        currentHp = maxHp;
    }

    private void Start()
    {
        cooldown.Value = 0f;
        attackSpeed.Value = 1f;
    }

    public void TakeDamage(float damage)
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
