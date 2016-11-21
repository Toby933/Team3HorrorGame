using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject monsterPrefab;

    public bool useDefault = true;

    GameObject monster;

    public bool makeActive = false;

    [Header("Monster Settings")]
    public Transform[] points;
    public int dest = 0;
    public bool usePatrol = false;

    public float patrolSpeed = 3.5f;
    public float chaseSpeed = 5f;

    [Tooltip("Turn on to stop ai from wandering")]
    public bool wanderOff = false;

    [Tooltip("Enable/Disable monster functionality")]
    public bool isDiabled = false;

    [Tooltip("Value from 0-1 (0-100%)")]
    public float chanceToStopToListen = .5f;

    public float stopToListenTimer = 5f;

    [Header("Wander properties")]
    [Tooltip("Controls how much AI can wander")]
    public float radius = 5;
    [Tooltip("Controls how sporadic AI movement is")]
    public float jitter = 10;
    [Tooltip("Affects how far AI will walk before changing directions")]
    public float distance = 10;

    [Header("Vision properties")]
    [Tooltip("How Far AI can see")]
    public float visionRange = 5;

    [Tooltip("Field of view in degrees")]
    public float FOV = 120;

    [Header("Auditory properties")]
    [Tooltip("Sensitivity to sound")]
    public float auditoryAcuity = 1.7f;

    [Header("Attack properties")]
    [Tooltip("How much damage is done each hit")]
    public float damage = 120;

    public float swingTime = 3;

    [Tooltip("How close monster needs to be before it attacks")]
    public float attackRange = 2;

    [Space()]
    [Tooltip("Need atleast 2, same audio clip is okay")]
    public AudioClip[] monsterSounds;


    // Use this for initialization
    void Start()
    {
        monster = Instantiate(monsterPrefab) as GameObject;
        monster.transform.position = transform.position;
        monster.transform.rotation = transform.rotation;
        if (!useDefault)
        {
            var monsterScript = monster.GetComponent<MonsterAI>();
            monsterScript.points = points;
            monsterScript.dest = dest;
            monsterScript.usePatrol = usePatrol;
            monsterScript.patrolSpeed = patrolSpeed;
            monsterScript.chaseSpeed = chaseSpeed;
            monsterScript.wanderOff = wanderOff;
            monsterScript.isDiabled = isDiabled;
            monsterScript.chanceToStopToListen = chanceToStopToListen;
            monsterScript.stopToListenTimer = stopToListenTimer;
            monsterScript.radius = radius;
            monsterScript.jitter = jitter;
            monsterScript.distance = distance;
            monsterScript.visionRange = visionRange;
            monsterScript.FOV = FOV;
            monsterScript.auditoryAcuity = auditoryAcuity;
            monsterScript.damage = damage;
            monsterScript.swingTime = swingTime;
            monsterScript.attackRange = attackRange;
            monsterScript.monsterSounds = monsterSounds;
        }
        monster.SetActive(makeActive);
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(makeActive)
        {
            monster.SetActive(makeActive);
        }
	}
}
