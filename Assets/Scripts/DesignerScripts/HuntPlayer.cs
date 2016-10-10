﻿using UnityEngine;
using System.Collections;

public class HuntPlayer : MonoBehaviour {

    public Transform[] points;
    public int dest = 0;
    private NavMeshAgent agent;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        dest = dest = Random.Range(0, points.Length);
        GoToNextPoint();
	}
	
	// Update is called once per frame
	void Update () {
        if (agent.remainingDistance < .05f)
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
}
