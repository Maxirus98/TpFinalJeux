using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeter : MonoBehaviour
{
    public List<Transform> targets;
    public Transform currentTarget;
    
    private void Start()
    {
        LookForTargets();
    }

    public void LookForTargets()
    {
        var others = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var go in others)
        {
            targets.Add(go.transform);
        }

        currentTarget = targets[0];
    }
    
    public void CheckForClosestTarget()
    {
        foreach(Transform target in targets)
        {
            if (target)
            {
                if (Vector3.Distance(transform.position, target.position) <
                    Vector3.Distance(transform.position, currentTarget.position))
                {
                    currentTarget = target;
                }
            }
                
        }
    }
}
