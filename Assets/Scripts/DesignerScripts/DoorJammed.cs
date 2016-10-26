using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DoorJammed : MonoBehaviour {

    public Text jammedText;
    public AudioSource jammedAudio;

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerStay (Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            jammedText.text = "It's jammed";
            jammedAudio.Play();
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.tag == "Player")
        {
            jammedText.text = "";
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
