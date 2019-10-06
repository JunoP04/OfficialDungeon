using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    float Speed = 5.0F;
    float JHeight = 0.7f;
    //efe
    //private bool Jumping;
    public LayerMask PhysicalLayer;
    private Rigidbody rb;
    public float timeVar;
    public CapsuleCollider col;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        timeVar = 1;
        //efe
        //Jumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(IsGrounded());
        float translation = Input.GetAxis("Vertical") * Speed;
        float strafe = Input.GetAxis("Horizontal") * Speed;
        translation *= (Time.deltaTime * timeVar);
        strafe *= (Time.deltaTime * timeVar);

        transform.Translate(strafe, 0, translation);

        if (IsGrounded() && Input.GetKey(KeyCode.Space))
        {

            rb.AddForce(new Vector3(0, JHeight, 0), ForceMode.Impulse);

        }
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

    }





    private bool IsGrounded()
    {
        
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * 0.9f, PhysicalLayer);
    }

}
