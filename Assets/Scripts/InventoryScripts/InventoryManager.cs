using System;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryScripts
{
    public class InventoryManager : MonoBehaviour
    {
        #region Singleton

        public static InventoryManager Instance;

        private void Awake()
        {
            if (Instance != null)
            {
                print("More than one instance found");
            }

            Instance = this;
        }

        #endregion

        public List<Item> items = new List<Item>();
        public delegate void OnItemChanged();
        public OnItemChanged OnItemChangedCallBack;
        private int _space = 15;

        public bool AddItem(Item item)
        {
            if (items.Count < _space)
            {
                items.Add(item);
                if (CheckIfCallBackIsNull())
                {
                    Instance.OnItemChangedCallBack.Invoke();
                }

                return true;
            }

            return false;
        }

        public void RemoveItem(Item item)
        {
            if (items.Count > 0)
            {
                items.Remove(item);

                if (CheckIfCallBackIsNull())
                    Instance.OnItemChangedCallBack.Invoke();
            }
        }

        private bool CheckIfCallBackIsNull()
        {
            return Instance.OnItemChangedCallBack != null;
        }
    }
}