using UnityEngine;
using UnityEngine.UI;

namespace InventoryScripts
{
    public class InventorySlotUI : MonoBehaviour
    {
        public Image icon;
        private Item _item;
        private GameObject _player;

        void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
        }

        public void PutItemInSlot(Item item)
        {
            _item = item;
            icon.sprite = item.icon;
            icon.enabled = true;
        }

        public void ClearItemFromSlot()
        {
            _item = null;
            icon.sprite = null;
            icon.enabled = false;
        }

        public void OnClickConsume()
        {
            CharacterStats characterStats = _player.GetComponent<CharacterStats>();
            characterStats.Heal(_item.bonusLife);
            InventoryManager.Instance.RemoveItem(_item);
        }
    }
}