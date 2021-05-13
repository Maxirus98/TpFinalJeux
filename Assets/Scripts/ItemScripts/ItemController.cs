using System;
using InventoryScripts;
using UnityEngine;

namespace ItemScripts
{
    public class ItemController : MonoBehaviour
    {
        private InventoryManager _inventoryManager;
        public Item item;
        public float radius = 3f;
        private Transform _playerTransform;

        void Start()
        {
            _inventoryManager = InventoryManager.Instance;
            _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }

        void Update()
        {
            float distance = Vector3.Distance(_playerTransform.position, transform.position);
            if (distance <= radius)
            {
                PickUpItem();
            }
        }

        public void PickUpItem()
        {
            bool wasPickedUp = _inventoryManager.AddItem(item);
            if (wasPickedUp)
            {
                Destroy(gameObject);
            }
        }
    }
}