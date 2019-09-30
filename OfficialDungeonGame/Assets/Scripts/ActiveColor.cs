using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveColor : MonoBehaviour
{
    public Material[] material;
    public int activeNo;
    public bool Pause;
    bool stopaddinggreen = false;
    //private GameObject leftBall;
    //private GameObject MainBall;
    //private GameObject rightBall;
    Renderer rend;
    public int intColor;
    GameManager mngr;
    void Start()
    {
        //leftBall = GameObject.FindGameObjectWithTag("SphereLeft");
        Pause = false;
        //MainBall = GameObject.FindGameObjectWithTag("MainColor");
        //leftBall = GameObject.FindGameObjectWithTag("SphereRight");
        mngr = GameManager.FindObjectOfType<GameManager>();
        rend = GetComponent<Renderer>();
        rend.enabled = true;

        if (mngr.isTwo)
        {
            activeNo = 1;
            if (this.tag == "SphereLeft")
            {
                intColor = 0;
                

            }
            else if (this.tag == "SphereRight")
            {
                intColor = 0;
            }
            else
            {
                intColor = 1;
                
            }
        }
        else
        {
            activeNo = 2;
            if (this.tag == "SphereLeft")
            {
                intColor = 0;
            }
            else if (this.tag == "SphereRight")
            {
                intColor = 2;
            }
            else
            {
                intColor = 1;
            }
        }
        //LeftMat = leftBall.GetComponent<Material[]>();
        rend.sharedMaterial = material[intColor];
    }

    // Update is called once per frame
    void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Pause == false)
            {
                Time.timeScale = 0;
                Pause = true;
            }
            else
            {
                Time.timeScale = 1;
                Pause = false;
            }
        }


        if (mngr.isTwo)
        {
            activeNo = 1;
        }
        else
        {
            activeNo = 2;
            if (!stopaddinggreen)
            {
                addGreenColor();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (intColor < activeNo)
            {
                intColor += 1;
            }
            else
            {
                intColor = 0;
            }
            rend.sharedMaterial = material[intColor];
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (intColor > 0)
            {
                intColor -= 1;
            }
            else
            {
                intColor = activeNo;
            }
            rend.sharedMaterial = material[intColor];
        }
        if (intColor == 2 && this.tag =="MainColor")

        {
            
       
            GameObject[] Blue = GameObject.FindGameObjectsWithTag("Blue");
            foreach (var item in Blue)
            {
                item.GetComponentInParent<BoxCollider>().enabled = false;
            }
            GameObject[] Red = GameObject.FindGameObjectsWithTag("Red");
            foreach (var item in Red)
            {
                item.GetComponentInParent<BoxCollider>().enabled = false;
            }
            GameObject[] Green = GameObject.FindGameObjectsWithTag("Green");
            foreach (var item in Green)
            {
                item.GetComponentInParent<BoxCollider>().enabled = true;                
            }
        }

        if (intColor ==0 && this.tag == "MainColor")
        {

            GameObject[] Green = GameObject.FindGameObjectsWithTag("Green");
            foreach (var item in Green)
            {
                item.GetComponentInParent<BoxCollider>().enabled = false;
            }
            GameObject[] Red = GameObject.FindGameObjectsWithTag("Red");
            foreach (var item in Red)
            {
                item.GetComponentInParent<BoxCollider>().enabled = false;
            }
            GameObject[] blue = GameObject.FindGameObjectsWithTag("Blue");
            foreach (var item in blue)
            {
                item.GetComponentInParent<BoxCollider>().enabled = true;
            }

        }
        if (intColor == 1 && this.tag == "MainColor")
        {

            GameObject[] Blue = GameObject.FindGameObjectsWithTag("Blue");
            foreach (var item in Blue)
            {
                item.GetComponentInParent<BoxCollider>().enabled = false;
            }
            GameObject[] Green = GameObject.FindGameObjectsWithTag("Green");
            foreach (var item in Green)
            {
                item.GetComponentInParent<BoxCollider>().enabled = false;
            }
            GameObject[] Red = GameObject.FindGameObjectsWithTag("Red");
            foreach (var item in Red)
            {
                item.GetComponentInParent<BoxCollider>().enabled = true;
            }

        }
        void addGreenColor(){
            
            if (this.tag == "SphereLeft")
            {
                intColor = 1;
            }
            else if (this.tag == "SphereRight")
            {
                intColor = 0;
            }
            else
            {
                intColor = 2;
            }
            rend.sharedMaterial = material[intColor];
            stopaddinggreen = true;
        }
    }
        
        
}

