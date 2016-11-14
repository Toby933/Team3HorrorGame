using UnityEngine;
using System.Collections;

public class WarningTrigger : MonoBehaviour
{
    private SoundPlayer monster;

    private bool played = false;

	// Use this for initialization
	void Start ()
    {
        monster = FindObjectOfType<SoundPlayer>();
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    void OnTriggerEnter(Collider other)
    {
        if(!played && other.tag == "Player")
        {
            played = true;
            monster.playSound();
        }
    }
}
