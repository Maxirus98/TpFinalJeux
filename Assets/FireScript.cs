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
                //the firecamps exhaust themselves
                case "BlueFire":
                    Timer timer = GameObject.Find("Timer").GetComponent<Timer>();
                    timer.timeLeft += 20;
                    print(timer.timeLeft);
                    break;
                case "RedFire":
                    //Augmente la vitesse de l'agent
                    var agent = other.GetComponent<NavMeshAgent>();
                    agent.speed *= 2f;
                    break;
                case "GreenFire":
                    //Heal le player et augmente ses max hp
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
