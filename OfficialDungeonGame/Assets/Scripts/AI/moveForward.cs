﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveForward : MonoBehaviour
{
    public float movementSpeed = 3f;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * movementSpeed;
    }
}
