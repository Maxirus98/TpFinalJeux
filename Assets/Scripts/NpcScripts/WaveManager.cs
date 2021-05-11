using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class WaveManager : MonoBehaviour
{
    public List<GameObject> prefabsNPC;
    public float time = 10f;
    public int _nbrNpcs = 0;
    private Targeter _targeter;
    private List<Transform> _checkpoints;
    //ajouter checkpoints
    
    void Start()
    {
        StartCoroutine(GenerateNpc());
        _targeter = GameObject.FindGameObjectWithTag("Player").GetComponent<Targeter>();
        _checkpoints = new List<Transform>(GameObject.Find("CheckPoints").GetComponentsInChildren<Transform>());
    }

    public IEnumerator GenerateNpc()
    {
        //replace by a boolean
        for (int i = 0; i < _nbrNpcs; i++)
        {
            yield return new WaitForSeconds(time);
            int positionInNpcList = (int) Random.Range(0f, prefabsNPC.Count - 1);
            int positionInCheckPoints = (int) Random.Range(0f, _checkpoints.Count - 1);
            InstantiateAsChild(prefabsNPC[positionInNpcList],_checkpoints[positionInCheckPoints]);
        }
    }
    
    private void InstantiateAsChild(GameObject prefab,Transform checkPointTransform)
    {
        GameObject npc = Instantiate(prefab,
            checkPointTransform.position,
            Quaternion.identity);
        npc.transform.parent = transform;
        _targeter.targets.Add(npc.transform);
    }
}