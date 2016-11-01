using UnityEngine;
using System.Collections;
using System;

public class LightController : MonoBehaviour {

    public FlickerSettings flickerSettings;
    private Light lights;
    public AudioSource[] buzz;
    [Tooltip("Whether light will turn on")]
    public bool turnsOn = true;
    private bool isOn;
    private float range;
    [Tooltip("Intensity of the light")]
    public float brightness;
    private float target = 2;
    [Tooltip("Whether range changes with light intensity")]
    public bool rangeChange = false;


    // Use this for initialization
    void Start () {
        lights = GetComponentInChildren<Light>();
        buzz = GetComponentsInChildren<AudioSource>();
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
    void TurnOn()//function called by lever/switch connected to object (LeverPull.cs)
    {
        if (turnsOn && (isOn==false))
        {
            lights.enabled = true;
            isOn = true;

        }
    }
    void Flicker()//causes the light to flicker randomly, charge back to brightness over time after flickering;
    {
        target =UnityEngine.Random.Range(flickerSettings.flickerMin, (brightness * flickerSettings.flickerRate));
        if (target < brightness)
        {
            var sound = buzz[UnityEngine.Random.Range(0, buzz.Length)];
            sound.Play();
            lights.intensity = target / 10;
            lights.intensity = target;
        }
        else if (target>lights.intensity && lights.intensity < brightness)
        {
            lights.intensity += 0.03f;
            if (rangeChange == true)//changes light range at same rate as intensity, to change the way the effect looks
            {
                lights.range = range * (lights.intensity / brightness);
            }
            lights.intensity += 0.1f;
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
