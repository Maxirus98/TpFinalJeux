using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            if(go.activeInHierarchy && !targets.Contains(go.transform))
                targets.Add(go.transform);
        }
        currentTarget = targets.Count>0?targets[0]:null;
    }
    
    public void CheckForClosestTarget()
    {
        if (targets.Count > 0)
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
}
