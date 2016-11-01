using UnityEngine;
using System.Collections;

public class ItemScript : MonoBehaviour
{
    public Item item;

    public GameObject itemObject;

    private Color defaultColour;

    [HideInInspector]
    public bool lookedAt = false;    

    Renderer itemRenderer;

	// Use this for initialization
	void Start ()
    {
        itemObject = transform.parent.gameObject;

        itemObject.tag = "Item";

        itemRenderer = transform.parent.GetComponent<Renderer>();

        defaultColour = itemRenderer.material.color;
    }

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" && lookedAt)
        {
            if (Input.GetKey(KeyCode.E))
            {
                other.GetComponent<CustomFirstPersonController>().inventory.Add(item);

                itemObject.SetActive(false);
                //parent.gameObject.SetActive(false);
            }
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!lookedAt)
        {
            itemRenderer.material.color = defaultColour;
        }
        else
        {
            itemRenderer.material.color = Color.blue;
        }
    }
}
