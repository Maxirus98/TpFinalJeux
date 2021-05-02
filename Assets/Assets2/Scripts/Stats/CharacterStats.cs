using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
[RequireComponent(typeof(Animator))]
public class CharacterStats : MonoBehaviour
{
    [SerializeField] private HpScript hpBar;
    
    public Stat damage;
    [SerializeField] public Stat attackSpeed;
    [SerializeField] public Stat cooldown;
    
    public float currentHp { get; private set; }
    public float maxHp;

    private Animator _animator;

    private void Awake()
    {
        currentHp = maxHp;
        hpBar.SetMaxHp(maxHp);
    }

    private void Start()
    {
        cooldown.Value = 0f;
        attackSpeed.Value = 1f;
        damage.Value = 40f;
        _animator = GetComponent<Animator>();
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

    public void Heal(FoodItem foodItem)
    {
        if (currentHp + foodItem.bonusLife < maxHp)
        {
            currentHp += foodItem.bonusLife;
            hpBar.SetHp(currentHp);
        }
    }

    public virtual void Die()
    {
        _animator.SetBool("isDead", true);
        Destroy(GetComponent<NavMeshAgent>());
        Debug.Log(transform.name  + " died");
    }
}
