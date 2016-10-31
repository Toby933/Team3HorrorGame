using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemDescription : MonoBehaviour
{
    public string description;

    private bool textOnScreen = false;

    private Text text;

	// Use this for initialization
	void Start ()
    {
        text = FindObjectOfType<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            text.text = description;

            if (text == null)
                Debug.Log("No Text Field Found");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            text.text = "";
        }
    }
}
