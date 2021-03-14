using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MaterialHeating : MonoBehaviour
{
    public float workTemp;
    [HideInInspector]
    public bool workable;
    [HideInInspector]
    public float objTemp = 0;
    private Color beginColour;
    private bool inFurnace = false;
    private float colour;
    private float t, startTime;


    private void Awake()
    {
        beginColour = gameObject.GetComponent<Renderer>().material.color;
        startTime = Time.time;
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.name == "Furnace")
        {
            inFurnace = true;
            if(objTemp<=FurnaceHeating.temp)
            {
                objTemp += 1f;
                if(colour <= 1)
                {
                    gameObject.GetComponent<Renderer>().material.color = new Vector4(colour, beginColour.g, beginColour.b, beginColour.a);
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.name == "Furnace")
        {
            inFurnace = false;
        }
    }

    private void Update()
    {
        colour = objTemp / workTemp;
        if (!inFurnace)
        {
            t = Time.time - startTime;
            if(gameObject.GetComponent<Renderer>().material.color.r > beginColour.r)
            {
                gameObject.GetComponent<Renderer>().material.color = new Vector4(colour, beginColour.g, beginColour.b, beginColour.a);
            }
            if(objTemp>0 && t>10)
            {
                objTemp -= 0.1F;
            }
        }
        else
        {
            startTime = Time.time;
        }
        gameObject.GetComponent<Mouldable>().hot = (objTemp >= workTemp);
    }
}


