using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    
    [Header("Max temp increase value")]
    public int fuelTemp;
    private float shrinkStep;
    [HideInInspector]
    public bool fuelEnter = false;
    private FurnaceHeating heating;

    private void Awake()
    {
        shrinkStep = transform.localScale.x / fuelTemp;
        heating = new FurnaceHeating();
    }

    private void Update()
    {
        if (fuelEnter)
        {
            if (transform.localScale.x <= 0 || transform.localScale.y <= 0 || transform.localScale.z <= 0)
            {
                Destroy(gameObject);
                Destroy(this);
            }
            else
            {
                transform.localScale -= new Vector3(shrinkStep, shrinkStep, shrinkStep);
            }
        }
    }    
}
