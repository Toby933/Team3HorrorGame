using UnityEngine;
using System.Collections;

public class Gate : MonoBehaviour
{
    private Animator animator;

    public AudioClip openSound;

    AudioSource self;

	// Use this for initialization
	void Start ()
    {
        animator = GetComponentInParent<Animator>();
        self = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void OpenDoor()
    {
        animator.SetBool("isOpen", true);

        self.clip = openSound;
        self.Play();
    }
}
