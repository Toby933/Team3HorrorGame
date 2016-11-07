using UnityEngine;
using System.Collections;

public class LabStart : MonoBehaviour {

    private GameObject Radio;
	// Use this for initialization
	void Start () {
        Radio = GameObject.Find("RadioAudio");
        Radio.SendMessage("FindObjects", SendMessageOptions.DontRequireReceiver);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
