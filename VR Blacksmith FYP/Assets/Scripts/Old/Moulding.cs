using UnityEngine;
using UnityEditor;
using System.Collections;

public class Moulding : MonoBehaviour
{
    [Header("Hits needed to split")]
    public int hitGoal;
    public GameObject[] instantiatingObjects = null;

    public GameObject parent = null;
    [Header("Set new obj pos relative to it's parent")]
    public bool parentPosition;
    [Header("Destroy this object after making new GOs")]
    public bool destroy = true;
    public bool instantiate = true;
    public bool splitting = true;

    [HideInInspector]
    public bool axing;
    private GameObject newObj;
    private bool anvil = false;
    private float spacing, t, startTime;
    private int hammerHits;
    private int stage;

    public Mesh[] meshsToClone = null;

    private void Awake()
    {
        startTime = Time.time;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.name == "Anvil")
        {
            anvil = true;
        }
        if ((other.name == "Hammer") || (other.transform.parent.name == "Hammer") || (other.transform.parent.name == "Hammer"))
        {
            hammerHits++;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (anvil && GetComponent<MaterialHeating>().workable)
        {

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

    private void NewObj()
    {
        foreach (GameObject go in instantiatingObjects)
        {
            spacing += 0.5f;
            if (t > spacing)
            {
                if (parentPosition)
                {
                    newObj = Instantiate(go, parent.transform, parentPosition);
                }
                else
                {
                    newObj = Instantiate(go, new Vector3(transform.position.x, transform.position.y + spacing, transform.position.z), transform.rotation, parent.transform);
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
            gameObject.GetComponent<MeshFilter>().mesh = meshsToClone[stage];
            stage++;
        }
        else
        {
            Debug.Log("No mesh present on NewMesh GO");
        }
    }
}
//if (instantiate)
//            {
//                if (splitting)
//                {
//                    Axe axe;
//                    if (axe = other.GetComponent<Axe>())
//                    {
//                        axe.hittable = true;
//                        if (axe.hamHits >= hitGoal)
//                        {
//                            axe.hamHits = 0;
//                            NewObj();
//                        }
//                    }
//                }
//                else
//                {

//                    if (hammerHits >= hitGoal)
//                    {
//                        hammerHits = 0;
//                        NewObj();
//                    }
                    
//                }
//            }
//            else
//            {
//                if (splitting)
//                {
//                    axing = true;
//                    Axe axe;
//                    if (axe = other.GetComponent<Axe>())
//                    {
//                        if (axe.hamHits >= hitGoal)
//                        {
//                            axe.hamHits = 0;
//                            NewMesh();

//                        }
//                    }
//                }
//                else
//                {
//                    hammerHits++;
//                    if (hammerHits >= hitGoal)
//                    {
//                        NewMesh();
//                    }
                    
//                }
//            }