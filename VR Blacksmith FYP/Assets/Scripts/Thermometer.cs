using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thermometer : MonoBehaviour
{
    public static float angle = 0;

    // Update is called once per frame
    void Update()
    {
        transform.parent.localRotation = Quaternion.AngleAxis(angle, Vector3.up);
    }
}
