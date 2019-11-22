using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseAI : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    public int speed = 5;
    public float timeVar;
    private Rigidbody rb;
    public bool checkingDir = false;
    //public GameObject self;

    //var rend = GetComponent.<Renderer>();

    private void Start()
    {
        //get rigidbody of the enemy for moving
        rb = GetComponent<Rigidbody>();
        timeVar = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        //enemy walks forward constantly
        float translation = speed * (Time.deltaTime * timeVar);
        transform.Translate(0, 0, translation);

        //if there is a wall 1 square away, initialize checking left and right
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3f) && hit.collider.gameObject.tag == "SolidBlue" && checkingDir == false)
        {
            StartCoroutine(checkRightLeft());
        }
        
    }


    IEnumerator checkRightLeft()
    {
        checkingDir = true;
        int minInt = -1;
        int maxInt = 1;
        bool wallRightClose = false;
        bool wallLeftClose = false;
        int rightLeft = 0;
        //stop moving
        speed = 0;
        //turn right, wait a second to simulate actually looking
        this.transform.Rotate(0, 90, 0);
        yield return new WaitForSecondsRealtime(1);
        //determine first, is there a wall within 3 cubes away? then if there is a wall 1 cube away
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 15f) && hit.collider.gameObject.tag == "SolidBlue")
        {
            //if theres a wall 3 cubes away, make it more likely to go the opposite direction
            minInt = -2;

        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5f) && hit.collider.gameObject.tag == "SolidBlue")
        {
            //if there is a wall immediately to the right, turn wallrightclose true
            Debug.Log("close on right");

            wallRightClose = true;
            //maxInt = 0;

        }

        //turn left to check that direction, and wait to simulate looking
        this.transform.Rotate(0, -180, 0);
        yield return new WaitForSecondsRealtime(1);

        //determine first, is there a wall within 3 cubes away? then if there is a wall 1 cube away
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 15f) && hit.collider.gameObject.tag == "SolidBlue")
        {
            //if theres a wall 3 cubes away, make it more likely to go the opposite direction
            maxInt = 2;
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5f) && hit.collider.gameObject.tag == "SolidBlue")
        {
            //if there is a wall immediately to the left, turn wallleftclose true
            Debug.Log("close on left");
            wallLeftClose = true;
            //minInt = 0;
        }
        if (wallLeftClose == true)
        {
            //if theres a wall left, you can't turn left
            minInt = 0;
        }
        if (wallRightClose == true)
        {
            //if theres a wall right you cant turn right
            maxInt = 0;
        }
        
        
        Debug.Log(wallRightClose + " " + wallLeftClose);
        //if walls are too close right and left go back
        if (wallLeftClose == true && wallRightClose == true)
        {
            //if there is a wall immediately right and left, turn around go back the way you came
            this.transform.Rotate(0, -90, 0);
        }
        //as long as you can go at least right or left, randomly pick a direction
        else if (wallRightClose != true || wallLeftClose !=true)
        {
            //roll a number from the adjusted range, dependant on where walls are. initial range is (-1. 1), or (-1, 2]
            rightLeft = Random.Range(minInt, maxInt);
            //if that number is 0 or greater go right
            if (rightLeft >= 0)
            {
                this.transform.Rotate(0, 180, 0);
            }
            //if that number is less than zero go left
            else if (rightLeft < 0)
            {
                this.transform.Rotate(0, 0, 0);
            }
        }
        //reset values, reassign speed value
        Debug.Log(rightLeft);
        minInt = -1;
        maxInt = 1;
        wallRightClose = false;
        wallLeftClose = false;
        checkingDir = false;
        speed = 5;

    }
}
