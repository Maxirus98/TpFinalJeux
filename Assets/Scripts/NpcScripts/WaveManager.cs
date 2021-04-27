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
            InstantiateAsChild(prefabsNPC[position]);
            yield return new WaitForSeconds(time);
        }
    }
    private void InstantiateAsChild(GameObject prefab)
    {
        GameObject npc = Instantiate(prefab, new Vector3(Random.Range(-48,48),-1,Random.Range(-24,24)), Quaternion.identity);
        npc.name = prefab.name;
        npc.transform.parent = transform;
        _nbrNpcs++;
    }
    
}
