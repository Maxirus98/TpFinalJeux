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
    private GameObject _inventoryUI;

    private void Awake()
    {
        _inventoryUI = gameObject;
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
        if (Input.GetButtonDown("Inventory"))
        {
            _inventoryUI.SetActive(!_inventoryUI.activeSelf);
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
