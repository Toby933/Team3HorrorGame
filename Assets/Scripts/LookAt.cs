using UnityEngine;
using System.Collections;

[System.Serializable]
public class LookAt
{
    [Tooltip("Max distance items can be highlighed from")]
    public float range = 2f;

    public float radius = .1f;

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

        RaycastHit[] hitList;

        hitList = Physics.SphereCastAll(ray, .05f, range);

        RaycastHit hit;

        bool itemFound = false;

        foreach (RaycastHit h in hitList)
        {
            if(h.collider.tag == "Item")
            {
                itemFound = true;
                hit = h;
                break;
            }
        }

        if (hitList.Length > 0 && itemFound)
        {
            if (currentFocus != null)
            {
                if (hit.collider.gameObject != currentFocus)
                {
                    currentFocus.GetComponentInChildren<ItemScript>().lookedAt = false;
                    hit.collider.gameObject.GetComponentInChildren<ItemScript>().lookedAt = true;
                    currentFocus = hit.collider.gameObject;
                }
                //else
                //{
                //    currentFocus = hit.collider.gameObject;
                //    hit.collider.gameObject.GetComponentInChildren<ItemScript>().lookedAt = true;
                //}
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
