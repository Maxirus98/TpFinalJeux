using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    #region Singleton
    private static InventoryManager _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            print("single instance of inventory");
            _instance = this;
        }
    }
    #endregion

    public List<Item> items = new List<Item>();

    public void AddItem(Item item)
    {
        if(!item.isDefaultItem)
            items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }
}
