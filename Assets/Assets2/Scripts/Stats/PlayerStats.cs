using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI;

//Useless for now
public class PlayerStats : CharacterStats
{
    // Start is called before the first frame update
    void Start()
    {
        attackSpeed.Value = 1f;
        damage.Value = 10f;
    }
}
