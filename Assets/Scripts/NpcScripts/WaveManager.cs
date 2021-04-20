using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveManager : MonoBehaviour
{
    public List<GameObject> prefabsNPC;
    public float time = 10f;
    public bool stop = false;
    private int _nbrNpcs = 0;
    void Start()
    {
        StartCoroutine(GenerateNpc());
    }

    public IEnumerator GenerateNpc()
    {
        //replace by a boolean
        while (!stop)
        {
            int position = (int) Random.Range(0f, prefabsNPC.Count-1);
            InstantiateAsChild(prefabsNPC[position],1,50);
            yield return new WaitForSeconds(time);
        }
    }
    private void InstantiateAsChild(GameObject prefab, float x, float y)
    {
        GameObject npc = Instantiate(prefab, new Vector3(Random.Range(x,y),0,Random.Range(x,y)), Quaternion.identity);
        npc.name = prefab.name;
        npc.transform.parent = transform;
        _nbrNpcs++;
    }
    
}
