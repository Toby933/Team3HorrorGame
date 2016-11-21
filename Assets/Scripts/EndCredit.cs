using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndCredit : MonoBehaviour
{
    Animator animator;

    Text text;

	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (animator.GetBool("Play Credits") && animator.GetCurrentAnimatorStateInfo(0).IsName("Finished"))
        {
            Debug.Log("Finished playing");
            text.enabled = false;
        }
	}

    public void playCredits()
    {
        text.enabled = true;
        animator.SetBool("Play Credits", true);
    }
}
