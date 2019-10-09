using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemies : MonoBehaviour
{
    private int nextUpdate = 1;
    // ...
    public Transform spawnPoint;
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public Transform spawnPoint4;
    public int spawnInterval = 3;

    public GameObject myPrefab;

    // Update is called once per frame
    void Update()
    {

        // If the next update is reached
        if (Time.time >= nextUpdate)
        {
            //Debug.Log(Time.time + ">=" + nextUpdate);
            // Change the next update (current second+1)
            nextUpdate = Mathf.FloorToInt(Time.time) + spawnInterval;
            // Call your fonction
            UpdatePerInterval();
        }

    }

    // Update is called once per second
    void UpdatePerInterval()
    {

        //if (Input.GetKey(KeyCode.Backspace))
        //{
            Vector3 position_1 = spawnPoint.position;
            Instantiate(myPrefab, position_1, Quaternion.identity);
            Vector3 position_2 = spawnPoint2.position;
            Instantiate(myPrefab, position_2, Quaternion.identity);
            Vector3 position_3 = spawnPoint3.position;
            Instantiate(myPrefab, position_3, Quaternion.identity);
            Vector3 position_4 = spawnPoint4.position;
            Instantiate(myPrefab, position_4, Quaternion.identity);
            //spawnPoint.position += Vector3.forward * Time.deltaTime;
            //Debug.Log("[<color=green>SPAWN MECHANIC] - spawned</color>");
        //}





    }



}
