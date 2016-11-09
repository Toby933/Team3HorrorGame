using UnityEngine;
using System.Collections;

public class PortraitSwitcher : MonoBehaviour {

    public GameObject portraitOriginal;
    public GameObject portraitScary;
    public AudioSource ambientNoise;

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            portraitOriginal.SetActive(false);
            portraitScary.SetActive(true);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
