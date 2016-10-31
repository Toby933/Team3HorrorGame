using UnityEngine;
using System.Collections;

public class LeverPull : MonoBehaviour {
    public GameObject lever;
    private Animator leverpull;
    [Tooltip("Targets of the Trigger")]
    public GameObject[] targets;

	// Use this for initialization
	void Start () {
        leverpull = lever.GetComponentInChildren<Animator>();
	}
	void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            TurnOn();
        }
    }
	// Update is called once per frame
	void Update () {
	
    }
    void TurnOn()
    {
        leverpull.SetTrigger("Activate");
        for (int i = 0; i < targets.Length; i++)
        {
            targets[i].SendMessage("TurnOn", SendMessageOptions.DontRequireReceiver);
        }
    }
}
