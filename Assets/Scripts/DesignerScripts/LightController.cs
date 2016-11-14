using UnityEngine;
using System.Collections;
using System;

public class LightController : MonoBehaviour {

    public FlickerSettings flickerSettings;
    private Light lights;
    public AudioClip[] buzz;
    [Tooltip("Whether light will turn on")]
    public bool turnsOn = true;
    private bool isOn;
    private float range;
    [Tooltip("Intensity of the light")]
    public float brightness;
    private float target = 2;
    [Tooltip("Whether range changes with light intensity")]
    public bool rangeChange = false;
    private AudioSource audioSource;

	public Renderer glowyRenderer;
	Color baseBulbColor;


    // Use this for initialization
    void Start () {
        lights = GetComponentInChildren<Light>();
        audioSource = GetComponent<AudioSource>();
        if (lights.isActiveAndEnabled)
        {
            isOn = true;
            Debug.Log("ON");
        }
        lights.intensity = brightness;
        range = lights.range;
		baseBulbColor = glowyRenderer.material.color;
		if (lights.isActiveAndEnabled != true)
		{
			isOn = false;
			glowyRenderer.material.color = (baseBulbColor * 0);
		}

    }

    // Update is called once per frame
    void Update () {
	if (isOn && flickerSettings.willFlicker)
        {
                Flicker();                   
        }
/*        if (!flickerSettings.willFlicker && lights.intensity < brightness)// This will make globes warm up over time, not worth the trouble :P
        {
            lights.intensity += 0.03f;
            if (rangeChange == true)//changes light range at same rate as intensity, to change the way the effect looks
            {
                lights.range = range * (lights.intensity / brightness);
            }
            lights.intensity += Time.deltaTime * 0.01f;
            glowyRenderer.material.color = (baseBulbColor * lights.intensity * 2);
        }*/
    }
    void TurnOn()//function called by lever/switch connected to object (LeverPull.cs)
    {
        if (turnsOn && (isOn==false))
        {
            lights.enabled = true;
            //lights.intensity = 0; // uncomment if using globes warming over time
            isOn = true;
			glowyRenderer.material.color =baseBulbColor;

        }


    }
    void Flicker()//causes the light to flicker randomly, charge back to brightness over time after flickering;
    {
        target =UnityEngine.Random.Range(flickerSettings.flickerMin, (brightness * flickerSettings.flickerRate));
        if (target < brightness)
        {
            int step = UnityEngine.Random.Range(0, buzz.Length); // Picks random footstep from array to play
            audioSource.clip = buzz[step];
            audioSource.PlayOneShot(audioSource.clip);
            lights.intensity = target / 10;
            lights.intensity = target;
			glowyRenderer.material.color = (baseBulbColor * target*2);
        }
        else if (target>lights.intensity && lights.intensity < brightness)
        {
            lights.intensity += 0.03f;
            if (rangeChange == true)//changes light range at same rate as intensity, to change the way the effect looks
            {
                lights.range = range * (lights.intensity / brightness);
            }
            lights.intensity += 0.1f;
			glowyRenderer.material.color = (baseBulbColor * lights.intensity*2);
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
