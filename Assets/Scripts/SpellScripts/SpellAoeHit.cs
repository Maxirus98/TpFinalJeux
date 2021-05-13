using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpellAoeHit : MonoBehaviour
{
    [SerializeField]protected CharacterCombat combat;
    [SerializeField]protected CharacterCombat playerCombat;
    [SerializeField]protected float damage;
    //[SerializeField]protected string tag;
    [SerializeField]protected  string targetTag;
    public float tmpDamage;

    public void DoubleSpellDamage()
    {
        tmpDamage = damage * 2;
    }

    private void OnDestroy()
    {
        tmpDamage = damage;
    }

    private void Start()
    {
        if (combat && targetTag == null) targetTag = "Enemy";
        //if (tag == null) tag = "Player";
        
        if(GameObject.Find("Boss"))
            combat = GameObject.Find("Boss").GetComponent<CharacterCombat>();
        playerCombat = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterCombat>();
    }
    
    //Will not destroy on hit
    public virtual void OnTriggerEnter(Collider other)
    {
        if (playerCombat && other.CompareTag(targetTag))
        {
            print("spell hit for " + damage);
            playerCombat.Attack(other.GetComponent<CharacterCombat>().Stats, tmpDamage);
        }
    }

    //Used for meteors and buses
    private void OnCollisionEnter(Collision other)
    {
        if (combat && other.gameObject.CompareTag(targetTag))
        {
            combat.Attack(other.gameObject.GetComponent<CharacterCombat>().Stats, damage);
        }
    }
}