using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Tool))]
[CanEditMultipleObjects]
public class ToolEditor : Editor
{
    private static string[] tools = new string[] { "Hammer", "Axe", "File", "Hole Punch", "Metal Sander", "Saw", "Wood Sander", "Nail", "Chisel" };

    private bool function;

    SerializedProperty tool, func;

    private void OnEnable()
    {
        tool = serializedObject.FindProperty("toolChoice");
        func = serializedObject.FindProperty("func");
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.BeginHorizontal();
        tool.intValue = EditorGUILayout.Popup(tool.intValue, tools);
        if(tool.intValue != 0)
        {
            if (GUILayout.Button(func.boolValue ? "Get hit" : "Backwards and forwards"))
            {
                func.boolValue = !func.boolValue;
            }
        }
        EditorGUILayout.EndHorizontal();
        serializedObject.ApplyModifiedProperties();
    }
}