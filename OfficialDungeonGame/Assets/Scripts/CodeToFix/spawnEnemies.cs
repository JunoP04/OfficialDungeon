using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemies : MonoBehaviour
{
    // ...
    public Transform targetSpawnNorth;
    public Transform targetSpawnEast;
    public Transform targetSpawnWest;
    public Transform targetSpawnSouth;
    public int spawnInterval = 3;

    public GameObject EnemyPrefab;

    // Update is called once per frame
    void Update()
    {

    
            if (Input.GetKey(KeyCode.Backspace))
            {
            SpawnEnemy(targetSpawnWest.position);
            }
        

    }

    // Update is called once per second
    void SpawnEnemy(Vector3 SpawnPosition)
    {

        
            //spawn an enemy at each spawnpoint
            //Vector3 position_1 = spawnPoint.position;
            //Instantiate(myPrefab, position_1, Quaternion.identity);
            //Vector3 position_2 = spawnPoint2.position;
            //Instantiate(myPrefab, position_2, Quaternion.identity);
            //Vector3 position_3 = spawnPoint3.position;
            Instantiate(EnemyPrefab, SpawnPosition, Quaternion.identity);
            //spawnPoint.position += Vector3.forward * Time.deltaTime;
            Debug.Log("[<color=green>SPAWN MECHANIC] - spawned at location: </color>" + SpawnPosition);


    }



}
