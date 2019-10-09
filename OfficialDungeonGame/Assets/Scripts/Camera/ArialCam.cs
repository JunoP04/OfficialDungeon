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

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            pos.x = Character.transform.position.x;
            pos.z = Character.transform.position.z;
        }



        transform.position = pos;

        pos.x = Mathf.Clamp(pos.x, -panLim.x, panLim.x);
        pos.y = Mathf.Clamp(pos.y, -panLim.y, panLim.y);

    }
}
