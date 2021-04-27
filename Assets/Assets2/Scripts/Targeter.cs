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
}
