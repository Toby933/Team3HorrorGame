using UnityEngine;
using System.Collections;

public class SecretDoorOpen : MonoBehaviour {
    
    private Animator doorOpen;
    // Use this for initialization
    void Start () {
	doorOpen= gameObject.GetComponent<Animator>();
    }

    void TurnOn()
    {
        doorOpen.SetTrigger("Activate");
    }
    }
