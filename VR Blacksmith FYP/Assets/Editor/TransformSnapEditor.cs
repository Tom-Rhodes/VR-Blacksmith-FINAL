using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TransformSnap))]
[CanEditMultipleObjects]
public class TransformSnapEditor : Editor
{
    SerializedProperty change;
    SerializedProperty mesh;

    private void OnEnable()
    {
        change = serializedObject.FindProperty("meshChange");
        mesh = serializedObject.FindProperty("newMesh");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        DrawDefaultInspector();
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button(change.boolValue ? "Change mesh on snap" : "Keep same mesh"))
        {
            change.boolValue = !change.boolValue;
        }
        if (change.boolValue)
        {
            EditorGUILayout.PropertyField(mesh);
        }
        EditorGUILayout.EndHorizontal();
        serializedObject.ApplyModifiedProperties();
    }
}