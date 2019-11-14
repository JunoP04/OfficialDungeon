using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solidify : MonoBehaviour
{
    public GameObject Object;
    public Material[] material;
    public BoxCollider boxCol;
    Renderer rend;
    //private int intColor = 0;

    // Update is called once per frame
    private void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }
    void Update()
    {
        if (this.tag == "SolidBlue")
        {
            rend.sharedMaterial = material[0];
            boxCol.enabled = true;
        }
        //if (Object.GetComponent<BoxCollider>() == null)
        else
        {
            rend.sharedMaterial = material[1];
            boxCol.enabled = false;
        }
        
        
    }
}
