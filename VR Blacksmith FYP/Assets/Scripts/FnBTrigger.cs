using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FnBTrigger : MonoBehaviour
{
    [HideInInspector]
    public Mouldable mould;
    private Tool tool;

    private void OnTriggerEnter(Collider other)
    {
        if(mould = other.GetComponent<Mouldable>())
        {
            if (mould.workable)
            {
                if (tool = GetComponentInParent<Tool>() ?? transform.parent.GetComponentInParent<Tool>())
                {
                    Debug.Log(tool + " : " + tool.name);
                    if (name == "StartColl")
                    {
                        Debug.Log("Start colllider");
                        tool.startColl = true;
                    }                
                    if (name == "EndColl")
                    {
                        Debug.Log("End collider");
                        tool.endColl = true;
                    }
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (mould = other.GetComponent<Mouldable>())
        {
            tool = GetComponentInParent<Tool>() ?? transform.parent.GetComponentInParent<Tool>();
            if (name == "StartColl")
            {
                tool.startColl = false;
            }
            else if (name == "EndColl")
            {
                tool.endColl = false;
            }
            
        }
    }
}
