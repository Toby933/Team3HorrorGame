using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using InControl;
using UnityEngine.UI;


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

    [HideInInspector]
    public bool isPaused = false;

    GameObject pauseMenu;

    private InputDevice device;

    private bool reloadingLevel = false;

    private Text textOutput;

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

        pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");

        pauseMenu.GetComponent<Canvas>().enabled = true;

        pauseMenu.SetActive(false);

        textOutput = GameObject.FindGameObjectWithTag("CentreTextDisplay").GetComponent<Text>();

        bloodSplat.startUp((GameObject.FindGameObjectWithTag("BloodUI").GetComponent<UnityEngine.UI.Image>()));

        Unpause();
    }

	
	// Update is called once per frame
	void Update ()
    {
        device = InputManager.ActiveDevice;

        if(!isPaused)
            Time.timeScale = 1;
            
        if (!isPaused && !reloadingLevel)
            mouseLook.LookRotation(transform, FPCamera.transform);

        if (!isPaused && (Input.GetKeyDown(KeyCode.Escape)||device.MenuWasPressed))
            Pause();
        else if (isPaused && (Input.GetKeyDown(KeyCode.Escape) || device.MenuWasPressed))
            Unpause();

        lookAt.itemCheck();

	    if(controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);

            if ((Input.GetKey("left shift") || device.LeftStickButton) &&
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

            if ((Input.GetButton("Jump") || device.Action1) && !isJumping)
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

            if (Input.GetKey("left ctrl") || device.RightStickButton)
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

        /*if (Input.GetMouseButtonDown(1))
        {
            takeDamage(9);
        }*/

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

        if (currentHealth == 0 && !reloadingLevel)
        {

                StartCoroutine(reloadLevel());
        }

        if (exhaustedTimer > 0)
            audioManager.playExhausted();
        else if (currentStamina >= maxStamina)
            audioManager.stopExhausted();
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

            if (isCrouching && moveDirection.magnitude > .3f && !reloadingLevel)
                headBob.BobHead(controller.velocity.magnitude * 2f, this);
            else if (moveDirection.magnitude > .3f && !reloadingLevel)
                headBob.BobHead(controller.velocity.magnitude, this);
        }

        if (!controller.isGrounded)
            moveDirection.y -= gravity * Time.deltaTime;


        if ((moveDirection.magnitude > 0.3f || wasCrouching) && !reloadingLevel)
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

    void Pause()
    {
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    
    public void Unpause()
    {
        Debug.Log("unPausing");
        isPaused = false;           
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(false);     
    }

    IEnumerator reloadLevel()
    {
        reloadingLevel = true;
        textOutput.fontSize = 150;
        textOutput.color = Color.red;
        textOutput.text = "You Died";
        if (SceneManager.GetActiveScene().name == "04_Lab")
        {
            FindObjectOfType<EndCredit>().playCredits();
        }
        else
        {
            yield return new WaitForSeconds(3);
            textOutput.text = "";
            reloadingLevel = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
        
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("UI Splash");
    }
}
