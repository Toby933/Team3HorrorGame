using UnityEngine;
using System.Collections;

public class ThrowSomething : MonoBehaviour {
    public float thrust = 1000;
    public GameObject target;
    public Rigidbody rb;
    //public audio Bonk;
	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
        rb.AddForce((target.transform.position - transform.position) * thrust);
	}
	void OnCollisionEnter (Collision other)
    {
        if (other.gameObject.tag== "Player")
        {
            other.gameObject.SendMessage("takeDamage(10)", SendMessageOptions.DontRequireReceiver);
            Debug.Log("PEWPEWPEW");
        }
        //Stick code to play sound here when it collides with something, deepending on object.
    }
	// Update is called once per frame
	void Update () {
	
	}
}
