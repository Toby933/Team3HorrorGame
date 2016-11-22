using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using InControl;

public class RadioScript : MonoBehaviour {
    private bool turnedOn = true;
    private AudioSource powerOff;
    private float timer=0;
    private Text textBox;
    private GameObject textObject;
    public float grumpy=5;
    public AudioSource click;
    private bool isOn;


    void OnTriggerStay(Collider other)
    {
        /*if (other.tag == "Player" && turnedOn)
        {
            textBox.text = "Press E to turn off";
        }*/

        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E) && turnedOn)
        {
            TurnOff();
            turnedOn = false;
            textBox.text = "";
        }
    }
    /*void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            textBox.text = "";
        }
    }*/

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        
    }
    // Use this for initialization
    void Start () {
        FindObjects();
    }
	
	// Update is called once per frame
	void Update () {
	if (!turnedOn)
        {
            timer += Time.deltaTime;
        
        if (timer > grumpy)
        {
            turnedOn = true;
            RadioOn();
            click.Play();
        }
        }
    }
    public void TurnOn()
    {
        transform.position = new Vector3(16.25f, 1.166f, 2.232f);
    }
    public void TurnOff()
    {
        click.Play();
        gameObject.GetComponent<AudioSource>().volume = 0;
        timer = 0;
        if (grumpy > 0.5f)
        {
            grumpy -= 0.5f;
        }
    }
    void FindObjects()
    {
        powerOff = GetComponentInChildren<AudioSource>();
        textObject = GameObject.FindGameObjectWithTag("TextBox");
        textBox = textObject.GetComponent<Text>();
    }
    void RadioOn()
    {
        gameObject.GetComponent<AudioSource>().volume = 1;
    }
}
