using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //Function is called when the fireball hits another collider
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("You hit something with a ball");
        //Destroys an object with the tag Enemy
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Killed");
            Destroy(other.gameObject);
        }
    }
}