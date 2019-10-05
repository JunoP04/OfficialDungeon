using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemies : MonoBehaviour
{

    public Transform spawnPoint;
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public Transform spawnPoint4; 

    public float waveNumber = 0f;
    public float cooldown = 15f;
    public int interval  = 1;
    public int timer = 0;

    //private int wave_1Threshold = 15;
    //private int wave_2Threshold = 30;

    public GameObject myPrefab;
    

    // Start is called before the first frame update
    void Update()
    {

        if(timer == 15)
        { 
        Vector3 position_1 = spawnPoint.position;
        Instantiate(myPrefab, position_1, Quaternion.identity);
        spawnPoint.position += Vector3.forward * Time.deltaTime;
        Debug.Log("spawned");
        }
        //Vector3.MoveTowards

        timer = +1;

        if (Time.time >= interval)
        {
        interval = Mathf.FloorToInt(Time.time) + 1;
        UpdateEverySecond();



        }


    }

    // Update is called once per second
    void UpdateEverySecond()
    {

        Debug.Log("spawn enemies script running");
        timer = +1;

    }
}
