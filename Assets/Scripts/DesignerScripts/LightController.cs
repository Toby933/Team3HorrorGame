using UnityEngine;
using System.Collections;
using System;

public class LightController : MonoBehaviour {

    public FlickerSettings flickerSettings;
    private Light lights;
    public bool turnsOn = true;
    private bool isOn;
    public float brightness;
    private float target;

	// Use this for initialization
	void Start () {
        lights = GetComponent<Light>();
        if (lights == enabled)
        {
            isOn = true;
        }
        if (lights != enabled)
        {
            isOn = false;
        }
        lights.intensity = brightness;
	}
	
	// Update is called once per frame
	void Update () {
	if (isOn && flickerSettings.willFlicker)
        {
                Flicker();                   
        }
	}
    void TurnOn()
    {
        if (turnsOn && (isOn==false))
        {
            lights.enabled = true;
            isOn = true;

        }
    }
    void Flicker()
    {
        target=UnityEngine.Random.Range(flickerSettings.flickerMin, (brightness * flickerSettings.flickerRate));
        if (target > brightness)
        {
            target = brightness;
        }
        lights.intensity = target;
    }
}

[Serializable]
public class FlickerSettings
{
    [Tooltip("If the Light will flicker")]
    public bool willFlicker = false;
    [Tooltip("The minimum Intensity a light will reach")]
    public float flickerMin = 0;
    [Tooltip("Bigger number=less flickering")]
    public float flickerRate=10;
   /* [Tooltip("The Maximum time between light flickering incedents")]
    public float flickerTimerMax = 1;
    [Tooltip("The Mininum time between light flickering incedents")]
    public float flickerTimerMin = 0;*/
}
