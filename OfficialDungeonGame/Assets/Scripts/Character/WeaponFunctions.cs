using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFunctions : MonoBehaviour
{
    public Animator meleeAnimation;

    // Start is called before the first frame update
    void Start()
    {
        meleeAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if right click is pressed play melee animation
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            meleeAnimation.Play("Melee");
        }
    }
}
