﻿using UnityEngine;
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

    [SerializeField] private AudioClip[] footStepsAudio;

    // Boolean to check whether player is running or walking
    private bool isRunning = false;

    // Direction of character movement
    private Vector3 moveDirection = Vector3.zero;

    // Character controller component
    private CharacterController controller;

    // Reference to first person camera
    private Camera FPCamera;

    private AudioSource audioSource;

    private float stepPauseTimer = 0;

    public AudioClip[] altFootStepAudio = null;

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

            if(Input.GetButton("Jump"))
            {
                moveDirection.y = jumpHeight;
            }

            if (Input.GetKey("left ctrl"))
            {
                controller.height = originalHeight / 2;
                moveDirection *= crouchSpeed;
            }
            else
                controller.height = originalHeight;
        }

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
        
        headBob.BobHead(controller.velocity.magnitude, this);

        if (stepPauseTimer > 0)
            stepPauseTimer -= Time.deltaTime;

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
        if (!controller.isGrounded || stepPauseTimer > 0)
            return;

        stepPauseTimer = .2f;

        if (altFootStepAudio.Length == 0)
        {
            int step = Random.Range(1, footStepsAudio.Length);
            audioSource.clip = footStepsAudio[step];
            audioSource.PlayOneShot(audioSource.clip);

            footStepsAudio[step] = footStepsAudio[0];
            footStepsAudio[0] = audioSource.clip;
        }
        else
        {
            int step = Random.Range(1, altFootStepAudio.Length);
            audioSource.clip = altFootStepAudio[step];
            audioSource.PlayOneShot(audioSource.clip);

            altFootStepAudio[step] = altFootStepAudio[0];
            altFootStepAudio[0] = audioSource.clip;
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

    void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * 5);
    }
}
