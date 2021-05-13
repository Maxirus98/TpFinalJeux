using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour
{
    private CriDuTonerre spell1;
    private SprayAndPray spell2;
    private Empaler spell3;
    private Attack attack;

    private void Start()
    {
        spell1 = GetComponent<CriDuTonerre>();
        spell2 = GetComponent<SprayAndPray>();
        spell3 = GetComponent<Empaler>();
        attack = GetComponent<Attack>();
        
        ResetPlayerSpellDamage();
    }

    private void ResetPlayerSpellDamage()
    {
        spell1.go.GetComponent<SpellAoeHit>().tmpDamage = 40;
        spell2.GetBulletGo().GetComponent<SpellHit>().tmpDamage = 10;
        spell3.go.GetComponent<SpellAoeHit>().tmpDamage = 40;
        attack.go.GetComponent<SpellAoeHit>().tmpDamage = 10;
    }
}
