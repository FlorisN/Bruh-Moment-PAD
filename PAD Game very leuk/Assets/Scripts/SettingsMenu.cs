using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{

    public AudioSource audioSrc;

    public float audioVolume = 1f;

    void Start ()
    {
        audioSrc = GetComponent<AudioSource>();
    }


    private void Update()
    {
        audioSrc.volume = audioVolume;
    }

    public void SetVolume(float vol)
    {
        audioVolume = vol;
    }
}
