using UnityEngine;

public class ItemController : Interactable
{
    // Start is called before the first frame update
    private InventoryManager _inventoryManager;
    public Item item;
    void Start()
    {
        _inventoryManager = InventoryManager._instance;
        Interact();
    }
    public override void Interact()
    {
        base.Interact();
        PickUpItem();
    }
    public void PickUpItem()
    {
        bool wasPickedUp = _inventoryManager.AddItem(item);
        if (wasPickedUp)
        {
            print("picking this item" + _inventoryManager.items[0].name);
            Destroy(gameObject);
        }
    }
}
