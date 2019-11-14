using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapFunction : MonoBehaviour
{
    //private int distanceThreshold = 2000;

    //public GameObject trap;
    public Transform target; //player, enemy...
    public Transform source; //trap
    private float distanceThreshold = 27f;
    private Rigidbody TargetRigid;


    private void Start()
    {
        GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag("Enemy");

        if (gameObjects.Length > 0)
        {
            Debug.Log("Enemy tag is present...");
        }

        if (gameObjects.Length > 0)
        {
            Debug.Log("Enemy tag is present...");
        }
    }

    //public GameObject FindClosestEnemy()
    //{
    //    GameObject[] gos;
    //    gos = GameObject.FindGameObjectsWithTag("Enemy");
    //    GameObject closest = null;
    //    float distance = Mathf.Infinity;
    //    Vector3 position = transform.position;
    //    foreach (GameObject go in gos)
    //    {
    //        Vector3 diff = go.transform.position - position;
    //        float curDistance = diff.sqrMagnitude;
    //        if (curDistance < distance)
    //        {
    //            closest = go;
    //            distance = curDistance;
                
    //        }
    //    }
    //    return closest;
       
    //}

// Update is called once per frame
void Update()
    {
        StartCoroutine(wait2seconds());
        float forceToApplyX = Random.Range(-0.01f, 0.02f);
        float forceToApplyY = Random.Range(-0.01f, 0.02f);
        float forceToApplyZ = Random.Range(-0.01f, 0.02f);
        TargetRigid = target.GetComponent<Rigidbody>();



        // checks the public target, old way
        if (source)
        {
            //transform en = enemy.position;
            float dist = Vector3.Distance(source.position, target.position);

            if(dist > distanceThreshold)
            {
                //FindClosestEnemy();
                //Debug.Log("<color=green>[TRAP MECHANIC] - Object is not in range of the trap, current distance is </color>" + dist);

            }
            if(dist == distanceThreshold)
            {
                //Debug.Log("<color=green>[TRAP MECHANIC] - Enemy is in range. Current distance is </color>" + dist);
            }
            else if(dist < distanceThreshold)
            {
                //StartCoroutine(wait2seconds());
                TargetRigid.AddForce(new Vector3(forceToApplyX, forceToApplyY, forceToApplyZ), ForceMode.Impulse);
                //Destroy(target.gameObject);
                Debug.Log("<color=green>[TRAP MECHANIC] - Enemy interacted with a trap. Damaged! Distance is </color>" + dist);
            }
            //while (dist < 200f)
            //{ 
            ////Debug.Log("Enemy is in range. Current distance is " + dist);

            //    //if (dist == 2000)
            //    //{
            //    //    //Destroy(enemy);
            //    //    Debug.Log("Enemy interacted with a trap. Destroyed!" + dist);
            //    //    break;
            //    //}

            //}
        }
        //if (dist <= 10)
        //{
        //    Destroy(enemy);
        //    Debug.Log("enemy destroyed");
        //}
    }



    IEnumerator wait2seconds()
    {
        //Debug.Log(Time.time);
        yield return new WaitForSeconds(2);
        //Debug.Log(Time.time);
    }

    public void killNPC()
    {


    }
}
