using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    // Start is called before the first frame update
    private InventoryManager _inventoryManager;
    void Start()
    {
        _inventoryManager = GetComponentInParent<InventoryManager>();
        _inventoryManager._onItemChangedCallBack += UpdateUI;
    }

    void Update()
    {
        
    }

    public void UpdateUI()
    {
        print("updatingUI");
    }
}
