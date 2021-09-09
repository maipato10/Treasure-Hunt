using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource dyingSound;
    public Text text;
    public float restartDelay = 4f;
   
    public void EndGame()
    {

        FindObjectOfType<Blood>().DisplayBlood();
        text.gameObject.SetActive(true);
        dyingSound.Play();
        Restart();
    }
    public void Die()
    {
        //FindObjectOfType<Blood>().DisplayBloodEnemy();
        //gameObject.SetActive(false);
    }
    void Restart()
    {
        
        StartCoroutine("Restart2");
        
    }
    IEnumerator Restart2()
    {
        yield return new WaitForSeconds(restartDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

}
