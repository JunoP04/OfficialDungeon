using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemies : MonoBehaviour
{

    public Transform spawnPoint;
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public Transform spawnPoint4;

    public GameObject myPrefab;
    

    // Start is called before the first frame update
    void Update()
    {

        if(Input.GetKey(KeyCode.Backspace))
        { 
        Vector3 position_1 = spawnPoint.position;
        Instantiate(myPrefab, position_1, Quaternion.identity);
        spawnPoint.position += Vector3.forward * Time.deltaTime;
        Debug.Log("[<color=green>SPAWN MECHANIC] - spawned</color>");
        }
       

        if (Time.time == 2)
        {
            Debug.Log("<color=green>[SPAWN MECHANIC] -2 seconds passed...</color>");
        }
        

       


    }


}
