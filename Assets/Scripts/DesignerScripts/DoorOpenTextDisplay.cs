using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class DoorOpenTextDisplay : MonoBehaviour {

    public Text textBox;
    public bool doorOpened = false;
    private Animator doorOpenClose;
    AudioSource doorOpenSound;

	// Use this for initialization
	void Start ()
    {
        doorOpenClose = GetComponentInParent<Animator>();
        doorOpenSound = GetComponentInParent<AudioSource>();
	}

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            doorOpened = true;
            textBox.text = "";
            Open();
            doorOpenSound.Play();

        }
        else if (other.tag == "Player" && doorOpened == false)
        {
            textBox.text = "Press 'E' to open door";
        }
    }

    void OnTriggerExit (Collider other)
    {
        textBox.text = "";
    }

    void Open()
    {
        doorOpenClose.SetTrigger("Activate");
    }
	// Update is called once per frame
	void Update () {
	
	}
}
