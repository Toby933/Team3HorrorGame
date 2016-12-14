using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using InControl;

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

    private bool wasLookedAt = false;

    [HideInInspector]
    public bool lookedAt = false;    

    Renderer itemRenderer;

    public float displayTime = 2f;

    private InputDevice device;

	// Use this for initialization
	void Start ()
    {
        if (itemObject == null)
        {
            itemObject = transform.parent.gameObject;
        }

        item.textOutput = GameObject.FindGameObjectWithTag("CentreTextDisplay").GetComponent<Text>();

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
            if (Input.GetKeyDown(KeyCode.E) || device.Action2)
            {
                switch (action)
                {
                    case Action.PickUp:
                        StartCoroutine(pickUpText());
                        itemActions.PickUp(other, this);
                        break;
                    case Action.DisplayText:
                        wasLookedAt = true;
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
        device = InputManager.ActiveDevice;

        if (!lookedAt)
        {
            itemRenderer.material.color = defaultColour;
            itemRenderer.material.SetColor("_EmissionColor", new Color(0, 0, 0, 0));
            if (action == Action.DisplayText && wasLookedAt)
            {
                itemActions.ClearText(this);
                wasLookedAt = false;
            }
        }
        else
        {
            itemRenderer.material.SetColor("_EmissionColor", highLightColour);
        }
    }

    void setText(string text)
    {
        
    }

    IEnumerator pickUpText()
    {
        setText(System.String.Format("{0} obtained", item.itemName));
        Debug.Log(item.textOutput);
        yield return new WaitForSeconds(2);
        item.textOutput.text = "";
    }
}
