using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleRingSize : MonoBehaviour
{
    private List<Transform> rings;
    private Color alpha;
    private Color colour;
    private Vector3 scale;

    void Awake()
    {
        rings = new List<Transform>();
        alpha = new Vector4(0, 0, 0, 0.008F);
        foreach (Transform trans in gameObject.GetComponentsInChildren<Transform>())
        {
            if(trans.name == "Ring")
            {
                scale = trans.localScale;
                colour = trans.GetComponent<Renderer>().material.color;
                rings.Add(trans);
            }
        }
    }
    
    void Update()
    {
        foreach(Transform trans in rings)
        {
            trans.localScale += new Vector3(0.12F, 0, 0.12F);
            trans.GetComponent<Renderer>().material.color -= alpha;
            if(trans.GetComponent<Renderer>().material.color.a <= 0)
            {
                trans.GetComponent<Renderer>().material.color = colour; 
                trans.localScale = scale;
            }
        }
    }
}
