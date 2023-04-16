using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;
    
    public AudioSource GunSound;
    public AudioClip fireclip;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void PlayFireSound()
    {
        GunSound.clip = fireclip;
        GunSound.Play();
    }
}
