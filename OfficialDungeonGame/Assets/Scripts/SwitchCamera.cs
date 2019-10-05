using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            cam1.enabled = false;
            cam2.enabled = true;
            Debug.Log("enabling camera 1");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            cam2.enabled = false;
            cam1.enabled = true;
            Debug.Log("enabling camera 2");
        }
    }
}
