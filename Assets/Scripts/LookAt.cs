using UnityEngine;
using System.Collections;

[System.Serializable]
public class LookAt
{
    [Tooltip("Max distance items can be highlighed from")]
    public float range = 2f;

    private Camera FPSCamera;

    private GameObject currentFocus = null;

    private GameObject previousFocus;

    public void initialise(Camera camera)
    {
        FPSCamera = camera;
    }

    public void itemCheck()
    {
        Ray ray = new Ray(FPSCamera.transform.position, FPSCamera.transform.forward);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) &&
                    hit.distance < range &&
                    hit.collider.tag == "Item")
        {
            if (currentFocus != null)
            {
                if (hit.collider.gameObject != currentFocus)
                {
                    hit.collider.gameObject.GetComponentInChildren<ItemScript>().lookedAt = false;
                }
                else
                {
                    currentFocus = hit.collider.gameObject;
                    hit.collider.gameObject.GetComponentInChildren<ItemScript>().lookedAt = true;
                }
            }
            else
            {
                currentFocus = hit.collider.gameObject;
                hit.collider.gameObject.GetComponentInChildren<ItemScript>().lookedAt = true;
            }

        }
        else if (currentFocus != null)
        {
            currentFocus.GetComponentInChildren<ItemScript>().lookedAt = false;
            currentFocus = null;
        }
    }
}
