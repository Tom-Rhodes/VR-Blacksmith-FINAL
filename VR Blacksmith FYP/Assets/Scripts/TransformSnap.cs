using UnityEngine;
using System.Collections;

public class TransformSnap : MonoBehaviour
{
    public bool allowWood, allowMetal;
    public Transform snapPosition;
    [HideInInspector]
    public bool meshChange;
    [HideInInspector]
    public Mesh newMesh;
    private Vector3 holderPos;
    private Mouldable mould;
    private void Awake()
    {
        if(snapPosition != null)
        {
            holderPos = snapPosition.position;
        }
        else
        {
            holderPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        }
    }
    private void OnTriggerStay(Collider collider)
    {
        if ((mould = collider.GetComponent<Mouldable>()) && (!collider.GetComponent<OculusSampleFramework.DistanceGrabbable>().isGrabbed))
        {
            if(mould.metal && allowMetal)
            {
                Snap(collider);
            }
            if(!mould.metal && allowWood)
            {
                Snap(collider);
            }
        }
           
    }
    private void OnTriggerExit(Collider collider)
    {
        if (mould = collider.GetComponent<Mouldable>())
        {
            if (mould.metal && allowMetal)
            {
                mould.locked = false;
            }
            if (!mould.metal && allowWood)
            {
                mould.locked = false;
            }
        }
    }

    private void Snap(Collider col)
    {
        col.GetComponent<Rigidbody>().isKinematic = true;
        Vector3 vec = col.transform.eulerAngles;
        vec.x = Mathf.Round(vec.x / 90) * 90;
        vec.y = Mathf.Round(vec.y / 90) * 90;
        vec.z = Mathf.Round(vec.z / 90) * 90;
        col.transform.eulerAngles = vec;
        col.transform.position = holderPos;
        mould.locked = true;
        if(meshChange)
        {
            gameObject.GetComponent<MeshFilter>().mesh = newMesh;
        }
    }
}
