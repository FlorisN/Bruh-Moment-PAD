using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioManager instance;                //Making sure we have only 1 insance of the AudioManager

    void Awake()
    {

        if (instance == null)
            instance = this;
        else
        {

            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);


        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();  //Add a AudioSource where there needs to be an audio
            s.source.clip = s.clip;

            s.source.volume = s.volume;                         
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

     void Start()
    {
        Play("BackgroundMusic");            //Play the audio with the name BackgroundMusic
    }
    public void Play(string name)           //Play method
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)                      //If there isn't a sound, it returns
            return;
        s.source.Play();                    //Play the audio that is now the s
    }
}
