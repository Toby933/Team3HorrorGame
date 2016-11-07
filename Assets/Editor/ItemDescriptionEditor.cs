using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.UI;

[CustomEditor(typeof(ItemDescription))]
public class ItemDescriptionEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ItemDescription t = (ItemDescription)target;

        EditorGUILayout.LabelField("Item Description");

        t.description = EditorGUILayout.TextArea(t.description);        
    }
}
