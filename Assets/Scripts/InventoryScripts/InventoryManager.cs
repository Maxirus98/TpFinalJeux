using System.Collections.Generic;
using UnityEngine;

namespace InventoryScripts
{
    public class InventoryManager : MonoBehaviour
    {
        /*
        * 1) Define a delegate -> contract between the publisher and the subscriber,
        *   determines the signature of the method that will be called when the publisher publish
        * 2)Define an event based on that delegate
        * 3)Raise the event
        *                     
        */

        #region Singleton

        public static InventoryManager Instance;

        private void Awake()
        {
            DontDestroyOnLoad(this);
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

        public bool RemoveItem(Item item)
        {
            if (items.Count > 0)
            {
                items.Remove(item);

                if (CheckIfCallBackIsNull())
                    Instance.OnItemChangedCallBack.Invoke();
                return true;
            }

            return false;
        }

        private bool CheckIfCallBackIsNull()
        {
            return Instance.OnItemChangedCallBack != null;
        }
    }
}