using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quench : MonoBehaviour
{
    private MaterialHeating heat;
    private void OnTriggerStay(Collider other)
    {
        if(heat = other.GetComponent<MaterialHeating>())
        {
            if (heat.objTemp > 0)
            {
                heat.objTemp -= 10;
            }
        }
    }
}
