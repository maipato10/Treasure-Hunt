using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour
{
    [SerializeField]
    private int startingHealth = 5;
    private int currentHealth;
    public HealthBar healthBar;
    public GameObject PlayerBood;
    public GameObject enemyBlood;
    private void OnEnable()
    {
        currentHealth = startingHealth;
        healthBar.SetMaxHealth(startingHealth);
    }

    public void TakeDamage(int damageAmount)
    {
        
        currentHealth -= damageAmount;
        healthBar.SetHealth(currentHealth);
        //gameObject.Ima
        if (currentHealth <= 0)
        {
            
            if (gameObject.tag == "soldier")
            {
                FindObjectOfType<Blood>().DisplayBlood();
                FindObjectOfType<GameManager>().EndGame();
            }
            else 
            {
                gameObject.GetComponent<Blood>().DisplayBloodEnemy();
                gameObject.SetActive(false);
            }
            //Die();
            

        }
        else
        {
            if (gameObject.tag == "soldier")
            {
                FindObjectOfType<Blood>().DisplayBlood();
            }
            else
            {
                gameObject.GetComponent<Blood>().DisplayBloodEnemy();
            }
        }
        
            
    }

    
}
