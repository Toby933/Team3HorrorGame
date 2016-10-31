using UnityEngine;
using System.Collections;

public class SecretDoorOpen : MonoBehaviour {
    private AudioSource sound;
    private Animator doorOpen;
    private bool turnedOn=false;
    // Use this for initialization
    void Start () {
        sound = GetComponent<AudioSource>();
        doorOpen = gameObject.GetComponent<Animator>();
    }

    void TurnOn()
    {
        if (turnedOn)
        {
            sound.Play();
            doorOpen.SetTrigger("DeActivate");
        }
        if (!turnedOn)
        {
            sound.Play();
            doorOpen.SetTrigger("Activate");
            turnedOn = true;
        }
        
    }
    }
