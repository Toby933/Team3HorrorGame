using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_Documents : MonoBehaviour {

    public GameObject document;
    public Text uiTextBottom;
    public Text uiTextMiddle;
    bool documentOnScreen = false;

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
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E) && !documentOnScreen)
        {
            document.SetActive(true);
            documentOnScreen = true;
            uiTextBottom.text = "Press 'E' to close document";
        }
        else if (documentOnScreen == true && Input.GetKeyDown(KeyCode.E) && other.tag == "Player")
        {
            document.SetActive(false);
            documentOnScreen = false;
            uiTextBottom.text = "";
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            uiTextBottom.text = "";
            uiTextMiddle.text = "";
            document.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update () {
	
	}
}
