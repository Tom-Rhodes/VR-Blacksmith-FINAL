using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(Mouldable))]
[CanEditMultipleObjects]

public class MouldableEditor : Editor
{
    public static string[] options;
    
    SerializedProperty inst, metal, maxStages, stages, objects, parent, parPos, destroy, meshes;

    public void OnEnable()
    {
        inst = serializedObject.FindProperty("instantiateObj");

        metal = serializedObject.FindProperty("metal");

        maxStages = serializedObject.FindProperty("maxStages");
        stages = serializedObject.FindProperty("stages");
        
        meshes = serializedObject.FindProperty("newMeshes");

        objects = serializedObject.FindProperty("newObjects");
        parent = serializedObject.FindProperty("parent");
        parPos = serializedObject.FindProperty("parentPosition");
        destroy = serializedObject.FindProperty("destroy");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.BeginHorizontal();

        if (GUILayout.Button(inst.boolValue ? "Instantiate new GameObject" : "Swap Meshes"))
        {
            inst.boolValue = !inst.boolValue;
        }

        if (GUILayout.Button(metal.boolValue ? "Metal" : "Wood"))
        {
            metal.boolValue = !metal.boolValue;
        }

        EditorGUILayout.EndHorizontal();


        if (metal.boolValue)
        {
            options = new string[] { "Hammer", "Axe", "File", "Hole Punch", "Metal Sander" };
        }

        else if (!metal.boolValue)
        {
            options = new string[] { "Saw", "Wood Sander", "Nail", "Chisel" };
        }
        if (inst.boolValue)
        {
            EditorGUILayout.PropertyField(objects, true);
            EditorGUILayout.PropertyField(parent);
            stages.GetArrayElementAtIndex(0).intValue = EditorGUILayout.Popup(stages.GetArrayElementAtIndex(0).intValue, options);
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button(parPos.boolValue ? "Set position relative to parent" : "World position"))
            {
                parPos.boolValue = !parPos.boolValue;
            }
            if (GUILayout.Button(destroy.boolValue ? "Destroy after" : "Remain"))
            {
                destroy.boolValue = !destroy.boolValue;
            }
            EditorGUILayout.EndHorizontal();
        }
        else
        {
            EditorGUILayout.PropertyField(maxStages);
            EditorGUILayout.PropertyField(meshes, true);
            for (int i = 0; i < maxStages.intValue; i++)
            {
                stages.GetArrayElementAtIndex(i).intValue = EditorGUILayout.Popup(stages.GetArrayElementAtIndex(i).intValue, options);
            }
        }
        serializedObject.ApplyModifiedProperties();
    }
}