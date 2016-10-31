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

    [Header("Audio Properties")]

    [SerializeField] private AudioClip[] footStepsAudio;

    [HideInInspector] public AudioClip[] altFootStepAudio = null;

    [SerializeField] private AudioClip jumpingAudio;

    [HideInInspector] public AudioClip altJumpingAudio = null;

    [SerializeField] private AudioClip landingAudio;

    [HideInInspector] public AudioClip altLandingAudio = null;
    
    [Tooltip("0-1 value")] public float baseJumpingAndLandingVolume = .3f;


    // Boolean to check whether player is running or walking
    private bool isRunning = false;

    [HideInInspector] public bool isJumping = false;

    private bool isCrouching = false;

    // Used to hide crouch motion velocity change from monster so it can't hear crouch transtions
    [HideInInspector] public bool wasCrouching = false;

    // Direction of character movement
    private Vector3 moveDirection = Vector3.zero;

    // Character controller component
    private CharacterController controller;

    // Reference to first person camera
    private Camera FPCamera;

    private AudioSource audioSource;

    private float stepPauseTimer = 0;    

    private float originalHeight;

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
        audioSource = GetComponent<AudioSource>();
              
    }
	
	// Update is called once per frame
	void Update ()
    {
        mouseLook.LookRotation(transform, FPCamera.transform);

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
                playJumpingAudio();           
            }
            else if (isJumping && controller.isGrounded)
            {
                isJumping = false;
                playLandingAudio();
            }

            if (Input.GetKey("left ctrl"))
            {
                if(!isCrouching)
                    StartCoroutine(crouchTransition());
                isCrouching = true;                
            }
            else if(isCrouching)
            {
                isCrouching = false;
                StartCoroutine(crouchTransition());
            }
        }

        // lazy way to check if player is falling
        if (!controller.isGrounded && moveDirection.y < 0)
            isJumping = true;

        if(Input.GetMouseButtonDown(1))
        {
            takeDamage(9);
        }

        if(currentHealth < maxHealth)
        {
            currentHealth += (10 * Time.deltaTime);
            if (currentHealth > maxHealth)
                currentHealth = maxHealth;
        }

        bloodSplat.UpdateCondition(currentHealth / maxHealth);      

        if (stepPauseTimer > 0)
            stepPauseTimer -= Time.deltaTime;
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

            if (isJumping)
            {
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
    }

    // Plays default footstep
    public void playFootStepAudio()
    {
        // Only plays footstep while player is grounded
        if (!controller.isGrounded || stepPauseTimer > 0)
            return;

        stepPauseTimer = .2f;

        // Checks for whether there are alt footsteps audio to play
        if (altFootStepAudio.Length == 0)
        {
            int step = Random.Range(1, footStepsAudio.Length); // Picks random footstep from array to play
            audioSource.clip = footStepsAudio[step];
            audioSource.volume = controller.velocity.magnitude / runSpeed; // Scales audio based on current velocity/ max velocity
            audioSource.PlayOneShot(audioSource.clip);

            footStepsAudio[step] = footStepsAudio[0];
            footStepsAudio[0] = audioSource.clip;
        }
        else
        {
            int step = Random.Range(1, altFootStepAudio.Length);
            audioSource.clip = altFootStepAudio[step];
            audioSource.volume = controller.velocity.magnitude / runSpeed;
            audioSource.PlayOneShot(audioSource.clip);

            altFootStepAudio[step] = altFootStepAudio[0];
            altFootStepAudio[0] = audioSource.clip;
        }
    }

    public void playJumpingAudio()
    {
        Debug.Log("playing jump");
        if (altJumpingAudio != null)
        {
            audioSource.clip = altJumpingAudio;
            if (controller.velocity.magnitude / runSpeed > .5f)
                audioSource.volume = controller.velocity.magnitude / runSpeed;
            else
                audioSource.volume = baseJumpingAndLandingVolume;
            audioSource.PlayOneShot(audioSource.clip);
            stepPauseTimer = .2f;
        }
        else
        {
            audioSource.clip = jumpingAudio;
            if (controller.velocity.magnitude / runSpeed > .5f)
                audioSource.volume = controller.velocity.magnitude / runSpeed;
            else
                audioSource.volume = baseJumpingAndLandingVolume;
            audioSource.PlayOneShot(audioSource.clip);
            stepPauseTimer = .2f;
        }
    }

    public void playLandingAudio()
    {
        Debug.Log("playing land");
        if (altLandingAudio != null)
        {
            audioSource.clip = altLandingAudio;
            if (controller.velocity.magnitude / runSpeed > .5f)
                audioSource.volume = controller.velocity.magnitude / runSpeed;
            else
                audioSource.volume = baseJumpingAndLandingVolume;
            audioSource.PlayOneShot(audioSource.clip);
            stepPauseTimer = .2f;
        }
        else
        {
            audioSource.clip = landingAudio;
            if (controller.velocity.magnitude / runSpeed > .5f)
                audioSource.volume = controller.velocity.magnitude / runSpeed;
            else
                audioSource.volume = baseJumpingAndLandingVolume;
            audioSource.PlayOneShot(audioSource.clip);
            stepPauseTimer = .2f;
        }
    }

    // Plays custom footsteps
    public void playFootStepAudio(AudioClip[] footStepsAudio)
    {
        if (!controller.isGrounded || stepPauseTimer > 0)
            return;

        stepPauseTimer = .2f;

        int step = Random.Range(1, footStepsAudio.Length);
        audioSource.clip = footStepsAudio[step];
        audioSource.PlayOneShot(audioSource.clip);

        footStepsAudio[step] = footStepsAudio[0];
        footStepsAudio[0] = audioSource.clip;
    }

    IEnumerator crouchTransition ()
    {
        wasCrouching = true;
        yield return new WaitForSeconds(.5f);
        wasCrouching = false;
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * 5);
    }
}
