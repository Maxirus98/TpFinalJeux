using System;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryScripts
{
    public class InventoryUI : MonoBehaviour
    {
        public GameObject panel;
        public GameObject title;
        private InventoryManager _inventoryManager;
        private List<InventorySlotUI> _inventorySlotUIs;

        private void Awake()
        {
            //_inventoryManager = InventoryManager.Instance;
            //_inventoryManager.OnItemChangedCallBack += UpdateUI;
           // _inventorySlotUIs =
            //    new List<InventorySlotUI>(
               //     GetComponentInChildren<Transform>().GetComponentsInChildren<InventorySlotUI>());
        }

        private void Start()
        {
            _inventoryManager = InventoryManager.Instance;
            _inventoryManager.OnItemChangedCallBack += UpdateUI;
            _inventorySlotUIs =
                new List<InventorySlotUI>(
                    GetComponentInChildren<Transform>().GetComponentsInChildren<InventorySlotUI>());
        }

        void Update()
        {
            if (Input.GetButtonDown("Inventory"))
            {
                panel.SetActive(!panel.activeSelf);
                title.SetActive(!title.activeSelf);
            }
        }

        public void UpdateUI()
        {
            print("updatingUI");

            for (int i = 0; i < _inventorySlotUIs.Count; i++)
            {
                if (i < _inventoryManager.items.Count)
                {
                    _inventorySlotUIs[i].PutItemInSlot(_inventoryManager.items[i]);
                }
                else
                {
                    _inventorySlotUIs[i].ClearItemFromSlot();
                }
            }
        }
    }
}