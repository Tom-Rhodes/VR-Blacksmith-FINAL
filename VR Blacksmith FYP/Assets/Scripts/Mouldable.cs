using UnityEngine;
using System.Collections.Generic;

public class Mouldable : MonoBehaviour
{
    public bool metal, instantiateObj, locked, hot, workable, compFnB, compGH, compHam;
    public bool parentPosition, destroy;
    public int maxStages;
    public int[] stages = new int[30];

    public GameObject[] newObjects;
    public Mesh[] newMeshes;

    public GameObject parent;

    private int currStage = 0;
    private Tool tool;
    private int currMesh;
    private float t, startTime;

    private void Awake()
    {
        startTime = Time.time;
    }

    private void OnTriggerStay(Collider other)
    {
        if (tool = other.GetComponent<Tool>())
        {
            if(workable)
            {
                if(metal)
                {
                    switch (stages[currStage])
                    {
                        case 0:
                            if(tool.toolChoice == 0 && compHam)
                            {
                                instCheck();
                                compHam = false;
                            }
                            break;
                        case 1:
                            if (tool.toolChoice == 1 && compGH)
                            {
                                Debug.Log("Axe in block and hit goal reached - changing mesh");
                                instCheck();
                                compGH = false;
                            }
                            break;
                        case 2:
                            if (tool.toolChoice == 2 && compFnB)
                            {
                                Debug.Log("File grind");
                                instCheck();
                                compFnB = false;
                            }
                            break;
                        case 3:
                            if (tool.toolChoice == 3 && compGH)
                            {
                                instCheck();
                                compGH = false;
                            }
                            break;
                        case 4:
                            if (tool.toolChoice == 4 && compFnB)
                            {
                                instCheck();
                                compFnB = false;
                            }
                            break;
                        default:
                            break;
                    }
                }
                else if (!metal)
                {
                    switch (stages[currStage])
                    {
                        case 0:
                            if (tool.toolChoice == 5 && compFnB)
                            {
                                instCheck();
                                compFnB = false;
                            }
                            break;
                        case 1:
                            if (tool.toolChoice == 6 && compFnB)
                            {
                                instCheck();
                                compFnB = false;
                            }
                            break;
                        case 2:
                            if (tool.toolChoice == 7 && compGH)
                            {
                                instCheck();
                                compGH = false;
                            }
                            break;
                        case 3:
                            if (tool.toolChoice == 8 && compGH)
                            {
                                instCheck();
                                compGH = false;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }

    private void Update()
    {
        t = Time.time - startTime;
        workable = (hot && locked);
    }

    private void instCheck()
    {
        if(instantiateObj)
        {
            Debug.Log("Creating new obj");
            NewObj();
        }
        else
        {
            Debug.Log("Creating new mesh");
            NewMesh();
        }
        currStage++;
    }

    private void NewObj()
    {
        foreach (GameObject go in newObjects)
        {
            float spacing = 0;
            spacing+= 0.5f;

            if (t > 0.2)
            {
                if (parentPosition)
                {
                    Instantiate(go, parent.transform, parentPosition);
                }
                else
                {
                    Instantiate(go, new Vector3(transform.position.x, transform.position.y + spacing, transform.position.z), transform.rotation, parent.transform);
                }
                startTime = Time.time;
            }
        }
        if (destroy)
        {
            Destroy(gameObject);
            Destroy(this);
        }
    }

    private void NewMesh()
    {
        if (gameObject.GetComponent<MeshFilter>().mesh)
        {
            gameObject.GetComponent<MeshFilter>().mesh = newMeshes[currMesh];
            currMesh++;
        }
        else
        {
            Debug.Log("No mesh present on NewMesh GO");
        }
    }
}
