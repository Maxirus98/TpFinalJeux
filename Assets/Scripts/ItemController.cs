using UnityEngine;

public class ItemController : Interactable
{
    // Start is called before the first frame update
    private InventoryManager _inventoryManager;
    public Item item;
    void Start()
    {
        _inventoryManager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
        Interact();
        
    }
    public override void Interact()
    {
        base.Interact();
        PickUpItem();
    }
    public void PickUpItem()
    {
        if (_inventoryManager.AddItem(item))
        {
            print("picking this item" + _inventoryManager.items[0].name);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
