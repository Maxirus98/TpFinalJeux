using UnityEngine;
using UnityEngine.UI;

namespace InventoryScripts
{
    public class InventorySlotUI : MonoBehaviour
    {
        private Item _item;
        public Image _icon;
        private GameObject _player;

        void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
        }

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

        public void OnClickConsume()
        {
            CharacterStats characterStats = _player.GetComponent<CharacterStats>();
            characterStats.Heal(_item.bonusLife);
            InventoryManager.Instance.RemoveItem(_item);
        }
    }
}