using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[System.Serializable]
[CreateAssetMenu(fileName = "Inventory", menuName = "Inventory/List", order = 2)]
public class InventoryListCreator : ScriptableObject
{
    public List<Item> Inventory;

    public static InventoryListCreator Create()
    {
        InventoryListCreator asset = ScriptableObject.CreateInstance<InventoryListCreator>();

        AssetDatabase.CreateAsset(asset, "Assets/Inventory.asset");
        AssetDatabase.SaveAssets();
        return asset;
    }
}
