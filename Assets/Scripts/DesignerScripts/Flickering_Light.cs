using UnityEngine;
using System.Collections;

public class Flickering_Light : MonoBehaviour {

    public GameObject lightFlicker;
    int randomNumber;
    public int min = 0;
    public int max = 20;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        randomNumber = Random.Range(min, max);
        StartCoroutine(RandomGenerator());
        //print(randomNumber); //Debug
    }

    void LightOn()
    {
        GetComponent<Light>().enabled = true;
    }

    void LightOff()
    {
        GetComponent<Light>().enabled = false;
    }

    IEnumerator RandomGenerator()
    {
        yield return new WaitForSeconds(1f);
        if (randomNumber == 1)
        {
            LightOn();
        }
        else
        {
            LightOff();
        }
    }
}
