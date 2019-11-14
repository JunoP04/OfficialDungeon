using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachPlayer : MonoBehaviour
{
    public GameObject Player;
    //if the player stands on a moving platform, this will adopt the speed of the moving platform
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {

            Player.transform.parent = transform;
        }
    }
    //once the player leaves the moving platform they no longer adopt that platform's speed
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            Player.transform.parent = null;
        }
    }
   
}
