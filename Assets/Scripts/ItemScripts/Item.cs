using System.Runtime.InteropServices;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item",menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
     new public string name = "New Item";
     public Sprite icon = null;
     public GameObject gameObject = null;
     public bool isDefaultItem = false;
     public float bonusLife = 0f;

     public virtual void Use()
     {
          Debug.Log("Using" + name);
     }
}
