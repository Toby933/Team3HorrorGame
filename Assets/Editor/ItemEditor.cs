using UnityEngine;
using UnityEditor;
using System.Collections;

[System.Serializable]
[CustomEditor(typeof(Item))]
public class ItemEditor : Editor
{
    private static bool foldout;

    public override void OnInspectorGUI()
    {
        Item t = (Item)target;

        base.OnInspectorGUI();      

        t.itemDescription = EditorGUILayout.TextArea(t.itemDescription, GUILayout.Height(200));
    }
}
