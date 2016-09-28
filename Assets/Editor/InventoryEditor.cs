using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[CustomEditor(typeof(InventoryListCreator))]
public class InventoryEditor : Editor
{
    public List<bool> foldout = new List<bool>();
    public override void OnInspectorGUI()
    {
        InventoryListCreator t = (InventoryListCreator)target;

        base.OnInspectorGUI();

        for (int i = 0; i < t.Inventory.Count; ++i) 
        {
            if (i + 1 > foldout.Count)
                foldout.Add(false);

            Editor e = CreateEditor(t.Inventory[i], null);
            foldout[i] = EditorGUILayout.Foldout(foldout[i], t.Inventory[i].itemName);

            if (foldout[i])
                e.OnInspectorGUI();          
        }

        EditorUtility.SetDirty(target);
    }
}
