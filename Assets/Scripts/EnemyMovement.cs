using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    //private AggroDetection aggroDetection;
    private Transform target;
    public GameObject Player;
    private float detectionRadius = 3;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        //aggroDetection = GetComponent<AggroDetection>();
        //aggroDetection.OnAggro += AggroDetection_OnAggro;
        //animator.SetFloat("Speed", 1.5f);
        //GetComponent<NavMeshAgent>().destination = Player.transform.position;


    }
    /*
    private void AggroDetection_OnAggro(Transform target)
    {

        this.target = target;
        navMeshAgent.SetDestination(target.position);
        float currentSpeed = navMeshAgent.velocity.magnitude;
        animator.SetFloat("Speed", currentSpeed);

    }
    */
    private void Update()
    {
        if (target != null)
        {
            //navMeshAgent.SetDestination(target.position);
            //float currentSpeed = navMeshAgent.velocity.magnitude;
            //animator.SetFloat("Speed", currentSpeed);

        }
        else
        {
            //animator.SetFloat("Speed", 1.5f);
            //GetComponent<NavMeshAgent>().destination = Player.transform.position;
        }
        


    }
}
