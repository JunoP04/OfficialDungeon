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
        if (Input.GetKeyDown(KeyCode.U))
        {
            ShootBall();
        }
    }

    void ShootBall()
    {
        GameObject go = Instantiate(projectile, spawnPoint.transform.position, Quaternion.identity);
        Rigidbody rb = go.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * launchVelocity);
        Destroy(go, 1.0f);
    }
}
