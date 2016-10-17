using UnityEngine;
using System.Collections;

public class HuntPlayer : MonoBehaviour {

    public Transform[] points;
    public int dest = 0;
    private NavMeshAgent agent;
    private bool hunting = false;
    [Tooltip("Delay before creature goes hunting in the dark")]
    public float timer = 30;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();


	}
	
	// Update is called once per frame
	void Update () {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            TurnOn();
        }
        if (agent.remainingDistance < .05f && hunting==true)
        {
            GoToNextPoint();
        }
	}
    void GoToNextPoint()
    {
       /* if (points.Length == 0)
            return;*/
        agent.destination = points[dest].position;
        dest = Random.Range(0, points.Length);
    }
    void TurnOn()
    {
        if (hunting != true) 
        {
            hunting = true;

            dest = Random.Range(0, points.Length);
            GoToNextPoint();
        }
    }
}
