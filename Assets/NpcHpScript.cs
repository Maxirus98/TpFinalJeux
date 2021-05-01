using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcHpScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //Disappear when npc is dead ? Need a state + Publisher/Subscriber to announce States
        transform.LookAt(Camera.main.transform);
    }
}
