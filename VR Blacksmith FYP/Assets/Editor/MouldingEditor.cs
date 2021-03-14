using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Moulding))]
[CanEditMultipleObjects]
public class MouldingEditor : Editor
{
    SerializedProperty inst;
    SerializedProperty split;
    private void OnEnable()
    {
        inst = serializedObject.FindProperty("instantiate");
        split = serializedObject.FindProperty("splitting");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button(inst.boolValue ? "Instantiate new GameObject" : "Swap Meshes"))
        {
            inst.boolValue = !inst.boolValue;
        }
        if (GUILayout.Button(split.boolValue ? "Axe + hammer (splitting)" : "Hammer (moulding)"))
        {
            split.boolValue = !split.boolValue;
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("hitGoal"), true);
        if (inst.boolValue)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("instantiatingObjects"), true);           
            EditorGUILayout.PropertyField(serializedObject.FindProperty("parent"), true);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("parentPosition"));     
            EditorGUILayout.PropertyField(serializedObject.FindProperty("destroy"), true);
        }
        else
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("meshsToClone"), true);
        }

        serializedObject.ApplyModifiedProperties();
    }
}