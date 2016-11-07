using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Lightning2 : MonoBehaviour {

    Light lightComponent;
    public bool lightningON = true;
    public float flashTime = 0.1f;
    float originalSkyExposure;
    Color originalFogColor;
    public Color lightningFogColor;
    public List<AudioClip> thunderSounds = new List<AudioClip>();
    AudioSource thunderAudio;
    public float minDelay = 8.0f;
    public float maxDelay = 12.0f;


	// Use this for initialization
	void Start () {
        lightComponent = GetComponent<Light>();
        originalSkyExposure = RenderSettings.skybox.GetFloat("_Exposure");
        originalFogColor = RenderSettings.fogColor;
        thunderAudio = GetComponent<AudioSource>();
        StartCoroutine(flashLighting());
	}

    IEnumerator flashLighting()
    {
        while (lightningON)
        {
            Debug.Log("ZAP!");
            lightComponent.enabled = true;
            RenderSettings.skybox.SetFloat("_Exposure", 8.0f);
            RenderSettings.fogColor = lightningFogColor;
            yield return new WaitForSeconds(flashTime);
            lightComponent.enabled = false;
            RenderSettings.skybox.SetFloat("_Exposure", originalSkyExposure);
            RenderSettings.fogColor = originalFogColor;
            thunderAudio.clip = thunderSounds[Random.Range(0, (thunderSounds.Count))];
            thunderAudio.Play();
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
        }        
        yield return null;
    }
	
	// Update is called once per frame
	void Update () {
	}

    void OnDestroy()
    {
        RenderSettings.skybox.SetFloat("_Exposure", originalSkyExposure);
        RenderSettings.fogColor = originalFogColor;
    }
}
