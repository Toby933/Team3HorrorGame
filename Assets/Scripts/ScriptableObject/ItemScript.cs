using UnityEngine;
using System.Collections;

public class ItemScript : MonoBehaviour
{
    public Item item;

	// Use this for initialization
	void Start ()
    {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<CustomFirstPersonController>().inventory.Add(item);
            
            gameObject.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
