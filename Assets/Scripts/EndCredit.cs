using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndCredit : MonoBehaviour
{
    Animator animator;

	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (animator.GetBool("Play Credits") && animator.GetCurrentAnimatorStateInfo(0).IsName("Finished"))
        {
            Debug.Log("Finished playing");
        }
	}

    public void playCredits()
    {
        animator.SetBool("Play Credits", true);
    }
}
