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
 

    // Update is called once per frame
    void Update()
    {

        float forceToApplyX = Random.Range(-0.01f, 0.02f);
        float forceToApplyY = Random.Range(-0.01f, 0.02f);
        float forceToApplyZ = Random.Range(-0.01f, 0.02f);
        TargetRigid = target.GetComponent<Rigidbody>();



        // new way, checks in a radius if there is any object of specific tag
        // then applies force to those objects
        // NVM - need to find a way for 3D
            //Collider2D[] hitColliders = Physics2D.OverlapCircleAll(center, radius);
            //int i = 0;
            //while (i < hitColliders.Length)
            //{
            //    if (hitColliders[i].tag == "CertainTag")
            //    {
            //        //do something
            //    }
            //    i++;
            //}
        


        // checks the public target, old way
        if (source)
        {
            //transform en = enemy.position;
            float dist = Vector3.Distance(source.position, target.position);

            if(dist > distanceThreshold)
            { 
                Debug.Log("<color=green>[TRAP MECHANIC] - Object is not in range of the trap, current distance is </color>" + dist);
                
            }
            if(dist == distanceThreshold)
            {
                Debug.Log("<color=green>[TRAP MECHANIC] - Enemy is in range. Current distance is </color>" + dist);
            }
            else if(dist < distanceThreshold)
            {
                StartCoroutine(wait2seconds());
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
        Debug.Log(Time.time);
        yield return new WaitForSeconds(2);
        Debug.Log(Time.time);
    }

    public void killNPC()
    {


    }
}
