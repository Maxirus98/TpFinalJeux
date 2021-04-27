using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Empaler : Spell
{
    private float vitesseEmpaler = 1000f;
    private GameObject empalerClone;
    void Update()
    {
        position = transform.position;
        if (Input.GetButton("Jump") && Time.time >= TimeStamp)
        {
            DoSpell();
        }
    }

    public override void DoSpell()
    {
        Spawn();
        Shoot();
        StartCoroutine(Cooldown.WaitFor(cooldown));
        TimeStamp = Time.time + cooldown;
    }

    public override void Spawn()
    {
        empalerClone = Instantiate(go, position, transform.rotation);
        Destroy(empalerClone, 0.5f);
    }

    public override void Shoot()
    {
        empalerClone.GetComponent<Rigidbody>().velocity = (transform.forward * (vitesseEmpaler * Time.deltaTime));;
    }
}
