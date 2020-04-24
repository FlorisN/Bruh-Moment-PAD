using UnityEngine.Audio;
using UnityEngine;


[System.Serializable]                       //A custum class can appear in the Inspector in Unity when this is called
public class Sound {

    public string name;                     //These are all settings to change inside of Unity

    public AudioClip clip;

    [Range(0f, 1f)]                         //Minimum and maximum value to change inside of Unity
    public float volume;
    [Range(.1f, 3)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
