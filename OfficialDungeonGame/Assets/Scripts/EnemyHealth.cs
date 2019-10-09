using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyMaxHealth;
    float currenthealth;


    void Start()
    {
        currenthealth = enemyMaxHealth;
    }

    public void addDamage(float damage)
    {
        // currenthealth -= damage();
        // if(currenthealth <= 0) makeDead();
    }

    void makdeDead()
    {
        Destroy(gameObject);
    }
}
