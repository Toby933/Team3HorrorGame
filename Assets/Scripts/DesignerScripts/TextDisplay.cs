using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using InControl;


public class DooorOpenTextDisplay : MonoBehaviour {

    public Text textBox;
    public bool doorOpened = false;
    private Animator doorOpenClose;

	// Use this for initialization
	void Start ()
    {
        doorOpenClose = GetComponentInParent<Animator>();
	}

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && (Input.GetKeyDown(KeyCode.E) || InputManager.ActiveDevice.Action2))
        {
            doorOpened = true;
            textBox.text = "";
            Open();
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
