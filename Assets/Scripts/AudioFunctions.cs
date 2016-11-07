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

    [Tooltip("0-1 value")]
    public float baseJumpingAndLandingVolume = .3f;

    public float stepPauseTimer = 0;

    private CharacterController controller;

    private AudioSource audioSource;

    private float runSpeed;

    public void initialise(CharacterController controller, AudioSource audioSource, float runSpeed)
    {
        this.controller = controller;

        this.audioSource = audioSource;

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
            audioSource.clip = footStepsAudio[step];
            audioSource.volume = controller.velocity.magnitude / runSpeed; // Scales audio based on current velocity/ max velocity
            audioSource.PlayOneShot(audioSource.clip);

            footStepsAudio[step] = footStepsAudio[0];
            footStepsAudio[0] = audioSource.clip;
        }
        else
        {
            int step = Random.Range(1, altFootStepAudio.Length);
            audioSource.clip = altFootStepAudio[step];
            audioSource.volume = controller.velocity.magnitude / runSpeed;
            audioSource.PlayOneShot(audioSource.clip);

            altFootStepAudio[step] = altFootStepAudio[0];
            altFootStepAudio[0] = audioSource.clip;
        }
    }

    public void playJumpingAudio()
    {
        Debug.Log("playing jump");
        if (altJumpingAudio != null)
        {
            audioSource.clip = altJumpingAudio;
            if (controller.velocity.magnitude / runSpeed > .5f)
                audioSource.volume = controller.velocity.magnitude / runSpeed;
            else
                audioSource.volume = baseJumpingAndLandingVolume;
            audioSource.PlayOneShot(audioSource.clip);
            stepPauseTimer = .2f;
        }
        else
        {
            audioSource.clip = jumpingAudio;
            if (controller.velocity.magnitude / runSpeed > .5f)
                audioSource.volume = controller.velocity.magnitude / runSpeed;
            else
                audioSource.volume = baseJumpingAndLandingVolume;
            audioSource.PlayOneShot(audioSource.clip);
            stepPauseTimer = .2f;
        }
    }

    public void playLandingAudio()
    {
        Debug.Log("playing land");
        if (altLandingAudio != null)
        {
            audioSource.clip = altLandingAudio;
            if (controller.velocity.magnitude / runSpeed > .5f)
                audioSource.volume = controller.velocity.magnitude / runSpeed;
            else
                audioSource.volume = baseJumpingAndLandingVolume;
            audioSource.PlayOneShot(audioSource.clip);
            stepPauseTimer = .2f;
        }
        else
        {
            audioSource.clip = landingAudio;
            if (controller.velocity.magnitude / runSpeed > .5f)
                audioSource.volume = controller.velocity.magnitude / runSpeed;
            else
                audioSource.volume = baseJumpingAndLandingVolume;
            audioSource.PlayOneShot(audioSource.clip);
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
        audioSource.clip = footStepsAudio[step];
        audioSource.PlayOneShot(audioSource.clip);

        footStepsAudio[step] = footStepsAudio[0];
        footStepsAudio[0] = audioSource.clip;
    }
}
