using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotStep;
    private float curRot = 0;
    private float startTime;

    void Start()
    {
        startTime = Time.time;
    }
    // Update is called once per frame

    void Update()
    {
        if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x > 0.6 || OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x > 0.6)
        {
            rotate(rotStep);
        }
        else if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x < -0.6 || OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x < -0.6)
        {
            rotate(-rotStep);
        }
    }
    void rotate(float rotation)
    {
        Debug.Log("Rotating: " + rotation);
        float t = Time.time - startTime;
        if (t > 0.2)
        {
            curRot += rotation;
            gameObject.transform.rotation = Quaternion.AngleAxis(curRot, Vector3.up);
            t = 0;
            startTime = Time.time;
        }
    }
}
