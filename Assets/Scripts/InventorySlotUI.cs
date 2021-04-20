using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    Item _item;
    Image _icon;

    public void PutItemInSlot(Item item)
    {
        _item = item;
        _icon.sprite = item.icon;
        _icon.enabled = true;
    }

    public void ClearItemFromSlot()
    {
        _item = null;
        _icon.sprite = null;
        _icon.enabled = false;
    }
}
