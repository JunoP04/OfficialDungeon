using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapFunction : MonoBehaviour
{
    //private int distanceThreshold = 2000;

    //public GameObject trap;
    public Transform target; //player, enemy...
    public Transform source; //trap

    // Update is called once per frame
    void Update()
    {
  

        if (source)
        {
            //transform en = enemy.position;
            float dist = Vector3.Distance(source.position, target.position);
            Debug.Log("Player is not in range of the trap, current distance is +" + dist);

            while (dist < 2000)
            { 
            Debug.Log("Enemy is in range. Current distance is " + dist);
            
                if (dist == 2000)
                {
                    //Destroy(enemy);
                    Debug.Log("Enemy interacted with a trap. Destroyed!" + dist);
                    break;
                }
      
            }
        }
        //if (dist <= 10)
        //{
        //    Destroy(enemy);
        //    Debug.Log("enemy destroyed");
        //}
    }
}
