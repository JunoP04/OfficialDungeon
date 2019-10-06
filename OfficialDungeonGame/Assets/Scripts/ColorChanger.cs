using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;

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
            Renderer rend = GetComponent<Renderer>();

            hit.collider.gameObject.GetComponent<Renderer>().material.shader = Shader.Find("RedST");
            //Debug.Log(hit.collider.gameObject.name);
        }
    }
}
