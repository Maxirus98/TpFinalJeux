using UnityEngine;
using UnityEngine.AI;

public class NpcController : MonoBehaviour
{
    public float lookRadius = 10f;
    private GameObject _target;
    private NavMeshAgent _agent;
     
    void Start()
    {
        //Peut la mettre public pour permettre de mettre un GO qu'il devra suivre
        _target = GameObject.FindGameObjectWithTag("Player");
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        detection();
    }

    private void detection()
    {
        float distance = Vector3.Distance(_target.transform.position, transform.position);

        if (distance <= lookRadius)
        {
            _agent.isStopped = false;
            _agent.SetDestination(_target.transform.position);
        }

        if (distance >= lookRadius + 5)
        {
            _agent.isStopped = true;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,lookRadius);
    }
}