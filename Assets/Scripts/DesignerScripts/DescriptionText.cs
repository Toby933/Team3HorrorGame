using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using InControl;

public class DescriptionText : MonoBehaviour {
    public string textOutput = "Fill me in you big girl";
    public Text descriptionText;
    bool textOnScreen = false;
    public bool keyPress = true;
    InputDevice device;

    // Use this for initialization
    void Start()
    {
        descriptionText.text = "";
    }

    void OnTriggerStay(Collider other)
    {
        device = InputManager.ActiveDevice;
        if (keyPress) { 
        if (other.tag == "Player" && (Input.GetKeyDown(KeyCode.E) || device.Action2) && !textOnScreen)
        {
            descriptionText.text = textOutput;
            textOnScreen = true;
        }
        else if (other.tag == "Player" && (Input.GetKeyDown(KeyCode.E) || device.Action2) && textOnScreen == true)
        {
            descriptionText.text = "";
            textOnScreen = false;
        }
        }
        if (!keyPress)
        {
            if (other.tag == "Player"  && !textOnScreen)
            {
                descriptionText.text = textOutput;
                textOnScreen = true;
            }
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.tag == "Player")
        {
            descriptionText.text = "";
            textOnScreen = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
