using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    PlayerMovement character;
    public AudioSource walking;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
       if(character.velocity == 0)
        {
            walking.Play();
        }
    }
}
