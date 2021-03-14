using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoalBucket : MonoBehaviour
{
    [Header("GameObject to store new coal")]
    public GameObject ActiveCoal, coal;
    [Header("Spawn location")]
    public Transform coalTrans;
    private float t, startTime;
    private void Start()
    {
        startTime = Time.time;
    }
    private void OnTriggerExit(Collider other)
    {
        t = Time.time - startTime;
        if (other.gameObject.tag == "Fuel" && t>0.5)
        {
            Debug.Log("Left");
            GameObject newCoal = Instantiate(coal, coalTrans.position, coalTrans.rotation, ActiveCoal.transform);
            newCoal.GetComponent<Rigidbody>().isKinematic = false;
            newCoal.GetComponent<SphereCollider>().isTrigger = false;
            startTime = Time.time;
        }
    }
}
