using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blood : MonoBehaviour
{
    public GameObject PlayerBood;
    public GameObject enemyBlood;
    private float sec = 0.5f;
    public void DisplayBlood()
    {
        PlayerBood.SetActive(true);
        //PlayerBood.SetActive(true)
        StartCoroutine(Late1());
        
    }
    public void DisplayBloodEnemy()
    {
        
        enemyBlood.SetActive(true);
        StartCoroutine(Late2());
        //enemyBlood.SetActive(false);

    }

    private IEnumerator Late1()
    {
        yield return new WaitForSeconds(sec);
        PlayerBood.SetActive(false);
    }

    private IEnumerator Late2()
    {
        yield return new WaitForSeconds(sec);
        enemyBlood.SetActive(false);
    }
}
