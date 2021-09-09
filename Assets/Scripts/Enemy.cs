using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private AudioSource gunFire;

    [SerializeField]
    private float attackRefreshRate = 2f;

    private GameObject player;

    [SerializeField]
    private ParticleSystem muzzleParticle;

    //private AggroDetection aggroDetection;
    private Health healthTarget;
    private float attackTimer;
    public float detectionRadius = 10;
    private NavMeshAgent navMeshAgent;
    public Animator animator;
    bool playerDetected = false;
    private void Awake()
    {
        //aggroDetection = GetComponent<AggroDetection>();
        //aggroDetection.OnAggro += AggroDetection_OnAggro;
        navMeshAgent = GetComponent<NavMeshAgent>();
        //animator = GetComponent<Animator>();
    }
    /*
    private void AggroDetection_OnAggro(Transform obj)
    {
        Health health = obj.GetComponent<Health>();
        if (health != null)
        {
            healthTarget = health;
        }
    }
    */

    // Update is called once per frame
    void Update()
    {
        Collider[] results = Physics.OverlapSphere(transform.position, detectionRadius);
        bool playerFound = false;
        foreach (Collider hit in results)
        {
            GameObject go = hit.transform.gameObject;

            if (go.CompareTag("soldier"))
            {
                Debug.Log("Player detected");
                playerFound = true;
                navMeshAgent.SetDestination(go.transform.position);
                float currentSpeed = navMeshAgent.velocity.magnitude;
                animator.SetFloat("Speed", currentSpeed);
            }
        }

        


        if (healthTarget != null && playerDetected)
        {
            attackTimer += Time.deltaTime;
            if (CanAttack())
            {
                //gunFire.Play();
                Attack();
            }
        }
    }

    private bool CanAttack()
    {
        //gunFire.Play();
        return attackTimer >= attackRefreshRate;
    }
    

    private void Attack()
    {
        muzzleParticle.Play();
        gunFire.Play();
        attackTimer = 0;
        healthTarget.TakeDamage(1);
    }


}
