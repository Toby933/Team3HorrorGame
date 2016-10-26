using UnityEngine;
using System.Collections;

public class SecretDoorOpen : MonoBehaviour {
    private AudioSource sound;
    private Animator doorOpen;
    // Use this for initialization
    void Start () {
        sound = GetComponent<AudioSource>();
        doorOpen = gameObject.GetComponent<Animator>();
    }

    void TurnOn()
    {
        sound.Play();
        doorOpen.SetTrigger("Activate");
    }
    }
