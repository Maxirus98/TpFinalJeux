using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    // Start is called before the first frame update
    private InventoryManager _inventoryManager;
    void Start()
    {
        _inventoryManager = GetComponentInParent<InventoryManager>().GetInstance();
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
