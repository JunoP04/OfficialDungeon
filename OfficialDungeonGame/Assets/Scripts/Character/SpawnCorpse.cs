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
        Instantiate(corpse, deathPoint, Quaternion.identity);
        Debug.Log("Corpse Spawned");
    }
}
