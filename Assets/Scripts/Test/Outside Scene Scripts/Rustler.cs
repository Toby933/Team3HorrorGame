using UnityEngine;
using System.Collections;

public class Rustler : MonoBehaviour
{
    public AudioClip rustleAudio;

    public float moveSpeed = 7;

    public float distance = 25f;

    private float traveled = 0;

    private AudioSource rustleSource;

    [HideInInspector]
    public bool Rustle{ get; set; }

	// Use this for initialization
	void Start ()
    {
        rustleSource = GetComponent<AudioSource>();
        Rustle = false;
        rustleSource.clip = rustleAudio;
        rustleSource.loop = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (distance < traveled)
            Rustle = false;

        if (Rustle && !rustleSource.isPlaying)
        {
            rustleSource.Play();            
        }
        else if(!Rustle)
        {
            rustleSource.Stop();
        }
        else if(rustleSource.isPlaying)
        {
            traveled += Time.deltaTime * moveSpeed;
            transform.position += new Vector3(Time.deltaTime * moveSpeed, 0, 0);
        }
	}
}
