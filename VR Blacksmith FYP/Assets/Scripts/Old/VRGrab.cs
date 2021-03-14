using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VRGrab : MonoBehaviour
{
    [HideInInspector]
    public GameObject Hand, objectInHand;
    public List<Transform> grabPoints;

    private OVRInput.Axis1D grabbingHand;
    private bool grabbing = false;
    private Vector3 handleStartTrans;
    private Vector3 newPos;

    private void Start()
    {
        handleStartTrans = transform.parent.position;
        Debug.Log("handleStartTrans" + handleStartTrans);
    }

    private void OnTriggerEnter(Collider other)
    {
        OVRGrabber grabber = other.transform.GetComponentInParent<OVRGrabber>();
        if (grabber != null)
        {
            if(grabber.m_controller == OVRInput.Controller.LTouch)
            {
                grabbingHand = OVRInput.Axis1D.PrimaryHandTrigger;
            }
            if(grabber.m_controller == OVRInput.Controller.RTouch)
            {
                grabbingHand = OVRInput.Axis1D.SecondaryHandTrigger;
            }
            Hand = grabber.gameObject;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.transform.root.name.ToString() == "VR Rig")
        {
            Hand = null;
        }
    }

    void Update() // refreshing program confirms trigger pressure and determines whether holding or releasing object
    {
        if (OVRInput.Get(grabbingHand) > 0.2 && Hand)
        {
            newPos = new Vector3(handleStartTrans.x, handleStartTrans.y, (Hand.transform.position.z + 0.59F));
            if(newPos.z < 10)
            {
                gameObject.transform.localPosition = new Vector3(handleStartTrans.x, handleStartTrans.y, 0F);
            }
            if(gameObject.transform.localPosition.x <= -1.9F)
            {
                gameObject.transform.localPosition = new Vector3(handleStartTrans.x, handleStartTrans.y, -1.9F);
            }
            grabbing = true;
        }      
    }
}

