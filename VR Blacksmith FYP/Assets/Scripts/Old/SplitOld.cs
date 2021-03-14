using UnityEngine;
using System.Collections;

public class SplitOld : MonoBehaviour
{
    [Header("Hits needed to split")]
    public int hitGoal;

    public GameObject[] cloningObj = null;
    public GameObject parent;
    [Header("Set new obj pos relative to it's parent")]
    public bool parentPos;
    [Header("Destroy this object after making new GOs")]
    public bool dest = true;
    [Header("True to change mesh, false to instantiate new GOs")]
    public bool changeMesh;

    [HideInInspector]
    public bool axing;
    private GameObject newObj;
    private bool anvil = false;
    private float spacing, t, startTime;
    private int axeHits;

    private void Awake()
    {
        startTime = Time.time;
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.transform.parent.name == "Anvil")
        {
            anvil = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (anvil && GetComponent<MaterialHeating>().workable)
        {
            Debug.Log("Workable and anvil");
            axing = true;
            Axe axe;
            if(axe = other.GetComponent<Axe>())
            {
                Debug.Log("Axe in block");
                if(axe.hamHits>hitGoal)
                {
                    if (changeMesh)
                    {

                    }
                    else
                    {
                        Debug.Log("Axe hits exceed goal: " + axe.hamHits + " " + hitGoal);
                        axe.hamHits = 0;
                        foreach (GameObject go in cloningObj)
                        {
                            spacing += 0.5f;
                            if (t > spacing)
                            {
                                if (parentPos)
                                {
                                    newObj = Instantiate(go, parent.transform, parentPos);
                                }
                                else
                                {
                                    newObj = Instantiate(go, new Vector3(transform.position.x, transform.position.y + spacing, transform.position.z), transform.rotation, parent.transform);
                                }
                                startTime = Time.time;
                            }
                        }
                        if (dest)
                        {
                            Destroy(gameObject);
                            Destroy(this);
                        }
                    }
                }
            }
        }
        else
        {
            Debug.Log("Left anvil/lost temp, reseting axing");
            axing = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.parent.name == "Anvil")
        {
            anvil = false;
        }
    }

    private void Update()
    {
        t = Time.time - startTime;
    }
}
