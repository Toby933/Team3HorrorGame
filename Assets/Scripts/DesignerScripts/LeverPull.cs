using UnityEngine;
using System.Collections;

public class LeverPull : MonoBehaviour {
    public GameObject lever;
    private Animator leverpull;
    [Tooltip("Targets of the Trigger")]
    public GameObject[] targets;
    private AudioSource sound;

	void Start () {
        sound = GetComponent<AudioSource>();
        leverpull = lever.GetComponentInChildren<Animator>();
	}
	void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            TurnOn();
        }
    }
	void Update () {
	
    }
    void TurnOn()//function activates lever animation, goes through gameobject list and sends message to objects
    {
        leverpull.SetTrigger("Activate");
        sound.Play();
        for (int i = 0; i < targets.Length; i++)
        {
            targets[i].SendMessage("TurnOn", SendMessageOptions.DontRequireReceiver);
        }
    }
}
