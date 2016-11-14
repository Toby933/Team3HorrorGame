using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemDescription : MonoBehaviour
{
    [HideInInspector] public string description;

    public Text textOutput;

    private bool textOnScreen = false;

    

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
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
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
