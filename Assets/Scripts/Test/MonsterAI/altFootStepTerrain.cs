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
            player.altFootStepAudio = footSteps;

            if (jumpSound != null)
                player.altJumpingAudio = jumpSound;

            if (landSound != null)
                player.altLandingAudio = landSound;
        }
    }

    public void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            player.altFootStepAudio = new AudioClip[0];

            player.altJumpingAudio = null;

            player.altLandingAudio = null;
        }
                
    }
}
