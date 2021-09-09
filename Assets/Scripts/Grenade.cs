using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public GameObject explosiveEffect;
    public float delay = 1f;
    public float explosiveForce = 10f;
    public float radius = 20f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Explode", delay);
    }

    // method that causes the explosion
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider near in colliders)
        {
            Rigidbody rig = near.GetComponent<Rigidbody>();

            if (rig != null)
            rig.AddExplosionForce(explosiveForce,transform.position,radius,1f,ForceMode.Force);
        }
        //Explosion effect
        Instantiate(explosiveEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
