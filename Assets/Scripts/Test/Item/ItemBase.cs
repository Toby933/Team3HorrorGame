using UnityEngine;
using System.Collections;

[System.Serializable]
public class ItemBase
{
    public void PickUp(Collider collider, ItemScript item)
    {
        collider.GetComponent<CustomFirstPersonController>().inventory.Add(item.item);

        item.itemObject.SetActive(false);
    }

    public void DisplayText(ItemScript itemScript)
    {
        itemScript.item.textOutput.text = itemScript.item.itemDescription;
    }

    public void ClearText(ItemScript item)
    {
        item.item.textOutput.text = "";
    }
}
