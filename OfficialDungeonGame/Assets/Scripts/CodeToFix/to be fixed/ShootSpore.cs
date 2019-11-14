using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSpore : MonoBehaviour
{
    public GameObject theProjectile;
    //public float shootTime;
    //public int chanceShoot;
    public Transform shootFrom;

    public float sporeSpeedHigh;
    public float sporeSpeedLow;
    public float sporeAngle;
   //public float sporeTorqueAngle;

    Rigidbody ProjectileRB;

    float nextShootTime;
   // Animator cannonAnim;

    // Start is called before the first frame update
    void Start()
    {
        // cannonAnim = GetComponentInChildren<Animator>();
        nextShootTime = 0f;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")// && nextShootTime < Time.time)
        {
           // nextShootTime = Time.time + shootTime;
            //if (Random.Range(0, 10) >= chanceShoot)
           // {
            Instantiate(theProjectile, shootFrom.position, Quaternion.identity);
            ProjectileRB = GetComponent<Rigidbody>();
            ProjectileRB.AddForce(new Vector3(Random.Range(-sporeAngle, sporeAngle), Random.Range(sporeSpeedLow, sporeSpeedHigh), Random.Range(sporeSpeedLow, sporeSpeedHigh)), ForceMode.Impulse);
            //  cannonAnim.SetTrigger("cannonShoot");
            Debug.Log("[TOWER MECHANIC] - A projectile shot!");
           // }
        }
    }
}
