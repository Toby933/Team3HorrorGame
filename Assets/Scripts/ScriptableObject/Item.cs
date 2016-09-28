using UnityEngine;
using System.Collections;

//[System.Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item", order = 1)]
public class Item : ScriptableObject
{
    public string itemName = "New Item";                                     
    public Texture2D itemIcon = null;                                         
    public GameObject itemObject = null;
    public bool destroyOnUse = false;
    public string itemDescription;
}
