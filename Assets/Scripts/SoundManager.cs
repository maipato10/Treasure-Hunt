using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip playerHitSound, keySound, finishSound;
    public static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        playerHitSound = Resources.Load<AudioClip>("dead");
        keySound = Resources.Load<AudioClip>("key");
        finishSound = Resources.Load<AudioClip>("finish");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlaySound(string sound)
    {
        switch (sound)
        {
            case "dead":
                audioSrc.PlayOneShot(playerHitSound);
                break;

            case "apple":
                audioSrc.PlayOneShot(keySound);
                break;

            case "finish":
                audioSrc.PlayOneShot(finishSound);
                break;
        }

    }
}
