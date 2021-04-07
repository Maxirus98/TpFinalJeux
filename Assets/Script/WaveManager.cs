using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public List<GameObject> prefabsNPC;
    public float time = 10f;
    void Start()
    {
        StartCoroutine(GenerateNpc());
    }

    public IEnumerator GenerateNpc()
    {
        //replace by a boolean
        while (true)
        {
            yield return new WaitForSeconds(time);
            foreach (var npc in prefabsNPC)
            {
                 Instantiate(npc,
                     new Vector3(GenerateRandomValue(1,50),0,GenerateRandomValue(1,50)),
                     Quaternion.identity);
            }
        }
    }

    private float GenerateRandomValue(float min, float max)
    {
       return Random.Range(min, max);;
    }
}
