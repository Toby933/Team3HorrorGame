using UnityEngine;
using System.Collections;

public class MonsterAI : MonoBehaviour
{
    [Tooltip("Drop Player in here")]
    public Transform target;    

    [Header("Patrol properties")]
    public Transform[] points;
    public int dest = 0;
    public bool usePatrol = false;

    public float patrolSpeed = 3.5f;
    public float chaseSpeed = 5f;

    [Tooltip("Turn on to stop ai from wandering")]
    public bool wanderOff = false;

    private float timer = 30;

    private bool hunting = false;

    [Header("Wander properties")]
    [Tooltip("Controls how much AI can wander")]
    public float radius = 5;
    [Tooltip("Controls how sporadic AI movement is")]
    public float jitter = 10;
    [Tooltip("Affects how far AI will walk before changing directions")]
    public float distance = 10;

    private Vector3 displacement = new Vector3();

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
    public float damage = 90;

    public float swingTime = 3;

    [Tooltip("How close monster needs to be before it attacks")]
    public float attackRange = 2;

    float swingtimer = 0;

    [Space()]
    [Tooltip("Need atleast 2, same audio clip is okay")]
    public AudioClip[] monsterSounds;

    private AudioSource audioSource;

    private float chaseTimer = 0;

    // Navmesh Ref
    private NavMeshAgent agent;
    // Used to raycast from head location
    private SphereCollider head;
    // Ref to player's character controller
    private CharacterController targetCon;
    // Getting player ref
    private CustomFirstPersonController player;
    // Used to stop monster from pushing player
    private float stoppingDistance;   

    // Use this for initialization
    void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
        head = GetComponentInChildren<SphereCollider>();
        targetCon = target.GetComponent<CharacterController>();
        player = target.GetComponent<CustomFirstPersonController>();
        // Converting FOV from deg to rad
        FOV /= 2; // needs to be halved due to how the angle will be calculated
        FOV = FOV / 180 * Mathf.PI; // formula for rad to deg conversion
        stoppingDistance = (agent.radius + targetCon.radius) * 2 + .5f;
        agent.speed = patrolSpeed;

	}
	
	// Update is called once per frame
	void Update ()
    {
        if(usePatrol && !agent.hasPath)
        {
            if (timer >= 0)
            {
                timer -= Time.deltaTime;
            }
            if (timer <= 0)
            {
                TurnOn();
            }
            if (agent.remainingDistance < .05f && hunting == true)
            {
                GoToNextPoint();
            }
        }

        RaycastHit hit;

        bool playerFound = false;

        // Casting 10 rays at player to see if in line of sight
        for (int i = 0; i < 5; ++i)
        {
            if (Physics.Raycast(head.transform.position, Quaternion.Euler(0, -25 * (i / 5), 0) * (target.position - head.transform.position), out hit, visionRange)) 
                if (hit.collider.tag == "Player")
                {
                    // Finding angle between monster's forward facing direction and player
                    if (Mathf.Acos(Vector3.Dot(head.transform.forward.normalized, target.transform.position.normalized)) < FOV)
                    {
                        agent.SetDestination(target.position);                        
                        playerFound = true;
                        break;
                    }
                }

            if (Physics.Raycast(head.transform.position, Quaternion.Euler(0, 25 * (i / 5), 0) * (target.position - head.transform.position), out hit, visionRange))
                if (hit.collider.tag == "Player")
                {
                    // Finding angle between monster's forward facing direction and player
                    if (Mathf.Acos(Vector3.Dot(head.transform.forward.normalized, target.transform.position.normalized)) < FOV)
                    {
                        agent.SetDestination(target.position);
                        playerFound = true;
                        break;
                    }
                }
        }

        if(playerFound && chaseTimer <= 0)
        {
            playRoar();
            chaseTimer = 5f;
        }
        else if (!playerFound && chaseTimer > 0)
        {
            chaseTimer -= Time.deltaTime;
        }

        Debug.Log(chaseTimer);

        if ((target.position - agent.transform.position).magnitude < stoppingDistance)
            agent.stoppingDistance = stoppingDistance;
        else
            agent.stoppingDistance = 0;        

        // Listens out to find player when not in vsion
        if (!playerFound && !player.wasCrouching && !player.isJumping)
        {
            listenForPlayer();
        }

        if ((target.position - agent.transform.position).magnitude - agent.radius < attackRange && playerFound)
            attack();

        if (swingtimer > 0)
            swingtimer -= Time.deltaTime;

        if (!agent.hasPath && !usePatrol)
            wander();

        // Adjusts max speed depending on whether player has been seen
        agent.speed = playerFound ? chaseSpeed : patrolSpeed;
    }

    // Wanders aimlessly
    public void wander()
    {
        if (!wanderOff)
        {
            displacement = displacement + new Vector3(Random.Range(-1, 1), 0, Random.Range(-1, 1)).normalized * jitter;

            displacement = displacement.normalized * radius;

            Vector3 target = new Vector3(agent.transform.forward.x, agent.transform.forward.y, agent.transform.forward.z) * distance + displacement;

            agent.SetDestination(target);
        }
    }

    public void attack()
    {
        if (swingtimer <= 0)
        {
            player.takeDamage(damage);
            swingtimer = swingTime;
            Debug.Log("Attacked");            
        }
    }

    // Uses player velocity determine how much sound is made scaled by monster's auditory acuity
    // Noise value is reduce by distance from sound source
    // Lerps monster current destination towards sound location depending on the resulting noise value
    public void listenForPlayer()
    {
        float noise = ((targetCon.velocity.magnitude * auditoryAcuity) -
                (target.position - head.transform.position).magnitude) /
                (target.position - head.transform.position).magnitude;

        //Debug.Log(noise);
        //Debug.Log(targetCon.velocity.magnitude);

        agent.destination = Vector3.Lerp(agent.destination, target.position, noise);
    }

    void GoToNextPoint()
    {
        agent.destination = points[dest].position;
        dest = Random.Range(0, points.Length);
    }

    void playRoar()
    {
        int index = Random.Range(1, monsterSounds.Length);
        audioSource.clip = monsterSounds[index];
        audioSource.PlayOneShot(audioSource.clip);

        monsterSounds[index] = monsterSounds[0];
        monsterSounds[0] = audioSource.clip;
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
