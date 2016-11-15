using UnityEngine;
using System.Collections;

public class NoiseMaker : MonoBehaviour {
    private AudioSource toot;
    private bool hasPlayed = false;
	// Use this for initialization
    void OnTriggerExit (Collider other)
    {
        if (!hasPlayed)
        {
            TurnOn();
            hasPlayed = true;
        }
    }
	void Start () {
        toot = GetComponent<AudioSource>();
	}
    void TurnOn()
    {
        toot.Play();
    }
}
