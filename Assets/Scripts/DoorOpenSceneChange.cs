using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoorOpenSceneChange : MonoBehaviour {

    public Text textAppear;

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            textAppear.text = "Press E to open door";
        }
    }

    void OnTriggerStay (Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
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
