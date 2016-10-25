using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

    public Item requiredItem;

	// Use this for initialization
	void Start ()
    {
	
	}
	
    void OnTriggerStay(Collider other)
    {
        var player = other.GetComponent<CustomFirstPersonController>();

        if (Input.GetKeyDown("e"))
        {
            if (player.inventory.Contains(requiredItem))
                Destroy(gameObject);
            else
            {
                player.takeSomeDamage();
                player.takeSomeDamage();
                player.takeSomeDamage();
            }
        }
            
        
    }

	// Update is called once per frame
	void Update ()
    {
	
	}
}
