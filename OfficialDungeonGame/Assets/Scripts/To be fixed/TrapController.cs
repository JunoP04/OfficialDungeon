using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    public GameObject Trap;
    private bool trapActive;
    // Start is called before the first frame update
    void Start()
    {
        trapActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) )
        {
           
            trapActive = !trapActive;

        }
        if (trapActive == true)
        {
            Trap.SetActive(true);
        }
        if (trapActive == false)
        {
            Trap.SetActive(false);
        }
 

    }
}
