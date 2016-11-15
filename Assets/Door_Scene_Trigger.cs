using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Door_Scene_Trigger : MonoBehaviour {

	public Text doorText;

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerStay (Collider other)
	{
		//Debug.Log ("triggered");
		if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
			{
			//Debug.Log ("loading");
				Application.LoadLevel("02_Manor");
			}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player") 
		{
			doorText.text = "Press E to enter the mansion";
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.tag == "Player") 
		{
			doorText.text = "";
		}
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
