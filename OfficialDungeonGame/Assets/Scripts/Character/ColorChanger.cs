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
        //always raycast out from the mouse position
        if (Time.timeScale == 0) return;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.collider.gameObject);
        }
        
        //if you are looking at something tagged **blue** (a buildable space), turn it light green to show it is buildable
        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Blue")
        {
         
            hit.collider.gameObject.GetComponent<Renderer>().material = newMat;
            //if you click while looking at something blue, change the tag to "SolidBlue", this solidifies the object in the Solidify script
            if (Input.GetMouseButtonDown(0))
            {
                hit.collider.gameObject.tag = "SolidBlue";
            }
            
        }
        //If you are looking at a cube that has already been solidified, make it look red
        else if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "SolidBlue")
        {

            hit.collider.gameObject.GetComponent<Renderer>().material = unBuildable;
            //clicking switches the tag bag to blue, which unsolidifies it in the Solidify script
            if (Input.GetMouseButtonDown(0))
            {
                hit.collider.gameObject.tag = "Blue";
            }
        }
        //if you are looking at a corpse, it changes the color slighty to indicate you are looking at it
        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Corpse")
        {
            hit.collider.gameObject.GetComponent<Renderer>().material = newMat2;
        }

        //if you are looking at a buildable space, and press H, place the heart there
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

        //if you are looking at a corpse in first person view and press E, get an increased amount of resources
        if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Corpse" && skyCube.active == false)
        {
            Destroy(hit.collider.gameObject);
            resourceCounter.GetComponent<ResourceMonitor>().number += 3;

        }

    }
}
