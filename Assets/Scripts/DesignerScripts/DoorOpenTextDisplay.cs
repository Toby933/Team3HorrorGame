using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class DoorOpenTextDisplay : MonoBehaviour
{

    public Text textBox;
    public bool doorOpened = false;
    Animator doorOpenClose;
    AudioSource doorOpenSound;

	// Use this for initialization
	void Start ()
    {
        doorOpenClose = GetComponent<Animator>();
        doorOpenSound = GetComponent<AudioSource>();
	}

    void OnTriggerStay(Collider other)
    {
        textBox.text = "Press 'E' to open door";
        if (other.tag == "Player" && Input.GetKey(KeyCode.E) && doorOpened == false)
        {
            doorOpened = true;
            Open();
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
