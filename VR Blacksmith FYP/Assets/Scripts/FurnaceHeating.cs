using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnaceHeating : MonoBehaviour
{
    private float startTime, t, startTime2, t2;
    [HideInInspector]
    public int tempCap = 300;
    [HideInInspector]
    public static float temp = 300;
    private static float thermoAngle = 0.134f;
    private bool tempReached = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Fuel")
        {
            other.GetComponent<Fuel>().fuelEnter = true;
            tempCap += other.GetComponent<Fuel>().fuelTemp;
            tempReached = false;
        }   
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Parts")
        {
            if (other.GetComponent<Mouldable>().hot)
            {
                t2 = Time.time - startTime2;
                if (t2 > 3)
                {
                    GetComponentInChildren<AudioSource>().Play();
                    startTime2 = Time.time;
                }
            }
        }
    }
    void Start()
    {
        startTime = Time.time;
        startTime2 = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        t = Time.time - startTime;
        if (temp < tempCap && !tempReached)
        {
            if ((t > 0.02))
            {
                temp++;
                Thermometer.angle +=  thermoAngle;
                t = 0;
                startTime = Time.time;
                if(temp == tempCap)
                {
                    tempReached = true;
                }
            }
        }
        else if(temp>300)
        {
            temp -= 0.2F;
            Thermometer.angle -= (thermoAngle * 0.2f);
        }
    }
}