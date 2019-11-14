using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public GameObject characterCam;
    public GameObject skyCube;

    private void Start()
    {

        characterCam.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V) && characterCam.active == true)
        {
            skyCube.SetActive(true);
            characterCam.SetActive(false);
            Cursor.lockState = CursorLockMode.None; 


        }
        else if (Input.GetKeyDown(KeyCode.V) && characterCam.active == false)
        {
            skyCube.SetActive(false);
            characterCam.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
