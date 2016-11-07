using System;
using UnityEngine;
using System.Collections;


[Serializable]
public class HeadBobber
{
    [Tooltip("How quickly head bob animation plays")]
    public float bobSpeed = 1f;

    [Tooltip("Amount of head bob")]
    public float bobAmount = .2f;

    [Tooltip("Smooths transition between moving and not moving")]
    public float transitionSpeed = 10f;
    
    // Initialized as half pi so that camera starts at crest of sin wave (Starts bobing upwards)
    private float timer = (float)Math.PI /2;

    // Ref to camera
    private Camera FPCamera;

    // Stores original localtransform of camera
    private Vector3 originalCameraPos;

    public void SetUp(Camera cameraRef)
    {
        FPCamera = cameraRef;
        originalCameraPos = FPCamera.transform.localPosition;
    }

    // Bobs head, call in update
    public void BobHead(float speedModifier, CustomFirstPersonController player)
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) //moving
        {
            // Scales headBob speed depending on how fast player is moving
            timer += bobSpeed * speedModifier * Time.deltaTime;

            //use the timer value to set the position
            Vector3 newPosition = new Vector3(Mathf.Cos(timer) * bobAmount, 
                                                originalCameraPos.y + Mathf.Abs((Mathf.Sin(timer) * bobAmount)), 
                                                originalCameraPos.z); //abs val of y for a parabolic path

            //Debug.Log(Mathf.Abs(Mathf.Sin(timer)));

            if (Mathf.Abs(Mathf.Sin(timer)) < .1)
                player.audioManager.playFootStepAudio();


            FPCamera.transform.localPosition = newPosition;
        }
        else
        {
            timer = Mathf.PI / 2; //reinitialize

            // Lerp back to original cam position for smooth transition
            Vector3 newPosition = new Vector3(Mathf.Lerp(FPCamera.transform.localPosition.x, originalCameraPos.x, transitionSpeed * Time.deltaTime),
                                            Mathf.Lerp(FPCamera.transform.localPosition.y, originalCameraPos.y, transitionSpeed * Time.deltaTime), 
                                            Mathf.Lerp(FPCamera.transform.localPosition.z, originalCameraPos.z, transitionSpeed * Time.deltaTime));
            FPCamera.transform.localPosition = newPosition;
        }

        // Reset timer after full cycle
        if (timer > Mathf.PI * 2) 
            timer = 0;
    }
}

