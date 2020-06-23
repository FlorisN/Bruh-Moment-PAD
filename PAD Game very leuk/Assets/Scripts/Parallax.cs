using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    //We need to know the length and start pos of the sprite.
    private float lengthSprite, startPosSprite;

    //Camera
    public GameObject cam;

    //How much parallax effect we want to give to our background.
    public float parallaxEffect;
    void Start()
    {
        //We need to find the start position and the length.
        startPosSprite = transform.position.x;

        //Bounds.size.x will give us the length of the sprite in x.
        lengthSprite = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));

        //How far we have moved in world space.
        float dist = (cam.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startPosSprite + dist, transform.position.y, transform.position.z);
        if (temp > startPosSprite + lengthSprite) startPosSprite += lengthSprite;
        else if (temp < startPosSprite - lengthSprite) startPosSprite -= lengthSprite;
    }
}