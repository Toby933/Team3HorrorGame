using UnityEngine;
using System.Collections;

public class RadioScript : MonoBehaviour {
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void TurnOn()
    {
        transform.position = new Vector3(16.25f, 1.166f, 2.232f);
    }
}
