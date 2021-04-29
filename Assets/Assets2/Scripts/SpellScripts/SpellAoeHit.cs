using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellAoeHit : MonoBehaviour
{
    //Will not destroy on hit
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            print("spell hit");
        }
    }

    //Works on fixed update, which isn't good 
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            print("tear hit");
        }
    }
}
