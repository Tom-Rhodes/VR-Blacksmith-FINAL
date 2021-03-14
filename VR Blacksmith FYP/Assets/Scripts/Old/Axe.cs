using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    [HideInInspector]
    public int hamHits;
    public bool hittable;
    private float t, startTime;

    private void Awake()
    {
        startTime = Time.time;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Hammer" && hittable && t>0.25f)
        {
            hamHits++;
            Debug.Log("Axe hit: +1, total: " + hamHits);
            startTime = Time.time;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Moulding>())
        {
            Debug.Log("Left split");
            hittable = false;
        }
    }
    private void Update()
    {
        t = Time.time - startTime;
    }
}
