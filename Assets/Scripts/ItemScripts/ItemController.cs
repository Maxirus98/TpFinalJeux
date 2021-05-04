using System;
using UnityEngine;

namespace InventoryScripts
{
    public class ItemController : MonoBehaviour
    {
        // Start is called before the first frame update
        private InventoryManager _inventoryManager;
        public Item item;
        public float radius = 3f;
        private Transform _playerTransform;

        void Start()
        {
            _inventoryManager = InventoryManager.Instance;
            _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }

        void FixedUpdate()
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
                Debug.Log("picking this item" + item.name);
                Destroy(gameObject);
            }
        }
    }
}