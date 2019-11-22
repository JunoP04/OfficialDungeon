using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCorpse : MonoBehaviour
{
    public GameObject corpse;
    public Vector3 deathPoint;

    private void OnDestroy()
    {

        deathPoint = gameObject.GetComponent<Transform>().position;
        deathPoint = new Vector3(deathPoint.x, (deathPoint.y - 0.6f), deathPoint.z);
        Instantiate(corpse, deathPoint, transform.rotation * Quaternion.Euler(90,0,0));
        Debug.Log("Corpse Spawned");
    }
}
