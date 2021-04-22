using UnityEngine;

public class ItemController : Interactable
{
    // Start is called before the first frame update
    private InventoryManager _inventoryManager;
    public Item item;
    void Start()
    {
        _inventoryManager = InventoryManager._instance;
    }
    public void PickUpItem()
    {
        bool wasPickedUp = _inventoryManager.AddItem(item);
        if (wasPickedUp)
        {
            Debug.Log("picking this item" + _inventoryManager.items[0].name);
            Destroy(gameObject);
        }
    }
}
