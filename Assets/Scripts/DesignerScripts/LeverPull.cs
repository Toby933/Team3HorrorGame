using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using InControl;


public class LeverPull : MonoBehaviour {
    public GameObject lever;
    private Animator leverpull;
    [Tooltip("Targets of the Trigger")]
    public GameObject[] targets;
    private AudioSource sound;
    public Text textBox;
    private bool pulled = false;
    InputDevice device;

    void Start()
    {
        sound = GetComponent<AudioSource>();
        //textBox = FindObjectOfType<Text>();
        leverpull = lever.GetComponentInChildren<Animator>();
	}
	void OnTriggerStay(Collider other)
    {
        device = InputManager.ActiveDevice;
        if (other.tag == "Player" && !pulled)
        {
            textBox.text = "Press E to activate";
        }

        if (other.tag == "Player" && (Input.GetKey(KeyCode.E) || device.Action2) && !pulled)
        {
            TurnOn();
            pulled = true;
            textBox.text = "";
        }
    }
        void OnTriggerExit(Collider other)
    {
            textBox.text = "";
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
