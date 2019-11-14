using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float damage;
    public float damageRate;
    public float pushBackForce;


    float nextDamage;


    // Start is called before the first frame update
    void Start()
    {
        nextDamage = 0f;  //take immediate damage
    }

    // Update is called once per frame
    void Update()
    {
        //********************CHANGE FROM 2D
    }
    //Used to be OnTriggerStay but switched for Marks.
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && nextDamage < Time.time)
        {
            PlayerHealth thePlayerHealth = other.gameObject.GetComponent<PlayerHealth>();
            thePlayerHealth.AddDamage(damage);
            nextDamage = Time.time + damageRate;

            PushBack(other.transform);
        }
    }

    void PushBack(Transform pushedObject)
    {
        Vector2 pushDirection = new Vector2(0, (pushedObject.position.y - transform.position.y)).normalized;
        pushDirection *= pushBackForce; //multiply normalized vector by pushback force
        Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D>();//find rigidbody
        pushRB.velocity = Vector2.zero;//set velocity to 0
        pushRB.AddForce(pushDirection, ForceMode2D.Impulse);//add directional force as pushback

    }
}

