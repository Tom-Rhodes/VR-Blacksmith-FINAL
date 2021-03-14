using UnityEngine;
using System.Collections;

public class Hammer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Mouldable>())
        {
            //if(other.GetComponent<Mouldable>().hammer == true)
            //{

            //}
        }
    }
}
