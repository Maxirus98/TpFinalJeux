using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/* Controls the Enemy AI */
//TODO : Brackeys --> Refactor
[RequireComponent(typeof(CharacterStats))]
public class EnemyController : MonoBehaviour {

    public float lookRadius = 10f;	// Detection range for player

    private Transform target;	// Reference to the player
    private NavMeshAgent agent; // Reference to the NavMeshAgent
    private CharacterCombat combat;
    private CharacterStats enemyStats;

    // Use this for initialization
    void Start () {
        target = PlayerManager.Instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();
    }
	
    // Update is called once per frame
    void Update () {
        // Distance to the target
        float distance = Vector3.Distance(target.position, transform.position);

        // If inside the lookRadius
        if (distance <= lookRadius)
        {
            // Move towards the target
            agent.SetDestination(target.position);

            // If within attacking distance
            if (distance <= agent.stoppingDistance)
            {
                CharacterStats targetStats = target.GetComponent<CharacterStats>();
                if (targetStats)
                {
                    combat.Attack(targetStats);
                }
            }
        }
    }
}