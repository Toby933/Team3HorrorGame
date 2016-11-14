using UnityEngine;
using System.Collections;

public class SoundPlayer : MonoBehaviour
{
    public AudioClip sound;

    public float volume = 1f;

    private AudioSource audioSource;

	// Use this for initialization
	void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = sound;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void playSound()
    {
        audioSource.Play();
    }
}
