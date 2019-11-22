using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solidify : MonoBehaviour
{
    public GameObject Object;
    public Material[] material;
    public BoxCollider boxCol;
    Renderer rend;
    private void Start()
    {
        //on start get renderer, and set the material to the default of the object
        boxCol = Object.GetComponent<BoxCollider>();
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }
    void Update()
    {
        //if the tag is "SolidBlue" enable colider, otherwise disable it
        if (this.tag == "SolidBlue")
        {
            rend.sharedMaterial = material[0];
            boxCol.enabled = true;
        }
        else
        {
            rend.sharedMaterial = material[1];
            boxCol.enabled = false;
        }
        
        
    }
}
