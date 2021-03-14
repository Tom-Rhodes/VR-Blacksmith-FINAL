using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMouldable : MonoBehaviour
{
    //public GameObject furnace;
    //public GameObject GuardBlock, PommelBlock, SwordBlock;
    //private int splitStage = 0;
    //private int temp = 0;
    
    //private void OnTriggerEnter(Collider collision)
    //{
    //    if(collision.gameObject.name == "Hammer")
    //    {
    //        //Debug.Log("Hammer hit");
    //    }
    //    if(collision.transform.parent.parent.name == "Axe")
    //    {
    //        //Debug.Log("Axe hit");
    //        if (collision.transform.root.GetComponentInChildren<Axe>().hammerHit == true)
    //        {
    //            //Debug.Log("hammerHit = true");
    //            collision.transform.root.GetComponentInChildren<Axe>().hammerHit = false;
                
    //            splitStage++;
    //            Instantiate(SwordBlock, transform.parent);
    //            Instantiate(GuardBlock, transform.parent);
    //            Instantiate(PommelBlock, transform.parent);
    //            foreach(Transform trans in transform.parent.GetComponentsInChildren<Transform>())
    //            {
    //                if(trans.name == "BaseMetal") { }
    //                else
    //                {
    //                    trans.gameObject.AddComponent<MeshCollider>();
    //                    trans.gameObject.GetComponent<MeshCollider>().convex = true;
    //                    trans.gameObject.AddComponent<Rigidbody>();
    //                    trans.gameObject.AddComponent<OVRGrabbable>();
    //                    trans.gameObject.AddComponent<SwordMouldable>();
    //                    trans.gameObject.GetComponent<SwordMouldable>().splitStage = splitStage;
    //                    trans.transform.localScale = new Vector3(10, 10, 10);
    //                }
    //            }
    //            Destroy(gameObject);

    //        }
    //    }
    //}

    //private void Update()
    //{
    //    temp = FurnaceHeating.temp;
    //}
}
