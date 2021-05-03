using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class SpellImageSelector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var spells = GameObject.FindGameObjectWithTag("Player").GetComponents<Spell>();
        //If it has a sprite
        foreach (var spell in spells)
        {
            if (spell.sprite && spell.enabled)
            {
                GetComponent<Image>().sprite = spell.sprite;
            }
        }
        
    }
}
