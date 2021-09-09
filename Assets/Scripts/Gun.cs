using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    [Range(0.1f,1.5f)]
    private float fireRate = 0.3f;

    [SerializeField]
    [Range(1, 10)]
    private int damage = 1;

    

    [SerializeField]
    private ParticleSystem muzzleParticle;

    [SerializeField]
    private AudioSource gunFire;

    private float timer;
    
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= fireRate)
        {
            if (Input.GetButtonDown("Fire1")/*|| Input.GetKeyDown(KeyCode.Space)*/)
            {
                timer = 0f;
                FireGun();
            }
        }
    }

    private void FireGun()
    {

        muzzleParticle.Play();
        gunFire.Play();
        Ray ray = Camera.main.ViewportPointToRay(Vector3.one * 0.5f);
        Debug.DrawRay(ray.origin, ray.direction * 20, Color.red, 2f);
        RaycastHit hitInfo;

        
        if (Physics.Raycast(ray, out hitInfo, 20))
        {
            var health = hitInfo.collider.GetComponent<Health>();

            if (health != null)
                health.TakeDamage(damage);
        }
    }
}
