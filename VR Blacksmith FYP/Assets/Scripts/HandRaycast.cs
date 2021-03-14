using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HandRaycast : MonoBehaviour
{
    [Header("Starting telespot")]
    public GameObject startPoint;
    private int layerMask = 1 << 9;
    //[Header("Colour to highlight with")]
    //public Color highlightCol;
    //private Transform previousTele;
    //private Dictionary<int, Color> baseColour;
    ////private bool teleHit = false;
    //private GameObject currentSpot = null;

    private void Awake()
    {
        //baseColour = new Dictionary<int, Color>();
        if(startPoint.name != "TeleSpot")
        {
            Debug.Log("No valid TeleSpot assigned for start; defaulting to (0,0,0)");

            gameObject.transform.root.transform.position = new Vector3(0,0,0);
        }
        else
        {
            gameObject.transform.position = startPoint.transform.position;
        }
    }

    void Update()
    {
        foreach (OVRGrabber hand in gameObject.GetComponentsInChildren<OVRGrabber>())
        {
            RaycastHit hit;
            Vector3 rayPos = new Vector3(hand.gameObject.transform.position.x, hand.gameObject.transform.position.y, hand.gameObject.transform.position.z + 0.1F);
            if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstick) || OVRInput.GetDown(OVRInput.Button.SecondaryThumbstick))
            {
                hand.gameObject.GetComponent<LineRenderer>().enabled = true;
                //if (Physics.Raycast(rayPos, hand.gameObject.transform.forward, out hit, Mathf.Infinity, layerMask))
                //{
                //    Debug.Log("Tele hit! " + hit.transform.name);
                //    teleHit = true;
                //    previousTele = hit.transform;
                //    if (!baseColour.ContainsKey(hit.transform.GetInstanceID()))
                //    {
                //        Debug.Log("Adding new colour: " + hit.transform.gameObject.GetComponent<Renderer>().material.color);
                //        baseColour.Add(hit.transform.GetInstanceID(), hit.transform.gameObject.GetComponent<Renderer>().material.color);
                //    }
                //    if (hit.transform.gameObject.GetComponent<Renderer>().material.color != highlightCol)
                //    {
                //        Debug.Log("Highlighting");
                //        hit.transform.gameObject.GetComponent<Renderer>().material.color = highlightCol;
                //    }
                //}
                //else if (teleHit)
                //{
                //    Debug.Log("Un-highlighting");
                //    previousTele.GetComponent<Renderer>().material.color = baseColour[previousTele.GetInstanceID()];
                //    teleHit = false;
                //    previousTele = null;
                //}
            }
            if (OVRInput.GetUp(OVRInput.Button.PrimaryThumbstick) || OVRInput.GetUp(OVRInput.Button.SecondaryThumbstick))
            {
                hand.GetComponent<LineRenderer>().enabled = false;
                if (Physics.Raycast(rayPos, hand.gameObject.transform.forward, out hit, Mathf.Infinity, layerMask))
                {
                    Debug.Log(hit.collider.name);
                    if (hit.collider.name == "Door")
                    {
                        Debug.Log("Quit");
                        Application.Quit();
                    }
                    else
                    {
                        Debug.Log("Moving to: " + hit.transform.position);
                        gameObject.transform.position = hit.transform.position;
                    }
                }
            }       
        }
    }
}
