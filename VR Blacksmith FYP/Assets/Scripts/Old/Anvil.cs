using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anvil : MonoBehaviour
{
    //private Vector3 distCentre;
    private Vector3 anvilPos;
    private Mouldable mould;
    private void Awake()
    {
        anvilPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.23F, gameObject.transform.position.z);
    }
    private void OnTriggerStay(Collider collider)
    {
        if ((mould = collider.GetComponent<Mouldable>()) && (!collider.GetComponent<OculusSampleFramework.DistanceGrabbable>().isGrabbed))
        {
            collider.transform.eulerAngles = NearestAxis(collider);
            collider.transform.position = anvilPos/* + new Vector3(0, Offset(collider), 0)*/;
            //mould.inAnvil = true;
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (mould = collider.GetComponent<Mouldable>())
        {
            //mould.inAnvil = false;
        }
    }
    private Vector3 NearestAxis(Collider col)
    {
        Vector3 vec = col.transform.eulerAngles;
        vec.x = Mathf.Round(vec.x / 90) * 90;
        vec.y = Mathf.Round(vec.y / 90) * 90;
        vec.z = Mathf.Round(vec.z / 90) * 90;
        return vec;
    }

    //private float Offset(Collider col)
    //{
    //    float y = 0;
    //    Debug.Log(distCentre);
    //    Debug.Log(col.transform.up.z);
    //    if (col.transform.up.x == 1.0F || col.transform.up.x == -1.0F)
    //    {
    //        if(col.transform.forward.y == 1.0f || col.transform.forward.y == -1.0f)
    //        {
    //            y = distCentre.z;
    //        }
    //        else if (col.transform.right.y == 1.0f || col.transform.right.y == -1.0f)
    //        {
    //            y = distCentre.x;
    //        }
    //    }
    //    else if((col.transform.forward.y == 1.0f || col.transform.forward.y == -1.0f) && (col.transform.right.x == 1.0f || col.transform.right.x == -1.0f))
    //    {
    //        y = distCentre.z;
    //    }
    //    else if ((col.transform.right.y == 1.0f || col.transform.right.y == -1.0f) && (col.transform.forward.x == 1.0f || col.transform.forward.x == -1.0f))
    //    {
    //        y = distCentre.x;
    //    }
    //    else if (col.transform.up.y == 1.0 || col.transform.up.y == -1.0)
    //    {
    //        y = distCentre.y;
    //    }
    //    Debug.Log(y);
    //    return y;
    //}
}
