using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using InControl;

public class ItemDescription : MonoBehaviour
{
    [HideInInspector] public string description;

    public Text textOutput;

    private bool textOnScreen = false;

    InputDevice device;

	// Use this for initialization
	void Start ()
    {
        if(textOutput == null)
        {
            foreach (Text t in FindObjectsOfType<Text>())
            {
                if (t.tag == "Item")
                {
                    textOutput = t;
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    void OnTriggerStay(Collider other)
    {
        device = InputManager.ActiveDevice;

        if (other.tag == "Player" && (Input.GetKey(KeyCode.E) || device.Action2))
        {
            textOutput.text = description;

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            textOutput.text = "";
        }
    }
}
