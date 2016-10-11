using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

    public GameObject lightFlicker;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
        Invoke("LightOn", 1);
        Invoke("LightOff", 1);	
	}

    void LightOn()
    {
        lightFlicker.SetActive(true);
    }

    void LightOff()
    {
        lightFlicker.SetActive(false);
    }
}
