using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SpellStat : MonoBehaviour
{
    [SerializeField] private float value;

    public float GetValue()
    {
        return value;
    }
    
    public void SetValue(float newValue)
    {
        value = newValue;
    }
}
