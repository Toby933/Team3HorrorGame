using UnityEngine;
using System.Collections;

public class altFootStepTerrain : MonoBehaviour
{
    public CustomFirstPersonController player;

    [Tooltip("Footstep audio")]
    public AudioClip[] footSteps;

    [Tooltip("Jump audio")]
    public AudioClip jumpSound = null;

    [Tooltip("Land audio")]
    public AudioClip landSound = null;

	// Use this for initialization
	void Start ()
    {
	    
	}

    public void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            player.audioManager.altFootStepAudio = footSteps;

            if (jumpSound != null)
                player.audioManager.altJumpingAudio = jumpSound;

            if (landSound != null)
                player.audioManager.altLandingAudio = landSound;
        }
    }

    public void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            player.audioManager.altFootStepAudio = new AudioClip[0];

            player.audioManager.altJumpingAudio = null;

            player.audioManager.altLandingAudio = null;
        }
                
    }
}
