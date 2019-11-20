using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFunctions : MonoBehaviour
{
    public Animator meleeAnimation;

    void Start()
    {
        meleeAnimation = GetComponent<Animator>();
    }

    void Update()
    {
        //if right click is pressed play melee animation
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            meleeAnimation.Play("Melee");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("You hit something");
        
        meleeAnimation.Play("MeleeBack");
    }
}
