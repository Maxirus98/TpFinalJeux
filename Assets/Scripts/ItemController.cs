using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemController : Interactable
{
    // Start is called before the first frame update
    public Item item;
    void Start()
    {
        Interact();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact()
    {
        base.Interact();
        PickUpItem();
    }

    public void PickUpItem()
    {
        print("picking this item" + item.name);
        
        Destroy(gameObject);
    }
}
