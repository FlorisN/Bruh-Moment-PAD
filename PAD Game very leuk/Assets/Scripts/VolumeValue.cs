using UnityEngine;

public class VolumeValue : MonoBehaviour
{

    private AudioSource audioSrc;               //Reference to Audio Source component



    private float audioVolume = 1f;             //Audio volume variable will be modified by the slider


    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();         //Assign Audio Source component to control it
    }


    private void Update()                       //Setting volume option of Audio Source equal to audioVolume
    {
        audioSrc.volume = audioVolume;
    }

    public void SetVolume(float vol)            //Method that is called by slider, takes volume value to the slider and sets as audioValue
    {
        audioVolume = vol;
    }
}
