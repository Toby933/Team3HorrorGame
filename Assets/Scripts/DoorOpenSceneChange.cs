using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using InControl;

public class DoorOpenSceneChange : MonoBehaviour {

    public Text textAppear;

    InputDevice device;

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            textAppear.text = "Press E to Enter Mansion";
        }
    }

    void OnTriggerStay (Collider other)
    {
        device = InputManager.ActiveDevice;
        if (other.tag == "Player" && (Input.GetKey(KeyCode.E) || device.Action2))
        {
            SceneManager.LoadScene("02_Manor");
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.tag == "Player")
        {
            textAppear.text = "";
        }
    }

	
	// Update is called once per frame
	void Update () {
	
	}
}
