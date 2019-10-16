using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorpseDestroy : MonoBehaviour
{
    public GameObject deadThing;
    //public GameObject resourceCounter;
    private float destroyTime = 10.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Decompose", destroyTime);
        //resourceCounter = GetComponent<GameManager>().resourceCounter;
    }


    public void Decompose()
    {
        //resourceCounter = GetComponent<GameManager>().resourceCounter;
        Debug.Log("Corpse has decomposed.");
        //resourceCounter.GetComponent<ResourceMonitor>().number += 1;
        Destroy(deadThing);
    }
}
