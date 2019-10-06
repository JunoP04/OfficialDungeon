using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    public Material newMat;

    //var rend = GetComponent.<Renderer>();

    private void Start()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    }


    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Blue")
        {
            //Renderer rend = GetComponent<Renderer>();
            //Material newMat = new Material(source);
            //newMat.color = Color.green;
            hit.collider.gameObject.GetComponent<Renderer>().material = newMat;
            //Debug.Log(hit.collider.gameObject.name);
        }
    }
}
