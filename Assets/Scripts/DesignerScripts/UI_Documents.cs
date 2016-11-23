using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using InControl;

public class UI_Documents : MonoBehaviour {

    public GameObject document;
    public Text uiTextBottom;
    public Text uiTextMiddle;
    public AudioSource pagePickUp;
    public AudioSource pagePutDown;
    bool documentOnScreen = false;
    InputDevice device;


	// Use this for initialization
	void Start ()
    {
	
	}

    void OnTriggerEnter(Collider other)
    { if (other.tag == "Player")
        {
            uiTextMiddle.text = "Press 'E' to look at document";
        }
    }
    void OnTriggerStay(Collider other)
    {
        device = InputManager.ActiveDevice;

        if (other.tag == "Player" && (Input.GetKeyDown(KeyCode.E) || device.Action2) && !documentOnScreen)
        {
            document.SetActive(true);
            documentOnScreen = true;
            uiTextMiddle.text = "";
            uiTextBottom.text = "Press 'E' to close document";
            pagePickUp.Play();
        }
        else if (documentOnScreen == true && (Input.GetKeyDown(KeyCode.E) || device.Action2) && other.tag == "Player")
        {
            document.SetActive(false);
            documentOnScreen = false;
            uiTextBottom.text = "";
            pagePutDown.Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            uiTextBottom.text = "";
            uiTextMiddle.text = "";
            document.SetActive(false);
            //pagePutDown.Play();            
        }
    }
    // Update is called once per frame
    void Update () {
	
	}
}
