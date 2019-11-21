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
        rb = GetComponent<Rigidbody>();
        timeVar = 1;
        //ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    }

    // Update is called once per frame
    void Update()
    {
        float translation = speed * (Time.deltaTime * timeVar);
        transform.Translate(0, 0, translation);

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
        speed = 0;
        //Debug.Log(speed);
        this.transform.Rotate(0, 90, 0);
        yield return new WaitForSecondsRealtime(1);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 15f) && hit.collider.gameObject.tag == "SolidBlue")
        {
            minInt = -2;

        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5f) && hit.collider.gameObject.tag == "SolidBlue")
        {
            Debug.Log("close on right");

            wallRightClose = true;
            //maxInt = 0;

        }


        this.transform.Rotate(0, -180, 0);
        yield return new WaitForSecondsRealtime(1);

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 15f) && hit.collider.gameObject.tag == "SolidBlue")
        {
            maxInt = 2;
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5f) && hit.collider.gameObject.tag == "SolidBlue")
        {
            Debug.Log("close on left");
            wallLeftClose = true;
            //minInt = 0;
        }
        if (wallLeftClose == true)
        {
            minInt = 0;
        }
        if (wallRightClose == true)
        {
            maxInt = 0;        }
        
        //this.transform.Rotate(0, 90, 0);
        int rightLeft = 0;
        Debug.Log(wallRightClose + " " + wallLeftClose);
        //if walls are too close right and left go back
        if (wallLeftClose == true && wallRightClose == true)
        {
            this.transform.Rotate(0, -90, 0);
        }
        else if (wallRightClose != true || wallLeftClose !=true)
        {
            rightLeft = Random.Range(minInt, maxInt);

            if (rightLeft >= 0)
            {
                this.transform.Rotate(0, 180, 0);
            }
            else if (rightLeft < 0)
            {
                this.transform.Rotate(0, 0, 0);
            }
        }
        Debug.Log(rightLeft);
        minInt = -1;
        maxInt = 1;
        wallRightClose = false;
        wallLeftClose = false;
        checkingDir = false;
        speed = 5;

    }
}
