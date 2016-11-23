using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using InControl;


public class DoorOpenTextDisplay : MonoBehaviour
{

    public Text textBox;
    public bool doorOpened = false;
    Animator doorOpenClose;
    AudioSource doorOpenSound;
    public Item requiredItem;
    public AudioSource doorLockedSound;
    InputDevice device;

	// Use this for initialization
	void Start ()
    {
        doorOpenClose = GetComponent<Animator>();
        doorOpenSound = GetComponent<AudioSource>();
	}

    void OnTriggerStay(Collider other)
    {
        device = InputManager.ActiveDevice;

        if (other.tag == "Player" && (Input.GetKeyDown(KeyCode.E) || device.Action2) && doorOpened == false && other.GetComponent<CustomFirstPersonController>().inventory.Contains(requiredItem))
        {
            doorOpened = true;            
            Open();
        }
        else if (other.tag == "Player" && (Input.GetKeyDown(KeyCode.E) || device.Action2) && doorOpened == false)
        {
            textBox.text = "It's locked";
            doorLockedSound.Play();
        }
        else if (other.tag == "Player" && doorOpened == true)
        {
            textBox.text = "";
        }
    }

    void OnTriggerExit (Collider other)
    {
        textBox.text = "";
    }

    void Open()
    {
        doorOpenSound.Play();
        doorOpenClose.SetTrigger("Activate");
        print("Something");
    }
	// Update is called once per frame
	void Update () {
	
	}
}
