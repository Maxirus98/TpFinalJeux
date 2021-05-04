using UnityEngine;
using UnityEngine.UI;

namespace InventoryScripts
{
    public class InventorySlotUI : MonoBehaviour
    {
        private Item _item;
        public Image _icon;
        private Button _removeButton;
        private GameObject _player;
        
        void Start()
        {
            _removeButton = GetComponentsInChildren<Button>()[1];
            _player = GameObject.FindGameObjectWithTag("Player");
        }

        public void PutItemInSlot(Item item)
        {
            _item = item;
            _icon.sprite = item.icon;
            _icon.enabled = true;
            _removeButton.interactable = true;
            print("put in slot");
        }

        public void ClearItemFromSlot()
        {
            _item = null;
            _icon.sprite = null;
            _icon.enabled = false;
            _removeButton.interactable = false;
        }

        public void OnClickRemoveButton()
        {
            InventoryManager.Instance.RemoveItem(_item);
        }

        public void OnClickConsume()
        {
            CharacterStats characterStats = _player.GetComponent<CharacterStats>();
            HealEffect healEffect = _player.GetComponentInChildren<HealEffect>();
            
            characterStats.Heal(_item.bonusLife);
            InventoryManager.Instance.RemoveItem(_item);
            
            StartCoroutine(healEffect.Effect());
        }
    }
}