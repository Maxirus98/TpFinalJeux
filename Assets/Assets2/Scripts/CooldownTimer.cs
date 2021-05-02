using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CooldownTimer : MonoBehaviour
{
    private Spell spell;

    private float cooldown;
    // Start is called before the first frame update
    void Start()
    {
        spell = GameObject.Find("Hog 1").GetComponent<Spell>();
        cooldown = spell.cooldown;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Jump"))
            gameObject.SetActive(true);
        if (isActiveAndEnabled)
        {
            if (cooldown > 0)
            {
                cooldown -= Time.deltaTime;
            }
            else
            {
                cooldown = 0;
            }
            SetTime();
        }
    }

    private void SetTime()
    {
        GetComponent<Text>().text = cooldown.ToString();
    }
}
