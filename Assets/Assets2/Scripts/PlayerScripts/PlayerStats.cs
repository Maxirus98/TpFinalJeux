using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI;


public class PlayerStats : MonoBehaviour
{ 
    public int maxHp = 100;
    public int currentHp;
    public HpScript hpBar;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        hpBar.SetMaxHp(maxHp);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            TakeDamage(2);
        }
    }

    public void TakeDamage(int dmg)
    {
        currentHp -= dmg;
        hpBar.SetHp(currentHp);
    }
}
