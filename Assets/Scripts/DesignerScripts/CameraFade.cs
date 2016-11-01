using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CameraFade : MonoBehaviour {
    public GameObject blackFade;
    public float fadeSpeed = 0.1f;
    public string target;
    private float alpha = 1;
    private float dir = -1;
    public Color shade;
    private bool turnedOn = false;
    void Start()
    {
        shade = blackFade.gameObject.GetComponent<Image>().color;
    }
    void Update()
    {
        alpha += dir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);
        shade.a = alpha;
        blackFade.gameObject.GetComponent<Image>().color = shade;
        //Debug.Log (shade.a);
        if (shade.a==1 && turnedOn)
        {
            SceneManager.LoadScene(target);
        }
    }
    public void TurnOn()
    {
        dir = 1;
        turnedOn = true;
    }
}



/*
public string target;
void OnTriggerStay(Collider other)
{
    if (other.tag == "Player")
    {
        SceneManager.LoadScene(target);
    }
}*/