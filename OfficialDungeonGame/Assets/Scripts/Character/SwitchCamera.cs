using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public GameObject characterCam;
    public GameObject skyCube;
    public GameObject crosshair;

    private void Start()
    {
        characterCam.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        //if the game is paused, do nothing
        if (Time.timeScale == 0) return;
        //lock the cursor and hid it if you are in first person view
        if (characterCam.active)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }


        //**** everything below here can be made more efficient
        //if you press V, and are in first person view swap to overhead view, adjust cursor accordingly
        if (Input.GetKeyDown(KeyCode.V) && characterCam.active == true)
        {
            skyCube.SetActive(true);
            skyCube.transform.position = new Vector3(characterCam.transform.position.x, 34, characterCam.transform.position.z);
            characterCam.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            //FIX
            //crosshair.SetActive(false);



        }
        //if you press V, and are in overhead view, swap back to first person, adjust cursor accordingly
        else if (Input.GetKeyDown(KeyCode.V) && characterCam.active == false)
        {
            skyCube.SetActive(false);
            characterCam.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            crosshair.SetActive(true);
        }
    }
}
