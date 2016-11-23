using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using InControl;

public class DoorJammed : MonoBehaviour {

    public Text jammedText;
    public AudioSource jammedAudio;
    InputDevice device;

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerStay (Collider other)
    {
        device = InputManager.ActiveDevice;
        if (other.tag == "Player" && (Input.GetKeyDown(KeyCode.E) || device.Action2))
        {
            jammedText.text = "It's jammed";
            jammedAudio.Play();
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.tag == "Player")
        {
            jammedText.text = "";
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
