using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    /*
    * 1) Define a delegate -> contract between the publisher and the subscriber,
    *   determines the signature of the method that will be called when the publisher publish
    * 2)Define an event based on that delegate
    * 3)Raise the event
    *                     
    */
    #region Singleton
    public static InventoryManager _instance;
    private void Awake()
    {
        if (_instance != null)
        {
            print("More than one instance found");
        }
        _instance = this;
    }
    #endregion
    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallBack;
    public List<Item> items = new List<Item>();
    private int _space = 15;
    public bool AddItem(Item item)
    {
        if (!item.isDefaultItem && items.Count < _space)
        {
            items.Add(item);
            _instance.OnItemChangedCallBack.Invoke();
            if (CheckIfCallBackIsNull())
            {
                print("Invoke");
                _instance.OnItemChangedCallBack.Invoke();
            }
            return true;
        }
        return false;
    }
    public bool RemoveItem(Item item)
    {
        if (items.Count > 0)
        {
            items.Remove(item);

            if(CheckIfCallBackIsNull())
                _instance.OnItemChangedCallBack.Invoke();
            return true;
        }
        return false;
    }
    private bool CheckIfCallBackIsNull()
    {
        return _instance.OnItemChangedCallBack != null;
    }
}
