using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DescriptionText : MonoBehaviour {

    public Text descriptionText;
    bool textOnScreen = false;

    // Use this for initialization
    void Start()
    {

    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E) && !textOnScreen)
        {
            descriptionText.text = "Nothing of interest";
            textOnScreen = true;
        }
        else if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E) && textOnScreen == true)
        {
            descriptionText.text = "";
            textOnScreen = false;
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.tag == "Player")
        {
            descriptionText.text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
