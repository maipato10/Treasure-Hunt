using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    public Animator animator;
    public float velocity;
    private  int currentGrenate;
    public Text grenateNumber;

    [SerializeField]
    private float moveSpeed = 7.5f;
    [SerializeField]
    private float backwardMoveSpeed = 3;
    [SerializeField]
    private float turnSpeed = 150f;

    public float moveSpeedToUse;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        
    }

    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var movement = new Vector3(horizontal, 0, vertical);

        animator.SetFloat("Speed", vertical);
        velocity = animator.GetFloat("Speed");
        transform.Rotate(Vector3.up, horizontal * turnSpeed * Time.deltaTime);
        
        
        if (vertical != 0)
        {
            
             moveSpeedToUse = vertical > 0 ? moveSpeed : backwardMoveSpeed;
             characterController.SimpleMove(transform.forward * moveSpeedToUse * vertical);
            
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        
        
        if(other.tag == "bomb")
        {
            Pickable pickable = other.GetComponent<Pickable>();
            if (pickable != null)
            {
                currentGrenate = (Convert.ToInt32(grenateNumber.text)) + 1;
                Destroy(other.gameObject);
                grenateNumber.text = currentGrenate.ToString();
            }
        }
        else if(other.tag == "life")
        {
            LifeBoost lifeBoost = other.GetComponent<LifeBoost>();
            if (lifeBoost != null)
            {
                currentGrenate = (Convert.ToInt32(grenateNumber.text)) - 1;
                Destroy(other.gameObject);
                grenateNumber.text = currentGrenate.ToString();
            }
        }
        
        
    }
}
