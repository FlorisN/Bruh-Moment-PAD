using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake: MonoBehaviour
{
    public float shakePower = 0.5f;             //how much effect the shake has on the camera.
    public float shakeTime = 0.2f;              //how long the effect lasts.
    public Transform camera;                    //reference for camera.
    public bool isShaking = false;              //should the camera shake or not.

    Vector3 startPosition;
    float starterShakeTime;    

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.transform;
        startPosition = camera.localPosition;
        starterShakeTime = shakeTime;
    }

    // Update is called once per frame
    void Update()
    {

        if (isShaking)
        {

            if (shakeTime > 0)
            {
                //change position of camera based on a Random.insideUnitSphere.
                //reduce shakeTime.
                camera.localPosition = startPosition + Random.insideUnitSphere * shakePower;
                shakeTime -= Time.deltaTime;
            }
            else
            {
                //when shakeTime is 0 or below, 
                //stop the shaking (isShaking = false), reset the shakeTime and the camera position.
                isShaking = false;
                shakeTime = starterShakeTime;
                camera.localPosition = startPosition;
            }
        }
    }

    public void needToShake()
    {
        isShaking = true;
    }
}