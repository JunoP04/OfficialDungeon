using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArialCam : MonoBehaviour
{

    public float panSpeed = 20f;
    public Vector2 panLim;
    public float panBorderThickness = 20f;
    public GameObject Character;


    // Update is called once per frame
    void Update()
    {
        //Move mouse within "borderthickness" of any side of the screen, to pan the camera in that direction
        Vector3 pos = transform.position;
        if (Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.z += panSpeed * Time.deltaTime;

        }
        if (Input.mousePosition.y <= panBorderThickness)
        {
            pos.z -= panSpeed * Time.deltaTime;

        }
        if (Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;

        }
        if (Input.mousePosition.x <= panBorderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime;

        }
        //Recenter camera on character
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            pos.x = Character.transform.position.x;
            pos.z = Character.transform.position.z;
        }


        //move the camera
        transform.position = pos;
        

    }
}
