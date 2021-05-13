using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    public float baseValue;

    public float getValue()
    {
        return baseValue;
    }
    public void setValue(float value)
    {
        baseValue = value;
    }

    public void decrementValue(float decrement)
    {
        baseValue -= decrement;
    }
}
