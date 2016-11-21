using UnityEngine;
using System.Collections;


[System.Serializable]
public class AudioFunctions
{
    [SerializeField]
    private AudioClip[] footStepsAudio;

    [HideInInspector]
    public AudioClip[] altFootStepAudio = null;

    [SerializeField]
    private AudioClip jumpingAudio;

    [HideInInspector]
    public AudioClip altJumpingAudio = null;

    [SerializeField]
    private AudioClip landingAudio;

    [HideInInspector]
    public AudioClip altLandingAudio = null;

    [Tooltip("In order of severity (low to high)")]
    [SerializeField]
    private AudioClip[] hurtAudio;

    [SerializeField]
    AudioClip outOfBreathAudio;

    [Tooltip("0-1 value")]
    public float baseJumpingAndLandingVolume = .3f;

    public float stepPauseTimer = 0;

    private CharacterController controller;

    private AudioSource[] audioSource;

    private float runSpeed;

    public void initialise(CharacterController controller, AudioSource audioSource, float runSpeed)
    {
        this.controller = controller;

        this.audioSource = controller.GetComponentsInParent<AudioSource>();

        this.runSpeed = runSpeed;
    }

    // Plays default footstep
    public void playFootStepAudio()
    {
        // Only plays footstep while player is grounded
        if (!controller.isGrounded || stepPauseTimer > 0)
            return;

        stepPauseTimer = .2f;

        // Checks for whether there are alt footsteps audio to play
        if (altFootStepAudio.Length == 0)
        {
            int step = Random.Range(1, footStepsAudio.Length); // Picks random footstep from array to play
            audioSource[0].clip = footStepsAudio[step];
            audioSource[0].volume = controller.velocity.magnitude / runSpeed; // Scales audio based on current velocity/ max velocity
            audioSource[0].PlayOneShot(audioSource[0].clip);

            footStepsAudio[step] = footStepsAudio[0];
            footStepsAudio[0] = audioSource[0].clip;
        }
        else
        {
            int step = Random.Range(1, altFootStepAudio.Length);
            audioSource[0].clip = altFootStepAudio[step];
            audioSource[0].volume = controller.velocity.magnitude / runSpeed;
            audioSource[0].PlayOneShot(audioSource[0].clip);

            altFootStepAudio[step] = altFootStepAudio[0];
            altFootStepAudio[0] = audioSource[0].clip;
        }
    }

    public void playExhausted()
    {
        audioSource[1].clip = outOfBreathAudio;
        if (!audioSource[1].isPlaying)
            audioSource[1].Play();
    }

    public void stopExhausted()
    {
        if (audioSource[1].isPlaying)
            audioSource[1].Stop();
    }

    public void playJumpingAudio()
    {
        if (altJumpingAudio != null)
        {
            audioSource[0].clip = altJumpingAudio;
            if (controller.velocity.magnitude / runSpeed > .5f)
                audioSource[0].volume = controller.velocity.magnitude / runSpeed;
            else
                audioSource[0].volume = baseJumpingAndLandingVolume;
            audioSource[0].PlayOneShot(audioSource[0].clip);
            stepPauseTimer = .2f;
        }
        else
        {
            audioSource[0].clip = jumpingAudio;
            if (controller.velocity.magnitude / runSpeed > .5f)
                audioSource[0].volume = controller.velocity.magnitude / runSpeed;
            else
                audioSource[0].volume = baseJumpingAndLandingVolume;
            audioSource[0].PlayOneShot(audioSource[0].clip);
            stepPauseTimer = .2f;
        }
    }

    public void playLandingAudio()
    {
        if (altLandingAudio != null)
        {
            audioSource[0].clip = altLandingAudio;
            if (controller.velocity.magnitude / runSpeed > .5f)
                audioSource[0].volume = controller.velocity.magnitude / runSpeed;
            else
                audioSource[0].volume = baseJumpingAndLandingVolume;
            audioSource[0].PlayOneShot(audioSource[0].clip);
            stepPauseTimer = .2f;
        }
        else
        {
            audioSource[0].clip = landingAudio;
            if (controller.velocity.magnitude / runSpeed > .5f)
                audioSource[0].volume = controller.velocity.magnitude / runSpeed;
            else
                audioSource[0].volume = baseJumpingAndLandingVolume;
            audioSource[0].PlayOneShot(audioSource[0].clip);
            stepPauseTimer = .2f;
        }
    }

    // Plays custom footsteps
    public void playFootStepAudio(AudioClip[] footStepsAudio)
    {
        if (!controller.isGrounded || stepPauseTimer > 0)
            return;

        stepPauseTimer = .2f;

        int step = Random.Range(1, footStepsAudio.Length);
        audioSource[0].clip = footStepsAudio[step];
        audioSource[0].PlayOneShot(audioSource[0].clip);

        footStepsAudio[step] = footStepsAudio[0];
        footStepsAudio[0] = audioSource[0].clip;
    }

    // Plays hurt audio accord to float ranging from 0-1 (0-100%)
    public void playHurtAudio(float serverity)
    {
        if (serverity > 1)
            serverity = 1;

        int index = (int)Mathf.Floor(hurtAudio.Length * serverity);

        if (index == hurtAudio.Length)
            index = hurtAudio.Length - 1;

        audioSource[1].PlayOneShot(hurtAudio[index]);
    }
}
