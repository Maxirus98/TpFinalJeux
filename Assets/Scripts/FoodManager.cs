using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FoodManager : MonoBehaviour
{
    public int amount;
    public List<GameObject> _foodPrefabs;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    public float minY;
    void Start()
    {
        InstantiateFood();
    }


    private void InstantiateFood()
    {
        for (int i = 0; i <= amount; i++)
        {
            int positionInListPrefab = (int) Random.Range(0f, _foodPrefabs.Count - 1);
            GameObject foodPrefab = _foodPrefabs[positionInListPrefab];
            GameObject food = Instantiate(foodPrefab, new Vector3(Random.Range(minX,minY), 0, Random.Range(minZ,minZ)),
                Quaternion.identity);
            food.name = foodPrefab.name;
            food.transform.parent = transform;
        }
        
    }
}