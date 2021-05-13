using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ItemScripts
{
    public class FoodManager : MonoBehaviour
    {
        public int amount;
        public List<GameObject> foodPrefabs;
        private List<Transform> _checkpoints;
        void Start()
        {
            _checkpoints = new List<Transform>(GameObject.Find("CheckPoints").GetComponentsInChildren<Transform>());
            InstantiateFood();
        }


        private void InstantiateFood()
        {
            for (int i = 0; i <= amount; i++)
            {
                int positionInListPrefab = (int) Random.Range(0f, foodPrefabs.Count - 1);
                int positionInCheckPoints = (int) Random.Range(0f, _checkpoints.Count - 1);
                GameObject foodPrefab = foodPrefabs[positionInListPrefab];
                GameObject food = Instantiate(foodPrefab,
                    _checkpoints[positionInCheckPoints].position,
                    Quaternion.identity);
                food.name = foodPrefab.name;
                food.transform.parent = transform;
            }
        
        }
    }
}