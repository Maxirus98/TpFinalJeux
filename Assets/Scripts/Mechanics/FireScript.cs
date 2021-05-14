using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FireScript : MonoBehaviour
{
    private ParticleSystem particleSystem;
    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        particleSystem = GetComponent<ParticleSystem>();
        particleSystem.trigger.SetCollider(0, player.GetComponent<Transform>());
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            particleSystem.Stop();
            Destroy(GetComponent<Collider>());
            switch (tag)
            {
                case "BlueFire":
                    Timer timer = GameObject.Find("Timer").GetComponent<Timer>();
                    timer.timeLeft += 20;
                    break;
                case "RedFire":
                    var spells = player.GetComponents<Spell>();
                    foreach (var spell in spells)
                    {
                        var spellDamage = spell.go.GetComponent<SpellAoeHit>() != null ?
                            spell.go.GetComponent<SpellAoeHit>() : 
                            ((SprayAndPray)spell).GetBulletGo().GetComponent<SpellHit>();
                        spellDamage.DoubleSpellDamage();
                    }
                    break;
                case "GreenFire":
                    var playerStats = other.GetComponent<CharacterStats>();
                    playerStats.maxHp += 50;
                    playerStats.Heal(50);
                    break;
                default:
                    break;
            } 
        }
    }
}
