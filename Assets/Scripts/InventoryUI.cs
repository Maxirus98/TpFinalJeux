using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    // Start is called before the first frame update
    private InventoryManager _inventoryManager;
    private List<InventorySlotUI> _inventorySlotUIs;

    private void Awake()
    {
        _inventoryManager = InventoryManager._instance;
        _inventoryManager.OnItemChangedCallBack += UpdateUI;
        _inventorySlotUIs =
            new List<InventorySlotUI>(GetComponentInChildren<Transform>().GetComponentsInChildren<InventorySlotUI>());
    }

    void Start()
    {
        //_inventoryManager = InventoryManager._instance;
        //_inventoryManager.OnItemChangedCallBack += UpdateUI;
        //_inventorySlotUIs = new List<InventorySlotUI>(GetComponentInChildren<Transform>().GetComponentsInChildren<InventorySlotUI>());
    }

    void Update()
    {
        
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
