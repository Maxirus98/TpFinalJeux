using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public List<GameObject> prefabsNPC;
    public float time = 10f;
    public bool stop = true;
    private int _nbrNpcs = 0;
    void Start()
    {
        StartCoroutine(GenerateNpc());
    }

    public IEnumerator GenerateNpc()
    {
        //replace by a boolean
        while (stop)
        {
            yield return new WaitForSeconds(time);
            foreach (var npc in prefabsNPC)
            {
                InstanciateAsChild(npc,1,50);
            }
        }
    }
    private void InstanciateAsChild(GameObject prefab, float x, float y)
    {
        GameObject npc = Instantiate(prefab, new Vector3(GenerateRandomValue(x,y),0,GenerateRandomValue(x,y)), Quaternion.identity);
        npc.name = prefab.name;
        npc.transform.parent = transform;
        _nbrNpcs++;
    }
    
    private float GenerateRandomValue(float min, float max)
    {
        return Random.Range(min, max);;
    }
}
