using System.Collections;
using System.Collections.Generic;
using Services;
using UnityEngine;

public class Blurry : MonoBehaviour
{
    void Start()
    {
        Blurriness();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Blurriness()
    {
            print(LevelTrackerService.Get().Split(',')[0]);
        
    }
}
