using UnityEngine;
using System.Collections;

public class Rustler : MonoBehaviour
{
    public AudioClip rustleAudio;

    public float moveSpeed = 7;

    private AudioSource rustleSource;

    [HideInInspector]
    public bool Rustle{ get; set; }

	// Use this for initialization
	void Start ()
    {
        rustleSource = GetComponent<AudioSource>();
        Rustle = true;        
        rustleSource.clip = rustleAudio;
        rustleSource.loop = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Rustle && !rustleSource.isPlaying)
        {
            rustleSource.Play();            
        }
        else if(!Rustle)
        {

        }
        else if(rustleSource.isPlaying)
        {
            transform.position += new Vector3(Time.deltaTime * moveSpeed, 0, 0);
        }
	}
}
