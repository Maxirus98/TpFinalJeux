using System;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    public Item _item;
    public Image _icon;
    public Button removeButton;

     void Awake()
     {
         removeButton = GetComponentsInChildren<Button>()[1];
     }

    public void PutItemInSlot(Item item)
    {
        _item = item;
        _icon.sprite = item.icon;
        _icon.enabled = true;
        removeButton.interactable = true;
        print("put in slot");
    }

    public void ClearItemFromSlot()
    {
        _item = null;
        _icon.sprite = null;
        _icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnClickRemoveButton()
    {
        InventoryManager._instance.RemoveItem(_item);
    }
}
