using UnityEngine;
using System.Collections;

public class MeshSwap : MonoBehaviour
{
    public static void NewMesh(GameObject go, Mesh[] meshsToClone)
    {
        Mesh mesh;
        if(mesh = go.GetComponent<MeshFilter>().mesh)
        {
            for (int stage = 0; stage < meshsToClone.Length; stage++)
            {
                mesh = meshsToClone[stage];
                stage++;
            }
        }
        else
        {
            Debug.Log("No mesh present on NewMesh GO");
        }
    }
}
