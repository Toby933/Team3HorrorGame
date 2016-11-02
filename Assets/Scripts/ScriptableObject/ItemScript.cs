using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour
{
    public enum Action { PickUp, DisplayText, DoNothing };

    public Item item;

    [Tooltip("Option to manually set item object")]
    public GameObject itemObject = null;

    public Action action;

    private ItemBase itemActions = new ItemBase();

    public Color highLightColour = new Color();

    public bool useDefault = true;

    private Color defaultColour;

    [HideInInspector]
    public bool lookedAt = false;    

    Renderer itemRenderer;

	// Use this for initialization
	void Start ()
    {
        if (itemObject == null)
        {
            itemObject = transform.parent.gameObject;
        }

        if (item.textOutput == null && action == Action.DisplayText)
        {
            foreach (Text t in FindObjectsOfType<Text>())
            {
                if (t.tag == "Item")
                    item.textOutput = FindObjectOfType<Text>();
            }
        }

        itemObject.tag = "Item";

        itemRenderer = transform.parent.GetComponent<Renderer>();

        defaultColour = itemRenderer.material.color;

        if(useDefault)
        {
            highLightColour = new Color(102 / 255, 178 / 255, 255 / 255, .1f);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" && lookedAt)
        {
            if (Input.GetKey(KeyCode.E))
            {
                switch (action)
                {
                    case Action.PickUp:
                        itemActions.PickUp(other, this);
                        break;
                    case Action.DisplayText:
                        itemActions.DisplayText(this);
                        break;
                    case Action.DoNothing:
                        break;
                }


                //parent.gameObject.SetActive(false);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            if (action == Action.DisplayText)
            {
                itemActions.ClearText(this);
            }
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!lookedAt)
        {
            itemRenderer.material.color = defaultColour;
            itemRenderer.material.SetColor("_EmissionColor", new Color(0, 0, 0, 0));
            if (action == Action.DisplayText)
                itemActions.ClearText(this);
        }
        else
        {
            itemRenderer.material.SetColor("_EmissionColor", highLightColour);
        }
    }
}
