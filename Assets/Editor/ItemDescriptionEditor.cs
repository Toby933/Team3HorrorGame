using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(ItemDescription))]
public class ItemDescriptionEditor : Editor
{
    public override void OnInspectorGUI()
    {

        ItemDescription t = (ItemDescription)target;

        EditorGUILayout.LabelField("Item Description");

        t.description = EditorGUILayout.TextArea(t.description);
    }
}
