using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    public Material newMat;
    public Material unBuildable;
    public Material newMat2;
    public GameObject heartPrefab;
    public GameObject resourceCounter;
    public GameObject skyCube;
    public GameObject heartHealth;

    //var rend = GetComponent.<Renderer>();

    private void Start()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    }


    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.collider.gameObject);
        }
         
        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Blue")
        {
         
            hit.collider.gameObject.GetComponent<Renderer>().material = newMat;
            if (Input.GetMouseButtonDown(0))
            {
                hit.collider.gameObject.tag = "SolidBlue";
            }
            
        }
        else if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "SolidBlue")
        {

            hit.collider.gameObject.GetComponent<Renderer>().material = unBuildable;
            if (Input.GetMouseButtonDown(0))
            {
                hit.collider.gameObject.tag = "Blue";
            }

        }
        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Corpse")
        {
            hit.collider.gameObject.GetComponent<Renderer>().material = newMat2;
        }
        if (Input.GetKeyDown(KeyCode.H) && Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Blue")
        {
            //get all the heart rooms and hearts already in the scene
            //get the transform of whatever you are looking at

            GameObject[] heartRooms = GameObject.FindGameObjectsWithTag("HeartRoom");
            GameObject[] Hearts = GameObject.FindGameObjectsWithTag("Heart");
            Transform target = hit.collider.gameObject.transform;

            //if there are any existing hearts/heart rooms, destroy them
            if (heartRooms.Length > 0)
            {
                Destroy(Hearts[0]);
                heartRooms[0].tag = "Blue";

            }

            //create an INSTANCE (this is important), of the heart
            GameObject heartInstance = GameObject.Instantiate(heartPrefab, target) as GameObject;
            //name it heart, because it kept adding "(copy)" to the end of the name, ie: Heart (copy), Heart (copy)(copy)... etc.
            heartInstance.name = "Heart";
            //retag the target room "heartRoom"
            hit.collider.gameObject.tag = "HeartRoom";
            //Enable hearth health in the HUD
            heartHealth.SetActive(true);

        }
        if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Corpse" && skyCube.active == false)
        {
            Destroy(hit.collider.gameObject);
            resourceCounter.GetComponent<ResourceMonitor>().number += 3;

        }

    }
}
