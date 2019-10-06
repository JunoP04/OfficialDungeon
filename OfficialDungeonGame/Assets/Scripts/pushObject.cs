using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushObject : MonoBehaviour
{

    private float speed = 5f;

    private Rigidbody body;

    void Start()
    {
        body = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {


        
        if (Input.GetKey(KeyCode.Tab))
        {
            Debug.Log("TAB pressed...");
            body.AddForce(new Vector3(1, 0, 0), ForceMode.Impulse);
        }
    }
}
