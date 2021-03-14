using UnityEngine;
using System.Collections;

public class MouldOld : MonoBehaviour
{
    [Header("Hits needed for each mould step")]
    public int hitGoal;
    public Mesh[] cloningMeshs = null;
    public int stage;
    
    private bool anvil = false;
    private int hammerHits;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.name == "Anvil")
        {
            anvil = true;
        }
        if (other.transform.parent.parent.name == "Hammer" && anvil && GetComponent<MaterialHeating>().workable && stage<= cloningMeshs.Length)
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
}
