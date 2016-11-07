using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {
    public string target;
    public bool sendMessage = false;
    public GameObject[] targets;
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (sendMessage)
            {
                for (int i = 0; i < targets.Length; i++)
                {
                    targets[i].SendMessage("TurnOn", SendMessageOptions.DontRequireReceiver);
                }
            }
            SceneManager.LoadScene(target);
        }
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
