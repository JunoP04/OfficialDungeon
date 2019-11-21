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

    //When the weapon hits an object with a collider run this function
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("You hit something");
        //retracts the weapon when it hits anothe object with a collider
        meleeAnimation.Play("MeleeBack");
        //Destroys any object with an Enemy tag
        if(other.gameObject.tag == "Enemy")
        {
            Debug.Log("Killed");
            Destroy(other.gameObject);
        }
    }
}
