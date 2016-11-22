using UnityEngine;
using System.Collections;

public class GameEnder : MonoBehaviour {
    public GameObject spawner;
    private bool haveSpawned = false;
    public AudioSource audio;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !haveSpawned)
        {
            haveSpawned = true;
            spawner.SendMessage("spawnMonster", SendMessageOptions.DontRequireReceiver);
            audio.Play();
        }
    }
}
