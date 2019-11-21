using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectile : MonoBehaviour
{
    public GameObject projectile;
    public GameObject spawnPoint;
    public float launchVelocity;

    private void Update()
    {
        //U button shoots a projectile "FireBall" forward of the camera
        if (Input.GetKeyDown(KeyCode.U))
        {
            ShootBall();
        }
    }

    void ShootBall()
    {
        //Shoots a projectile from the spawn point in front of the players
        GameObject go = Instantiate(projectile, spawnPoint.transform.position, Quaternion.identity);
        Rigidbody rb = go.GetComponentInChildren<Rigidbody>();
        rb.AddForce(transform.forward * launchVelocity);
        Destroy(go, 1.0f);
    }
}
