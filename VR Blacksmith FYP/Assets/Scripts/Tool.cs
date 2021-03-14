using UnityEngine;
using System.Collections;

public class Tool : MonoBehaviour
{
    public int toolChoice, toolFunc;
    public bool endColl, startColl, func;
    private int funcCount, goal = 2;
    private float t, startTime;
    private bool complete = false, workable = false;
    private MaterialHeating heat;
    private Mouldable mould;

    private void Awake()
    {
        startTime = Time.time;
        if(toolChoice != 0)
        {
            if(func)
            {
                toolFunc = 1;
            }
            else
            {
                toolFunc = 2;
            }
        }
        else
        {
            toolFunc = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        switch(toolFunc)
        {
            case 0:
                if((mould = other.GetComponent<Mouldable>()) && (heat = other.GetComponent<MaterialHeating>() ))
                {
                    if(mould.workable && t > 0.1f)
                    {
                        funcCount++;
                        if (funcCount >= goal)
                        {
                            funcCount = 0;
                            mould.compHam = true;
                        }
                        startTime = Time.time;
                    }
                }
                break;

            case 1:
                if(other.name == "Hammer" && t > 0.1f && workable)
                {
                    Debug.Log("Axe hit by hammer");
                    funcCount++;
                    if(funcCount > goal)
                    {
                        Debug.Log("Complete is true for axe + hammer");
                        funcCount = 0;
                        complete = true;
                    }
                    startTime = Time.time;
                }
                break;
            case 2:

                break;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        switch (toolFunc)
        {
            case 0:

                break;
            case 1:                
                if((mould = other.GetComponent<Mouldable>()) && (heat = other.GetComponent<MaterialHeating>()))
                {
                    workable = mould.workable;
                    mould.compGH = complete;
                }
                break;
            case 2:

                break;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        switch (toolFunc)
        {
            case 0:

                break;
            case 1:
                if ((mould = other.GetComponent<Mouldable>()) && (heat = other.GetComponent<MaterialHeating>()))
                {
                    workable = false;
                    complete = false;
                }
                break;
            case 2:

                break;
        }
    }
    private void Update()
    {
        t = Time.time - startTime;
        
        if (toolFunc == 2)
        {
            if (startColl && endColl)
            {
                Debug.Log("One stroke" + funcCount);
                funcCount++;
                startColl = false;
                endColl = false;
            }
            if (funcCount >= goal)
            {
                funcCount = 0;;
                GetComponentInChildren<FnBTrigger>().mould.compFnB = true;
            }
        }
    }
}
