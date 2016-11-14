using UnityEngine;
using System.Collections;

public class RustledTrigger : MonoBehaviour
{
    private bool played = false;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !played)
        {
            played = true;

        }
    }
}
