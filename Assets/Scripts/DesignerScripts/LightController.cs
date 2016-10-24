using UnityEngine;
using System.Collections;
using System;

public class LightController : MonoBehaviour {

    public FlickerSettings flickerSettings;
    private Light lights;
    private AudioSource audio;
    public bool turnsOn = true;
    private bool isOn;
    private float  range;
    public float brightness;
    private float target = 2;

	// Use this for initialization
	void Start () {
        lights = GetComponentInChildren<Light>();
        audio = GetComponentInChildren<AudioSource>();
        if (lights.isActiveAndEnabled)
        {
            isOn = true;
            Debug.Log("ON");
        }
        if (lights.isActiveAndEnabled != true)
        {
            isOn = false;
        }
        lights.intensity = brightness;
        range = lights.range;
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
        if (target < brightness)
        {
            lights.intensity = target;
        }
        else if (target>lights.intensity && lights.intensity < brightness)
        {
            lights.intensity += 0.1f;
            lights.range = range * (lights.intensity/ brightness );
        }
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
