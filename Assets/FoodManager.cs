using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FoodManager : MonoBehaviour
{
    public int amount;
    public List<GameObject> _foodPrefabs;
    void Start()
    {
        InstantiateFood();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InstantiateFood()
    {
        for (int i = 0; i <= amount; i++)
        {
            int positionInListPrefab = (int) Random.Range(0f, _foodPrefabs.Count - 1);
            GameObject foodPrefab = _foodPrefabs[positionInListPrefab];
            GameObject food = Instantiate(foodPrefab, GenerateRandomVector3(0,100),
                Quaternion.identity);
            food.name = foodPrefab.name;
            food.transform.parent = transform;
        }
        
    }

    private Vector3 GenerateRandomVector3(float min, float max)
    {
        return new Vector3(Random.Range(-48,48), -1, Random.Range(-24,24));
    }
}