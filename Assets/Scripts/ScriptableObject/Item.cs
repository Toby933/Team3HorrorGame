using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//[System.Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item", order = 1)]
public class Item : ScriptableObject
{
    public string itemName = "New Item";                                     
    public Texture2D itemIcon = null;
    [Tooltip("Item prefab for recreating")]                                         
    public GameObject itemPrefab = null;
    public bool destroyOnUse = false;
    public Text textOutput;
    public string itemDescription;
}
