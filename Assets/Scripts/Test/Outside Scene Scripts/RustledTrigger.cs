using UnityEngine;
using System.Collections;

public class RustledTrigger : MonoBehaviour
{
    private bool played = false;

    private Rustler rustler;

	// Use this for initialization
	void Start ()
    {
        rustler = FindObjectOfType<Rustler>();
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
            rustler.Rustle = true;
        }
    }
}
