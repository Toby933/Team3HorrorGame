using UnityEngine;
using System.Collections;

public class EnableMonsterTrigger : MonoBehaviour
{
    private MonsterAI monster;

    private bool triggered = false;

    private Gate gate;

	// Use this for initialization
	void Start ()
    {
        monster = FindObjectOfType<MonsterAI>();
        gate = FindObjectOfType<Gate>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (!triggered && other.tag == "Player")
        {
            monster.isDiabled = false;
            gate.OpenDoor();
        }
    }
}
