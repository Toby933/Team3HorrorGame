using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using System.Collections.Generic;


public class CustomFirstPersonController : MonoBehaviour
{
    [Tooltip("Walking Speed")]
    public float walkSpeed = 4f;

    [Tooltip("Running Speed")]
    public float runSpeed = 12f;

    [Tooltip("Crouch Speed Modifier (0-1)")]
    public float crouchSpeed = .3f;

    [Tooltip("Jump Height")]
    public float jumpHeight = 10f;

    [Tooltip("Max Stamina of player used for running")]
    public float maxStamina = 3f;

    // Tracks current stamina
    private float currentStamina;

    private float exhaustedTimer = 0;

    [Tooltip("Max HP of player")]
    public int maxHealth = 100;

    private float currentHealth;

    public float gravity = 20f;

    public List<Item> inventory = new List<Item>();

    // Standard FPS mouseLook class used to rotate camera
    [SerializeField] private MouseLook mouseLook;

    [SerializeField] private HeadBobber headBob = new HeadBobber();

    [SerializeField] private BloodSplatter bloodSplat = new BloodSplatter();

    public AudioFunctions audioManager = new AudioFunctions();

    [SerializeField]
    private LookAt lookAt;
   
    // Boolean to check whether player is running or walking
    private bool isRunning = false;

    [HideInInspector] public bool isJumping = false;

    private bool wasJumping = true;

    private bool isCrouching = false;

    // Used to hide crouch motion velocity change from monster so it can't hear crouch transtions
    [HideInInspector] public bool wasCrouching = false;

    // Direction of character movement
    private Vector3 moveDirection = Vector3.zero;

    // Character controller component
    private CharacterController controller;

    // Reference to first person camera
    private Camera FPCamera;        

    private float originalHeight;

    private float fallDistance = 0;

	// Use this for initialization
	void Start ()
    {
        controller = GetComponent<CharacterController>();
        FPCamera = Camera.main;
        mouseLook.Init(transform, FPCamera.transform);
        headBob.SetUp(FPCamera);
        currentStamina = maxStamina;
        currentHealth = maxHealth;
        originalHeight = controller.height;
        lookAt.initialise(FPCamera);
        audioManager.initialise(controller, GetComponent<AudioSource>(), runSpeed);              
    }
	
	// Update is called once per frame
	void Update ()
    {
        mouseLook.LookRotation(transform, FPCamera.transform);
        lookAt.itemCheck();

	    if(controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
                        
            if (Input.GetKey("left shift") && 
                currentStamina > 0 && 
                moveDirection.magnitude > 0 &&
                exhaustedTimer <= 0)
            {
                isRunning = true;
            }
            else
            {
                isRunning = false;                
            }

            if (Input.GetButton("Jump") && !isJumping)
            {
                isJumping = true;
                audioManager.playJumpingAudio();           
            }
            else if (isJumping && controller.isGrounded)
            {
                isJumping = false;
                wasJumping = false;
                if (fallDistance > .35f)
                    audioManager.playLandingAudio();
            }

            if (Input.GetKey("left ctrl"))
            {
                if(!isCrouching)
                    StartCoroutine(crouchTransition());
                isCrouching = true;                
            }
            else if(isCrouching && canStand())
            {
                isCrouching = false;
                StartCoroutine(crouchTransition());
            }

            if (fallDistance > 0)
                fallDistance = 0;
        }

        if(!controller.isGrounded)
            fallDistance += Time.deltaTime;

        //lazy way to check if player is falling
        if (!controller.isGrounded && moveDirection.y < 0)
        {
            isJumping = true;
            wasJumping = true;
        }

        //Debug.Log(moveDirection.y);

        if (Input.GetMouseButtonDown(1))
        {
            takeDamage(9);
        }

        if(currentHealth < maxHealth)
        {
            currentHealth += (10 * Time.deltaTime);
            if (currentHealth > maxHealth)
                currentHealth = maxHealth;

            if (currentHealth < 0)
                currentHealth = 0;
        }

        bloodSplat.UpdateCondition(currentHealth / maxHealth);      

        if (audioManager.stepPauseTimer > 0)
            audioManager.stepPauseTimer -= Time.deltaTime;
	}

    // Physics Updates
    void FixedUpdate()
    {
        if (controller.isGrounded)
        {
            if (isRunning)
            {
                currentStamina -= Time.deltaTime;
                moveDirection *= runSpeed;

                if (currentStamina < 0)
                    exhaustedTimer = 2;
            }
            else
            {
                if (maxStamina > currentStamina)
                    currentStamina += Time.deltaTime;
                moveDirection *= walkSpeed;
                exhaustedTimer -= Time.deltaTime;
            }

            if (isJumping && !wasJumping)
            {
                wasJumping = true;
                moveDirection.y = jumpHeight;
            }

            if (isCrouching)
            {
                controller.height = originalHeight / 2;
                moveDirection *= crouchSpeed;
            }
            else if(!isCrouching)
                controller.height = originalHeight;

            if(isCrouching)
                headBob.BobHead(controller.velocity.magnitude * 2f, this);            
            else
                headBob.BobHead(controller.velocity.magnitude, this);

            if (isRunning)
            {
                Vector3 velocity = moveDirection;
                velocity.y = 0;

                if (velocity.magnitude > runSpeed)
                {
                    velocity.Normalize();
                    velocity *= runSpeed;
                    moveDirection.x = velocity.x;
                    moveDirection.z = velocity.z;
                }
            }
            else
            {
                Vector3 velocity = moveDirection;
                velocity.y = 0;

                if (velocity.magnitude > walkSpeed)
                {
                    velocity.Normalize();
                    velocity *= walkSpeed;
                    moveDirection.x = velocity.x;
                    moveDirection.z = velocity.z;
                }
            }
        }

        if (!controller.isGrounded)
            moveDirection.y -= gravity * Time.deltaTime;


        controller.Move(moveDirection * Time.deltaTime);
    }

    public void takeDamage(float damage)
    {
        currentHealth -= damage;

        // plays different sound according to damage taken in regards to % of max health
        audioManager.playHurtAudio(damage / maxHealth);
    }

    IEnumerator crouchTransition ()
    {
        wasCrouching = true;
        yield return new WaitForSeconds(.5f);
        wasCrouching = false;
    }

    bool canStand()
    {
        RaycastHit hit;

        return !Physics.SphereCast(transform.position, controller.radius, transform.up, out hit, controller.height / 2 + .2f);        
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * 5);
    }
}
